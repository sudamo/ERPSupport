using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using System.Drawing;

namespace ERPSupport.SupForm.Bussiness
{
    /// <summary>
    /// 运算汇总
    /// </summary>
    public partial class frmOrderSummary : Form
    {
        #region Fields Properties Variable & Constructor

        private List<int> _FEntryIds;
        /// <summary>
        /// 订单分录ID
        /// </summary>
        public List<int> FEntryIds
        {
            get { return _FEntryIds; }
            set { _FEntryIds = value; }
        }
        ///// <summary>
        ///// 开始时间
        ///// </summary>
        //private DateTime starTime;
        ///// <summary>
        ///// 结束时间
        ///// </summary>
        //private DateTime EndTime;
        ///// <summary>
        ///// 指定的时间段内总天数
        ///// </summary>
        //private int SumDays;
        ///// <summary>
        ///// 指定的时间段内，除去周日的天数。
        ///// </summary>
        //private int iDays;
        /// <summary>
        /// 领料单编号
        /// </summary>
        //private string strPOBillNO;
        ///// <summary>
        ///// 生产订单编号
        ///// </summary>
        //private string strMoBillNO;

        /// <summary>
        /// 半成品明细信息
        /// </summary>
        private DataTable _dtDtl;

        /// <summary>
        /// 汇总信息
        /// </summary>
        private DataTable _dtSum;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pDT">销售订单分录信息</param>
        /// <param name="pFEntryId">销售订单分录内码</param>
        public frmOrderSummary(DataTable pDT, List<int> pFEntryId)
        {
            InitializeComponent();
            _dtDtl = pDT;
            _FEntryIds = pFEntryId;
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOrderSummary_Load(object sender, EventArgs e)
        {
            FillDepartment();
            SetDataSource(false, FEntryIds);
            dtpPlanStar.Value = DateTime.Now.AddDays(1);
            dtpPlanEnd.Value = DateTime.Now.AddDays(8);
        }

        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="pIsLack">是否缺料</param>
        /// /// <param name="pFEntryId"></param>
        private void SetDataSource(bool pIsLack, List<int> pFEntryId)
        {
            if (_dtDtl == null || _dtDtl.Rows.Count == 0) return;
            bool bMatch = false;
            string strNow = DateTime.Now.ToString("yyyy-MM-dd");
            _dtSum = new DataTable();
            DataRow dr;
            _dtSum.Columns.Add("日期");
            _dtSum.Columns.Add("物料编码");
            _dtSum.Columns.Add("物料名称");
            _dtSum.Columns.Add("物料属性");
            _dtSum.Columns.Add("单位");

            _dtSum.Columns.Add("BOM");
            _dtSum.Columns.Add("采购在途");
            _dtSum.Columns.Add("生产自制");
            _dtSum.Columns.Add("库存数量");
            _dtSum.Columns.Add("库存可用数量");

            _dtSum.Columns.Add("库存可用天数");
            _dtSum.Columns.Add("最低订货量");
            _dtSum.Columns.Add("最小批量");
            _dtSum.Columns.Add("安全库存");
            _dtSum.Columns.Add("欠料数量");

            _dtSum.Columns.Add("需求汇总");

            for (int i = 0; i < _dtDtl.Rows.Count; i++)
            {
                dr = _dtSum.NewRow();

                if (i == 0)
                {
                    dr["日期"] = strNow;
                    dr["物料编码"] = _dtDtl.Rows[i]["物料编码"].ToString();
                    dr["物料名称"] = _dtDtl.Rows[i]["物料名称"].ToString();
                    dr["物料属性"] = _dtDtl.Rows[i]["物料属性"].ToString();
                    dr["单位"] = _dtDtl.Rows[i]["单位"].ToString();

                    dr["BOM"] = _dtDtl.Rows[i]["BOM"].ToString();
                    dr["采购在途"] = _dtDtl.Rows[i]["采购在途"].ToString();
                    dr["生产自制"] = _dtDtl.Rows[i]["生产自制"].ToString();
                    dr["库存数量"] = _dtDtl.Rows[i]["库存数量"].ToString();
                    dr["库存可用数量"] = _dtDtl.Rows[i]["库存可用数量"].ToString();

                    dr["库存可用天数"] = string.Format("{0:N2}", decimal.Parse(_dtDtl.Rows[i]["库存可用天数"].ToString()));
                    dr["最低订货量"] = _dtDtl.Rows[i]["最低订货量"].ToString();
                    dr["最小批量"] = _dtDtl.Rows[i]["最小批量"].ToString();
                    dr["安全库存"] = _dtDtl.Rows[i]["安全库存"].ToString();
                    dr["欠料数量"] = _dtDtl.Rows[i]["欠料数量"].ToString();

                    dr["需求汇总"] = double.Parse(dr["欠料数量"].ToString()) <= 0 ? 0 : (dr["物料属性"].ToString() == "自制" ? double.Parse(dr["安全库存"].ToString()) : (double.Parse(dr["安全库存"].ToString()) <= double.Parse(dr["最低订货量"].ToString()) ? double.Parse(dr["最低订货量"].ToString()) : (double.Parse(dr["最小批量"].ToString()) <= 0 ? 0 : (double.Parse(dr["安全库存"].ToString()) % double.Parse(dr["最小批量"].ToString()) == 0 ? double.Parse(dr["安全库存"].ToString()) : double.Parse(dr["安全库存"].ToString()) / double.Parse(dr["最小批量"].ToString()) * (double.Parse(dr["最小批量"].ToString()) + 1)))));

                    _dtSum.Rows.Add(dr);
                }
                else
                {
                    for (int j = 0; j < _dtSum.Rows.Count; j++)
                    {
                        bMatch = false;
                        if (_dtSum.Rows[j]["物料编码"].ToString() == _dtDtl.Rows[i]["物料编码"].ToString())
                        {
                            _dtSum.Rows[j]["库存可用数量"] = double.Parse(_dtSum.Rows[j]["库存可用数量"].ToString()) > double.Parse(_dtDtl.Rows[i]["库存可用数量"].ToString()) ? double.Parse(_dtDtl.Rows[i]["库存可用数量"].ToString()) : double.Parse(_dtSum.Rows[j]["库存可用数量"].ToString());
                            _dtSum.Rows[j]["欠料数量"] = double.Parse(_dtSum.Rows[j]["欠料数量"].ToString()) > double.Parse(_dtDtl.Rows[i]["欠料数量"].ToString()) ? double.Parse(_dtSum.Rows[j]["欠料数量"].ToString()) : double.Parse(_dtDtl.Rows[i]["欠料数量"].ToString());

                            _dtSum.Rows[j]["需求汇总"] = double.Parse(_dtSum.Rows[j]["欠料数量"].ToString()) <= 0 ? 0 : (_dtSum.Rows[j]["物料属性"].ToString() == "自制" ? double.Parse(_dtSum.Rows[j]["安全库存"].ToString()) : (double.Parse(_dtSum.Rows[j]["安全库存"].ToString()) <= double.Parse(_dtSum.Rows[j]["最低订货量"].ToString()) ? double.Parse(_dtSum.Rows[j]["最低订货量"].ToString()) : (double.Parse(_dtSum.Rows[j]["最小批量"].ToString()) <= 0 ? 0 : (double.Parse(_dtSum.Rows[j]["安全库存"].ToString()) % double.Parse(_dtSum.Rows[j]["最小批量"].ToString()) == 0 ? double.Parse(_dtSum.Rows[j]["安全库存"].ToString()) : double.Parse(_dtSum.Rows[j]["安全库存"].ToString()) / double.Parse(_dtSum.Rows[j]["最小批量"].ToString()) * (double.Parse(_dtSum.Rows[j]["最小批量"].ToString()) + 1)))));

                            bMatch = true;
                            break;
                        }
                    }
                    if (!bMatch)
                    {
                        dr["日期"] = strNow;
                        dr["物料编码"] = _dtDtl.Rows[i]["物料编码"].ToString();
                        dr["物料名称"] = _dtDtl.Rows[i]["物料名称"].ToString();
                        dr["物料属性"] = _dtDtl.Rows[i]["物料属性"].ToString();
                        dr["单位"] = _dtDtl.Rows[i]["单位"].ToString();

                        dr["BOM"] = _dtDtl.Rows[i]["BOM"].ToString();
                        dr["采购在途"] = _dtDtl.Rows[i]["采购在途"].ToString();
                        dr["生产自制"] = _dtDtl.Rows[i]["生产自制"].ToString();
                        dr["库存数量"] = _dtDtl.Rows[i]["库存数量"].ToString();
                        dr["库存可用数量"] = _dtDtl.Rows[i]["库存可用数量"].ToString();

                        dr["库存可用天数"] = string.Format("{0:N2}", decimal.Parse(_dtDtl.Rows[i]["库存可用天数"].ToString())); 
                        dr["最低订货量"] = _dtDtl.Rows[i]["最低订货量"].ToString();
                        dr["最小批量"] = _dtDtl.Rows[i]["最小批量"].ToString();
                        dr["安全库存"] = _dtDtl.Rows[i]["安全库存"].ToString();
                        dr["欠料数量"] = _dtDtl.Rows[i]["欠料数量"].ToString();

                        dr["需求汇总"] = double.Parse(dr["欠料数量"].ToString()) <= 0 ? 0 : (dr["物料属性"].ToString() == "自制" ? double.Parse(dr["安全库存"].ToString()) : (double.Parse(dr["安全库存"].ToString()) <= double.Parse(dr["最低订货量"].ToString()) ? double.Parse(dr["最低订货量"].ToString()) : (double.Parse(dr["最小批量"].ToString()) <= 0 ? 0 : (double.Parse(dr["安全库存"].ToString()) % double.Parse(dr["最小批量"].ToString()) == 0 ? double.Parse(dr["安全库存"].ToString()) : double.Parse(dr["安全库存"].ToString()) / double.Parse(dr["最小批量"].ToString()) * (double.Parse(dr["最小批量"].ToString()) + 1)))));

                        _dtSum.Rows.Add(dr);
                    }
                }
            }

            dgv1.DataSource = _dtSum;
        }

        #region 勾选
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbHand_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            foreach (DataGridViewRow dr in dgv1.Rows)
            {
                dr.Cells[0].Value = ((CheckBox)sender).Checked;
            }
            dgv1.EndEdit();
        }
        #endregion

        /// <summary>
        /// 填充部门下拉框
        /// </summary>
        private void FillDepartment()
        {
            cbxWorkShop.DataSource = CommonFunction.GetDepartment(1);
            cbxWorkShop.DisplayMember = "FName";
            cbxWorkShop.ValueMember = "FValue";
        }

        /// <summary>
        /// 保存汇总结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            return;
            //string strSQL = string.Empty;
            //string FBILLNO, FMTLNUMBER, FMTLNAME, FMTLPRO, FUNIT, BOM, FREMAINSTOCKINQTY, FQTY, FSTOCKQTY, FSTOCKAVBQTY, FSTOCKDAYS, FLOWQTY, FMINQTY, FSSQTY, FLACKQTY, FSUMQTY, FOPERATOR;

            //int iSEQ = 0;
            //FBILLNO = "HZ" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            //for (int i = 0; i < dtSum.Rows.Count; i++)
            //{
            //    iSEQ++;

            //    FMTLNUMBER = dtSum.Rows[i]["物料编码"].ToString();
            //    FMTLNAME = dtSum.Rows[i]["物料名称"].ToString();
            //    FMTLPRO = dtSum.Rows[i]["物料属性"].ToString();
            //    FUNIT = dtSum.Rows[i]["单位"].ToString();
            //    BOM = dtSum.Rows[i]["BOM"].ToString();

            //    FREMAINSTOCKINQTY = dtSum.Rows[i]["采购在途"].ToString();
            //    FQTY = dtSum.Rows[i]["生产自制"].ToString();
            //    FSTOCKQTY = dtSum.Rows[i]["库存数量"].ToString();
            //    FSTOCKAVBQTY = dtSum.Rows[i]["库存可用数量"].ToString();
            //    FSTOCKDAYS = dtSum.Rows[i]["库存可用天数"].ToString();

            //    FLOWQTY = dtSum.Rows[i]["最低订货量"].ToString();
            //    FMINQTY = dtSum.Rows[i]["最小批量"].ToString();
            //    FSSQTY = dtSum.Rows[i]["安全库存"].ToString();
            //    FLACKQTY = dtSum.Rows[i]["欠料数量"].ToString();
            //    FSUMQTY = dtSum.Rows[i]["需求汇总"].ToString();

            //    FOPERATOR = Model.GlobalParameter.K3Inf.UserName;

            //    strSQL = @"INSERT INTO DM_LOG_ORDERRUNSUM(FBILLNO,FMTLNUMBER,FMTLNAME,FMTLPRO,FUNIT,BOM
            //                ,FREMAINSTOCKINQTY,FQTY,FSTOCKQTY,FSTOCKAVBQTY,FSTOCKDAYS
            //                ,FLOWQTY,FMINQTY,FSSQTY,FLACKQTY,FSUMQTY
            //                ,FOPERATOR,FSEQ）
            //                VALUES('" + FBILLNO + "','" + FMTLNUMBER + "','" + FMTLNAME + "','" + FMTLPRO + "','" + FUNIT + "','" + BOM + @"'
            //                ," + FREMAINSTOCKINQTY + "," + FQTY + "," + FSTOCKQTY + "," + FSTOCKAVBQTY + "," + FSTOCKDAYS + @"
            //                ," + FLOWQTY + "," + FMINQTY + "," + FSSQTY + "," + FLACKQTY + "," + FSUMQTY + ",'" + FOPERATOR + "'," + iSEQ + ")";
            //    SQL.SQLHelper.ExecuteNonQuery(strSQL);
            //}
            //MessageBox.Show("操作成功");
        }

        /// <summary>
        /// 生成采购订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPo_Click(object sender, EventArgs e)
        {
            return;
            //if (dgv1.DataSource == null || dgv1.Rows.Count == 0) return;

            //strPOBillNO = string.Empty;//返回单据编号
            //int iCount = 0;//外购明细数量
            //double dQTY = 0;//采购数量
            //string strUnit = string.Empty;
            //client = new K3CloudApiClient(Model.GlobalParameter.K3Inf.C_ERPADDRESS);
            ////var bLogin = client.Login(kInfo.C_ZTID, kInfo.C_USERNAME, kInfo.C_PASSWORD, 2052);
            //var bLogin = client.Login(Model.GlobalParameter.K3Inf.C_ZTID, "damo", "111111", 2052);
            //if (bLogin)
            //{
            //    JObject jsonRoot = new JObject();
            //    jsonRoot.Add("Creator", "");
            //    jsonRoot.Add("NeedUpDateFields", new JArray(""));

            //    JObject model = new JObject();
            //    jsonRoot.Add("Model", model);
            //    model.Add("FID", 0);

            //    JObject basedata = new JObject();
            //    basedata.Add("FNumber", "CGSQD01_SYS");
            //    model.Add("FBillTypeID", basedata);

            //    model.Add("FApplicationDate", DateTime.Now);
            //    model.Add("FRequestType", "Material");

            //    basedata = new JObject();
            //    basedata.Add("FNumber", "HN02");
            //    model.Add("FApplicationOrgId", basedata);

            //    basedata = new JObject();
            //    basedata.Add("FNumber", "BM000058");
            //    model.Add("FApplicationDeptId", basedata);

            //    basedata = new JObject();
            //    basedata.Add("FNumber", "PRE001");
            //    model.Add("FCurrencyId", basedata);

            //    model.Add("FISPRICEEXCLUDETAX", "true");
            //    basedata = new JObject();
            //    basedata.Add("FNumber", "HLTX01_SYS");
            //    model.Add("FExchangeTypeId", basedata);

            //    JArray entryRows = new JArray();
            //    string entityKey = "FEntity";
            //    model.Add(entityKey, entryRows);
            //    for (int i = 0; i < dgv1.Rows.Count; i++)
            //    {
            //        if (dgv1.Rows[i].Cells[4].Value.ToString() != "外购" || !Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value)) continue;
            //        //if (double.Parse(dgv1.Rows[i].Cells[16].Value.ToString()) - double.Parse(dgv1.Rows[i].Cells[10].Value.ToString()) - double.Parse(dgv1.Rows[i].Cells[7].Value.ToString()) <= 0) continue;
            //        iCount++;
            //        dQTY = 1;//double.Parse(dgv1.Rows[i].Cells[16].Value.ToString()) - double.Parse(dgv1.Rows[i].Cells[10].Value.ToString()) - double.Parse(dgv1.Rows[i].Cells[7].Value.ToString());
            //        strUnit = dgv1.Rows[i].Cells[5].Value.ToString();

            //        JObject entryRow = new JObject();
            //        entryRows.Add(entryRow);
            //        entryRow.Add("FEntryID", 0);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", "HN02");
            //        entryRow.Add("FRequireOrgId", basedata);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", dgv1.Rows[i].Cells[2].Value.ToString());
            //        entryRow.Add("FMaterialId", basedata);//物料编码
            //        entryRow.Add("FMaterialDesc", dgv1.Rows[i].Cells[3].Value.ToString());//物料名称

            //        basedata = new JObject();
            //        basedata.Add("FNumber", strUnit);
            //        entryRow.Add("FUnitId", basedata);

            //        entryRow.Add("FReqQty", dQTY);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", "HN02");
            //        entryRow.Add("FPurchaseOrgId", basedata);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", "HN02");
            //        entryRow.Add("FReceiveOrgId", basedata);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", strUnit);
            //        entryRow.Add("FPriceUnitId", basedata);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", strUnit);
            //        entryRow.Add("FREQSTOCKUNITID", basedata);

            //        entryRow.Add("FREQSTOCKQTY", dQTY);
            //        entryRow.Add("FBaseReqQty", dQTY);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", strUnit);
            //        entryRow.Add("FSalUnitID", basedata);

            //        entryRow.Add("FSalQty", dQTY);
            //        entryRow.Add("FSalBaseQty", dQTY);
            //        entryRow.Add("FREQSTOCKBASEQTY", dQTY);
            //        entryRow.Add("FPRICEBASEQTY", dQTY);
            //        entryRow.Add("FEvaluatePrice", 0.0);
            //        entryRow.Add("FTAXPRICE", 0.0);
            //    }
            //    if (iCount == 0)
            //    {
            //        MessageBox.Show("请选择物料属性为“外购”的物料");
            //        return;
            //    }
            //    // 调用Web API接口服务，保存领料单
            //    strPOBillNO = client.Save("PUR_Requisition", jsonRoot.ToString());
            //    JObject jo = JObject.Parse(strPOBillNO);

            //    if (!jo["Result"]["ResponseStatus"]["IsSuccess"].Value<bool>())
            //    {
            //        strPOBillNO = "生成失败:";
            //        for (int i = 0; i < ((IList)jo["Result"]["ResponseStatus"]["Errors"]).Count; i++)
            //            strPOBillNO += jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>() + "\r\n";//保存不成功返错误信息
            //    }
            //    else
            //    {
            //        strPOBillNO = jo["Result"]["Number"].Value<string>();
            //    }
            //}
            //MessageBox.Show("生生采购申请单：[" + strPOBillNO + "]");
            //btnSave.Enabled = true;
        }

        /// <summary>
        /// 生成生产订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMo_Click(object sender, EventArgs e)
        {
            return;
            //if (dgv1.DataSource == null || dgv1.Rows.Count == 0) return;

            //strMoBillNO = string.Empty;//返回单据编号
            //int iCount = 0;//外购明细数量
            //double dQTY = 0;//采购数量
            //string strUnit = string.Empty;
            //client = new K3CloudApiClient(Model.GlobalParameter.K3Inf.C_ERPADDRESS);
            ////var bLogin = client.Login(kInfo.C_ZTID, kInfo.C_USERNAME, kInfo.C_PASSWORD, 2052);
            //var bLogin = client.Login(Model.GlobalParameter.K3Inf.C_ZTID, "damo", "111111", 2052);
            //if (bLogin)
            //{
            //    JObject jsonRoot = new JObject();
            //    jsonRoot.Add("Creator", "");
            //    jsonRoot.Add("NeedUpDateFields", new JArray(""));
            //    jsonRoot.Add("IsVerifyBaseDataField", "false");
            //    jsonRoot.Add("IsDeleteEntry", "True");

            //    JObject model = new JObject();
            //    jsonRoot.Add("Model", model);
            //    model.Add("FID", 0);

            //    JObject basedata = new JObject();
            //    basedata.Add("FNumber", "SCDD03_SYS");
            //    model.Add("FBillType", basedata);

            //    model.Add("FApplicationDate", DateTime.Now);

            //    basedata = new JObject();
            //    basedata.Add("FNumber", "HN02");
            //    model.Add("FPrdOrgId", basedata);

            //    model.Add("FOwnerTypeId", "BD_OwnerOrg");
            //    model.Add("FIsRework", "false");
            //    model.Add("FTrustteed", "false");
            //    model.Add("FIsEntrust", "false");
            //    model.Add("FPPBOMType", "1");
            //    //model.Add("F_PRODUCTSUM", 100.0);

            //    JArray entryRows = new JArray();
            //    string entityKey = "FTreeEntity";
            //    model.Add(entityKey, entryRows);
            //    for (int i = 0; i < dgv1.Rows.Count; i++)
            //    {
            //        if (dgv1.Rows[i].Cells[4].Value.ToString() != "自制" || !Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value)) continue;
            //        //if (double.Parse(dgv1.Rows[i].Cells[16].Value.ToString()) - double.Parse(dgv1.Rows[i].Cells[10].Value.ToString()) - double.Parse(dgv1.Rows[i].Cells[8].Value.ToString()) <= 0) continue;
            //        iCount++;
            //        dQTY = 1;//double.Parse(dgv1.Rows[i].Cells[16].Value.ToString()) - double.Parse(dgv1.Rows[i].Cells[10].Value.ToString()) - double.Parse(dgv1.Rows[i].Cells[8].Value.ToString());
            //        strUnit = dgv1.Rows[i].Cells[5].Value.ToString();

            //        JObject entryRow = new JObject();
            //        entryRows.Add(entryRow);
            //        entryRow.Add("FEntryID", 0);

            //        entryRow.Add("FProductType", "1");

            //        basedata = new JObject();
            //        basedata.Add("FNumber", dgv1.Rows[i].Cells[2].Value.ToString());
            //        entryRow.Add("FMaterialId", basedata);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", cbxWorkShop.SelectedValue.ToString());
            //        entryRow.Add("FWorkShopID", basedata);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", strUnit);
            //        entryRow.Add("FUnitId", basedata);

            //        entryRow.Add("FQty", dQTY);
            //        entryRow.Add("FYieldQty", dQTY);

            //        entryRow.Add("FPlanStartDate", dtpPlanStar.Value.ToString());
            //        entryRow.Add("FPlanFinishDate", dtpPlanEnd.Value.ToString());

            //        basedata = new JObject();
            //        basedata.Add("FNumber", "HN02");
            //        entryRow.Add("FPurchaseOrgId", basedata);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", dgv1.Rows[i].Cells[6].Value.ToString());
            //        entryRow.Add("FBomId", basedata);

            //        entryRow.Add("FISBACKFLUSH", "true");

            //        basedata = new JObject();
            //        basedata.Add("FNumber", "HN02");
            //        entryRow.Add("FStockInOrgId", basedata);

            //        entryRow.Add("FBaseYieldQty", dQTY);
            //        entryRow.Add("FReqType", "1");
            //        entryRow.Add("FInStockOwnerTypeId", "BD_OwnerOrg");
            //        entryRow.Add("FBaseStockInLimitH", dQTY * 1.05);//?

            //        basedata = new JObject();
            //        basedata.Add("FNumber", "HN02");
            //        entryRow.Add("FInStockOwnerId", basedata);

            //        entryRow.Add("FBaseStockInLimitL", dQTY);

            //        basedata = new JObject();
            //        basedata.Add("FNumber", strUnit);
            //        entryRow.Add("FBaseUnitId", basedata);

            //        entryRow.Add("FStockInLimitH", dQTY * 1.05);
            //        entryRow.Add("FStockInLimitL", dQTY);
            //        entryRow.Add("FCostRate", dQTY);
            //        entryRow.Add("FCreateType", "1");
            //        entryRow.Add("FYieldRate", dQTY);
            //        entryRow.Add("FGroup", "1");
            //        entryRow.Add("FNoStockInQty", dQTY);
            //        entryRow.Add("FBaseNoStockInQty", dQTY);
            //        entryRow.Add("FRowId", "e61f13e8-4fd7-8114-11e7-f69d17c998e4");
            //    }
            //    if (iCount == 0)
            //    {
            //        MessageBox.Show("请选择物料属性为“自制”的物料");
            //        return;
            //    }
            //    // 调用Web API接口服务，保存领料单
            //    strMoBillNO = client.Save("PRD_MO", jsonRoot.ToString());
            //    JObject jo = JObject.Parse(strMoBillNO);

            //    if (!jo["Result"]["ResponseStatus"]["IsSuccess"].Value<bool>())
            //    {
            //        strMoBillNO = "生成失败:";
            //        for (int i = 0; i < ((IList)jo["Result"]["ResponseStatus"]["Errors"]).Count; i++)
            //            strMoBillNO += jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>() + "\r\n";//保存不成功返错误信息
            //    }
            //    else
            //    {
            //        strMoBillNO = jo["Result"]["Number"].Value<string>();
            //    }
            //}
            //MessageBox.Show("生成生产订单：[" + strMoBillNO + "]");
            //btnSave.Enabled = true;
        }
    }
    /*
    public delegate void CheckBoxClickedHandler(bool state);
    class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        public event CheckBoxClickedHandler OnCheckBoxClicked;

        public DatagridViewCheckBoxHeaderCell()
        {
        }

        protected override void Paint(System.Drawing.Graphics graphics,
            System.Drawing.Rectangle clipBounds,
            System.Drawing.Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                dataGridViewElementState, value,
                formattedValue, errorText, cellStyle,
                advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
                (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y +
                (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                    CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(_checked);
                    this.DataGridView.InvalidateCell(this);
                }

            }
            base.OnMouseClick(e);
        }
    }
    */
}
