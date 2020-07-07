using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.Bussiness
{
    using Model.INOrder;
    using DALFacorty.INOrder;

    /// <summary>
    /// 网上订单系统辅助
    /// </summary>
    public partial class frmINOrder : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmINOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmINOrder_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 打开报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择Excel文件";
            fileDialog.Filter = "Excel报表(*.xlsx)|*.xlsx|Excel其他文件(*.xls)|*.xls";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;

                if (filePath.Length <= 0)
                {
                    txtFileDir.Text = string.Empty;
                    btnImport.Enabled = false;
                }
                else
                {
                    txtFileDir.Text = filePath;
                    btnImport.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportExcel(txtFileDir.Text);
        }

        /// <summary>
        /// 导入报表
        /// </summary>
        /// <param name="pFilePath"></param>
        private void ImportExcel(string pFilePath)
        {
            string strError = string.Empty;

            //导入
            object missing = Type.Missing;
            Excel.Application myApp = new Excel.Application();
            myApp.DisplayAlerts = false;
            Excel.Workbook workBook = myApp.Workbooks.Open(pFilePath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Excel.Worksheet worksheet = workBook.Worksheets[1] as Excel.Worksheet;
            myApp.Visible = false;
            string FNumber = string.Empty;

            if(worksheet.Cells[1, 1].Text!="小类"|| worksheet.Cells[1, 2].Text!="品牌" || worksheet.Cells[1, 3].Text != "系列" || worksheet.Cells[1, 4].Text != "商品名" || worksheet.Cells[1, 5].Text != "定价要素" || worksheet.Cells[1, 6].Text != "生效日期" || worksheet.Cells[1, 7].Text != "失效日期" || worksheet.Cells[1, 8].Text != "是否禁用" || worksheet.Cells[1, 9].Text != "省代价" || worksheet.Cells[1, 10].Text != "市代价")
            {
                MessageBox.Show("请使用标准模板导入价格！并按以下顺序导入数据[小类-品牌-系列-商品名-定价要素-生效日期-失效日期-是否禁用-省代价-市代价]");
                goto Show;
            }

            OrderImportInfo entry;
            
            for (int i = 2; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                entry = new OrderImportInfo();
                try
                {
                    entry.BasicDataID = worksheet.Cells[i, 1].Text;
                    entry.BrandID = worksheet.Cells[i, 2].Text;
                    entry.SeriesID = worksheet.Cells[i, 3].Text;
                    entry.CommodityID = worksheet.Cells[i, 4].Text;
                    entry.PricingFactorID = worksheet.Cells[i, 5].Text;
                    entry.TimeBegin = DateTime.Parse(worksheet.Cells[i, 6].Text);
                    entry.TimeEnd = DateTime.Parse(worksheet.Cells[i, 7].Text);
                    entry.IsEnable = true;
                    entry.GeneralFactoryPrice = float.Parse(worksheet.Cells[i, 9].Text);
                    entry.BranchFactoryPrice = float.Parse(worksheet.Cells[i, 10].Text);

                    DALCreater.CommFunction.MegerPrice(entry);
                }
                catch (Exception ex)
                {
                    worksheet.Cells[i, 12] = ex.Message;
                    strError += i.ToString() + ex.Message;
                   
                    continue;
                }
                worksheet.Cells[i, 12] = "导入成功";
            }
            if (strError != "")
            {
                MessageBox.Show("有些信息导入出错，请查看最后一列的错误提示！");
            }
            else
            {
                MessageBox.Show("全部数据已经成功导入！");
            }

            Show:
            myApp.Visible = true;

            btnImport.Enabled = false;

            //日志............
            SQL.K3Cloud.CommFunction.DM_Log_Local("价格导入", "项目->网上订单系统->导入新价格", pFilePath);
        }
    }
}
