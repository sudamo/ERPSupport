using System;
using System.Data;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using ERPSupport.Model.Globa;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 物料-仓库 对应设置
    /// </summary>
    public partial class ucCS_DefaultStock : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCS_DefaultStock()
        {
            InitializeComponent();
        }

        private void ucCS_DefaultStock_Load(object sender, EventArgs e)
        {
            cbxStock.DataSource = CommFunction.GetStock(3, null);
            cbxStock.DisplayMember = "FName";
            cbxStock.ValueMember = "FValue";
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = null;
            dgv1.DataSource = CommFunction.MStockSetting(txtMaterialNO.Text.Trim());

            if (dgv1.DataSource != null && dgv1.Rows.Count > 0)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        /// <summary>
        /// 保存仓库设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxStock.SelectedIndex == 0) return;
            if (dgv1.Rows.Count == 0) return;
            string FID = dgv1.CurrentRow.Cells[0].Value.ToString();
            string STOCKNUMBER = cbxStock.SelectedValue.ToString();

            CommFunction.UpdateMStockSetting(STOCKNUMBER, int.Parse(FID));
            btnSearch_Click(null, null);
            cbxStock.SelectedIndex = 0;

            //操作日志
            CommFunction.DM_Log_Local("设置默认仓库", "配置\\物料默认仓库", txtMaterialNO.Text + ":" + cbxStock.Text, "1");
        }

        /// <summary>
        /// 清除空值仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            CommFunction.DelMStockSetting();

            //操作日志
            CommFunction.DM_Log_Local("设置默认仓库", "配置\\物料默认仓库", "清除空值仓库", "1");

            MessageBox.Show("清除完成");
        }

        #region 响应事件
        /// <summary>
        /// dgv1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count > 0)
            {
                txtMaterialNO.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                lblMaterialName.Text = "物料名称：" + dgv1.CurrentRow.Cells[2].Value.ToString();
                lblDepartment.Text = "部门名称：" + dgv1.CurrentRow.Cells[3].Value.ToString();
                cbxStock.SelectedValue = dgv1.CurrentRow.Cells[4].Value.ToString();
            }
        }

        /// <summary>
        /// txtMaterialNO_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMaterialNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch_Click(null, null);
        }
        #endregion
    }
}
