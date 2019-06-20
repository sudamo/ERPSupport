﻿using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ERPSupport.SupForm.Menu
{
    /// <summary>
    /// 
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
            if (Model.Globa.GlobalRights.MIDs.Contains("502"))
                gbxDB_WMS.Enabled = true;
            else
                gbxDB_WMS.Enabled = false;

            txtIP.Text = UserClass.AppConfig.ReadValue("SQL_IP", "AppSettings");
            txtCatalog.Text = UserClass.AppConfig.ReadValue("SQL_Catalog", "AppSettings");
            txtUser.Text = UserClass.AppConfig.ReadValue("SQL_User", "AppSettings");
            txtPWD.Text = UserClass.AppConfig.ReadValue("SQL_PWD", "AppSettings");

            rbtERP.Checked = System.Configuration.ConfigurationManager.AppSettings["DIR_DirType"] == "1";

            //盆子调拨
            chbIsUsePZ.Checked = UserClass.AppConfig.ReadValue("DIR_IsUsePZ", "AppSettings").ToString() == "1" ? true : false;
            if (!chbIsUsePZ.Checked)
            {
                txtMaxQtyPZ.ReadOnly = true;
                txtPianYiPZ.ReadOnly = true;
            }

            txtMaxQtyPZ.Text = UserClass.AppConfig.ReadValue("DIR_MaxQtyPZ", "AppSettings");
            txtPianYiPZ.Text = UserClass.AppConfig.ReadValue("DIR_PianYiPZ", "AppSettings");

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            string DirType = rbtERP.Checked ? "1" : "0";
            UserClass.AppConfig.WriteValue("DIR_DirType", DirType);

            //
            string IsUsePZ = chbIsUsePZ.Checked ? "1" : "0";
            UserClass.AppConfig.WriteValue("DIR_IsUsePZ", IsUsePZ);
            UserClass.AppConfig.WriteValue("DIR_MaxQtyPZ", txtMaxQtyPZ.Text);
            UserClass.AppConfig.WriteValue("DIR_PianYiPZ", txtPianYiPZ.Text);

            //
            string IsUseCL = chbIsUseCL.Checked ? "1" : "0";
            UserClass.AppConfig.WriteValue("DIR_IsUseCL", IsUseCL);
            UserClass.AppConfig.WriteValue("DIR_MaxQtyCL", txtMaxQtyCL.Text);
            UserClass.AppConfig.WriteValue("DIR_PianYiCL", txtPianYiCL.Text);

            //
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
            }
            else
            {
                txtMaxQtyPZ.ReadOnly = true;
                txtPianYiPZ.ReadOnly = true;
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
    }
}
