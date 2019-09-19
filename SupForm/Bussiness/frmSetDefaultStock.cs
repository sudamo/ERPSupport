using System;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Bussiness
{
    using SQL.K3Cloud;

    /// <summary>
    /// 默认仓库设置
    /// </summary>
    public partial class frmSetDefaultStock : Form
    {
        #region Variable & Constructor
        /// <summary>
        /// 计划开工日期
        /// </summary>
        private string _PlanStartDate;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pFPlanStartDate">计划开工日期</param>
        public frmSetDefaultStock(string pFPlanStartDate)
        {
            InitializeComponent();

            _PlanStartDate = pFPlanStartDate;
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetDefaultStock_Load(object sender, EventArgs e)
        {
            dgv1.DataSource = PrdInstock.GetMo(_PlanStartDate);

            DataGridViewComboBoxColumn colcbx = new DataGridViewComboBoxColumn();
            colcbx.HeaderText = "默认仓库";
            colcbx.AutoComplete = true;
            colcbx.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colcbx.DataSource = CommFunction.GetStock();
            dgv1.Columns.Add(colcbx);
            colcbx.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colcbx.DisplayMember = "FName";
            colcbx.ValueMember = "FValue";
        }

        private void bnTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    BatchFill();
                    break;
                case "2":
                    Save();
                    break;
            }
        }
        private void BatchFill()
        {
            string strStockValue = string.Empty;

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1.Rows[i].Selected)
                {
                    string FName = (dgv1.Rows[i].Cells[4]).EditedFormattedValue.ToString();
                    if (strStockValue == string.Empty && (dgv1.Rows[i].Cells[4]).EditedFormattedValue != null && FName != string.Empty)
                        strStockValue = CommFunction.GetStockNumber(FName);

                    dgv1.Rows[i].Cells[4].Value = strStockValue;
                }
            }
        }
        private void Save()
        {
            if (dgv1.Rows.Count < 1)
            {
                MessageBox.Show("没有数据！");
                return;
            }

            string strSQL = string.Empty;
            string strMaterialNumber = string.Empty;
            string strMaterialID = string.Empty;
            string strDeptNumber = string.Empty;
            string strDeptID = string.Empty;
            string strStockNumber = string.Empty;
            string strStockID = string.Empty;

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if ((dgv1.Rows[i].Cells[4]).EditedFormattedValue != null && (dgv1.Rows[i].Cells[4]).EditedFormattedValue.ToString() != string.Empty)
                {
                    string FName = (dgv1.Rows[i].Cells[4]).EditedFormattedValue.ToString();

                    strMaterialNumber = dgv1.Rows[i].Cells[0].Value.ToString();
                    strMaterialID = CommFunction.GetMTLIDByNumber(100508, dgv1.Rows[i].Cells[0].Value.ToString()).ToString();
                    strDeptNumber = dgv1.Rows[i].Cells[2].Value.ToString();
                    strDeptID = CommFunction.GetDepartIdByNumber(100508, dgv1.Rows[i].Cells[2].Value.ToString()).ToString();
                    strStockNumber = CommFunction.GetStockNumber(FName);
                    strStockID = CommFunction.GetStockIdByNumber(100508, strStockNumber).ToString();

                    if (strStockID == null || strStockID == "-1") continue;

                    CommFunction.AddMStockSetting(strMaterialID, strMaterialNumber, strDeptID, strDeptNumber, strStockID, strStockNumber);
                }
            }

            //dgv1.DataSource = PrdInstock.GetMo(_PlanStartDate);
            MessageBox.Show("保存成功");
            Close();
        }

        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
