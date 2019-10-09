using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ERPSupport.SupForm.Menu
{
    using SQL.K3Cloud;

    /// <summary>
    /// 调拨单选项
    /// </summary>
    public partial class frmPro_Dir : Form
    {
        /// <summary>
        /// 正则表达式判断
        /// </summary>
        private Regex _reg;
        /// <summary>
        /// 
        /// </summary>
        public frmPro_Dir()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPro_Dir_Load(object sender, EventArgs e)
        {
            cbxDepartment.DataSource = CommFunction.GetDepartment(3, 100508, "辅助生产部门");
            cbxDepartment.DisplayMember = "FNAME";
            cbxDepartment.ValueMember = "FNAME";
            string strDepartment = Model.Globa.GlobalParameter.Dir_CPDB_Department;
            cbxDepartment.SelectedIndex = cbxDepartment.FindString(strDepartment) == -1 ? 0 : cbxDepartment.FindString(strDepartment);

            cbxStock.DataSource = CommFunction.GetStock(3);
            cbxStock.DisplayMember = "FNAME";
            cbxStock.ValueMember = "FNAME";
            string strStock = Model.Globa.GlobalParameter.Dir_CPDB_Stock;
            cbxStock.SelectedIndex = cbxStock.FindString(strStock) == -1 ? 0 : cbxStock.FindString(strStock);

            if (Model.Globa.GlobalRights.MIDs.Contains("502"))
                gbxDB_WMS.Enabled = true;
            else
                gbxDB_WMS.Enabled = false;

            txtIP.Text = UserClass.AppConfig.ReadValue("SQL_IP", "AppSettings");
            txtCatalog.Text = UserClass.AppConfig.ReadValue("SQL_Catalog", "AppSettings");
            txtUser.Text = UserClass.AppConfig.ReadValue("SQL_User", "AppSettings");
            txtPWD.Text = UserClass.AppConfig.ReadValue("SQL_PWD", "AppSettings");

            //rbtERP.Checked = System.Configuration.ConfigurationManager.AppSettings["DIR_DirType"] == "1";

            //盆子调拨
            chbIsUsePZ.Checked = UserClass.AppConfig.ReadValue("DIR_IsUsePZ", "AppSettings").ToString() == "1" ? true : false;
            if (!chbIsUsePZ.Checked)
            {
                txtMaxQtyPZ.ReadOnly = true;
                txtPianYiPZ.ReadOnly = true;
                txtDPQtyPZ.ReadOnly = true;
                txtMinQtyPZ.ReadOnly = true;
            }

            txtMaxQtyPZ.Text = UserClass.AppConfig.ReadValue("DIR_MaxQtyPZ", "AppSettings");
            txtPianYiPZ.Text = UserClass.AppConfig.ReadValue("DIR_PianYiPZ", "AppSettings");
            txtDPQtyPZ.Text = UserClass.AppConfig.ReadValue("DIR_DPQtyPZ", "AppSettings");
            txtMinQtyPZ.Text = UserClass.AppConfig.ReadValue("DIR_MinQtyPZ", "AppSettings");

            //材料调拨
            chbIsUseCL.Checked = UserClass.AppConfig.ReadValue("DIR_IsUseCL", "AppSettings").ToString() == "1" ? true : false;
            if (!chbIsUseCL.Checked)
            {
                txtMaxQtyCL.ReadOnly = true;
                txtPianYiCL.ReadOnly = true;
            }

            txtMaxQtyCL.Text = UserClass.AppConfig.ReadValue("DIR_MaxQtyCL", "AppSettings");
            txtPianYiCL.Text = UserClass.AppConfig.ReadValue("DIR_PianYiCL", "AppSettings");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                return;//退格键

            _reg = new Regex(@"^[1-9]\d*|0$");

            if (!_reg.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbIsUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIsUsePZ.Checked)
            {
                txtMaxQtyPZ.ReadOnly = false;
                txtPianYiPZ.ReadOnly = false;
                txtDPQtyPZ.ReadOnly = false;
                txtMinQtyPZ.ReadOnly = false;
            }
            else
            {
                txtMaxQtyPZ.ReadOnly = true;
                txtPianYiPZ.ReadOnly = true;
                txtDPQtyPZ.ReadOnly = true;
                txtMinQtyPZ.ReadOnly = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbIsUseCL_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIsUseCL.Checked)
            {
                txtMaxQtyCL.ReadOnly = false;
                txtPianYiCL.ReadOnly = false;
            }
            else
            {
                txtMaxQtyCL.ReadOnly = true;
                txtPianYiCL.ReadOnly = true;
            }
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckConnect_Click(object sender, EventArgs e)
        {
            if (txtIP.Text.Trim() == "" || txtCatalog.Text.Trim() == "" || txtUser.Text.Trim() == "" || txtPWD.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整信息。");
                return;
            }

            MessageBox.Show(CommFunction.ConnectionCheck_SQL("Data Source=" + txtIP.Text + ";Initial Catalog=" + txtCatalog.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPWD.Text + ";Max Pool Size=1024;"));
        }

        /// <summary>
        /// 设置对应仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnStock_Click(object sender, EventArgs e)
        {
            frmPro_Dir_Stock frm = new frmPro_Dir_Stock();
            frm.ShowDialog();
        }

        /// <summary>
        /// 保存信息并退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnOK_Click(object sender, EventArgs e)
        {
            string DirType = rbtERP.Checked ? "1" : "0";
            UserClass.AppConfig.WriteValue("DIR_DirType", DirType);

            //
            string IsUsePZ = chbIsUsePZ.Checked ? "1" : "0";
            UserClass.AppConfig.WriteValue("DIR_IsUsePZ", IsUsePZ);
            UserClass.AppConfig.WriteValue("DIR_MaxQtyPZ", txtMaxQtyPZ.Text);
            UserClass.AppConfig.WriteValue("DIR_PianYiPZ", txtPianYiPZ.Text);
            UserClass.AppConfig.WriteValue("DIR_DPQtyPZ", txtDPQtyPZ.Text);
            UserClass.AppConfig.WriteValue("DIR_MinQtyPZ", txtMinQtyPZ.Text);

            //
            string IsUseCL = chbIsUseCL.Checked ? "1" : "0";
            UserClass.AppConfig.WriteValue("DIR_IsUseCL", IsUseCL);
            UserClass.AppConfig.WriteValue("DIR_MaxQtyCL", txtMaxQtyCL.Text);
            UserClass.AppConfig.WriteValue("DIR_PianYiCL", txtPianYiCL.Text);

            //
            string strDepartment = cbxDepartment.SelectedValue.ToString(), strStock = cbxStock.SelectedValue.ToString();
            UserClass.AppConfig.WriteValue("DIR_CPDB_Department", strDepartment);
            UserClass.AppConfig.WriteValue("DIR_CPDB_Stock", strStock);

            //
            UserClass.AppConfig.WriteValue("SQL_IP", txtIP.Text);
            UserClass.AppConfig.WriteValue("SQL_Catalog", txtCatalog.Text);
            UserClass.AppConfig.WriteValue("SQL_User", txtUser.Text);
            UserClass.AppConfig.WriteValue("SQL_PWD", txtPWD.Text);

            Model.Globa.GlobalParameter.Tmp_Params = DirType;
            Model.Globa.GlobalParameter.Dir_DPQtyPZ = int.Parse(txtDPQtyPZ.Text);
            Model.Globa.GlobalParameter.Dir_MinQtyPZ = int.Parse(txtMinQtyPZ.Text);
            Model.Globa.GlobalParameter.Dir_CPDB_Department = strDepartment;
            Model.Globa.GlobalParameter.Dir_CPDB_Stock = strStock;

            Model.Globa.GlobalParameter.SQLInf.ConnectionString = "Data Source=" + txtIP.Text + ";Initial Catalog=" + txtCatalog.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPWD.Text + ";Max Pool Size=1024;";

            MessageBox.Show("保存成功");
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 取消并退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
