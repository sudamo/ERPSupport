using System;
using System.IO;
using System.Text;
using System.Data;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using Oracle.ManagedDataAccess.Client;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 销售订单日志
    /// </summary>
    public partial class ucOrderRecord : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucOrderRecord()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucOrderRecord_Load(object sender, EventArgs e)
        {
            FillComboBox();
            dtpFrom.Value = DateTime.Now.AddDays(-1);
            dtpTO.Value = DateTime.Now;
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            DataTable dt = null;
            DataRow dr = null;

            //Type
            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            dr = dt.NewRow();
            dr["FName"] = "请选择类型";
            dr["FValue"] = "-1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "订单锁库记录";
            dr["FValue"] = "ORDERLOCK";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "订单运算结果";
            dr["FValue"] = "ORDERRUN";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "订单运算汇总";
            dr["FValue"] = "ORDERRUNSUM";
            dt.Rows.Add(dr);

            cbxType.DataSource = dt;
            cbxType.DisplayMember = "FName";
            cbxType.ValueMember = "FValue";
            cbxType.SelectedIndex = 1;

            //Status
            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            dr = dt.NewRow();
            dr["FName"] = "全部";
            dr["FValue"] = "-1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "操作失败";
            dr["FValue"] = "0";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "操作成功";
            dr["FValue"] = "1";
            dt.Rows.Add(dr);

            cbxStatus.DataSource = dt;
            cbxStatus.DisplayMember = "FName";
            cbxStatus.ValueMember = "FValue";
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex == 0)
            {
                MessageBox.Show("请选择类型");
                return;
            }
            dgv1.DataSource = null;
            dgv1.DataSource = CommonFunction.Log_OrderLock(cbxType.SelectedIndex, txtFBillNO.Text.Trim(), txtYSD.Text.Trim(), dtpFrom.Value, dtpTO.Value, cbxStatus.SelectedValue.ToString(), txtMaterialNo.Text);
        }

        /// <summary>
        /// 导出报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发中...");
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



        #region 导出CSV
        /// <summary>
        /// 导出CSV
        /// </summary>
        /// <param name="pDT"></param>
        public void DataTableToCSV(DataTable pDT)
        {
            if (pDT.Rows.Count == 0)
            {
                MessageBox.Show("没有数据信息");
            }

            string strFilePath = "d:\\Temp";
            if (!Directory.Exists(strFilePath))
            {
                Directory.CreateDirectory(strFilePath);
            }

            strFilePath += "\\销售订单运算结果" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".CSV";
            string title = "";

            FileStream fs = new FileStream(strFilePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);

            for (int i = 0; i < pDT.Columns.Count; i++)
            {
                title += pDT.Columns[i].ColumnName + "\t"; //栏位：自动跳到下一单元格
            }

            title = title.Substring(0, title.Length - 1) + "\n";
            sw.Write(title);

            foreach (DataRow row in pDT.Rows)
            {
                string line = "";
                for (int i = 0; i < pDT.Columns.Count; i++)
                {
                    line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格
                }
                line = line.Substring(0, line.Length - 1) + "\n";
                sw.Write(line);
            }

            sw.Close();
            fs.Close();
            MessageBox.Show(@"结果已经保存在d:\Temp\");
        }
        #endregion

        #region Office
        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// <param name="pDT">数据集</param>
        /// <param name="pFilePath">文件保存路径</param>
        /// <param name="pShowExcle">导出后是否打开文件</param>
        /// <returns></returns>
        public static void DataTableToExcel(DataTable pDT, string pFilePath, bool pShowExcle)
        {
            int rowNumber = pDT.Rows.Count;
            int columnNumber = pDT.Columns.Count;
            int colIndex = 0;

            if (rowNumber == 0)
            {
                return;
            }

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
            xlApp.Visible = pShowExcle;
            Excel.Range range;


            foreach (DataColumn col in pDT.Columns)
            {
                colIndex++;
                xlApp.Cells[1, colIndex] = col.ColumnName;
            }

            object[,] objData = new object[rowNumber, columnNumber];

            for (int r = 0; r < rowNumber; r++)
            {
                for (int c = 0; c < columnNumber; c++)
                {
                    objData[r, c] = pDT.Rows[r][c];
                }
            }

            range = worksheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[rowNumber + 1, columnNumber]);

            range.Value2 = objData;

            range.NumberFormatLocal = "@";

            worksheet.SaveAs(pFilePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            return;
        }

        /// <summary>
        /// 读取Excel文件数据到DataTable
        /// </summary>
        /// <param name="pFilePath">Excel文件路径</param>
        private static void Import_Excel(string pFilePath)
        {
            string sqlconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pFilePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";

            string sql = @"select * from [Sheet1$]";

            try
            {
                using (OracleConnection conn = new OracleConnection(sqlconn))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        //LoadDataGridView(dt);
                    }
                }
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("打开文件出错，错误信息：" + ex.Message.ToString(), "提示");
            }
        }

        /// <summary>
        /// 导出文件，使用文件流。该方法使用的数据源为DataTable,导出的Excel文件没有具体的样式。
        /// </summary>
        /// <param name="pDT"></param>
        /// <param name="pFilePath"></param>
        /// <returns></returns>
        public static string ExportToExcel(DataTable pDT, string pFilePath)
        {
            KillSpecialExcel();
            string result = string.Empty;
            try
            {
                // 实例化流对象，以特定的编码向流中写入字符。
                StreamWriter sw = new StreamWriter(pFilePath, false, Encoding.GetEncoding("gb2312"));

                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < pDT.Columns.Count; k++)
                {
                    // 添加列名称
                    sb.Append(pDT.Columns[k].ColumnName.ToString() + "\t");
                }
                sb.Append(Environment.NewLine);
                // 添加行数据
                for (int i = 0; i < pDT.Rows.Count; i++)
                {
                    DataRow row = pDT.Rows[i];
                    for (int j = 0; j < pDT.Columns.Count; j++)
                    {
                        // 根据列数追加行数据
                        sb.Append(row[j].ToString() + "\t");
                    }
                    sb.Append(Environment.NewLine);
                }
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                sw.Dispose();

                // 导出成功后打开
                //System.Diagnostics.Process.Start(path);
            }
            catch (Exception)
            {
                result = "请保存或关闭可能已打开的Excel文件";
            }
            finally
            {
                pDT.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 结束进程
        /// </summary>
        private static void KillSpecialExcel()
        {
            foreach (System.Diagnostics.Process theProc in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            {
                if (!theProc.HasExited)
                {
                    bool b = theProc.CloseMainWindow();
                    if (b == false)
                    {
                        theProc.Kill();
                    }
                    theProc.Close();
                }
            }
        }

        #endregion

        /// <summary>
        /// cbxType_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex == 0)
            {
                cbxStatus.Visible = true;

                lblYSD.Visible = true;
                txtYSD.Visible = true;
            }
            else if(cbxType.SelectedIndex == 1)
            {
                cbxStatus.Visible = true;

                lblYSD.Visible = false;
                txtYSD.Visible = false;
            }
            else
            {
                cbxStatus.Visible = false;

                lblYSD.Visible = true;
                txtYSD.Visible = true;
            }
        }
    }
}
