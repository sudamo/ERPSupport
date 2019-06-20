﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Kingdee.BOS.WebApi.Client;
using ERPSupport.Model.Globa;

namespace ERPSupport.SQL.K3Cloud
{
    /// <summary>
    /// 调拨
    /// </summary>
    public static class PrdAllocation
    {
        #region STATIC
        private static string _SQL;
        private static object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        static PrdAllocation()
        {
            _SQL = string.Empty;
            _obj = new object();
        }
        #endregion

        /// <summary>
        /// 获取调拨单数据ERP
        /// </summary>
        /// <param name="pFNeedDate">需求日期</param>
        /// <param name="pDeptNos">部门</param>
        /// <returns></returns>
        public static DataTable GetTransERP(string pFNeedDate, string pDeptNos)
        {
            _SQL = @"SELECT ORG.FNUMBER 调入库存组织, NVL(ORG2.FNUMBER, 'HN02') 货主, AC.FOWNERTYPEID 货主类型, MTL.FNUMBER 物料编码,UNT.FNUMBER 单位
                , STK.FNUMBER 调入仓库, STK2.FNUMBER 调出仓库, DEP.FNUMBER 领料部门, SUM(AE.FMUSTQTY) 调拨数量
            FROM T_PRD_PPBOM A
            INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID
            INNER JOIN T_PRD_PPBOMENTRY_C AC ON AE.FENTRYID = AC.FENTRYID
            INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID AND TO_CHAR(MOE.FPLANSTARTDATE,'yyyy-MM-dd') = TO_CHAR(AE.FNEEDDATE,'yyyy-MM-dd')
            INNER JOIN T_PRD_MO MO ON MO.FID = MOE.FID AND MO.FDOCUMENTSTATUS = 'C'
            INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID AND MOA.FSTATUS IN(3,4)
            INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508
            INNER JOIN T_ORG_ORGANIZATIONS ORG ON AC.FSUPPLYORG = ORG.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS ORG2 ON AC.FOWNERID = ORG2.FORGID
            INNER JOIN T_BD_UNIT UNT ON AE.FUNITID = UNT.FUNITID
            INNER JOIN T_BD_DEPARTMENT DEP ON MOE.FWORKSHOPID = DEP.FDEPTID
            INNER JOIN T_BD_STOCK STK ON DEP.FINSTOCKID = STK.FSTOCKID
            INNER JOIN T_AUTO_MSTOCKSETTING MST ON AE.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID
            INNER JOIN T_BD_STOCK STK2 ON MST.FSTOCKID = STK2.FSTOCKID
            WHERE A.FDOCUMENTSTATUS = 'C' AND AE.FPAEZHAVEDIRECT = 0 AND STK.FNUMBER <> STK2.FNUMBER AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') = '" + pFNeedDate + "' AND DEP.FNUMBER IN(" + pDeptNos + @")--用料清单未生成过调拨单、调入仓不等于调出仓
            GROUP BY ORG.FNUMBER, ORG2.FNUMBER, AC.FOWNERTYPEID, MTL.FNUMBER, UNT.FNUMBER, STK.FNUMBER, STK2.FNUMBER,DEP.FNUMBER";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取调拨单数据WMS
        /// </summary>
        /// <param name="pFNeedDate"></param>
        /// <returns></returns>
        public static DataTable GetTransWMS(string pFNeedDate)//根据仓库属性-是否汇总 判断汇总信息。
        {
            _SQL = @"SELECT * FROM (
            SELECT AC.FOWNERID 货主,NVL(ORG.FNUMBER, 'HN02') 货主编码,NVL(ORGL.FNAME, '河南工厂') 货主名称, AC.FOWNERTYPEID 货主类型,AE.FMATERIALID 物料,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称
              ,AE.FUNITID 单位,UNT.FNUMBER 单位编码,UNTL.FNAME 单位名称,MOE.FWORKSHOPID 领料部门,DEP.FNUMBER 领料部门编码,DEPL.FNAME 领料部门名称
              ,AC.FSUPPLYORG 调入库存组织,NVL(ORG2.FNUMBER,' ') 调入库存组织编码,NVL(ORGL2.FNAME,' ') 调入库存组织名称,DEP.FINSTOCKID 调入仓库,STK2.FNUMBER 调入仓库编码,STKL2.FNAME 调入仓库名称,STK2.FDEFSTOCKSTATUSID 调入库存状态,STT2.FNUMBER 调入库存状态编码,STTL2.FNAME 调入库存状态名称
              ,AC.FSRCTRANSORGID 调出库存组织,NVL(ORG3.FNUMBER,' ') 调出库存组织编码,NVL(ORGL3.FNAME,' ') 调出库存组织名称,MST.FSTOCKID 调出仓库,STK3.FNUMBER 调出仓库编码,STKL3.FNAME 调出仓库名称,STK3.FDEFSTOCKSTATUSID 调出库存状态,STT3.FNUMBER 调出库存状态编码,STTL3.FNAME 调出库存状态名称
              ,AC.FLOT 批号,AE.FMUSTQTY 调拨数量,MOE.FPRODUCTIONSEQ 生产顺序号,TO_CHAR(MOE.F_PAEZ_DESCRIPTION) 生产订单备注,NVL(MTLSK.F_PAEZ_FMinsendQty,0) 最小批量,MTL.F_PAEZ_SENDPERCENT 发料百分比
              ,NVL(ASS.FNUMBER,' ') 调拨类型,NVL(ASSL2.FDATAVALUE,' ') 启用批次,NVL(ASSL3.FDATAVALUE,' ') 启用序列号,NVL(ASSL4.FDATAVALUE,' ') 发货类别
            FROM T_PRD_PPBOM A
            INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID
            INNER JOIN T_PRD_PPBOMENTRY_C AC ON AE.FENTRYID = AC.FENTRYID
            INNER JOIN T_PRD_PPBOMENTRY_Q AQ ON AE.FENTRYID = AQ.FENTRYID
            INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID AND TO_CHAR(MOE.FPLANSTARTDATE,'yyyy-mm-dd') = TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd')
            INNER JOIN T_PRD_MO MO ON MO.FID = MOE.FID AND MO.FDOCUMENTSTATUS = 'C'
            INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID AND MOA.FSTATUS IN(3,4)
            INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508
            INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
            LEFT JOIN T_BD_MATERIALSTOCK MTLSK ON MTL.FMATERIALID = MTLSK.FMATERIALID
            INNER JOIN T_BD_UNIT UNT ON AE.FUNITID = UNT.FUNITID
            INNER JOIN T_BD_UNIT_L UNTL ON UNT.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
            INNER JOIN T_BD_DEPARTMENT DEP ON MOE.FWORKSHOPID = DEP.FDEPTID
            INNER JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052
            LEFT JOIN T_ORG_ORGANIZATIONS ORG ON AC.FOWNERID = ORG.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL ON ORG.FORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
            LEFT JOIN T_ORG_ORGANIZATIONS ORG2 ON AC.FSUPPLYORG = ORG2.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL2 ON ORG2.FORGID = ORGL2.FORGID AND ORGL2.FLOCALEID = 2052
            LEFT JOIN T_ORG_ORGANIZATIONS ORG3 ON AC.FSRCTRANSORGID = ORG3.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL3 ON ORG3.FORGID = ORGL3.FORGID AND ORGL3.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY ASS ON MTL.F_PAEZ_SENDTYPE = ASS.FENTRYID
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL2 ON MTL.F_ISBATCHMANAGER = ASSL2.FENTRYID AND ASSL2.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL3 ON MTL.F_ISSNMANAGER = ASSL3.FENTRYID AND ASSL3.FLOCALEID = 2052
            LEFT JOIN T_SAL_ORDER O ON MOE.FSALEORDERID = O.FID
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL4 ON O.FHEADDELIVERYWAY = ASSL4.FENTRYID AND ASSL4.FLOCALEID = 2052
            INNER JOIN T_BD_STOCK STK2 ON DEP.FINSTOCKID = STK2.FSTOCKID
            INNER JOIN T_BD_STOCK_L STKL2 ON STK2.FSTOCKID = STKL2.FSTOCKID AND STKL2.FLOCALEID = 2052
            INNER JOIN T_BD_STOCKSTATUS STT2 ON STK2.FDEFSTOCKSTATUSID = STT2.FSTOCKSTATUSID
            INNER JOIN T_BD_STOCKSTATUS_L STTL2 ON STT2.FSTOCKSTATUSID = STTL2.FSTOCKSTATUSID AND STTL2.FLOCALEID = 2052
            INNER JOIN T_AUTO_MSTOCKSETTING MST ON AE.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID
            INNER JOIN T_BD_STOCK STK3 ON MST.FSTOCKID = STK3.FSTOCKID
            INNER JOIN T_BD_STOCK_L STKL3 ON STK3.FSTOCKID = STKL3.FSTOCKID AND STKL3.FLOCALEID = 2052
            INNER JOIN T_BD_STOCKSTATUS STT3 ON STK3.FDEFSTOCKSTATUSID = STT3.FSTOCKSTATUSID
            INNER JOIN T_BD_STOCKSTATUS_L STTL3 ON STT3.FSTOCKSTATUSID = STTL3.FSTOCKSTATUSID AND STTL3.FLOCALEID = 2052
            WHERE A.FDOCUMENTSTATUS = 'C' AND AE.FPAEZHAVEDIRECT = 0 AND STK2.FNUMBER <> STK3.FNUMBER AND STK3.FALLOWSUM = '0' AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') = '" + pFNeedDate + @"'
            ORDER BY MOE.FPRODUCTIONSEQ) a
            UNION ALL
            SELECT AC.FOWNERID 货主,NVL(ORG.FNUMBER, 'HN02') 货主编码,NVL(ORGL.FNAME, '河南工厂') 货主名称, AC.FOWNERTYPEID 货主类型,AE.FMATERIALID 物料,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称
              ,AE.FUNITID 单位,UNT.FNUMBER 单位编码,UNTL.FNAME 单位名称,MOE.FWORKSHOPID 领料部门,DEP.FNUMBER 领料部门编码,DEPL.FNAME 领料部门名称
              ,AC.FSUPPLYORG 调入库存组织,NVL(ORG2.FNUMBER,' ') 调入库存组织编码,NVL(ORGL2.FNAME,' ') 调入库存组织名称,DEP.FINSTOCKID 调入仓库,STK2.FNUMBER 调入仓库编码,STKL2.FNAME 调入仓库名称,STK2.FDEFSTOCKSTATUSID 调入库存状态,STT2.FNUMBER 调入库存状态编码,STTL2.FNAME 调入库存状态名称
              ,AC.FSRCTRANSORGID 调出库存组织,NVL(ORG3.FNUMBER,' ') 调出库存组织编码,NVL(ORGL3.FNAME,' ') 调出库存组织名称,MST.FSTOCKID 调出仓库,STK3.FNUMBER 调出仓库编码,STKL3.FNAME 调出仓库名称,STK3.FDEFSTOCKSTATUSID 调出库存状态,STT3.FNUMBER 调出库存状态编码,STTL3.FNAME 调出库存状态名称
              ,AC.FLOT 批号,SUM(AE.FMUSTQTY) 调拨数量,N' ' 生产顺序号,' ' 生产订单备注,NVL(MTLSK.F_PAEZ_FMinsendQty,0) 最小批量,MTL.F_PAEZ_SENDPERCENT 发料百分比
              ,NVL(ASS.FNUMBER,' ') 调拨类型,NVL(ASSL2.FDATAVALUE,' ') 启用批次,NVL(ASSL3.FDATAVALUE,' ') 启用序列号,N' ' 发货类别
            FROM T_PRD_PPBOM A
            INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID
            INNER JOIN T_PRD_PPBOMENTRY_C AC ON AE.FENTRYID = AC.FENTRYID
            INNER JOIN T_PRD_PPBOMENTRY_Q AQ ON AE.FENTRYID = AQ.FENTRYID
            INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID AND TO_CHAR(MOE.FPLANSTARTDATE,'yyyy-mm-dd') = TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd')
            INNER JOIN T_PRD_MO MO ON MO.FID = MOE.FID AND MO.FDOCUMENTSTATUS = 'C'
            INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID AND MOA.FSTATUS IN(3,4)
            INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508
            INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
            LEFT JOIN T_BD_MATERIALSTOCK MTLSK ON MTL.FMATERIALID = MTLSK.FMATERIALID
            INNER JOIN T_BD_UNIT UNT ON AE.FUNITID = UNT.FUNITID
            INNER JOIN T_BD_UNIT_L UNTL ON UNT.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
            INNER JOIN T_BD_DEPARTMENT DEP ON MOE.FWORKSHOPID = DEP.FDEPTID
            INNER JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052
            LEFT JOIN T_ORG_ORGANIZATIONS ORG ON AC.FOWNERID = ORG.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL ON ORG.FORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
            LEFT JOIN T_ORG_ORGANIZATIONS ORG2 ON AC.FSUPPLYORG = ORG2.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL2 ON ORG2.FORGID = ORGL2.FORGID AND ORGL2.FLOCALEID = 2052
            LEFT JOIN T_ORG_ORGANIZATIONS ORG3 ON AC.FSRCTRANSORGID = ORG3.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL3 ON ORG3.FORGID = ORGL3.FORGID AND ORGL3.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY ASS ON MTL.F_PAEZ_SENDTYPE = ASS.FENTRYID
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL2 ON MTL.F_ISBATCHMANAGER = ASSL2.FENTRYID AND ASSL2.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL3 ON MTL.F_ISSNMANAGER = ASSL3.FENTRYID AND ASSL3.FLOCALEID = 2052
            LEFT JOIN T_SAL_ORDER O ON MOE.FSALEORDERID = O.FID
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL4 ON O.FHEADDELIVERYWAY = ASSL4.FENTRYID AND ASSL4.FLOCALEID = 2052
            INNER JOIN T_BD_STOCK STK2 ON DEP.FINSTOCKID = STK2.FSTOCKID
            INNER JOIN T_BD_STOCK_L STKL2 ON STK2.FSTOCKID = STKL2.FSTOCKID AND STKL2.FLOCALEID = 2052
            INNER JOIN T_BD_STOCKSTATUS STT2 ON STK2.FDEFSTOCKSTATUSID = STT2.FSTOCKSTATUSID
            INNER JOIN T_BD_STOCKSTATUS_L STTL2 ON STT2.FSTOCKSTATUSID = STTL2.FSTOCKSTATUSID AND STTL2.FLOCALEID = 2052
            INNER JOIN T_AUTO_MSTOCKSETTING MST ON AE.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID
            INNER JOIN T_BD_STOCK STK3 ON MST.FSTOCKID = STK3.FSTOCKID
            INNER JOIN T_BD_STOCK_L STKL3 ON STK3.FSTOCKID = STKL3.FSTOCKID AND STKL3.FLOCALEID = 2052
            INNER JOIN T_BD_STOCKSTATUS STT3 ON STK3.FDEFSTOCKSTATUSID = STT3.FSTOCKSTATUSID
            INNER JOIN T_BD_STOCKSTATUS_L STTL3 ON STT3.FSTOCKSTATUSID = STTL3.FSTOCKSTATUSID AND STTL3.FLOCALEID = 2052
            WHERE A.FDOCUMENTSTATUS = 'C' AND AE.FPAEZHAVEDIRECT = 0 AND STK2.FNUMBER <> STK3.FNUMBER AND STK3.FALLOWSUM = '1' AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') = '" + pFNeedDate + @"'
            GROUP BY AC.FOWNERID,ORG.FNUMBER,ORGL.FNAME, AC.FOWNERTYPEID,AE.FMATERIALID,MTL.FNUMBER,MTLL.FNAME,AE.FUNITID,UNT.FNUMBER,UNTL.FNAME,MOE.FWORKSHOPID,DEP.FNUMBER,DEPL.FNAME,AC.FSUPPLYORG,ORG2.FNUMBER,ORGL2.FNAME,DEP.FINSTOCKID,STK2.FNUMBER,STKL2.FNAME,STK2.FDEFSTOCKSTATUSID,STT2.FNUMBER,STTL2.FNAME,AC.FSRCTRANSORGID,ORG3.FNUMBER,ORGL3.FNAME,MST.FSTOCKID,STK3.FNUMBER,STKL3.FNAME,STK3.FDEFSTOCKSTATUSID,STT3.FNUMBER,STTL3.FNAME,AC.FLOT,MTLSK.F_PAEZ_FMinsendQty,MTL.F_PAEZ_SENDPERCENT,ASS.FNUMBER,ASSL2.FDATAVALUE,ASSL3.FDATAVALUE";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 半成品调拨ERP
        /// </summary>
        /// <param name="pDataTable">数据表</param>
        /// <param name="pDate">日期</param>
        /// <returns></returns>
        public static string TransferDirERP(DataTable pDataTable, DateTime pDate)
        {
            if (pDataTable.Rows.Count <= 0)
                return "";

            string strPMBillNO = string.Empty;

            K3CloudApiClient client = new K3CloudApiClient(GlobalParameter.K3Inf.C_ERPADDRESS);
            var bLogin = client.Login(GlobalParameter.K3Inf.C_ZTID, GlobalParameter.K3Inf.UserName, GlobalParameter.K3Inf.UserPWD, 2052);

            if (bLogin)
            {
                JObject jsonRoot = new JObject();
                jsonRoot.Add("Creator", "MANUAL");
                jsonRoot.Add("NeedUpDateFields", new JArray(""));

                JObject model = new JObject();
                jsonRoot.Add("Model", model);
                model.Add("FID", 0);

                JObject basedata = new JObject();
                basedata.Add("FNumber", "ZJDB01_SYS");
                model.Add("FBillTypeID", basedata);

                model.Add("FTransferDirect", "GENERAL");
                model.Add("FTransferBizType", "InnerOrgTransfer");

                basedata = new JObject();
                basedata.Add("FNumber", pDataTable.Rows[0]["调入库存组织"].ToString());
                model.Add("FSettleOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDataTable.Rows[0]["调入库存组织"].ToString());
                model.Add("FSaleOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDataTable.Rows[0]["调入库存组织"].ToString());
                model.Add("FStockOutOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDataTable.Rows[0]["调入库存组织"].ToString());
                model.Add("FStockOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDataTable.Rows[0]["领料部门"].ToString());
                model.Add("F_PickDepart", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", "PRE001");
                model.Add("FSETTLECURRID", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", "PRE001");
                model.Add("FBaseCurrId", basedata);

                model.Add("FDate", pDate);

                JArray entryRows = new JArray();
                string entityKey = "FBillEntry";
                model.Add(entityKey, entryRows);
                for (int i = 0; i < pDataTable.Rows.Count; i++)
                {
                    JObject entryRow = new JObject();
                    entryRows.Add(entryRow);
                    entryRow.Add("FEntryID", 0);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["物料编码"].ToString());
                    entryRow.Add("FMaterialId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["物料编码"].ToString());
                    entryRow.Add("FDestMaterialId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["单位"].ToString());
                    entryRow.Add("FUnitID", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["单位"].ToString());
                    entryRow.Add("FBaseUnitId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["单位"].ToString());
                    entryRow.Add("FPriceUnitID", basedata);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["调出仓库"].ToString());
                    entryRow.Add("FSrcStockId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["调入仓库"].ToString());
                    entryRow.Add("FDestStockId", basedata);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["货主"].ToString());
                    entryRow.Add("FOwnerId", basedata);
                    entryRow.Add("FOwnerTypeId", "BD_OwnerOrg");
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["货主"].ToString());
                    entryRow.Add("FOwnerOutId", basedata);
                    entryRow.Add("FOwnerTypeOutId", "BD_OwnerOrg");

                    entryRow.Add("FQty", pDataTable.Rows[i]["调拨数量"].ToString());
                    entryRow.Add("FPAEZAskQty", 0);
                    entryRow.Add("FBaseQty", pDataTable.Rows[i]["调拨数量"].ToString());
                    entryRow.Add("FActQty", pDataTable.Rows[i]["调拨数量"].ToString());
                    entryRow.Add("FPriceQty", pDataTable.Rows[i]["调拨数量"].ToString());
                    entryRow.Add("FPriceBaseQty", pDataTable.Rows[i]["调拨数量"].ToString());
                }
                // 调用Web API接口服务，保存领料单
                strPMBillNO = client.Save("STK_TransferDirect", jsonRoot.ToString());
                JObject jo = JObject.Parse(strPMBillNO);

                if (!jo["Result"]["ResponseStatus"]["IsSuccess"].Value<bool>())
                {
                    strPMBillNO = "生成失败:";
                    for (int i = 0; i < ((IList)jo["Result"]["ResponseStatus"]["Errors"]).Count; i++)
                        strPMBillNO += jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>() + "\r\n";//保存不成功返错误信息
                }
                else
                {
                    strPMBillNO = jo["Result"]["Number"].Value<string>();
                }
            }

            return strPMBillNO;
        }

        /// <summary>
        /// 半成品调拨WMS
        /// </summary>
        /// <param name="pDataTable"></param>
        /// <param name="pDate"></param>
        /// <returns></returns>
        public static string TransferDirWMS(DataTable pDataTable, string pDate)
        {
            if (pDataTable == null || pDataTable.Rows.Count <= 0)
                return "";

            string strBillNo = string.Empty;

            //编号
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DM_P_GetBillNo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FBillType", SqlDbType.Int);
                cmd.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);

                cmd.Parameters["@FBillType"].Value = 1;
                cmd.Parameters["@BillNo"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                strBillNo = cmd.Parameters["@BillNo"].Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@OwnerInId", SqlDbType.Int),
                new SqlParameter("@OwnerInNumber", SqlDbType.VarChar),
                new SqlParameter("@OwnerInName", SqlDbType.VarChar),
                new SqlParameter("@InOrgId", SqlDbType.Int),
                new SqlParameter("@InOrgNumber", SqlDbType.VarChar),

                new SqlParameter("@InOrgName", SqlDbType.VarChar),
                new SqlParameter("@OutOrgID", SqlDbType.Int),
                new SqlParameter("@OutOrgNumber", SqlDbType.VarChar),
                new SqlParameter("@OutOrgName", SqlDbType.VarChar),
                new SqlParameter("@PickDepartId", SqlDbType.Int),

                new SqlParameter("@PickDepartNumber", SqlDbType.VarChar),
                new SqlParameter("@PickDepartName", SqlDbType.VarChar),
                new SqlParameter("@BillNo", SqlDbType.VarChar),
                new SqlParameter("@businessType", SqlDbType.Char),
                new SqlParameter("@billStatus", SqlDbType.Char)
            };
            parms[0].Value = int.Parse(pDataTable.Rows[0]["货主"].ToString());
            parms[1].Value = pDataTable.Rows[0]["货主编码"].ToString();
            parms[2].Value = pDataTable.Rows[0]["货主名称"].ToString();
            parms[3].Value = int.Parse(pDataTable.Rows[0]["调入库存组织"].ToString());
            parms[4].Value = pDataTable.Rows[0]["调入库存组织编码"].ToString();

            parms[5].Value = pDataTable.Rows[0]["调入库存组织名称"].ToString();
            parms[6].Value = int.Parse(pDataTable.Rows[0]["调出库存组织"].ToString());
            parms[7].Value = pDataTable.Rows[0]["调出库存组织编码"].ToString();
            parms[8].Value = pDataTable.Rows[0]["调出库存组织名称"].ToString();
            parms[9].Value = int.Parse(pDataTable.Rows[0]["领料部门"].ToString());

            parms[10].Value = pDataTable.Rows[0]["领料部门编码"].ToString();
            parms[11].Value = pDataTable.Rows[0]["领料部门名称"].ToString();
            parms[12].Value = strBillNo;
            parms[13].Value = pDataTable.Rows[0]["调拨类型"].ToString();
            parms[14].Value = pDataTable.Rows[0]["调拨类型"].ToString() == "1" ? 2 : 1;//按次调拨类型：审核状态，否则为新建状态

            _SQL = @"BEGIN TRANSACTION
            INSERT INTO t_StkTransferOut(billNo,transferDirect,bizType,outOrgID,outOrgNumber,outOrgName,inOrgId,inOrgNumber,inOrgName,billDate,stockManagerId,stockManagerNumber,stockManagerName,transferBizType,pickType,pickDepartId,pickDepartNumber,pickDepartName,ownerTypeOut,ownerTypeIn,ownerInId,ownerInNumber,ownerInName,businessType,billStatus,ownerOutId,ownerOutNumber,ownerOutName,settleOrgId,settleOrgNumber,settleOrgName)
            VALUES(@BillNo,'General','Standard ',100508,'HN02','河南工厂',@InOrgId,@InOrgNumber,@InOrgName,'" + pDate + @"',0,'','','InnerOrgTransfer',1,@PickDepartId,@PickDepartNumber,@PickDepartName,'BD_OwnerOrg','BD_OwnerOrg',@OwnerInId,@OwnerInNumber,@OwnerInName,@businessType,@billStatus,@InOrgId,@InOrgNumber,@InOrgName,@InOrgId,@InOrgNumber,@InOrgName);
            DECLARE @stkBillId INT 
            SELECT @stkBillId = id FROM t_StkTransferOut WHERE billNo = @BillNo;";

            decimal fqty = 0;
            for (int i = 0; i < pDataTable.Rows.Count; i++)
            {
                if (decimal.Parse(pDataTable.Rows[i]["最小批量"].ToString()) == 0)
                    fqty = decimal.Parse(pDataTable.Rows[i]["调拨数量"].ToString());
                else if (decimal.Parse(pDataTable.Rows[i]["最小批量"].ToString()) >= decimal.Parse(pDataTable.Rows[i]["调拨数量"].ToString()))
                    fqty = decimal.Parse(pDataTable.Rows[i]["最小批量"].ToString());
                else
                    fqty = decimal.Parse(pDataTable.Rows[i]["最小批量"].ToString()) * Math.Round(decimal.Parse(pDataTable.Rows[i]["调拨数量"].ToString()) / decimal.Parse(pDataTable.Rows[i]["最小批量"].ToString()), MidpointRounding.AwayFromZero);

                _SQL += @"
                INSERT INTO t_StkTransferOutEntry(stkBillId,mtlId,mtlFnumber,mtlFname,inStockId,inStockNumber,inStockName,inStockStatusId,inStockStatusNumber,inStockStatusName,outStockId,outStockNumber,outStockName,outStockStatusId,outStockStatusNumber,outStockStatusName,unitId,unitFumber,unitFname,fqty,applicationQty,needFqty,pickFqty,batchCode,FPRODUCTIONSEQ,FMONote,deliveryWayName)
                VALUES(@stkBillId," + int.Parse(pDataTable.Rows[i]["物料"].ToString()) + ",'" + pDataTable.Rows[i]["物料编码"].ToString() + "','" + pDataTable.Rows[i]["物料名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调入仓库"].ToString()) + ",'" + pDataTable.Rows[i]["调入仓库编码"].ToString() + "','" + pDataTable.Rows[i]["调入仓库名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调入库存状态"].ToString()) + ",'" + pDataTable.Rows[i]["调入库存状态编码"].ToString() + "','" + pDataTable.Rows[i]["调入库存状态名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调出仓库"].ToString()) + ",'" + pDataTable.Rows[i]["调出仓库编码"].ToString() + "','" + pDataTable.Rows[i]["调出仓库名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调出库存状态"].ToString()) + ",'" + pDataTable.Rows[i]["调出库存状态编码"].ToString() + "','" + pDataTable.Rows[i]["调出库存状态名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["单位"].ToString()) + ",'" + pDataTable.Rows[i]["单位编码"].ToString() + "','" + pDataTable.Rows[i]["单位名称"].ToString() + "'," + fqty.ToString() + "," + fqty.ToString() + "," + decimal.Parse(pDataTable.Rows[i]["调拨数量"].ToString()) + ",0,'" + pDataTable.Rows[i]["批号"].ToString() + "','" + pDataTable.Rows[i]["生产顺序号"].ToString() + "','" + pDataTable.Rows[i]["生产订单备注"].ToString() + "','" + pDataTable.Rows[i]["发货类别"].ToString() + "');";
            }

            _SQL += @"
            IF @@ERROR = 0
            BEGIN
	            COMMIT
	            SELECT @BillNo
            END
            ELSE
            BEGIN
	            ROLLBACK
	            SELECT ''
            END";

            strBillNo = SQLHelper.ExecuteScalar(_SQL, parms).ToString();

            return strBillNo;
        }

        /// <summary>
        /// 成品调拨数据WMS
        /// </summary>
        /// <param name="pFilter"></param>
        /// <returns></returns>
        public static DataTable GetTransForP(string pFilter)
        {
            _SQL = @"SELECT O.* FROM
            (
            SELECT * FROM OPENQUERY(ERP_ORACLE,
            '";
            string strOra = @"
            SELECT DISTINCT A.FBILLNO 订单编号,O.FDATE 订单日期,A.FOWNERID 货主ID,ORG.FNUMBER 货主代码,ORGL.FNAME 货主名称,A.FOWNERTYPEID 货主类型,A.FSTOCKORGID 库存组织ID,ORG2.FNUMBER 库存组织代码,ORGL2.FNAME 库存组织名称
                ,A.FMATERIALID 物料ID,MTL.FNUMBER 物料代码,MTLL.FNAME 物料名称,A.FBASEUNITID 单位ID,UNT.FNUMBER 单位代码,UNTL.FNAME 单位名称,SUM(A.FLOCKQTY) 锁库数量,OE.F_PAEZ_LOCKALLOTQTY 锁库调拨数量,OER.FBASEDELIQTY 发货通知数量
                ,MTL.F_PAEZ_SENDPERCENT 发料百分比,MTLS.F_PAEZ_FMINSENDQTY 最小发出数量,A.FSTOCKID 调出仓库ID,STK.FNUMBER 调出仓库代码,STKL.FNAME 调出仓库名称,CUST.FNUMBER 客户代码,CUSTL.FNAME 客户名称
                ,NVL(ASS.FNUMBER,' ') 调拨类型,NVL(ASSL2.FDATAVALUE,' ') 启用批次,NVL(ASSL3.FDATAVALUE,' ') 启用序列号,NVL(ASSL4.FDATAVALUE,' ') 发货类别,NVL(ASSL5.FDATAVALUE,' ') 品牌,NVL(ASSL6.FDATAVALUE,' ') 系列,NVL(ASSL7.FDATAVALUE,' ') 商品名,NVL(ASSL8.FDATAVALUE,' ') 颜色
                ,NVL(ASSL9.FDATAVALUE,' ') 车系,NVL(ASSL10.FDATAVALUE,' ') 车型,O.FID,OE.FENTRYID
            FROM V_PLN_LOCKSTOCK A
            INNER JOIN T_SAL_ORDERENTRY OE ON A.FBILLDETAILID = OE.FENTRYID AND OE.FQTY - OE.F_PAEZ_LOCKALLOTQTY > 0
            INNER JOIN T_SAL_ORDERENTRY_R OER ON OE.FENTRYID = OER.FENTRYID
            INNER JOIN T_SAL_ORDER O ON OE.FID = O.FID
            INNER JOIN T_BD_MATERIAL MTL ON A.FMATERIALID = MTL.FMATERIALID
            INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
            LEFT JOIN T_BD_MATERIALSTOCK MTLS ON MTL.FMATERIALID = MTLS.FMATERIALID
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY ASS ON MTL.F_PAEZ_SENDTYPE = ASS.FENTRYID
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL2 ON MTL.F_ISBATCHMANAGER = ASSL2.FENTRYID AND ASSL2.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL3 ON MTL.F_ISSNMANAGER = ASSL3.FENTRYID AND ASSL3.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL4 ON O.FHEADDELIVERYWAY = ASSL4.FENTRYID AND ASSL4.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL5 ON MTL.F_PAEZ_BRAND = ASSL5.FENTRYID AND ASSL5.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL6 ON MTL.F_PAEZ_SERIES = ASSL6.FENTRYID AND ASSL6.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL7 ON MTL.F_PAEZ_TRADE = ASSL7.FENTRYID AND ASSL7.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL8 ON MTL.F_PAEZ_COLOR = ASSL8.FENTRYID AND ASSL8.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL9 ON MTL.F_PAEZ_CARSERIES = ASSL9.FENTRYID AND ASSL9.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL10 ON MTL.F_PAEZ_CARTYPE = ASSL10.FENTRYID AND ASSL10.FLOCALEID = 2052
            INNER JOIN T_ORG_ORGANIZATIONS ORG ON A.FOWNERID = ORG.FORGID
            INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON ORG.FORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
            INNER JOIN T_ORG_ORGANIZATIONS ORG2 ON A.FSTOCKORGID = ORG2.FORGID
            INNER JOIN T_ORG_ORGANIZATIONS_L ORGL2 ON ORG2.FORGID = ORGL2.FORGID AND ORGL2.FLOCALEID = 2052
            INNER JOIN T_BD_UNIT UNT ON A.FBASEUNITID = UNT.FUNITID
            INNER JOIN T_BD_UNIT_L UNTL ON UNT.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
            INNER JOIN T_BD_STOCK STK ON A.FSTOCKID = STK.FSTOCKID
            INNER JOIN T_BD_STOCK_L STKL ON STK.FSTOCKID = STKL.FSTOCKID AND STKL.FLOCALEID = 2052
            INNER JOIN T_BD_CUSTOMER CUST ON O.FCUSTID = CUST.FCUSTID
            INNER JOIN T_BD_CUSTOMER_L CUSTL ON CUST.FCUSTID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052
            WHERE " + pFilter + @"
            GROUP BY A.FBILLNO,O.FDATE,A.FOWNERID,ORG.FNUMBER,ORGL.FNAME,A.FOWNERTYPEID,A.FSTOCKORGID,ORG2.FNUMBER,ORGL2.FNAME,A.FMATERIALID,MTL.FNUMBER,MTLL.FNAME,A.FBASEUNITID,UNT.FNUMBER,UNTL.FNAME,OE.F_PAEZ_LOCKALLOTQTY,OER.FBASEDELIQTY,MTL.F_PAEZ_SENDPERCENT,MTLS.F_PAEZ_FMINSENDQTY,A.FSTOCKID,STK.FNUMBER,STKL.FNAME,CUST.FNUMBER,CUSTL.FNAME,ASS.FNUMBER,ASSL2.FDATAVALUE,ASSL3.FDATAVALUE,ASSL4.FDATAVALUE,ASSL5.FDATAVALUE,ASSL6.FDATAVALUE,ASSL7.FDATAVALUE,ASSL8.FDATAVALUE,ASSL9.FDATAVALUE,ASSL10.FDATAVALUE,O.FID,OE.FENTRYID";

            _SQL += strOra.Replace("'", "''");
            _SQL += @"
            ')
            ) O
            LEFT JOIN t_StkTransferOutEntry AE ON O.FENTRYID = AE.orderEntryId
            GROUP BY O.订单编号,O.订单日期,O.货主ID,O.货主代码,O.货主名称,O.货主类型,O.库存组织ID,O.库存组织代码,O.库存组织名称,O.物料ID,O.物料代码,O.物料名称,O.单位ID,O.单位代码,O.单位名称,O.锁库数量,O.锁库调拨数量,O.发货通知数量,O.发料百分比,O.最小发出数量,O.调出仓库ID,O.调出仓库代码,O.调出仓库名称,O.客户代码,O.客户名称,O.调拨类型,O.启用批次,O.启用序列号,O.发货类别,O.品牌,O.系列,O.商品名,O.颜色,O.车系,O.车型,O.FID,O.FENTRYID
            HAVING O.锁库数量 + O.锁库调拨数量 - SUM(ISNULL(AE.FQTY,0)) > 0";

            return SQLHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 成品直接调拨单WMS
        /// </summary>
        /// <param name="pDataTable"></param>
        /// <param name="pList"></param>
        /// <returns></returns>
        public static string TransferDir(DataTable pDataTable, List<string> pList)
        {
            if (pDataTable == null || pDataTable.Rows.Count == 0)
                return "";

            string strBillNo = string.Empty, strBillNos = string.Empty;
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);

            //统计调出仓库
            List<string> lstOutStock = new List<string>();
            for (int i = 0; i < pDataTable.Rows.Count; i++)
            {
                if (!lstOutStock.Contains(pDataTable.Rows[i]["调出仓库代码"].ToString()))
                    lstOutStock.Add(pDataTable.Rows[i]["调出仓库代码"].ToString());
            }

            //根据不同的调出仓库分组生成调拨单
            for (int i = 0; i < lstOutStock.Count; i++)
            {
                //单据编号
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DM_P_GetBillNo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FBillType", SqlDbType.Int);
                    cmd.Parameters.Add("@BillNo", SqlDbType.VarChar, 50);

                    cmd.Parameters["@FBillType"].Value = 1;
                    cmd.Parameters["@BillNo"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    strBillNo = cmd.Parameters["@BillNo"].Value.ToString();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    conn.Close();
                }
                SqlParameter[] parms = new SqlParameter[]
                {
                    new SqlParameter("@BillNo", SqlDbType.VarChar),
                    new SqlParameter("@PickDepartId", SqlDbType.Int),
                    new SqlParameter("@PickDepartNumber", SqlDbType.VarChar),
                    new SqlParameter("@PickDepartName", SqlDbType.VarChar),
                    new SqlParameter("@OwnerInId", SqlDbType.Int),

                    new SqlParameter("@OwnerInNumber", SqlDbType.VarChar),
                    new SqlParameter("@OwnerInName", SqlDbType.VarChar)
                };
                parms[0].Value = strBillNo;
                parms[1].Value = int.Parse(pList[0]);
                parms[2].Value = pList[1];
                parms[3].Value = pList[2];
                parms[4].Value = int.Parse(pDataTable.Rows[0]["货主ID"].ToString());

                parms[5].Value = pDataTable.Rows[0]["货主代码"].ToString();
                parms[6].Value = pDataTable.Rows[0]["货主名称"].ToString();

                _SQL = @"BEGIN TRANSACTION
                INSERT INTO t_StkTransferOut(billNo,transferDirect,bizType,outOrgID,outOrgNumber,outOrgName,inOrgId,inOrgNumber,inOrgName,settleOrgId,settleOrgNumber,settleOrgName,billDate,businessType,billStatus,transferBizType,pickType,pickDepartId,pickDepartNumber,pickDepartName,stockManagerId,stockManagerNumber,stockManagerName,ownerTypeOut,ownerOutId,ownerOutNumber,ownerOutName,ownerTypeIn,ownerInId,ownerInNumber,ownerInName)
                VALUES(@BillNo,'General','Standard ',100508,'HN02','河南工厂',100508,'HN02','河南工厂',100508,'HN02','河南工厂',GETDATE(),3,1,'InnerOrgTransfer',1,@PickDepartId,@PickDepartNumber,@PickDepartName,0,'','','BD_OwnerOrg',100508,'HN02','河南工厂','BD_OwnerOrg',@OwnerInId,@OwnerInNumber,@OwnerInName);
                DECLARE @stkBillId INT 
                SELECT @stkBillId = id FROM t_StkTransferOut WHERE billNo = @BillNo;";

                for (int j = 0; j < pDataTable.Rows.Count; j++)
                {
                    if (pDataTable.Rows[j]["调出仓库代码"].ToString() != lstOutStock[i]) continue;

                    _SQL += @"
                    INSERT INTO t_StkTransferOutEntry(stkBillId,mtlId,mtlFnumber,mtlFname,inStockId,inStockNumber,inStockName,outStockId,outStockNumber,outStockName,unitId,unitFumber,unitFname,fqty,needFqty,pickFqty,lockQty,deliveryQty,deliveryWayName,orderDate,brandName,seriesName,productName,carSeriesName,carTypeName,colorName,custNumber,custName,orderNo,orderId,orderEntryId)
                    VALUES(@stkBillId," + pDataTable.Rows[j]["物料ID"].ToString() + ",'" + pDataTable.Rows[j]["物料代码"].ToString() + "','" + pDataTable.Rows[j]["物料名称"].ToString() + "'," + pList[3] + ",'" + pList[4] + "','" + pList[5] + "'," + pDataTable.Rows[j]["调出仓库ID"].ToString() + ",'" + pDataTable.Rows[j]["调出仓库代码"].ToString() + "','" + pDataTable.Rows[j]["调出仓库名称"].ToString() + "'," + pDataTable.Rows[j]["单位ID"].ToString() + ",'" + pDataTable.Rows[j]["单位代码"].ToString() + "','" + pDataTable.Rows[j]["单位名称"].ToString() + "'," + pDataTable.Rows[j]["锁库数量"].ToString() + "," + pDataTable.Rows[j]["锁库数量"].ToString() + ",0," + pDataTable.Rows[j]["锁库数量"].ToString() + "," + pDataTable.Rows[j]["发货通知数量"].ToString() + ",'" + pDataTable.Rows[j]["发货类别"].ToString() + "','" + pDataTable.Rows[j]["订单日期"].ToString() + "','" + pDataTable.Rows[j]["品牌"].ToString() + "','" + pDataTable.Rows[j]["系列"].ToString() + "','" + pDataTable.Rows[j]["商品名"].ToString() + "','" + pDataTable.Rows[j]["车系"].ToString() + "','" + pDataTable.Rows[j]["车型"].ToString() + "','" + pDataTable.Rows[j]["颜色"].ToString() + "','" + pDataTable.Rows[j]["客户代码"].ToString() + "','" + pDataTable.Rows[j]["客户名称"].ToString() + "','" + pDataTable.Rows[j]["订单编号"].ToString() + "'," + pDataTable.Rows[j]["FID"].ToString() + "," + pDataTable.Rows[j]["FENTRYID"].ToString() + ");";
                }

                _SQL += @"
                IF @@ERROR = 0
                BEGIN
	                COMMIT
	                SELECT @BillNo
                END
                ELSE
                BEGIN
	                ROLLBACK
	                SELECT ''
                END";

                strBillNo = SQLHelper.ExecuteScalar(_SQL, parms).ToString();

                if (strBillNo != "")
                    strBillNos += "[" + strBillNo + "]";
            }

            return strBillNos;
        }

        /// <summary>
        /// 更新已经生成调拨单字段状态（半成品）ERP
        /// </summary>
        /// <param name="pFNeedDate">需求日期</param>
        /// <param name="pDeptNos">部门</param>
        /// <param name="pList">根据调出仓排除更新</param>
        public static void UpdateDirFields(string pFNeedDate, string pDeptNos, List<string> pList)
       {
            if (pList.Count > 0)
            {
                string strOutStock = string.Empty;

                for (int i = 0; i < pList.Count; i++)
                {
                    strOutStock += "'" + pList[i] + "',";
                }
                strOutStock = strOutStock.Substring(0, strOutStock.Length - 1);

                _SQL = @"UPDATE T_PRD_PPBOMENTRY
                SET FPAEZHAVEDIRECT = 1
                WHERE FPAEZHAVEDIRECT = 0 AND FENTRYID IN
                (
                SELECT AE.FENTRYID
                FROM T_PRD_PPBOMENTRY AE
                INNER JOIN T_PRD_PPBOM A ON AE.FID = A.FID AND A.FDOCUMENTSTATUS = 'C'
                INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID AND TO_CHAR(MOE.FPLANSTARTDATE, 'yyyy-mm-dd') = TO_CHAR(AE.FNEEDDATE, 'yyyy-mm-dd')
                INNER JOIN T_PRD_MO MO ON MOE.FID = MO.FID AND MO.FDOCUMENTSTATUS = 'C'
                INNER JOIN T_PRD_MOENTRY_A MOA ON AE.FMOENTRYID = MOA.FENTRYID AND MOA.FSTATUS IN(3,4)
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508
                INNER JOIN T_BD_DEPARTMENT DEP ON MOE.FWORKSHOPID = DEP.FDEPTID
                INNER JOIN T_BD_STOCK STK ON DEP.FINSTOCKID = STK.FSTOCKID
                INNER JOIN T_AUTO_MSTOCKSETTING MST ON AE.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID
                INNER JOIN T_BD_STOCK STK2 ON MST.FSTOCKID = STK2.FSTOCKID
                WHERE AE.FPAEZHAVEDIRECT = 0 AND STK.FNUMBER <> STK2.FNUMBER AND TO_CHAR(AE.FNEEDDATE, 'yyyy-MM-dd') = '" + pFNeedDate + "' AND DEP.FNUMBER IN(" + pDeptNos + ") AND STK2.FNUMBER NOT IN(" + strOutStock + @")
                GROUP BY MTL.FNUMBER,STK.FNUMBER,STK2.FNUMBER,DEP.FNUMBER,AE.FENTRYID
                )";
            }
            else
                _SQL = @"UPDATE T_PRD_PPBOMENTRY
                SET FPAEZHAVEDIRECT = 1
                WHERE FPAEZHAVEDIRECT = 0 AND FENTRYID IN
                (
                SELECT AE.FENTRYID
                FROM T_PRD_PPBOMENTRY AE
                INNER JOIN T_PRD_PPBOM A ON AE.FID = A.FID AND A.FDOCUMENTSTATUS = 'C'
                INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID AND TO_CHAR(MOE.FPLANSTARTDATE, 'yyyy-mm-dd') = TO_CHAR(AE.FNEEDDATE, 'yyyy-mm-dd')
                INNER JOIN T_PRD_MO MO ON MOE.FID = MO.FID AND MO.FDOCUMENTSTATUS = 'C'
                INNER JOIN T_PRD_MOENTRY_A MOA ON AE.FMOENTRYID = MOA.FENTRYID AND MOA.FSTATUS IN(3,4)
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508
                INNER JOIN T_BD_DEPARTMENT DEP ON MOE.FWORKSHOPID = DEP.FDEPTID
                INNER JOIN T_BD_STOCK STK ON DEP.FINSTOCKID = STK.FSTOCKID
                INNER JOIN T_AUTO_MSTOCKSETTING MST ON AE.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID
                INNER JOIN T_BD_STOCK STK2 ON MST.FSTOCKID = STK2.FSTOCKID
                WHERE AE.FPAEZHAVEDIRECT = 0 AND STK.FNUMBER <> STK2.FNUMBER AND TO_CHAR(AE.FNEEDDATE,'yyyy-MM-dd') = '" + pFNeedDate + "' AND DEP.FNUMBER IN(" + pDeptNos + @")
                GROUP BY MTL.FNUMBER,STK.FNUMBER,STK2.FNUMBER,DEP.FNUMBER,AE.FENTRYID
                )";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 更新已经生成调拨单字段状态（半成品）WMS
        /// </summary>
        /// <param name="pFNeedDate"></param>
        public static void UpdateDirFieldsWMS(string pFNeedDate, List<string> pList)
        {
            _SQL = @"UPDATE T_PRD_PPBOMENTRY
            SET FPAEZHAVEDIRECT = 1
            WHERE FPAEZHAVEDIRECT = 0 AND FENTRYID IN
            (
            SELECT A.FENTRYID
            FROM T_PRD_PPBOMENTRY A
            INNER JOIN T_PRD_PPBOM E ON A.FID = E.FID AND E.FDOCUMENTSTATUS = 'C'
            INNER JOIN T_PRD_MOENTRY G ON A.FMOENTRYID = G.FENTRYID AND TO_CHAR(G.FPLANSTARTDATE,'yyyy-mm-dd') = TO_CHAR(A.FNEEDDATE,'yyyy-mm-dd')
            INNER JOIN T_PRD_MO H ON G.FID = H.FID AND H.FDOCUMENTSTATUS = 'C'
            INNER JOIN T_PRD_MOENTRY_A I ON A.FMOENTRYID = I.FENTRYID AND I.FSTATUS IN(3,4)
            INNER JOIN T_BD_MATERIAL J ON A.FMATERIALID = J.FMATERIALID AND J.FUSEORGID = 100508
            INNER JOIN T_BD_DEPARTMENT L ON G.FWORKSHOPID = L.FDEPTID
            INNER JOIN T_BD_STOCK M ON L.FINSTOCKID = M.FSTOCKID
            INNER JOIN T_AUTO_MSTOCKSETTING N ON A.FMATERIALID = N.FMATERIALID AND L.FDEPTID = N.FDEPTID
            INNER JOIN T_BD_STOCK O ON N.FSTOCKID = O.FSTOCKID
            WHERE A.FPAEZHAVEDIRECT = 0 AND M.FNUMBER <> O.FNUMBER AND TO_CHAR(A.FNEEDDATE,'yyyy-mm-dd') = '" + pFNeedDate + @"'
            GROUP BY J.FNUMBER, M.FNUMBER, O.FNUMBER, L.FNUMBER, A.FENTRYID
            )";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        public static void UpdateDirFieldsWMS(DataTable pDataTable)
        {
            _SQL = "BEGIN";
            for (int i = 0; i < pDataTable.Rows.Count; i++)
            {
                _SQL += @"
                UPDATE T_SAL_ORDERENTRY SET F_PAEZ_LOCKALLOTQTY = F_PAEZ_LOCKALLOTQTY + " + pDataTable.Rows[i]["锁库数量"].ToString() + " WHERE FENTRYID = " + pDataTable.Rows[i]["FENTRYID"].ToString() + ";";
            }
            _SQL += @"
            COMMIT;            
            DBMS_OUTPUT.PUT_LINE('成功');
            EXCEPTION
                WHEN OTHERS THEN 
                ROLLBACK;
                DBMS_OUTPUT.PUT_LINE('失败：');
                DBMS_OUTPUT.PUT_LINE(SQLERRM);
            END;";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 检查当前开工日期是否所有物料都设置了默认仓库
        /// </summary>
        /// <param name="pDateTime">开工日期</param>
        /// <returns></returns>
        public static bool SetDefaultStock(DateTime pDateTime)
        {
            _SQL = @"SELECT COUNT(*)
            FROM T_PRD_MO A
            INNER JOIN T_PRD_MOENTRY AE ON A.FID = AE.FID
            INNER JOIN T_PRD_MOENTRY_A AA ON AE.FENTRYID = AA.FENTRYID AND AA.FSTATUS IN(3,4)
            INNER JOIN T_BD_DEPARTMENT DEP ON AE.FWORKSHOPID = DEP.FDEPTID
            INNER JOIN T_PRD_PPBOMENTRY PBE ON AE.FENTRYID = PBE.FMOENTRYID
            INNER JOIN T_BD_MATERIAL MTL ON PBE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508
            LEFT JOIN T_AUTO_MSTOCKSETTING MST ON MTL.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID
            WHERE (MST.FMATERIALID IS NULL OR MST.FSTOCKID IS NULL) AND A.FDOCUMENTSTATUS = 'C' AND A.FPRDORGID = 100508 AND TO_CHAR(AE.FPLANSTARTDATE,'yyyy-mm-dd') = '" + pDateTime.ToString("yyyy-MM-dd") + "'";

            _obj = ORAHelper.ExecuteScalar(_SQL);

            if (_obj == null || int.Parse(_obj.ToString()) != 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 用料清单的需求日期与生产订单的计划开工时间不一致的用料清单数量
        /// </summary>
        /// <param name="pFrom">开始时间</param>
        /// <param name="pTo">结束时间</param>
        /// <returns></returns>
        public static int Asyn_PPBom_FNeedDate(DateTime pFrom, DateTime pTo)
        {
            _SQL = @"SELECT COUNT(BE.FENTRYID)
            FROM T_PRD_PPBOM A
            INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID
            LEFT JOIN T_PRD_MOENTRY BE ON AE.FMOENTRYID = BE.FENTRYID
            LEFT JOIN T_PRD_MO B ON BE.FID = B.FID
            WHERE TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') <> TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') AND BE.FPLANSTARTDATE BETWEEN TO_DATE('" + pFrom.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pTo.ToString("yyyy-MM-dd") + "','yyyy-mm-dd')";

            return int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString());
        }

        /// <summary>
        /// 同步用料清单的需求日期为生产订单的计划开工时间
        /// </summary>
        /// <param name="pFrom">开始时间</param>
        /// <param name="pTo">结束时间</param>
        public static void Syn_PPBom_FNeedDate(DateTime pFrom, DateTime pTo)
        {
            _SQL = @"UPDATE T_PRD_PPBOMENTRY AE SET FNEEDDATE = 
            (
            SELECT FPLANSTARTDATE FROM T_PRD_MOENTRY BE WHERE AE.FMOENTRYID = BE.FENTRYID AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') <> TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') AND BE.FPLANSTARTDATE BETWEEN TO_DATE('" + pFrom.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pTo.ToString("yyyy-MM-dd") + @"','yyyy-mm-dd')
            )
            WHERE EXISTS
            (
            SELECT 1 FROM T_PRD_MOENTRY BE WHERE AE.FMOENTRYID = BE.FENTRYID AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') <> TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') AND BE.FPLANSTARTDATE BETWEEN TO_DATE('" + pFrom.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pTo.ToString("yyyy-MM-dd") + @"','yyyy-mm-dd')
            )";
            ORAHelper.ExecuteNonQuery(_SQL);
        }
    }
}
