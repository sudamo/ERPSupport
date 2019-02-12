using System;
using System.Windows.Forms;
using System.Configuration;

namespace ERPSupport.SupForm.Common
{
    /// <summary>
    /// 设置配置信息
    /// </summary>
    public partial class frmSetting : Form
    {
        #region Fields,Properties & Constructor
        /// <summary>
        /// ERP地址
        /// </summary>
        private string C_ERPADDRESS;
        /// <summary>
        /// Owner
        /// </summary>
        private string C_OWNER;
        /// <summary>
        /// 账套ID
        /// </summary>
        private string C_ZTID;
        /// <summary>
        /// 数据密码
        /// </summary>
        private string C_PWD;
        /// <summary>
        /// Oracle数据库地址
        /// </summary>
        private string C_ORCLADDRESS;
        private bool _bLogout;
        /// <summary>
        /// 是否注销
        /// </summary>
        public bool BLogout
        {
            get
            {
                return _bLogout;
            }

            set
            {
                _bLogout = value;
            }
        }
        private int _iEntry;
        /// <summary>
        /// 加载方式：1、从登陆界面加载；2、从菜单加载
        /// </summary>
        public int IEntry
        {
            get
            {
                return _iEntry;
            }

            set
            {
                _iEntry = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pEntry">加载方式：1、从登陆界面加载；2、从菜单加载</param>
        public frmSetting(int pEntry)
        {
            InitializeComponent();
            _iEntry = pEntry;
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetting_Load(object sender, EventArgs e)
        {
            txtERPADDRESS.Text = C_ERPADDRESS = ConfigurationManager.AppSettings["K3_URL"];
            txtZTID.Text = C_ZTID = ConfigurationManager.AppSettings["K3_ZTID"];
            txtOwner.Text = ConfigurationManager.AppSettings["K3_User"];
            txtPWD.Text = DMData.Code.DataEncoder.DecryptData(ConfigurationManager.AppSettings["K3_Orcl_PWD"]);
            txtORCLADDRESS.Text = C_ORCLADDRESS = ConfigurationManager.AppSettings["K3_Orcl_IP"];
            _bLogout = false;
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtERPADDRESS.Text.Trim() == "")
            {
                MessageBox.Show("服务器地址不能为空");
                txtERPADDRESS.Focus();
                return;
            }

            if (txtZTID.Text.Trim() == "")
            {
                MessageBox.Show("账套ID不能为空");
                txtZTID.Focus();
                return;
            }

            if (txtOwner.Text.Trim() == "")
            {
                MessageBox.Show("库用户不能为空");
                txtOwner.Focus();
                return;
            }

            if (txtPWD.Text.Trim() == "")
            {
                MessageBox.Show("数据库地址不能为空");
                txtPWD.Focus();
                return;
            }

            //保存配置文件
            UserClass.AppConfig.WriteValue("K3_URL", txtERPADDRESS.Text.Trim());
            UserClass.AppConfig.WriteValue("K3_ZTID", txtZTID.Text.Trim());
            UserClass.AppConfig.WriteValue("K3_User", txtOwner.Text.Trim());
            UserClass.AppConfig.WriteValue("K3_Orcl_PWD", txtPWD.Text.Trim());
            UserClass.AppConfig.WriteValue("K3_Orcl_IP", txtORCLADDRESS.Text.Trim());

            if (IEntry == 2)//从菜单加载需要询问是否重新登录
                if (MessageBox.Show("保存成功，重新登录后生效，现在注销吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    _bLogout = true;
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