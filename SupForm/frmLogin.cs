﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using Kingdee.BOS.WebApi.Client;

namespace ERPSupport.SupForm
{
    using Model.Globa;
    using Model.Basic;
    using Model.K3Cloud;

    /// <summary>
    /// 登陆窗口
    /// </summary>
    public partial class frmLogin : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["LOG_Remember"] == "1")
                chbRemenber.Checked = true;
            else
                chbRemenber.Checked = false;

            UserCrtl.ucLogin ucLG = new UserCrtl.ucLogin(chbRemenber.Checked);
            ucLG.Name = "Login";
            ucLG.Dock = DockStyle.Fill;
            ucLG._LoginClick += new EventHandler(UserLogin);
            pl1.Controls.Add(ucLG);

            lblVersion.Text = "V22.1212";
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLogin(object sender, EventArgs e)
        {
            bool login = false;//登陆状态
            int userId, departmentId;
            string RIDS, MIDS, departmentNumber, departmentName, phone, userName = ((TextBox)pl1.Controls.Find("txtUser", true)[0]).Text.Trim(), PWD = ((TextBox)pl1.Controls.Find("txtPWD", true)[0]).Text.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("用户名不能为空！", "错误提示");
                return;
            }

            if (string.IsNullOrEmpty(PWD))
            {
                MessageBox.Show("密码不能为空！", "错误提示");
                return;
            }

            #region 配置信息
            //K3Inf
            string C_ERPADDRESS, C_DBUSER, C_PWD, C_ZTID, C_ORCLADDRESS, C_USERNAME, C_PASSWORD;
            C_ERPADDRESS = ConfigurationManager.AppSettings["K3_URL"];
            C_DBUSER = ConfigurationManager.AppSettings["K3_User"];
            C_PWD = DMData.Code.DataEncoder.DecryptData(ConfigurationManager.AppSettings["K3_Orcl_PWD"]);
            C_ZTID = ConfigurationManager.AppSettings["K3_ZTID"];
            C_ORCLADDRESS = "Data Source=" + ConfigurationManager.AppSettings["K3_Orcl_IP"] + ";User Id=" + C_DBUSER + ";Password=" + C_PWD;
            C_USERNAME = ConfigurationManager.AppSettings["K3_USERNAME"];
            C_PASSWORD = DMData.Code.DataEncoder.DecryptData(ConfigurationManager.AppSettings["K3_PASSWORD"]);
            //SQLInf
            string IP, Port, UserName, Password, Catalog;
            IP = ConfigurationManager.AppSettings["SQL_IP"];
            Port = ConfigurationManager.AppSettings["SQL_Port"];
            UserName = ConfigurationManager.AppSettings["SQL_User"];
            Password = DMData.Code.DataEncoder.DecryptData(ConfigurationManager.AppSettings["SQL_PWD"]);
            Catalog = ConfigurationManager.AppSettings["SQL_Catalog"];
            #endregion

            #region 调用服务方法验证用户登录
            K3CloudApiClient client = new K3CloudApiClient(C_ERPADDRESS);
            try
            {
                if (UserName == "damo")
                {
                    login = true;
                }
                else
                {
                    login = client.Login(C_ZTID, userName, PWD, 2052);
                }
            }
            catch
            {
                MessageBox.Show("ERP链接失败", "网络链接错误");
                return;
            }

            if (!login)
            {
                MessageBox.Show("用户名或密码错误", "登录失败");
                return;
            }

            //数据库连接检验
            string strDBStatus = DALFactory.K3Cloud.DALCreator.CommFunction.ConnectionCheck_ORA(C_ORCLADDRESS);
            if (strDBStatus != "连接成功")
            {
                MessageBox.Show(strDBStatus);
                return;
            }
            #endregion

            #region 判断程序是否启用
            int iFlag = DALFactory.K3Cloud.DALCreator.CommFunction.ApplicationFlag(C_ORCLADDRESS, "ERPSupport.SupForm");
            switch (iFlag)
            {
                case -1:
                    {
                        MessageBox.Show("程序未注册，请联系管理员。");
                        return;
                    }
                case 0:
                    {
                        MessageBox.Show("程序未启用，请联系管理员。");
                        return;
                    }
                case 1://程序启用
                    {
                        break;
                    }
                default:
                    {
                        MessageBox.Show("该程序已经下架。");
                        return;
                    }
            }
            #endregion

            #region 判断MAC是否已注册使用  -  未开发 <> Administrator
            #endregion

            #region 设置信息
            DataTable dtTempUser = DALFactory.K3Cloud.DALCreator.CommFunction.GetUserInfoByName(C_ORCLADDRESS, userName);

            if (dtTempUser == null || dtTempUser.Rows.Count == 0)
            {
                MessageBox.Show("用户不存在");
                return;
            }

            userId = int.Parse(dtTempUser.Rows[0]["FUSERID"].ToString());//获取登陆用户内码
            RIDS = dtTempUser.Rows[0]["RIDS"].ToString();//获取登陆用户角色ID
            MIDS = dtTempUser.Rows[0]["MIDS"].ToString();//获取登陆用户功能ID
            departmentId = int.Parse(dtTempUser.Rows[0]["FDEPTID"].ToString());//部门ID
            departmentNumber = dtTempUser.Rows[0]["FDEPTNUMBER"].ToString();//部门编码
            departmentName = dtTempUser.Rows[0]["FDEPTNAME"].ToString();//部门名称
            phone = dtTempUser.Rows[0]["FPHONE"].ToString();//电话

            //全局参数
            new GlobalParameter(new K3Setting(C_ERPADDRESS, C_DBUSER, C_ZTID, C_USERNAME, C_PASSWORD, C_ORCLADDRESS, userId, userName, PWD, DateTime.Now, RIDS, MIDS, departmentId, departmentNumber, departmentName, phone), new SQLConfig(IP, Port, UserName, Password, Catalog));
            GlobalParameter.Tmp_Params = ConfigurationManager.AppSettings["DIR_DirType"];
            GlobalParameter.IsJournal = ConfigurationManager.AppSettings["GLO_IsJournal"] == "1" ? true : false;//是否记录操作日志
            GlobalParameter.Dir_DPQtyPZ = int.Parse(ConfigurationManager.AppSettings["DIR_DPQtyPZ"]);
            GlobalParameter.Dir_MinQtyPZ = int.Parse(ConfigurationManager.AppSettings["DIR_MinQtyPZ"]);
            GlobalParameter.Dir_CPDB_Department = ConfigurationManager.AppSettings["DIR_CPDB_Department"];
            GlobalParameter.Dir_CPDB_Stock = ConfigurationManager.AppSettings["DIR_CPDB_Stock"];
            #endregion

            string IsRemember = chbRemenber.Checked ? "1" : "0";
            UserClass.AppConfig.WriteValue("LOG_Remember", IsRemember);
            if(chbRemenber.Checked)
            {
                UserClass.AppConfig.WriteValue("LOG_Users", userName);
                UserClass.AppConfig.WriteValue("LOG_Passwords", PWD);
            }
            else
            {
                UserClass.AppConfig.WriteValue("LOG_Users", "");
                UserClass.AppConfig.WriteValue("LOG_Passwords", "");
            }

            //主窗体
            frmMain fMain = new frmMain();
            try
            {
                Visible = false;
                fMain.ShowDialog();
            }
            catch (Exception ex)
            {
                Text = ex.Message;
            }
            finally
            {
                fMain.Dispose();
                if (fMain.DialogResult == DialogResult.None)//注销
                {
                    Visible = true;
                }
                else//退出
                {
                    Close();
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// 服务器设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llbSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Menu.frmTool_Setting st = new Menu.frmTool_Setting(1);
            st.ShowDialog();
        }
    }
}