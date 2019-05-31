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
                //DataGridViewComboBoxColumn colcbx = new DataGridViewComboBoxColumn();
                //colcbx.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                //colcbx.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //colcbx.DataSource = CommFunction.GetStock();
                //colcbx.HeaderText = "修改仓库";
                //colcbx.DisplayMember = "FName";
                //colcbx.ValueMember = "FValue";

                //dgv1.Columns.Add(colcbx);

                DataGridViewComboBoxColumn colcbx = new DataGridViewComboBoxColumn();
                colcbx.HeaderText = "修改仓库";
                colcbx.AutoComplete = true;
                colcbx.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                colcbx.DataSource = CommFunction.GetStock();
                dgv1.Columns.Add(colcbx);
                colcbx.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colcbx.DisplayMember = "FName";
                colcbx.ValueMember = "FValue";
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
                    string FName = (dgv1.Rows[i].Cells[iCol]).EditedFormattedValue.ToString();

                    if (strStockValue == string.Empty && FName != string.Empty)
                        strStockValue = CommFunction.GetStockNumber(FName);

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
                string FName = (dgv1.Rows[i].Cells[iCol]).EditedFormattedValue.ToString();
                if (FName == string.Empty)
                    continue;

                FID = dgv1.Rows[i].Cells[0].Value.ToString();
                StockNumber = CommFunction.GetStockNumber(FName);

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
