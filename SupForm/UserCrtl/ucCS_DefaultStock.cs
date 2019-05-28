using System;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 物料-仓库 对应设置
    /// </summary>
    public partial class ucCS_DefaultStock : UserControl
    {
        /// <summary>
        /// 查询次数
        /// </summary>
        private int _SearchCount;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCS_DefaultStock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCS_DefaultStock_Load(object sender, EventArgs e)
        {
            _SearchCount = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    Search();
                    break;
                case "2":
                    BatchFill();
                    break;
                case "3":
                    Save();
                    break;
                case "4":
                    ClearNullStock();
                    break;
            }
        }

        private void Search()
        {
            _SearchCount++;
            dgv1.DataSource = CommFunction.MStockSetting(bnTop_txtNumber.Text.Trim());

            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            if (dgv1.Columns.Count <= 6)
            {
                DataGridViewComboBoxColumn _ComboBoxCol = new DataGridViewComboBoxColumn();
                _ComboBoxCol.HeaderText = "修改仓库";
                _ComboBoxCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                _ComboBoxCol.DataSource = CommFunction.GetStock();
                _ComboBoxCol.DisplayMember = "FName";
                _ComboBoxCol.ValueMember = "FValue";

                dgv1.Columns.Add(_ComboBoxCol);
            }
        }
        private void BatchFill()
        {
            if (dgv1 == null)
                return;

            string strStockValue = string.Empty;
            int iCol = _SearchCount == 1 ? 6 : 0;

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1.Rows[i].Selected)
                {
                    if (strStockValue == string.Empty && dgv1.Rows[i].Cells[iCol].Value != null)
                        strStockValue = dgv1.Rows[i].Cells[iCol].Value.ToString();

                    dgv1.Rows[i].Cells[iCol].Value = strStockValue; ;
                }
            }
        }
        private void Save()
        {
            if (dgv1 == null)
                return;

            string FID, StockNumber;
            int iCol = _SearchCount == 1 ? 6 : 0;

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1.Rows[i].Cells[iCol].Value == null)
                    continue;

                FID = dgv1.Rows[i].Cells[0].Value.ToString();
                StockNumber = dgv1.Rows[i].Cells[iCol].Value.ToString();

                CommFunction.UpdateMStockSetting(StockNumber, int.Parse(FID));

                //操作日志
                CommFunction.DM_Log_Local("设置默认仓库", "配置\\物料默认仓库", bnTop_txtNumber.Text + ":" + dgv1.Rows[i].Cells[iCol].Value, "1");
            }

            Search();
        }
        private void ClearNullStock()
        {
            CommFunction.DelMStockSetting();

            //操作日志
            CommFunction.DM_Log_Local("设置默认仓库", "配置\\物料默认仓库", "清除空值仓库", "1");

            MessageBox.Show("清除完成");
        }
    }
}
