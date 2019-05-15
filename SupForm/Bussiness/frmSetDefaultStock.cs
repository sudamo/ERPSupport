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
        /// 初次加载
        /// </summary>
        private bool _Load;
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

            _Load = false;
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetDefaultStock_Load(object sender, EventArgs e)
        {
            CheckStock();
        }


        /// <summary>
        /// 批量填充
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatFill_Click(object sender, EventArgs e)
        {
            string strStockValue = string.Empty;

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if(dgv1.Rows[i].Selected)
                {
                    if (strStockValue == string.Empty && dgv1.Rows[i].Cells[4].Value != null)
                        strStockValue = dgv1.Rows[i].Cells[4].Value.ToString();

                    dgv1.Rows[i].Cells[4].Value = strStockValue;
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
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

            CheckStock();
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        private void CheckStock()
        {
            dgv1.DataSource = PrdInstock.GetMo(_PlanStartDate);

            if (!_Load)
            {
                DataGridViewComboBoxColumn dgvcbxc = new DataGridViewComboBoxColumn();
                dgvcbxc.HeaderText = "仓库";
                dgvcbxc.AutoComplete = true;
                dgvcbxc.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dgvcbxc.DataSource = CommFunction.GetStock(-1, null);
                dgvcbxc.DisplayMember = "FName";
                dgvcbxc.ValueMember = "FValue";
                dgv1.Columns.Add(dgvcbxc);
                _Load = true;
            }
        }

        /// <summary>
        /// dgv1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count > 0)
            {
                txtMaterialName.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            }
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
