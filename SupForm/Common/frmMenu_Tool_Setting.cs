using System;
using System.Windows.Forms;
using System.Configuration;

namespace ERPSupport.SupForm.Common
{
    /// <summary>
    /// 设置配置信息
    /// </summary>
    public partial class frmMenu_Tool_Setting : Form
    {
        #region Fields,Properties & Constructor
        /// <summary>
        /// ERP地址
        /// </summary>
        private string _K3_URL;
        /// <summary>
        /// 账套ID
        /// </summary>
        private string _K3_ZTID;
        /// <summary>
        /// Oracle数据库地址
        /// </summary>
        private string _K3_Orcl_IP;

        private bool _Logout;
        /// <summary>
        /// 是否注销
        /// </summary>
        public bool Logout
        {
            get
            {
                return _Logout;
            }

            set
            {
                _Logout = value;
            }
        }

        private int _Entry;
        /// <summary>
        /// 加载方式：1、从登陆界面加载；2、从菜单加载
        /// </summary>
        public int Entry
        {
            get
            {
                return _Entry;
            }

            set
            {
                _Entry = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pEntry">加载方式：1、从登陆界面加载；2、从菜单加载</param>
        public frmMenu_Tool_Setting(int pEntry)
        {
            InitializeComponent();
            _Entry = pEntry;

            _Logout = false;
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetting_Load(object sender, EventArgs e)
        {
            txtURL.Text = _K3_URL = ConfigurationManager.AppSettings["K3_URL"];
            txtZTID.Text = _K3_ZTID = ConfigurationManager.AppSettings["K3_ZTID"];
            txtUser.Text = ConfigurationManager.AppSettings["K3_User"];
            txtOrcl_PWD.Text = DMData.Code.DataEncoder.DecryptData(ConfigurationManager.AppSettings["K3_Orcl_PWD"]);
            txtOrcl_IP.Text = _K3_Orcl_IP = ConfigurationManager.AppSettings["K3_Orcl_IP"];
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.Trim() == "")
            {
                MessageBox.Show("服务器地址不能为空");
                txtURL.Focus();
                return;
            }

            if (txtZTID.Text.Trim() == "")
            {
                MessageBox.Show("账套ID不能为空");
                txtZTID.Focus();
                return;
            }

            if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("库用户不能为空");
                txtUser.Focus();
                return;
            }

            if (txtOrcl_PWD.Text.Trim() == "")
            {
                MessageBox.Show("数据库地址不能为空");
                txtOrcl_PWD.Focus();
                return;
            }

            //保存配置文件
            UserClass.AppConfig.WriteValue("K3_URL", txtURL.Text.Trim());
            UserClass.AppConfig.WriteValue("K3_ZTID", txtZTID.Text.Trim());
            UserClass.AppConfig.WriteValue("K3_User", txtUser.Text.Trim());
            UserClass.AppConfig.WriteValue("K3_Orcl_PWD", txtOrcl_PWD.Text.Trim());
            UserClass.AppConfig.WriteValue("K3_Orcl_IP", txtOrcl_IP.Text.Trim());

            if (Entry == 2)//从菜单加载需要询问是否重新登录
                if (MessageBox.Show("保存成功，重新登录后生效，现在注销吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    _Logout = true;
                }

            Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}