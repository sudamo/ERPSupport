using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using Kingdee.BOS.WebApi.Client;
using ERPSupport.SQL.K3Cloud;
using ERPSupport.Model.Globa;
using ERPSupport.Model.Basic;
using ERPSupport.Model.K3Cloud;

namespace ERPSupport.SupForm
{
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
            UserCrtl.ucLogin ucLG = new UserCrtl.ucLogin();
            ucLG.Name = "Login";
            ucLG.Dock = DockStyle.Fill;
            ucLG.pLoginClick += new EventHandler(UserLogin);
            pl1.Controls.Add(ucLG);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLogin(object sender, EventArgs e)
        {
            bool bLog = false;//登陆状态
            int iUserId;//用户内码
            string strRIDS, strMIDS;
            string strUserName = ((TextBox)pl1.Controls.Find("txtUser", true)[0]).Text.Trim();//登陆用户名
            string strPWD = ((TextBox)pl1.Controls.Find("txtPWD", true)[0]).Text.Trim();//登陆用户密码

            if (string.IsNullOrEmpty(strUserName))
            {
                MessageBox.Show("用户名不能为空！", "错误提示");
                return;
            }

            if (string.IsNullOrEmpty(strPWD))
            {
                MessageBox.Show("密码不能为空！", "错误提示");
                return;
            }

            //配置信息
            //K3Inf
            string C_ERPADDRESS, C_DBUSER, C_PWD, C_ZTID, C_ORCLADDRESS;
            C_ERPADDRESS = ConfigurationManager.AppSettings["K3_URL"];
            C_DBUSER = ConfigurationManager.AppSettings["K3_User"];
            C_PWD = DMData.Code.DataEncoder.DecryptData(ConfigurationManager.AppSettings["K3_Orcl_PWD"]);
            C_ZTID = ConfigurationManager.AppSettings["K3_ZTID"];
            C_ORCLADDRESS = "Data Source=" + ConfigurationManager.AppSettings["K3_Orcl_IP"] + ";User Id=" + C_DBUSER + ";Password=" + C_PWD;
            //SQLInf
            string IP, Port, UserName, Password, Catalog;
            IP = ConfigurationManager.AppSettings["SQL_IP"];
            Port = ConfigurationManager.AppSettings["SQL_Port"];
            UserName = ConfigurationManager.AppSettings["SQL_User"];
            Password = ConfigurationManager.AppSettings["SQL_PWD"];
            Catalog = ConfigurationManager.AppSettings["SQL_Catalog"];

            //调用服务方法验证用户登录
            K3CloudApiClient client = new K3CloudApiClient(C_ERPADDRESS);
            try
            {
                bLog = client.Login(C_ZTID, strUserName, strPWD, 2052);
            }
            catch
            {
                MessageBox.Show("ERP链接失败", "网络链接错误");
                return;
            }

            if (!bLog)
            {
                MessageBox.Show("用户名或密码错误", "登录失败");
                return;
            }

            //数据库连接检验
            int iDBStatus = CommonFunction.DB_Connection(C_ORCLADDRESS);
            if (iDBStatus == -1)
            {
                MessageBox.Show("数据库连接失败，请联系管理员。");
                return;
            }
            else if (iDBStatus == 0)
            {
                MessageBox.Show("数据库查询失败，请联系管理员。");
                return;
            }

            //判断程序是否启用
            int iFlag = CommonFunction.ApplicationFlag(C_ORCLADDRESS, "ERPSupport.SupForm");
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

            //判断MAC是否已注册使用  -  未开发 <> Administrator
            //

            //获取用户信息
            DataTable dtTempUser = CommonFunction.GetUserInfoByName(C_ORCLADDRESS, strUserName);

            if (dtTempUser == null || dtTempUser.Rows.Count == 0)
            {
                MessageBox.Show("用户不存在");
                return;
            }

            iUserId = int.Parse(dtTempUser.Rows[0]["FUSERID"].ToString());//获取登陆用户内码
            strRIDS = dtTempUser.Rows[0]["RIDS"].ToString();//获取登陆用户角色ID
            strMIDS = dtTempUser.Rows[0]["MIDS"].ToString();//获取登陆用户功能ID

            //设置全局参数
            new GlobalParameter(new K3Setting(C_ERPADDRESS, C_DBUSER, C_ZTID, "Administrator", "tjb316,", C_ORCLADDRESS, iUserId, strUserName, strPWD, DateTime.Now, strRIDS, strMIDS), new SQLConfig(IP, Port, UserName, Password, Catalog));

            //主窗体
            frmMain fMain = new frmMain();
            try
            {
                Visible = false;
                fMain.ShowDialog();
            }
            catch (Exception ex) { }
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
            Common.frmSetting st = new Common.frmSetting(1);
            st.ShowDialog();
        }
    }
}