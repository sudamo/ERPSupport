using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 物料清单报表
    /// </summary>
    public partial class ucReportBom : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucReportBom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucReportBom_Load(object sender, EventArgs e)
        {
            FillComboBox();
            rbtBom.Checked = true;
            rbtReplaceGroup.Checked = false;
            rbtBOMChild.Checked = false;
            btnReport.Enabled = false;
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            DataTable dt = null;
            DataRow dr = null;

            cbxUseOrg.DataSource = CommonFunction.GetOrganization("LOCKSTOCK");
            cbxUseOrg.DisplayMember = "FName";
            cbxUseOrg.ValueMember = "FValue";
            cbxUseOrg.SelectedIndex = 2;

            //cbxLogic
            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            dr = dt.NewRow();
            dr["FName"] = "等于";
            dr["FValue"] = "=";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "小于";
            dr["FValue"] = "<";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "大于";
            dr["FValue"] = ">";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "小于等于";
            dr["FValue"] = "<=";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "大于等于";
            dr["FValue"] = ">=";
            dt.Rows.Add(dr);

            cbxLogic.DataSource = dt;
            cbxLogic.DisplayMember = "FName";
            cbxLogic.ValueMember = "FValue";
            cbxLogic.SelectedIndex = 2;

            //Times
            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            dr = dt.NewRow();
            dr["FName"] = "1";
            dr["FValue"] = "1";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "2";
            dr["FValue"] = "2";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "5";
            dr["FValue"] = "5";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "10";
            dr["FValue"] = "10";
            dt.Rows.Add(dr);

            cbxTimes.DataSource = dt;
            cbxTimes.DisplayMember = "FName";
            cbxTimes.ValueMember = "FValue";
            cbxTimes.SelectedIndex = 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = CommonFunction.BOMQuery(rbtBom.Checked, rbtBOMChild.Checked, rbtReplaceGroup.Checked, cbxUseOrg.SelectedIndex, cbxUseOrg.SelectedValue.ToString(), cbxLogic.SelectedValue.ToString(), cbxTimes.SelectedValue.ToString());
            btnReport.Enabled = true;
        }

        /// <summary>
        /// 导出报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            Export_Bom();
        }

        #region 导出报表
        /// <summary>
        /// 导出盘子物料报表
        /// </summary>
        private void Export_Bom()
        {
            if (dgv1.Rows.Count <= 0) return;

            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            Excel.Workbook xlBook = xlApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = xlBook.Worksheets[1] as Excel.Worksheet;

            //标题
            string strTitle = string.Empty;
            if (rbtBom.Checked || rbtReplaceGroup.Checked)
            {
                strTitle += rbtBom.Checked ? "BOM重复报表" : "BOM项次查询报表";

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
                worksheet.Cells[2, 5] = rbtBom.Checked ? "重复次数" : "项次";

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

        /// <summary>
        /// rbtBom_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtBom_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtBom.Checked)
            {
                cbxUseOrg.Enabled = false;
                cbxLogic.Enabled = false;
                cbxTimes.Enabled = false;
            }
            else if (rbtBOMChild.Checked)
            {
                cbxUseOrg.Enabled = false;
                cbxLogic.Enabled = false;
                cbxTimes.Enabled = false;
            }
            else if(rbtReplaceGroup.Checked)
            {
                cbxUseOrg.Enabled = true;
                cbxLogic.Enabled = true;
                cbxTimes.Enabled = true;
            }
            btnReport.Enabled = false;
        }

        /// <summary>
        /// rbtBOMChild_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtBOMChild_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBom.Checked)
            {
                cbxUseOrg.Enabled = false;
                cbxLogic.Enabled = false;
                cbxTimes.Enabled = false;
            }
            else if (rbtBOMChild.Checked)
            {
                cbxUseOrg.Enabled = false;
                cbxLogic.Enabled = false;
                cbxTimes.Enabled = false;
            }
            else if (rbtReplaceGroup.Checked)
            {
                cbxUseOrg.Enabled = true;
                cbxLogic.Enabled = true;
                cbxTimes.Enabled = true;
            }
            btnReport.Enabled = false;
        }
    }
}