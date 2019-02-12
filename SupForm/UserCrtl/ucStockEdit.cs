﻿using System;
using System.Data;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 物料-仓库 对应设置
    /// </summary>
    public partial class ucStockEdit : UserControl
    {
        #region Constructor
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucStockEdit()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucStockEdit_Load(object sender, EventArgs e)
        {
            DataTable dtp = CommonFunction.GetStock(3, 0);
            DataTable dt = null;
            DataRow dr = null;
            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");
            dr = dt.NewRow();
            dr["FName"] = "请选择";
            dr["FValue"] = "";
            dt.Rows.Add(dr);
            for (int i = 0; i < dtp.Rows.Count; i++)
            {
                dt.ImportRow(dtp.Rows[i]);
            }
            cbxStock.DataSource = dt;
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
            dgv1.DataSource = CommonFunction.MStockSetting(txtMaterialNO.Text.Trim());

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

            CommonFunction.UpdateMStockSetting(STOCKNUMBER, int.Parse(FID));
            btnSearch_Click(null, null);
            cbxStock.SelectedIndex = 0;
        }

        /// <summary>
        /// 清除空值仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            CommonFunction.DelMStockSetting();
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
