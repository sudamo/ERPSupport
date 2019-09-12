using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Bussiness
{
    /// <summary>
    /// 修改生产用料清单信息
    /// </summary>
    public partial class frmPPBom : Form
    {
        /// <summary>
        /// 原数据
        /// </summary>
        private DataTable _dtDataSource;
        /// <summary>
        /// 修改后数据
        /// </summary>
        private DataTable _dtNew;
        public frmPPBom()
        {
            InitializeComponent();
        }

        private void frmPPBom_Load(object sender, EventArgs e)
        {
            Text = "修改生产用料清单信息 - " + Model.Globa.GlobalParameter.K3Inf.UserName;
        }

        private void bnTop_btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void bnC_btnSearch_Click(object sender, EventArgs e)
        {
            if (1 == 1)
            {
                bnC_btnChange.Visible = true;
            }
            //else
            //{
            //    bnC_btnChange.Visible = false;
            //}
        }

        private void bnC_bntChange_Click(object sender, EventArgs e)
        {
            DateTime tNeedDate = DateTime.Now.AddDays(-3);
            frmBomCompare frm = new frmBomCompare(_dtDataSource, _dtNew, tNeedDate);
            frm.ShowDialog();
        }

        private void txtLoss_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
