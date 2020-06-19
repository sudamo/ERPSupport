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

        private int _OrgId;
        /// <summary>
        /// 计划开工日期
        /// </summary>
        private string _PlanStartDate;
        /// <summary>
        /// 业务标识
        /// </summary>
        private Model.Enum.FormID _FormId;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pFPlanStartDate">计划开工日期</param>
        public frmSetDefaultStock(string pFPlanStartDate, Model.Enum.FormID pFormId)
        {
            InitializeComponent();

            _PlanStartDate = pFPlanStartDate;
            _FormId = pFormId;

            if (_FormId == Model.Enum.FormID.PRD_PPBOM)
                _OrgId = 100508;
            else
                _OrgId = 492501088;
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetDefaultStock_Load(object sender, EventArgs e)
        {
            dgv1.DataSource = PrdInstock.GetMo(_PlanStartDate, _FormId);
            

            DataGridViewComboBoxColumn colcbx = new DataGridViewComboBoxColumn();
            colcbx.HeaderText = "默认仓库";
            colcbx.AutoComplete = true;
            colcbx.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            colcbx.DataSource = CommFunction.GetStock(5, _OrgId);
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
                        strStockValue = CommFunction.GetStockNumber(_OrgId, FName);

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
                    strMaterialID = CommFunction.GetMTLIDByNumber(_OrgId, dgv1.Rows[i].Cells[0].Value.ToString()).ToString();
                    strDeptNumber = dgv1.Rows[i].Cells[2].Value.ToString();
                    strDeptID = CommFunction.GetDepartIdByNumber(_OrgId, dgv1.Rows[i].Cells[2].Value.ToString()).ToString();
                    strStockNumber = CommFunction.GetStockNumber(_OrgId, FName);
                    strStockID = CommFunction.GetStockIdByNumber(_OrgId, strStockNumber).ToString();

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
