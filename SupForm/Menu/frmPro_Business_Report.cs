using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.Menu
{
    using Model.Globa;
    using Model.K3Cloud;
    using DALFactory.K3Cloud;
    using Newtonsoft.Json.Linq;
    using Kingdee.BOS.WebApi.Client;

    /// <summary>
    /// 电商报表管理
    /// </summary>
    public partial class frmPro_Business_Report : Form
    {
        /// <summary>
        /// 
        /// </summary>
        bool _fileSelect;
        /// <summary>
        /// 
        /// </summary>
        string _filePath;
        /// <summary>
        /// 
        /// </summary>
        string _BillNos;
        /// <summary>
        /// 
        /// </summary>
        string _Eorros;

        /// <summary>
        /// 
        /// </summary>
        public frmPro_Business_Report()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPro_Business_Report_Load(object sender, EventArgs e)
        {
            _fileSelect = false;
            _filePath = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDLTemplate_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择Excel文件";
            fileDialog.Filter = "Excel报表(*.xlsx)|*.xlsx|Excel其他文件(*.xls)|*.xls";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = fileDialog.FileName;

                if (_filePath.Length <= 0)
                {
                    txtPath.Text = string.Empty;
                    _fileSelect = false;
                    btnImport.Enabled = false;
                }
                else
                {
                    txtPath.Text = _filePath;
                    _fileSelect = true;
                    btnImport.Enabled = true;
                }
            }
            else
            {
                _filePath = string.Empty;
                txtPath.Text = string.Empty;
                _fileSelect = false;
                btnImport.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!_fileSelect)
                return;

            //导入
            object missing = Type.Missing;
            Excel.Application myApp = new Excel.Application();
            myApp.DisplayAlerts = false;
            Excel.Workbook workBook = myApp.Workbooks.Open(_filePath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Excel.Worksheet worksheet = workBook.Worksheets[1] as Excel.Worksheet;
            myApp.Visible = false;

            _BillNos = string.Empty;
            _Eorros = string.Empty;

            if (worksheet.Cells[1, 1].Text != "电商销售订单导入模版")
            {
                MessageBox.Show("请使用[电商销售订单导入模版]格式的Excel文件导入！");
                return;
            }

            OrderInfo entry;
            List<OrderInfo> list = new List<OrderInfo>();

            for (int i = 3; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                entry = new OrderInfo();
                try
                {
                    entry.F_CUSTOMERORDERNUMBE = worksheet.Cells[i, 1].Text;

                    if (entry.F_CUSTOMERORDERNUMBE == null || entry.F_CUSTOMERORDERNUMBE == "")
                        break;

                    entry.FCUSTName = worksheet.Cells[i, 2].Text;
                    entry.FHEADDELIVERYWAY = worksheet.Cells[i, 3].Text;
                    entry.FDELIVERYMETHOD = worksheet.Cells[i, 4].Text;
                    entry.F_PAEZ_CONTACTS = worksheet.Cells[i, 5].Text;
                    entry.F_PAEZ_CONTACTNUMBER = worksheet.Cells[i, 6].Text;
                    entry.F_PAEZ_HEADLOCADDRESS = worksheet.Cells[i, 7].Text;
                    entry.FMaterialCode = worksheet.Cells[i, 8].Text;
                    entry.FPRICE = double.Parse(worksheet.Cells[i, 9].Text);
                    entry.FQTY = double.Parse(worksheet.Cells[i, 10].Text);
                    entry.FEntryNOTE = worksheet.Cells[i, 11].Text;

                    entry.StrError = string.Empty;

                    list.Add(entry);
                }
                catch (Exception ex)
                {
                    worksheet.Cells[i, 13] = ex.Message;
                    _Eorros += i.ToString() + ex.Message;

                    continue;
                }
            }

            if (list.Count == 0)
            {
                MessageBox.Show("没有导入数据。");
                QuitExcel(myApp);
                return;
            }

            string strMess = ImportOrderToK3(list);

            //修复业务类型
            //DALCreator.CommFunction.SqlOperation(0, ConstStrings._K3_Sal_1);

            if (_Eorros != "")
                _Eorros = "有些信息导入出错，请查看提示。";
            else
                _Eorros = "全部数据已经成功导入。";

            MessageBox.Show(_Eorros + "\r\n" + strMess);

            myApp.Visible = true;

            btnImport.Enabled = false;

            //日志............
            DALFactory.K3Cloud.DALCreator.CommFunction.DM_Log_Local("电商销售订单导入", "项目->电商->报表管理", _BillNos + _Eorros);
        }

        private string ImportOrderToK3(List<OrderInfo> pList)
        {
            string strReturl;
            List<OrderInfo> list;

            //不同的客户单号分单生成
            do
            {
                list = new List<OrderInfo>();
                list.Add(pList[0]);
                pList.RemoveAt(0);

                if (pList.Count > 0)
                {
                    //相同的客户单号合单生成
                    foreach (OrderInfo entity in pList)
                    {
                        if (entity.F_CUSTOMERORDERNUMBE == list[0].F_CUSTOMERORDERNUMBE)
                            list.Add(entity);
                    }

                    foreach (OrderInfo entity in list)
                        pList.Remove(entity);
                }

                strReturl = WebApiForSalOrder(list);

                if (strReturl.Contains("ID:"))
                    _BillNos += "[" + strReturl.Substring(strReturl.IndexOf("Number:") + 7) + "]";//
                else
                    _Eorros += strReturl;
            }
            while (pList.Count > 0);

            return strReturl;
        }

        private string WebApiForSalOrder(List<OrderInfo> pList)
        {
            bool bTitle = false;
            foreach (OrderInfo entity in pList)
            {
                try
                {
                    if (!bTitle)
                    {
                        entity.FCUSTCode = DALCreator.CommFunction.GetCustomerCode(entity.FCUSTName, 477965);
                        entity.FHEADDELIVERYWAYCode = DALCreator.CommFunction.GetAssistantDataCode(entity.FHEADDELIVERYWAY, "801e1892b8824299936cb07c1fd1694d");

                        if (entity.FDELIVERYMETHOD == null || entity.FDELIVERYMETHOD == string.Empty)
                            entity.FDELIVERYMETHODCode = string.Empty;
                        else
                            entity.FDELIVERYMETHODCode = DALCreator.CommFunction.GetAssistantDataCode(entity.FDELIVERYMETHOD, "58709d3c96a15e");//58709cf996a15c

                        bTitle = true;
                    }
                    entity.FUnitNumber = DALCreator.CommFunction.GetUnitCodeByMTLCode(entity.FMaterialCode);
                }
                catch (Exception ex)
                {
                    _Eorros += ex.Message;
                    entity.StrError = ex.Message;
                }
            }

            string strMess = string.Empty;
            try
            {
                K3CloudApiClient client = new K3CloudApiClient(GlobalParameter.K3Inf.C_ERPADDRESS);
                bool login = client.Login(GlobalParameter.K3Inf.C_ZTID, GlobalParameter.K3Inf.C_USERNAME, GlobalParameter.K3Inf.C_PASSWORD, 2052);
                if (login)
                {
                    JObject jsonRoot = new JObject();
                    jsonRoot.Add("Creator", "WebApi");
                    jsonRoot.Add("NeedUpDateFields", new JArray(""));
                    jsonRoot.Add("NeedReturnFields", new JArray(""));

                    jsonRoot.Add("IsDeleteEntry", "true");
                    jsonRoot.Add("SubSystemId", "");
                    jsonRoot.Add("IsVerifyBaseDataField", "false");

                    // Model: 单据详细数据参数
                    JObject model = new JObject();
                    jsonRoot.Add("Model", model);

                    // 
                    model.Add("FID", 0);
                    // 单据类型
                    JObject basedata = new JObject();
                    basedata.Add("FNumber", "XSDD01_SYS");
                    model.Add("FBillTypeID", basedata);
                    // 日期
                    model.Add("FBillNo", "");
                    model.Add("FDate", DateTime.Today);
                    model.Add("FBusinessType", "NORMAL");
                    //组织
                    basedata = new JObject();
                    basedata.Add("FNumber", "GZ04");
                    model.Add("FSaleOrgId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pList[0].FCUSTCode);
                    model.Add("FCustId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pList[0].FHEADDELIVERYWAYCode);
                    model.Add("FHeadDeliveryWay", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pList[0].FHEADDELIVERYWAYCode);
                    model.Add("FReceiveId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", "");
                    model.Add("FHEADLOCID", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", "");
                    model.Add("FCorrespondOrgId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", "BM000051");
                    model.Add("FSaleDeptId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", "");
                    model.Add("FSaleGroupId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", "GZDSB046");
                    model.Add("FSalerId", basedata);

                    model.Add("FReceiveAddress", "");
                    basedata = new JObject();
                    basedata.Add("FNumber", pList[0].FHEADDELIVERYWAYCode);
                    model.Add("FSettleId", basedata);
                    basedata = new JObject();
                    basedata.Add("FName", "");
                    model.Add("FReceiveContact", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pList[0].FHEADDELIVERYWAYCode);
                    model.Add("FChargeId", basedata);

                    model.Add("FNetOrderBillNo", "");
                    model.Add("FNetOrderBillId", 0);
                    model.Add("FOppID", 0);
                    basedata = new JObject();
                    basedata.Add("FNumber", "");
                    model.Add("FSalePhaseID", basedata);
                    model.Add("FISINIT", false);
                    //摘要
                    model.Add("FNote", "");
                    basedata = new JObject();
                    basedata.Add("FNumber", "HN02");
                    model.Add("F_PAEZ_FactOrgID", basedata);
                    model.Add("FIsMobile", false);
                    model.Add("FSalePath", "1");

                    //发货方式
                    basedata = new JObject();
                    basedata.Add("FNumber", pList[0].FDELIVERYMETHODCode);
                    model.Add("FDeliveryMethod", basedata);
                    //basedata = new JObject();
                    //basedata.Add("FNumber", pList[0].F_PAEZ_LOGISTCSCOMPANYCode);
                    //model.Add("F_PAEZ_LogistcsCompany", basedata);
                    model.Add("F_PAEZ_HeadlocAddress", pList[0].F_PAEZ_HEADLOCADDRESS);
                    model.Add("F_PAEZ_Salesplan", "");
                    model.Add("F_PAEZ_Packinstruction", "");
                    model.Add("F_PAEZ_Amountpacking", 0.0);
                    model.Add("F_PAEZ_Singleshipment", true);
                    //联系人、联系电话、对应客户单号
                    model.Add("F_PAEZ_Contactnumber", pList[0].F_PAEZ_CONTACTNUMBER);
                    model.Add("F_PAEZ_Contacts", pList[0].F_PAEZ_CONTACTS);
                    model.Add("F_CustomeRorderNumber", pList[0].F_CUSTOMERORDERNUMBE);

                    //FPOOrderFinance
                    JObject SaleOrderFinance = new JObject();
                    model.Add("FSaleOrderFinance", SaleOrderFinance);
                    
                    basedata = new JObject();
                    basedata.Add("FNumber", "PRE001");
                    SaleOrderFinance.Add("FSettleCurrId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", "");
                    SaleOrderFinance.Add("FRecConditionId", basedata);

                    SaleOrderFinance.Add("FIsPriceExcludeTax", true);
                    basedata = new JObject();
                    basedata.Add("FNumber", "");
                    SaleOrderFinance.Add("FSettleModeId", basedata);
                    SaleOrderFinance.Add("FIsIncludedTax", false);
                    basedata = new JObject();
                    basedata.Add("FNumber", "");
                    SaleOrderFinance.Add("FPriceListId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", "");
                    SaleOrderFinance.Add("FDiscountListId", basedata);

                    SaleOrderFinance.Add("FBillTaxAmount", 0.0);
                    SaleOrderFinance.Add("FBillAmount", 0.0);
                    SaleOrderFinance.Add("FBillAllAmount", 0.0);
                    
                    basedata = new JObject();
                    basedata.Add("FNumber", "HLTX01_SYS");
                    SaleOrderFinance.Add("FExchangeTypeId", basedata);

                    SaleOrderFinance.Add("FExchangeRate", 1.0);
                    SaleOrderFinance.Add("FCreChkOverAmount", 0.0);

                    // 开始构建单据体参数：集合参数JArray
                    JArray entryRows = new JArray();
                    // 把单据体行集合，添加到model中，以单据体Key为标识
                    string entityKey = "FSaleOrderEntry";
                    model.Add(entityKey, entryRows);

                    // 通过循环创建单据体行：示例代码仅创建一行
                    for (int i = 0; i < pList.Count; i++)
                    {
                        // 添加新行，把新行加入到单据体行集合
                        JObject entryRow = new JObject();
                        entryRows.Add(entryRow);

                        // 单据体主键：必须填写，系统据此判断是新增还是修改行
                        entryRow.Add("FEntryID", 0);
                        entryRow.Add("FReturnType", "");

                        basedata = new JObject();
                        basedata.Add("FNumber", "");
                        entryRow.Add("F_PAEZ_Customizeseries", basedata);
                        basedata = new JObject();
                        basedata.Add("FNumber", "");
                        entryRow.Add("F_PAEZ_Customizetype", basedata);
                        basedata = new JObject();
                        basedata.Add("FNumber", "1");
                        entryRow.Add("F_IsStandard", basedata);
                        
                        basedata = new JObject();
                        basedata.Add("FNumber", pList[i].FMaterialCode);
                        entryRow.Add("FMaterialId", basedata);

                        entryRow.Add("FQty", pList[i].FQTY);
                        entryRow.Add("FPrice", pList[i].FPRICE);
                        entryRow.Add("FIsFree", false);
                        entryRow.Add("FEntryNote", pList[i].FEntryNOTE);

                        basedata = new JObject();
                        basedata.Add("FNumber", pList[i].FUnitNumber);
                        entryRow.Add("FUnitID", basedata);

                        entryRow.Add("FDeliveryDate", DateTime.Today);

                        basedata = new JObject();
                        basedata.Add("FNumber", "HN02");
                        entryRow.Add("FStockOrgId", basedata);
                        basedata = new JObject();
                        basedata.Add("FNumber", "GZ04");
                        entryRow.Add("FSettleOrgIds", basedata);
                        basedata = new JObject();
                        basedata.Add("FNumber", "HN02");
                        entryRow.Add("FSupplyOrgId", basedata);

                        entryRow.Add("FOwnerTypeId", "BD_OwnerOrg");
                        basedata = new JObject();
                        basedata.Add("FNumber", "HN02");
                        entryRow.Add("FOwnerId", basedata);
                        entryRow.Add("FReserveType", "1");

                        entryRow.Add("FPriceBaseQty", pList[i].FQTY);
                        entryRow.Add("FStockQty", pList[i].FQTY);
                        entryRow.Add("FStockBaseQty", pList[i].FQTY);
                        basedata = new JObject();
                        basedata.Add("FNumber", pList[i].FUnitNumber);
                        entryRow.Add("FStockUnitID", basedata);

                        entryRow.Add("FOUTLMTUNIT", "SAL");
                        basedata = new JObject();
                        basedata.Add("FNumber", pList[i].FUnitNumber);
                        entryRow.Add("FOutLmtUnitID", basedata);

                        entryRow.Add("FBatchFlag", "0");
                        entryRow.Add("F_PAEZ_Dotd", false);
                        entryRow.Add("F_PAEZ_RunTime", 0);

                        basedata = new JObject();
                        basedata.Add("FNumber", "");
                        entryRow.Add("F_ProductDepartment", basedata);

                        entryRow.Add("F_PAEZ_Saledate", DateTime.Today);

                        //FOrderEntryPlan
                        JArray planRows = new JArray();                        
                        string planKey = "FOrderEntryPlan";
                        entryRow.Add(planKey, planRows);
                        JObject planRow = new JObject();
                        planRows.Add(planRow);

                        planRow.Add("FPlanDate", DateTime.Today);
                        planRow.Add("FPlanQty", pList[i].FQTY);
                    }

                    // 调用Web API接口服务，保存单据
                    strMess = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "SAL_SaleOrder", jsonRoot.ToString() });
                    JObject jo = JObject.Parse(strMess);

                    if (!jo["Result"]["ResponseStatus"]["IsSuccess"].Value<bool>())
                    {
                        strMess = string.Empty;
                        for (int i = 0; i < ((IList)jo["Result"]["ResponseStatus"]["Errors"]).Count; i++)
                            strMess += jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>() + "\r\n";//保存不成功返错误信息
                    }
                    else
                    {
                        strMess = "ID:" + jo["Result"]["Id"].Value<string>() + ";Number:" + jo["Result"]["Number"].Value<string>();//保存成功返回入库单FID和单据编号FBILLNO

                        //client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Submit", new object[] { "SAL_SaleOrder", "{\"CreateOrgId\":\"0\",\"Numbers\":[\"" + jo["Result"]["Number"].Value<string>() + "\"]}" });//根据单号提交单据
                        //client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Audit", new object[] { "SAL_SaleOrder", "{\"CreateOrgId\":\"0\",\"Numbers\":[\"" + jo["Result"]["Number"].Value<string>() + "\"]}" });//根据单号审核单据

                        //反写数量
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return strMess;
        }

        #region 关闭Excel进程
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowsThreadProcessId(IntPtr pPtr, out int pID);
        public void QuitExcel(Microsoft.Office.Interop.Excel.Application pApp)
        {
            IntPtr ptr = new IntPtr(pApp.Hwnd);//获取句柄
            int id = 0;
            GetWindowsThreadProcessId(ptr, out id);//获取进程ID
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(id);
            p.Kill();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPath_MouseEnter(object sender, EventArgs e)
        {
            txtPath.BackColor = Color.Azure;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPath_MouseLeave(object sender, EventArgs e)
        {
            txtPath.BackColor = BackColor;
        }
    }
}
