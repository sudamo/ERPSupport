using System;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;

namespace ERPSupport.SupForm.Bussiness
{
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
        /// 
        /// </summary>
        private DataGridViewComboBoxColumn _ComboBoxCol;

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

            _ComboBoxCol = new DataGridViewComboBoxColumn();
            _ComboBoxCol.HeaderText = "仓库";
            _ComboBoxCol.AutoComplete = true;
            _ComboBoxCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            _ComboBoxCol.DataSource = CommFunction.GetStock(-1, null);
            _ComboBoxCol.DisplayMember = "FName";
            _ComboBoxCol.ValueMember = "FValue";

            dgv1.Columns.Add(_ComboBoxCol);
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
                    if (strStockValue == string.Empty && dgv1.Rows[i].Cells[4].Value != null)
                        strStockValue = dgv1.Rows[i].Cells[4].Value.ToString();

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
                if (dgv1.Rows[i].Cells[4].Value != null && dgv1.Rows[i].Cells[4].Value.ToString() != string.Empty)
                {
                    strMaterialNumber = dgv1.Rows[i].Cells[0].Value.ToString();
                    strMaterialID = CommFunction.GetMTLIDByNumber(100508, dgv1.Rows[i].Cells[0].Value.ToString()).ToString();
                    strDeptNumber = dgv1.Rows[i].Cells[2].Value.ToString();
                    strDeptID = CommFunction.GetDepartIdByNumber(100508, dgv1.Rows[i].Cells[2].Value.ToString()).ToString();
                    strStockNumber = dgv1.Rows[i].Cells[4].Value.ToString();
                    strStockID = CommFunction.GetStockIdByNumber(100508, dgv1.Rows[i].Cells[4].Value.ToString()).ToString();

                    if (strStockID == null) continue;

                    CommFunction.AddMStockSetting(strMaterialID, strMaterialNumber, strDeptID, strDeptNumber, strStockID, strStockNumber);
                }
            }

            dgv1.DataSource = PrdInstock.GetMo(_PlanStartDate);
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
