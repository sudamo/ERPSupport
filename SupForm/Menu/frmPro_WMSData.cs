using System;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Menu
{
    public partial class frmPro_WMSData : Form
    {
        public frmPro_WMSData()
        {
            InitializeComponent();
        }

        private void frmPro_WMSData_Load(object sender, EventArgs e)
        {
            lblTips.Text = "";
            chbAll.Checked = false;
        }

        private void txtMTL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                lblTips.Text = "";
        }

        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
                txtMTL.Enabled = false;
            else
                txtMTL.Enabled = true;
            lblTips.Text = "";
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSyn_Click(object sender, EventArgs e)
        {
            if (!chbAll.Checked && txtMTL.Text.Trim() == "")
                return;

            DALFactory.K3Cloud.DALCreator.CommFunction.SynMTLForWMS(chbAll.Checked, txtMTL.Text.Trim());
            lblTips.Text = "已执行！";
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
