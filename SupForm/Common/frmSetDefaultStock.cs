using System;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;

namespace ERPSupport.SupForm.Common
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
        private string PlanStartDate = string.Empty;
        /// <summary>
        /// 初次加载
        /// </summary>
        private bool bLoad = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pFPlanStartDate">计划开工日期</param>
        public frmSetDefaultStock(string pFPlanStartDate)
        {
            InitializeComponent();
            PlanStartDate = pFPlanStartDate;
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
                    strMaterialID = CommonFunction.GetMTLIDByNumber(100508, dgv1.Rows[i].Cells[0].Value.ToString()).ToString();
                    strDeptNumber = dgv1.Rows[i].Cells[2].Value.ToString();
                    strDeptID = CommonFunction.GetDepartIdByNumber(100508, dgv1.Rows[i].Cells[2].Value.ToString()).ToString();
                    strStockNumber = dgv1.Rows[i].Cells[4].Value.ToString();
                    strStockID = CommonFunction.GetStockIdByNumber(100508, dgv1.Rows[i].Cells[4].Value.ToString()).ToString();

                    if (strStockID == null) continue;
                    
                    CommonFunction.AddMStockSetting(strMaterialID, strMaterialNumber, strDeptID, strDeptNumber, strStockID, strStockNumber);
                }
            }

            CheckStock();
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        private void CheckStock()
        {
            dgv1.DataSource = PrdInstock.GetMo(PlanStartDate);

            if (!bLoad)
            {
                DataGridViewComboBoxColumn dgvcbxc = new DataGridViewComboBoxColumn();
                dgvcbxc.HeaderText = "仓库";
                dgvcbxc.AutoComplete = true;
                dgvcbxc.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dgvcbxc.DataSource = CommonFunction.GetStock(3, 0);
                dgvcbxc.DisplayMember = "FName";
                dgvcbxc.ValueMember = "FValue";
                dgv1.Columns.Add(dgvcbxc);
                bLoad = true;
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
