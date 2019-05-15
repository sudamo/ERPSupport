using System;
using System.Data;
using ERPSupport.SQL.K3Cloud;
using System.Windows.Forms;
using ERPSupport.Model.Globa;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 单据修改
    /// </summary>
    public partial class ucCS_BillEdit : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCS_BillEdit()
        {
            InitializeComponent();
        }

        private void ucCS_BillEdit_Load(object sender, EventArgs e)
        {
            FillCombobox();
            dtpFrom.Value = DateTime.Now.AddDays(-3);
            dtpTo.Value = DateTime.Now;
            btnSyn.Visible = false;

            cbxType_SelectedIndexChanged(null, null);
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
            dr["FValue"] = "SAL_SaleOrder";
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
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //cbxType.SelectedValue = "SAL_ORDER";
            //DataBind();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            //string strFormID = cbxType.SelectedValue.ToString(), strFBillNo = txtBillNo.Text.Trim();
            //DateTime dtFrom = dtpFrom.Value, dtTo = dtpTo.Value;

            //if (strFBillNo == string.Empty)
            //    dgv1.DataSource = SalOrder.GetBillInfo(Model.Enum.FormID.SAL_SaleOrder, dtFrom, dtTo);
            //else
            //    dgv1.DataSource = SalOrder.GetBillInfo(strFormID, strFBillNo, dtFrom, dtTo);
        }

        /// <summary>
        /// btnBatchModify_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatchModify_Click(object sender, EventArgs e)
        {
            Bussiness.frmBillModify frmBM = new Bussiness.frmBillModify(cbxType.SelectedValue.ToString(), txtBillNo.Text);
            frmBM.ShowDialog();
            //if (frmBM.DialogResult == DialogResult.OK)
            //    DataBind();
        }

        /// <summary>
        /// 同步需求日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSyn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此时间段：" + dtpFrom.Value.ToString("yyyy-MM-dd") + "至" + dtpTo.Value.ToString("yyyy-MM-dd") + "\n 共有" + PrdAllocation.Asyn_PPBom_FNeedDate(dtpFrom.Value, dtpTo.Value).ToString() + "不同步，确定同步吗？", "同步确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PrdAllocation.Syn_PPBom_FNeedDate(dtpFrom.Value, dtpTo.Value);
                //操作日志
                CommFunction.DM_Log_Local("同步需求日期", "配置\\单据信息调整", "时间段：" + dtpFrom.Value.ToString("yyyy-MM-dd") + "至" + dtpTo.Value.ToString("yyyy-MM-dd"), "1");
            }
        }

        /// <summary>
        /// btnModify_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            string billno = txtBillNo.Text.Trim();
            bool chk = chkSingle.Checked;

            if (billno.Equals(string.Empty))
            {
                MessageBox.Show("请输入销售订单编号。");
                return;
            }

            MessageBox.Show(SalOrder.UpdateSingle(billno, chk));
        }

        /// <summary>
        /// cbxType_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType == null) return;

            if (cbxType.SelectedValue.ToString() == "PRD_MO")
                btnSyn.Visible = true;
            else
                btnSyn.Visible = false;

            if (cbxType.SelectedValue.ToString() == "SAL_SaleOrder" && (GlobalParameter.K3Inf.DepartmentID == 619615 || GlobalParameter.K3Inf.DepartmentID == 481013))
            {
                pl2.Visible = true;
                dgv1.Location = new System.Drawing.Point(new System.Drawing.Size(5, 75));
            }
            else
            {
                pl2.Visible = false;
                dgv1.Location = new System.Drawing.Point(new System.Drawing.Size(5, 30));
            }
        }
    }
}
