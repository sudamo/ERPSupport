using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 盆子物料报表
    /// </summary>
    public partial class ucRP_Mtl203 : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucRP_Mtl203()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucRP_Mtl203_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        #region 填充筛选条件下拉框
        /// <summary>
        /// 填充筛选条件下拉框
        /// </summary>
        /// <param name="pFormId"></param>
        private void FillComboBox()
        {
            DataTable dt = null;
            DataRow dr = null;
            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");
            dr = dt.NewRow();
            dr["FName"] = "";
            dr["FValue"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "日期";
            dr["FValue"] = "A.FDATE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "单据编号";
            dr["FValue"] = "A.FBILLNO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "客户";
            dr["FValue"] = "HL.FName";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "销售组织";
            dr["FValue"] = "CL3.FName";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "物料编码";
            dr["FValue"] = "D.FNumber";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "物料名称";
            dr["FValue"] = "DL.FName";
            dt.Rows.Add(dr);

            cbxCondition.DataSource = dt;
            cbxCondition.DisplayMember = "FName";
            cbxCondition.ValueMember = "FValue";
            cbxCondition.SelectedIndex = 1;

            //cbxLogic
            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            dr = dt.NewRow();
            dr["FName"] = "";
            dr["FValue"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "等于";
            dr["FValue"] = "=";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "不等于";
            dr["FValue"] = "<>";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "包含";
            dr["FValue"] = "LIKE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "不包含";
            dr["FValue"] = "NOT LIKE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "左包含";
            dr["FValue"] = "LIKE";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "右包含";
            dr["FValue"] = "LIKE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "大于";
            dr["FValue"] = ">";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "大于等于";
            dr["FValue"] = ">=";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "小于";
            dr["FValue"] = "<";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "小于等于";
            dr["FValue"] = "<=";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "为空";
            dr["FValue"] = "EMPTY";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "不为空";
            dr["FValue"] = "NOT EMPTY";
            dt.Rows.Add(dr);

            cbxLogic.DataSource = dt;
            cbxLogic.DisplayMember = "FName";
            cbxLogic.ValueMember = "FValue";
            cbxLogic.SelectedIndex = 1;
        }
        #endregion

        /// <summary>
        /// cbxCondition_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCondition.SelectedIndex == 1)
            {
                txtCondition.Visible = false;
                dtpDate.Visible = true;
            }
            else
            {
                txtCondition.Visible = true;
                dtpDate.Visible = false;
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = CommFunction.MTL203(SetFilter());
        }

        /// <summary>
        /// 筛选条件
        /// </summary>
        /// <returns></returns>
        private string SetFilter()
        {
            string strFilter = string.Empty;
            if (cbxCondition.SelectedIndex == 0 || cbxLogic.SelectedIndex == 0) return string.Empty;//不选择筛选条件
            if (cbxCondition.SelectedIndex == 1 || cbxCondition.SelectedIndex == 11)//日期类型
            {
                switch (cbxLogic.SelectedIndex)
                {
                    case 1:
                        strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " = '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                        break;
                    case 2:
                        strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " <> '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                        break;
                    case 7:
                        strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " > '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                        break;
                    case 8:
                        strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " >= '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                        break;
                    case 9:
                        strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " < '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                        break;
                    case 10:
                        strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " <= '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                        break;
                    default:
                        strFilter = "";
                        break;
                }
            }
            else//非日期类型
            {
                if (txtCondition.Text.Trim().Length == 0) return string.Empty;//没输入筛选条件
                switch (cbxLogic.SelectedIndex)
                {
                    case 1:
                        strFilter = cbxCondition.SelectedValue.ToString() + " = '" + txtCondition.Text.Trim() + "'";
                        break;
                    case 2:
                        strFilter = cbxCondition.SelectedValue.ToString() + " <> '" + txtCondition.Text.Trim() + "'";
                        break;
                    case 3:
                        strFilter = cbxCondition.SelectedValue.ToString() + " LIKE '%" + txtCondition.Text.Trim() + "%'";
                        break;
                    case 4:
                        strFilter = cbxCondition.SelectedValue.ToString() + " NOT LIKE '%" + txtCondition.Text.Trim() + "%'";
                        break;
                    case 5:
                        strFilter = cbxCondition.SelectedValue.ToString() + " LIKE '" + txtCondition.Text.Trim() + "%'";
                        break;
                    case 6:
                        strFilter = cbxCondition.SelectedValue.ToString() + " LIKE '%" + txtCondition.Text.Trim() + "'";
                        break;
                    case 11:
                        strFilter = cbxCondition.SelectedValue.ToString() + " IS NULL ";
                        break;
                    case 12:
                        strFilter = cbxCondition.SelectedValue.ToString() + " IS NOT NULL ";
                        break;
                    default:
                        strFilter = "";
                        break;
                }
            }
            return strFilter;
        }

        /// <summary>
        /// 导报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            Export_203();
        }

        #region 导出报表
        /// <summary>
        /// 导出盘子物料报表
        /// </summary>
        private void Export_203()
        {
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            Excel.Workbook xlBook = xlApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = xlBook.Worksheets[1] as Excel.Worksheet;

            //标题
            string strTitle = string.Empty;
            strTitle += DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日 盆子材料报表";

            //生成表头
            (worksheet.Columns["A:A", Type.Missing] as Excel.Range).ColumnWidth = "9";          //部门
            (worksheet.Columns["B:B", Type.Missing] as Excel.Range).ColumnWidth = "12";         //销售订单号
            (worksheet.Columns["C:C", Type.Missing] as Excel.Range).ColumnWidth = "16";         //产品代码
            (worksheet.Columns["D:D", Type.Missing] as Excel.Range).ColumnWidth = "36";         //产品名称
            (worksheet.Columns["E:E", Type.Missing] as Excel.Range).ColumnWidth = "12";         //车型
            (worksheet.Columns["F:F", Type.Missing] as Excel.Range).ColumnWidth = "9";          //颜色
            (worksheet.Columns["G:G", Type.Missing] as Excel.Range).ColumnWidth = "4.5";        //数量
            (worksheet.Columns["H:H", Type.Missing] as Excel.Range).ColumnWidth = "12";         //盆子编码
            (worksheet.Columns["I:I", Type.Missing] as Excel.Range).ColumnWidth = "36";         //盆子名称
            (worksheet.Columns["J:J", Type.Missing] as Excel.Range).ColumnWidth = "12";         //生产顺序号

            (worksheet.Columns["K:K", Type.Missing] as Excel.Range).ColumnWidth = "16";         //计划开工时间

            worksheet.Cells[2, 1] = "部门";
            worksheet.Cells[2, 2] = "销售订单号";
            worksheet.Cells[2, 3] = "产品代码";
            worksheet.Cells[2, 4] = "产品名称";
            worksheet.Cells[2, 5] = "车型";
            worksheet.Cells[2, 6] = "颜色";
            worksheet.Cells[2, 7] = "数量";
            worksheet.Cells[2, 8] = "盆子编码";
            worksheet.Cells[2, 9] = "盆子名称";
            worksheet.Cells[2, 10] = "生产顺序号";

            worksheet.Cells[2, 11] = "计划开工时间";

            //worksheet.Rows.RowHeight = "85.50";
            worksheet.Cells[1, 1] = strTitle;
            Excel.Range rTitle = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 12]];
            rTitle.Merge();
            rTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rTitle.Interior.Color = Color.FromArgb(26, 180, 240);
            rTitle.Font.Bold = true;
            rTitle.Font.Size = 24;
            rTitle.Font.Name = "宋体";

            Excel.Range rCTitle = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 12]];
            rCTitle.Interior.Color = Color.FromArgb(135, 165, 175);

            ((Excel.Range)worksheet.Rows[1, Type.Missing]).RowHeight = "32";
            ((Excel.Range)worksheet.Rows[2, Type.Missing]).RowHeight = "24";
            ((Excel.Range)worksheet.Columns[2, Type.Missing]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            (worksheet.Columns["K:K", Type.Missing] as Excel.Range).NumberFormat = "yyyy-MM-dd";
            (worksheet.Columns["C:C", Type.Missing] as Excel.Range).NumberFormatLocal = "@";
            (worksheet.Columns["H:H", Type.Missing] as Excel.Range).NumberFormatLocal = "@";

            //填充数据
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                try
                {
                    worksheet.Cells[i + 3, 1] = dgv1.Rows[i].Cells[0].Value.ToString();
                    worksheet.Cells[i + 3, 2] = dgv1.Rows[i].Cells[1].Value.ToString();
                    worksheet.Cells[i + 3, 3] = dgv1.Rows[i].Cells[2].Value.ToString();
                    worksheet.Cells[i + 3, 4] = dgv1.Rows[i].Cells[3].Value.ToString();
                    worksheet.Cells[i + 3, 5] = dgv1.Rows[i].Cells[4].Value.ToString();
                    worksheet.Cells[i + 3, 6] = dgv1.Rows[i].Cells[5].Value.ToString();
                    worksheet.Cells[i + 3, 7] = dgv1.Rows[i].Cells[6].Value.ToString();
                    worksheet.Cells[i + 3, 8] = dgv1.Rows[i].Cells[7].Value.ToString();
                    worksheet.Cells[i + 3, 9] = dgv1.Rows[i].Cells[8].Value.ToString();
                    worksheet.Cells[i + 3, 10] = dgv1.Rows[i].Cells[9].Value.ToString();
                    worksheet.Cells[i + 3, 11] = dgv1.Rows[i].Cells[10].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出错误：" + ex.Message);
                }
            }
            xlApp.Visible = true;
        }
        #endregion
    }
}