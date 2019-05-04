using System;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMenu_Pro_Dir : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmMenu_Pro_Dir()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMenu_Pro_Dir_Load(object sender, EventArgs e)
        {
            if (Model.Globa.GlobalRights.MIDs.Contains("502"))
                gbxDB_WMS.Enabled = true;
            else
                gbxDB_WMS.Enabled = false;
                   
            rbtERP.Checked = System.Configuration.ConfigurationManager.AppSettings["TMP_DirType"] == "1";
            txtIP.Text = UserClass.AppConfig.ReadValue("SQL_IP", "AppSettings");
            txtCatalog.Text = UserClass.AppConfig.ReadValue("SQL_Catalog", "AppSettings");
            txtUser.Text = UserClass.AppConfig.ReadValue("SQL_User", "AppSettings");
            txtPWD.Text = UserClass.AppConfig.ReadValue("SQL_PWD", "AppSettings");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string DirType = rbtERP.Checked ? "1" : "0";
            UserClass.AppConfig.WriteValue("TMP_DirType", DirType);

            UserClass.AppConfig.WriteValue("SQL_IP", txtIP.Text);
            UserClass.AppConfig.WriteValue("SQL_Catalog", txtCatalog.Text);
            UserClass.AppConfig.WriteValue("SQL_User", txtUser.Text);
            UserClass.AppConfig.WriteValue("SQL_PWD", txtPWD.Text);

            Model.Globa.GlobalParameter.Tmp_Params = DirType;

            Model.Globa.GlobalParameter.SQLInf.ConnectionString = "Data Source=" + txtIP.Text + ";Initial Catalog=" + txtCatalog.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPWD.Text + ";Max Pool Size=1024;";

            MessageBox.Show("保存成功");
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
