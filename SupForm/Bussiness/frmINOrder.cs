using System;
using System.Data;
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
        private DataRow _dataRow;

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
            FillComboBox();
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

                    DALCreator.CommFunction.MegerPrice(entry);
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
            DALFactory.K3Cloud.DALCreator.CommFunction.DM_Log_Local("价格导入", "项目->网上订单系统->导入新价格", pFilePath);
        }

        /// <summary>
        /// 查询客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim().Equals(string.Empty))
                return;

            DataTable dt = DALFactory.K3Cloud.DALCreator.CommFunction.GetCustomerListByName(txtCustomerName.Text);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("未在金蝶ERP查询到客户，请检查是否输入完整客户名称！");
                btnAddCustomer.Enabled = false;
                cbxCreateOrg.Enabled = false;
                cbxSeller.Enabled = false;
                return;
            }

            //DataTable dtSource = new DataTable();
            //DataRow drN;
            //dtSource.Columns.Add("FValue");
            //dtSource.Columns.Add("FName");

            //DataColumn[] dtCS = new DataColumn[1];
            //dtCS[0] = dtSource.Columns[0];
            //dtSource.PrimaryKey = dtCS;

            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (dtSource.Rows.Contains(dr["FCREATEORGID"]))
            //        continue;

            //    drN = dtSource.NewRow();
            //    drN["FValue"] = dr["FCREATEORGID"];
            //    drN["FName"] = dr["ORGNAME"];
            //    dtSource.Rows.Add(drN);
            //}

            DataView dv = dt.DefaultView;
            DataTable dtSource = dv.ToTable("dtOrg", true, "FCREATEORGID", "ORGNAME");

            FillComboBox(cbxCreateOrg, dtSource, "FCREATEORGID", "ORGNAME");

            btnAddCustomer.Enabled = true;
            cbxCreateOrg.Enabled = true;
            cbxSeller.Enabled = true;

            _dataRow = dt.Rows[0];
        }

        /// <summary>
        /// 新增客户到网上订单系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string creatorOrg = cbxCreateOrg.SelectedValue.ToString();
                string sellerId = cbxSeller.Items.Count == 0 ? "0" : cbxSeller.SelectedValue.ToString();
                MessageBox.Show(DALCreator.CommFunction.AddCustomer(_dataRow, creatorOrg, sellerId));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //日志
            DALFactory.K3Cloud.DALCreator.CommFunction.DM_Log_Local("新增客户", "项目->网上订单系统->新增客户", "新增客户：" + _dataRow["FNAME"].ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddADD_Click(object sender, EventArgs e)
        {
            int iParentId, iLevel;
            string sFirstChar;
            if (txtDistrict.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入行政区信息，如果没有市级信息，可以留空。");
                return;
            }
            try
            {
                if (cbxCity != null && cbxCity.Items.Count > 0)
                {
                    iParentId = int.Parse(cbxCity.SelectedValue.ToString());
                    iLevel = 2;
                    sFirstChar = txtDistrict.Text.Substring(0, 1);
                }
                else
                {
                    iParentId = int.Parse(cbxProvince.SelectedValue.ToString());
                    iLevel = 1;
                    sFirstChar = txtDistrict.Text.Substring(0, 1);
                }

                MessageBox.Show(DALCreator.CommFunction.AddADD(iParentId, iLevel, sFirstChar, txtDistrict.Text));
                //日志
                DALFactory.K3Cloud.DALCreator.CommFunction.DM_Log_Local("新增地区", "项目->网上订单系统->新增地区", "新增地区信息");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCreateOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCreateOrg == null || cbxCreateOrg.Items.Count == 0)
                return;

            int iOrgId;
            try
            {
                iOrgId = int.Parse(cbxCreateOrg.SelectedValue.ToString());
            }
            catch
            {
                return;
            }

            DataTable dt = DALFactory.K3Cloud.DALCreator.CommFunction.GetSellerList(iOrgId, 1);
            FillComboBox(cbxSeller, dt, "FVALUE", "FNAME", 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProvince == null || cbxProvince.Items.Count == 0)
                return;

            int iParentId;
            try
            {
                iParentId = int.Parse(cbxProvince.SelectedValue.ToString());
            }
            catch
            {
                return;
            }

            DataTable dt = DALCreator.CommFunction.GetChinaAddByParentId(iParentId);
            DataRow dr = dt.NewRow();
            dr["ID"] = 0;
            dr["Name"] = "-请选择-";
            dt.Rows.Add(dr);
            int iSelectIndex = dt.Rows.Count;

            FillComboBox(cbxCity, dt, "ID", "Name", iSelectIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillComboBox()
        {
            DataTable dt = DALCreator.CommFunction.GetChinaAddByParentId();
            if (dt == null || dt.Rows.Count == 0)
                return;
            FillComboBox(cbxProvince, dt, "ID", "Name");
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        /// <param name="pComboBox">下拉框控件</param>
        /// <param name="pDT">数据源</param>
        /// <param name="pFValue">ValueMember</param>
        /// <param name="pFName">DisplayMember</param>
        /// <param name="pSelectedIndex">SelectedIndex</param>
        private void FillComboBox(ComboBox pComboBox, DataTable pDT, string pFValue, string pFName, int pSelectedIndex = 0)
        {
            if (pDT == null || pDT.Rows.Count == 0)
            {
                if (pComboBox != null && pComboBox.Items.Count > 0)
                    pComboBox.Items.Clear();

                return;
            }
            try
            {
                pComboBox.DataSource = pDT;
                pComboBox.ValueMember = pFValue;
                pComboBox.DisplayMember = pFName;
                pComboBox.SelectedIndex = pSelectedIndex;
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_Price_Click(object sender, EventArgs e)
        {
            frmOrderPriceSyn frmP = new frmOrderPriceSyn();
            frmP.Show(this);
        }
    }
}
