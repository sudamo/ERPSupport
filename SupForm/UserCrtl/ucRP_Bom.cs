using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 物料清单报表
    /// </summary>
    public partial class ucRP_Bom : UserControl
    {
        /// <summary>
        /// 选择类型
        /// </summary>
        private int _Type;
        /// <summary>
        /// ToolStripBOM重复查询
        /// </summary>
        private ToolStripRadioButton _rbtBom;
        /// <summary>
        /// ToolStripBOM项次重复查询
        /// </summary>
        private ToolStripRadioButton _rbtBomChild;
        /// <summary>
        /// ToolStripBOM项次查询
        /// </summary>
        private ToolStripRadioButton _rbtBomChild_Times;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucRP_Bom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucRP_Bom_Load(object sender, EventArgs e)
        {
            _Type = 1;

            _rbtBom = new ToolStripRadioButton();
            _rbtBom.Text = "BOM重复查询";
            _rbtBom.Checked = true;
            ((RadioButton)_rbtBom.Control).CheckedChanged += new EventHandler(rbt_CheckedChanged);

            _rbtBomChild = new ToolStripRadioButton();
            _rbtBomChild.Text = "BOM项次重复查询";
            ((RadioButton)_rbtBomChild.Control).CheckedChanged += new EventHandler(rbt_CheckedChanged);

            _rbtBomChild_Times = new ToolStripRadioButton();
            _rbtBomChild_Times.Text = "BOM项次查询";

            //重新排列Items
            List<ToolStripItem> list = new List<ToolStripItem>();
            list.Add(bnTop.Items[0]);
            list.Add(_rbtBom);
            list.Add(_rbtBomChild);
            list.Add(_rbtBomChild_Times);
            list.Add(bnTop.Items[1]);
            list.Add(bnTop.Items[2]);
            list.Add(bnTop.Items[3]);
            list.Add(bnTop.Items[4]);
            list.Add(bnTop.Items[5]);
            list.Add(bnTop.Items[6]);

            bnTop.Items.Clear();
            foreach (ToolStripItem item in list)
                bnTop.Items.Add(item);

            bnTop_lblTimes.Visible = false;
            bnTop_cbxLogic.Visible = false;
            bnTop_cbxValue.Visible = false;

            FillComboBox();
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            DataTable dtLogic,dtValue;
            DataRow dr;

            //cbxLogic
            dtLogic = new DataTable();
            dtLogic.Columns.Add("FName");
            dtLogic.Columns.Add("FValue");

            dr = dtLogic.NewRow();
            dr["FName"] = "等于";
            dr["FValue"] = "=";
            dtLogic.Rows.Add(dr);
            dr = dtLogic.NewRow();
            dr["FName"] = "小于";
            dr["FValue"] = "<";
            dtLogic.Rows.Add(dr);
            dr = dtLogic.NewRow();
            dr["FName"] = "小于等于";
            dr["FValue"] = "<=";
            dtLogic.Rows.Add(dr);
            dr = dtLogic.NewRow();
            dr["FName"] = "大于";
            dr["FValue"] = ">";
            dtLogic.Rows.Add(dr);
            dr = dtLogic.NewRow();
            dr["FName"] = "大于等于";
            dr["FValue"] = ">=";
            dtLogic.Rows.Add(dr);

            bnTop_cbxLogic.ComboBox.DataSource = dtLogic;
            bnTop_cbxLogic.ComboBox.DisplayMember = "FName";
            bnTop_cbxLogic.ComboBox.ValueMember = "FValue";
            bnTop_cbxLogic.SelectedIndex = 3;

            //Value
            dtValue = new DataTable();
            dtValue.Columns.Add("FName");
            dtValue.Columns.Add("FValue");

            dr = dtValue.NewRow();
            dr["FName"] = "1";
            dr["FValue"] = "1";
            dtValue.Rows.Add(dr);
            dr = dtValue.NewRow();
            dr["FName"] = "2";
            dr["FValue"] = "2";
            dtValue.Rows.Add(dr);
            dr = dtValue.NewRow();
            dr["FName"] = "5";
            dr["FValue"] = "5";
            dtValue.Rows.Add(dr);
            dr = dtValue.NewRow();
            dr["FName"] = "10";
            dr["FValue"] = "10";
            dtValue.Rows.Add(dr);

            bnTop_cbxValue.ComboBox.DataSource = dtValue;
            bnTop_cbxValue.ComboBox.DisplayMember = "FName";
            bnTop_cbxValue.ComboBox.ValueMember = "FValue";
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = DALFactory.K3Cloud.DALCreator.CommFunction.BOMQuery(_Type, SetFilter());
            if (dt == null || dt.Rows.Count == 0)
                return;

            dgv1.DataSource = dt;
            bnTop_btnReport.Enabled = true;
        }

        /// <summary>
        /// 设置过滤条件
        /// </summary>
        /// <returns></returns>
        private string SetFilter()
        {
            return bnTop_cbxLogic.ComboBox.SelectedValue.ToString() + bnTop_cbxValue.ComboBox.SelectedValue.ToString();
        }

        /// <summary>
        /// rbtBom_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtBom.Checked)
            {
                _Type = 1;
                bnTop_lblTimes.Visible = false;
                bnTop_cbxLogic.Visible = false;
                bnTop_cbxValue.Visible = false;
            }
            else if (_rbtBomChild.Checked)
            {
                _Type = 2;
                bnTop_lblTimes.Visible = false;
                bnTop_cbxLogic.Visible = false;
                bnTop_cbxValue.Visible = false;
            }
            else if (_rbtBomChild_Times.Checked)
            {
                _Type = 3;
                bnTop_lblTimes.Visible = true;
                bnTop_cbxLogic.Visible = true;
                bnTop_cbxValue.Visible = true;
            }

            bnTop_btnReport.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnReport_Click(object sender, EventArgs e)
        {

        }

        #region 报表
        /// <summary>
        /// 导出报表
        /// </summary>
        private void Report_Bom()
        {
            if (dgv1 == null || dgv1.Rows.Count == 0) return;

            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            Excel.Workbook xlBook = xlApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = xlBook.Worksheets[1] as Excel.Worksheet;

            //标题
            string strTitle = string.Empty;
            if (_rbtBom.Checked || _rbtBomChild_Times.Checked)
            {
                strTitle += _rbtBom.Checked ? "BOM重复报表" : "BOM项次查询报表";

                //生成表头
                (worksheet.Columns["A:A", Type.Missing] as Excel.Range).ColumnWidth = "20";         //物料编码
                (worksheet.Columns["B:B", Type.Missing] as Excel.Range).ColumnWidth = "50";         //物料名称
                (worksheet.Columns["C:C", Type.Missing] as Excel.Range).ColumnWidth = "12";         //使用组织
                (worksheet.Columns["D:D", Type.Missing] as Excel.Range).ColumnWidth = "24";         //BOM
                (worksheet.Columns["E:E", Type.Missing] as Excel.Range).ColumnWidth = "9";          //次数

                worksheet.Cells[2, 1] = "物料编码";
                worksheet.Cells[2, 2] = "物料名称";
                worksheet.Cells[2, 3] = "使用组织";
                worksheet.Cells[2, 4] = "BOM";
                worksheet.Cells[2, 5] = _rbtBom.Checked ? "重复次数" : "项次";

                worksheet.Cells[1, 1] = strTitle;
                Excel.Range rTitle = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]];
                rTitle.Merge();
                rTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rTitle.Interior.Color = Color.FromArgb(26, 180, 240);
                rTitle.Font.Bold = true;
                rTitle.Font.Size = 24;
                rTitle.Font.Name = "宋体";

                Excel.Range rCTitle = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 5]];
                rCTitle.Interior.Color = Color.FromArgb(135, 165, 175);

                ((Excel.Range)worksheet.Rows[1, Type.Missing]).RowHeight = "32";
                ((Excel.Range)worksheet.Rows[2, Type.Missing]).RowHeight = "24";
                ((Excel.Range)worksheet.Columns[2, Type.Missing]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                (worksheet.Columns["A:A", Type.Missing] as Excel.Range).NumberFormatLocal = "@";

                //填充数据
                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    worksheet.Cells[i + 3, 1] = dgv1.Rows[i].Cells[0].Value.ToString();
                    worksheet.Cells[i + 3, 2] = dgv1.Rows[i].Cells[1].Value.ToString();
                    worksheet.Cells[i + 3, 3] = dgv1.Rows[i].Cells[2].Value.ToString();
                    worksheet.Cells[i + 3, 4] = dgv1.Rows[i].Cells[3].Value.ToString();
                    worksheet.Cells[i + 3, 5] = dgv1.Rows[i].Cells[4].Value.ToString();
                }
            }
            else
            {
                strTitle += "BOM项次重复报表";

                //生成表头
                (worksheet.Columns["A:A", Type.Missing] as Excel.Range).ColumnWidth = "20";         //物料编码
                (worksheet.Columns["B:B", Type.Missing] as Excel.Range).ColumnWidth = "50";         //物料名称
                (worksheet.Columns["C:C", Type.Missing] as Excel.Range).ColumnWidth = "12";         //使用组织
                (worksheet.Columns["D:D", Type.Missing] as Excel.Range).ColumnWidth = "24";         //BOM
                (worksheet.Columns["E:E", Type.Missing] as Excel.Range).ColumnWidth = "20";         //子项物料编码
                (worksheet.Columns["F:F", Type.Missing] as Excel.Range).ColumnWidth = "9";          //重复次数

                worksheet.Cells[2, 1] = "物料编码";
                worksheet.Cells[2, 2] = "物料名称";
                worksheet.Cells[2, 3] = "使用组织";
                worksheet.Cells[2, 4] = "BOM";
                worksheet.Cells[2, 5] = "子项物料编码";
                worksheet.Cells[2, 6] = "重复次数";

                worksheet.Cells[1, 1] = strTitle;
                Excel.Range rTitle = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 6]];
                rTitle.Merge();
                rTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rTitle.Interior.Color = Color.FromArgb(26, 180, 240);
                rTitle.Font.Bold = true;
                rTitle.Font.Size = 24;
                rTitle.Font.Name = "宋体";

                Excel.Range rCTitle = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 6]];
                rCTitle.Interior.Color = Color.FromArgb(135, 165, 175);

                ((Excel.Range)worksheet.Rows[1, Type.Missing]).RowHeight = "32";
                ((Excel.Range)worksheet.Rows[2, Type.Missing]).RowHeight = "24";
                ((Excel.Range)worksheet.Columns[2, Type.Missing]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                (worksheet.Columns["A:A", Type.Missing] as Excel.Range).NumberFormatLocal = "@";
                (worksheet.Columns["E:E", Type.Missing] as Excel.Range).NumberFormatLocal = "@";

                //填充数据
                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    worksheet.Cells[i + 3, 1] = dgv1.Rows[i].Cells[0].Value.ToString();
                    worksheet.Cells[i + 3, 2] = dgv1.Rows[i].Cells[1].Value.ToString();
                    worksheet.Cells[i + 3, 3] = dgv1.Rows[i].Cells[2].Value.ToString();
                    worksheet.Cells[i + 3, 4] = dgv1.Rows[i].Cells[3].Value.ToString();
                    worksheet.Cells[i + 3, 5] = dgv1.Rows[i].Cells[4].Value.ToString();
                    worksheet.Cells[i + 3, 6] = dgv1.Rows[i].Cells[5].Value.ToString();
                }
            }
            xlApp.Visible = true;
        }
        #endregion
    }
}