using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// PDA日志
    /// </summary>
    public partial class ucRC_PDA : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucRC_PDA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucRC_PDA_Load(object sender, EventArgs e)
        {
            FillComboBox();
            dtpFrom.Value = DateTime.Now.AddDays(-7);
            dtpFrom.Value = DateTime.Now;
            chbSucc.Checked = true;
            chbFailed.Checked = true;
        }

        /// <summary>
        /// 下拉框填充
        /// </summary>
        private void FillComboBox()
        {
            cbxType.DataSource = CommFunction.AssistantData();
            cbxType.DisplayMember = "FName";
            cbxType.ValueMember = "FValue";
            cbxType.SelectedIndex = 0;

            cbxOperator.DataSource = CommFunction.ExceptionRecord();
            cbxOperator.DisplayMember = "FName";
            cbxOperator.ValueMember = "FValue";
            cbxType.SelectedIndex = 0;
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = CommFunction.ExceptionRecord(cbxType.SelectedIndex, cbxType.SelectedValue.ToString(), cbxOperator.SelectedIndex, cbxOperator.SelectedValue.ToString(), txtNo.Text.Trim(), txtBarcode.Text.Trim(), txtCompany.Text.Trim(), dtpFrom.Value, dtpTo.Value, chbSucc.Checked, chbFailed.Checked);
            if (dt.Rows.Count > 0)//
            {
                if (cbxType.SelectedIndex == 6 && txtCompany.Text.Trim().Length > 0)//添加快递公司列
                {
                    dt.Columns.Add("快递公司");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["快递公司"] = txtCompany.Text.Trim();
                    }
                }
                dgv1.DataSource = dt;
            }
            else
                dgv1.DataSource = null;
        }

        /// <summary>
        /// 导出Excel报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count <= 0) return;
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            Excel.Workbook xlBook = xlApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = xlBook.Worksheets[1] as Excel.Worksheet;

            //标题
            string strTitle = "PDA日志报表";
            worksheet.Cells[1, 1] = strTitle;
            Excel.Range rTitle = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 8]];
            rTitle.Merge();
            rTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rTitle.Interior.Color = Color.FromArgb(26, 180, 240);
            rTitle.Font.Bold = true;
            rTitle.Font.Size = 24;
            rTitle.Font.Name = "宋体";

            ((Excel.Range)worksheet.Rows[1, Type.Missing]).RowHeight = "32";

            //表头
            worksheet.Cells[2, 1] = "日期";
            worksheet.Cells[2, 2] = "单号";
            worksheet.Cells[2, 3] = "员工";
            worksheet.Cells[2, 4] = "类型";
            worksheet.Cells[2, 5] = "状态";
            worksheet.Cells[2, 6] = "条码";
            worksheet.Cells[2, 7] = "说明";
            worksheet.Cells[2, 8] = "异常信息";

            (worksheet.Columns["A:A", Type.Missing] as Excel.Range).ColumnWidth = "20";     //日期
            (worksheet.Columns["B:B", Type.Missing] as Excel.Range).ColumnWidth = "18";     //单号
            (worksheet.Columns["C:C", Type.Missing] as Excel.Range).ColumnWidth = "9";      //员工
            (worksheet.Columns["D:D", Type.Missing] as Excel.Range).ColumnWidth = "9";      //类型
            (worksheet.Columns["E:E", Type.Missing] as Excel.Range).ColumnWidth = "9";      //状态
            (worksheet.Columns["F:F", Type.Missing] as Excel.Range).ColumnWidth = "48";     //条码
            (worksheet.Columns["G:G", Type.Missing] as Excel.Range).ColumnWidth = "12";     //说明
            (worksheet.Columns["H:H", Type.Missing] as Excel.Range).ColumnWidth = "36";     //异常信息

            Excel.Range rCTitle = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 8]];
            rCTitle.Interior.Color = Color.FromArgb(135, 165, 175);
            rTitle.Font.Bold = true;
            rTitle.Font.Size = 12;

            ((Excel.Range)worksheet.Rows[2, Type.Missing]).RowHeight = "24";
            ((Excel.Range)worksheet.Columns[2, Type.Missing]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            (worksheet.Columns["A:A", Type.Missing] as Excel.Range).NumberFormat = "yyyy-MM-dd HH:mm:ss";
            (worksheet.Columns["B:B", Type.Missing] as Excel.Range).NumberFormatLocal = "@";
            (worksheet.Columns["F:F", Type.Missing] as Excel.Range).NumberFormatLocal = "@";

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出错误：" + ex.Message);
                    xlApp.Quit();
                }
            }
            xlApp.Visible = true;
        }

        /// <summary>
        /// cbxType_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex == 6)
            {
                txtCompany.Focus();
                txtCompany.SelectAll();
                txtCompany.Enabled = true;
            }
            else
            {
                txtCompany.Enabled = false;
            }
        }

        /// <summary>
        /// btnSynchr_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSynchr_Click(object sender, EventArgs e)
        {
            btnSynchr.Visible = false;
        }

        /// <summary>
        /// 同步选择的单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count < 1)
            {
                MessageBox.Show("请先在列表上选择数据");
                return;
            }
            if (dgv1.CurrentRow.Cells[3].Value.ToString() != "入库" && dgv1.CurrentRow.Cells[3].Value.ToString() != "出库")
            {
                MessageBox.Show("请选择入库或出库类型");
                return;
            }

            string strSQL = string.Empty;
            string strBillno = dgv1.CurrentRow.Cells[1].Value.ToString();
            string strBarcodes = dgv1.CurrentRow.Cells[5].Value.ToString();
            if (strBarcodes.Length <= 1) return;
            strBarcodes = "'" + strBarcodes.Replace(",", "','") + "'";

            CommFunction.SynBarcodr(dgv1.CurrentRow.Cells[3].Value.ToString(), strBillno, strBarcodes);
            MessageBox.Show("同步成功!");
        }

        /// <summary>
        /// 同步入库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2_Click(object sender, EventArgs e)
        {
            Bussiness.frmInstockSynchr frmIs = new Bussiness.frmInstockSynchr();
            frmIs.ShowDialog();
        }

        /// <summary>
        /// pl1_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pl1_MouseLeave(object sender, EventArgs e)
        {
            btnSynchr.Visible = true;
        }

        /// <summary>
        /// dgv1_RowStateChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}