using System;
using System.Data;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    using SQL.K3Cloud;
    using System.Collections.Generic;

    /// <summary>
    /// 物料-仓库 对应设置
    /// </summary>
    public partial class ucCS_DefaultStock : UserControl
    {
        private bool _FirstLoad;
        private int _Search;
        private DataTable _Stocks;
        private DataTable _DataSource;
        private DataGridViewComboBoxColumn _colStock;
        private DataGridViewComboBoxColumn _colStockTran;

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
            _FirstLoad = true;
            _Search = 0;
            _Stocks = CommFunction.GetStock(4);
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
                    Delete();
                    break;
                case "5":
                    ClearNullStock();
                    break;
            }
        }

        private void Search()
        {
            _DataSource = CommFunction.MStockSetting(bnTop_txtNumber.Text.Trim());
            dgv1.DataSource = _DataSource;

            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;
                        
            if (_FirstLoad)
            {
                _colStock = new DataGridViewComboBoxColumn();
                SetComboBoxCol(ref _colStock, "调出仓设置", _Stocks);
                _colStockTran = new DataGridViewComboBoxColumn();
                SetComboBoxCol(ref _colStockTran, "中间仓设置", _Stocks);

                //dgv1.Columns.Add(_colStock);
                //dgv1.Columns.Insert(7, _colStock);
                //dgv1.Columns.Insert(8, _colStockTran);
                dgv1.Columns.AddRange(new DataGridViewColumn[] { _colStock, _colStockTran });
                _FirstLoad = false;
            }
            _Search ++;
        }
        private void BatchFill()
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            int iCol, iColTran;
            string FValue, FName, FValueTran, FNameTran;
            FValue = string.Empty;
            FValueTran = string.Empty;

            if (_Search > 1)
            {
                iCol = 0;
                iColTran = 1;
            }
            else
            {
                iCol = 7;
                iColTran = 8;
            }

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1.Rows[i].Selected)
                {
                    FName = (dgv1.Rows[i].Cells[iCol]).EditedFormattedValue.ToString();
                    FNameTran = (dgv1.Rows[i].Cells[iColTran]).EditedFormattedValue.ToString();

                    if (FValue == string.Empty && FName != string.Empty)
                    {
                        if (FName == " 请选择")
                            FValue = " 请选择";
                        else
                            FValue = CommFunction.GetStockNumber(100508, FName);
                    }
                    if (FValueTran == string.Empty && FNameTran != string.Empty)
                    {
                        if (FNameTran == " 请选择")
                            FValueTran = " 请选择";
                        else
                            FValueTran = CommFunction.GetStockNumber(100508, FNameTran);
                    }

                    if (FValue != string.Empty)
                        dgv1.Rows[i].Cells[iCol].Value = FValue;
                    if (FValueTran != string.Empty)
                        dgv1.Rows[i].Cells[iColTran].Value = FValueTran;
                }
            }
        }
        private void Save()
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            int iFID, iCol, iColTran;
            string FID, FName, FNameTran;

            if (_Search > 1)
            {
                iFID = 2;
                iCol = 0;
                iColTran = 1;
            }
            else
            {
                iFID = 0;
                iCol = 7;
                iColTran = 8;
            }

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                FID = dgv1.Rows[i].Cells[iFID].Value.ToString();
                FName = (dgv1.Rows[i].Cells[iCol]).EditedFormattedValue.ToString();
                FNameTran = (dgv1.Rows[i].Cells[iColTran]).EditedFormattedValue.ToString();

                //保存
                CommFunction.UpdateMStockSetting(FID, FName, FNameTran);

                //操作日志
                CommFunction.DM_Log_Local("设置默认仓库", "配置\\物料默认仓库", bnTop_txtNumber.Text + ":[" + FName + "|" + FNameTran + "]");
            }
            MessageBox.Show("更新完成。");
            Search();
        }
        private void Delete()
        {
            if (MessageBox.Show("您确定要删除信息吗？", "默认仓库设置删除", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            int iFID;
            string FID;
            if (_Search > 1)
            {
                iFID = 2;
            }
            else
            {
                iFID = 0;
            }

            List<string> list = new List<string>();

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1.Rows[i].Selected)
                {
                    FID = dgv1.Rows[i].Cells[iFID].Value.ToString();

                    if (FID != string.Empty)
                        list.Add(FID);
                }
            }

            //删除
            CommFunction.DeleteMStockSetting(list);

            //操作日志
            CommFunction.DM_Log_Local("设置默认仓库", "配置\\物料默认仓库", "删除[" + bnTop_txtNumber.Text + "]");

            MessageBox.Show("删除完成。");
            Search();
        }
        private void ClearNullStock()
        {
            CommFunction.DelMStockSetting();

            //操作日志
            CommFunction.DM_Log_Local("设置默认仓库", "配置\\物料默认仓库", "清除空值仓库");

            MessageBox.Show("清除完成");
        }

        public bool SetComboBoxCol(ref DataGridViewComboBoxColumn pCol, string pHearderText, DataTable pDtSource)
        {
            if (pDtSource == null || pDtSource.Rows.Count == 0)
                return false;

            pCol.HeaderText = pHearderText;
            pCol.DataSource = pDtSource;
            pCol.ValueMember = pDtSource.Columns[0].ColumnName;
            pCol.DisplayMember = pDtSource.Columns[1].ColumnName;
            pCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            pCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            return true;
        }
        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
