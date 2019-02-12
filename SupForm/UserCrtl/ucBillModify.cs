using System;
using System.Data;
using ERPSupport.SQL.K3Cloud;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 单据修改
    /// </summary>
    public partial class ucBillModify : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ucBillModify()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBillModify_Load(object sender, EventArgs e)
        {
            FillCombobox();
            dtpFrom.Value = DateTime.Now.AddDays(-3);
            dtpTo.Value = DateTime.Now;
            btnSyn.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillCombobox()
        {
            DataTable dt;
            DataRow dr;

            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            dr = dt.NewRow();
            dr["FName"] = "销售订单";
            dr["FValue"] = "SAL_ORDER";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "生产订单";
            dr["FValue"] = "PRD_MO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "生产入库单";
            dr["FValue"] = "PRD_INSTOCK";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "销售出库单";
            dr["FValue"] = "SAL_OUTSTOCK";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "应收单";
            dr["FValue"] = "AR_RECEIVABLE";
            dt.Rows.Add(dr);

            cbxType.DataSource = dt;
            cbxType.DisplayMember = "FName";
            cbxType.ValueMember = "FValue";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            cbxType.SelectedValue = "SAL_ORDER";
            DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        private void DataBind()
        {
            string strFormID = cbxType.SelectedValue.ToString(), strFBillNo = txtBillNo.Text.Trim();
            DateTime dtFrom = dtpFrom.Value, dtTo = dtpTo.Value;

            if (strFBillNo == string.Empty)
                dgv1.DataSource = SalOrder.GetBillInfo(strFormID, dtFrom, dtTo);
            else
                dgv1.DataSource = SalOrder.GetBillInfo(strFormID, strFBillNo, dtFrom, dtTo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatchModify_Click(object sender, EventArgs e)
        {
            Common.frmBillModify frmBM = new Common.frmBillModify(cbxType.SelectedValue.ToString(), txtBillNo.Text);
            frmBM.ShowDialog();
            //if (frmBM.DialogResult == DialogResult.OK)
            //    DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSyn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此时间段：" + dtpFrom.Value.ToString("yyyy-MM-dd") + "至" + dtpTo.Value.ToString("yyyy-MM-dd") + "\n 共有" + PrdAllocation.Asyn_PPBom_FNeedDate(dtpFrom.Value, dtpTo.Value).ToString() + "不同步，确定同步吗？", "同步确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                PrdAllocation.Syn_PPBom_FNeedDate(dtpFrom.Value, dtpTo.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType != null && cbxType.SelectedValue.ToString() == "PRD_MO")
                btnSyn.Visible = true;
            else
                btnSyn.Visible = false;
        }
    }
}
