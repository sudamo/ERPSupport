using System;
using System.Data;
using System.Collections;
using ERPSupport.Model.Globa;
using Newtonsoft.Json.Linq;
using Kingdee.BOS.WebApi.Client;

namespace ERPSupport.SQL.K3Cloud
{
    /// <summary>
    /// 调拨
    /// </summary>
    public static class PrdAllocation
    {
        #region STATIC
        private static string strSQL;
        private static object obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        static PrdAllocation()
        {
            strSQL = string.Empty;
            obj = new object();
        }
        #endregion

        /// <summary>
        /// 获取调拨单数据
        /// </summary>
        /// <param name="pFNeedDate">需求日期</param>
        /// <param name="pDeptNos">部门</param>
        /// <returns></returns>
        public static DataTable GetTransferDirectDt(string pFNeedDate, string pDeptNos)
        {
            strSQL = @"SELECT ORG.FNUMBER 调入库存组织, NVL(ORG2.FNUMBER, 'HN02') 货主, AC.FOWNERTYPEID 货主类型, MTL.FNUMBER 物料编码,UNT.FNUMBER 单位
                , STK.FNUMBER 调入仓库, STK2.FNUMBER 调出仓库, DEP.FNUMBER 领料部门, SUM(AE.FMUSTQTY) 调拨数量
            FROM T_PRD_PPBOM A
            INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID
            INNER JOIN T_PRD_PPBOMENTRY_C AC ON AE.FENTRYID = AC.FENTRYID
            INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID AND TO_CHAR(MOE.FPLANSTARTDATE,'yyyy-MM-dd') = TO_CHAR(AE.FNEEDDATE,'yyyy-MM-dd')
            INNER JOIN T_PRD_MO MO ON MO.FID = MOE.FID AND MO.FDOCUMENTSTATUS = 'C'
            INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID AND MOA.FSTATUS = 4
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

            return ORAHelper.ExecuteTable(strSQL);
        }

        /// <summary>
        /// 生成直接调拨单
        /// </summary>
        /// <param name="pDT">数据表</param>
        /// <param name="pDate">日期</param>
        /// <returns></returns>
        public static string TransferDirect(DataTable pDT, DateTime pDate)
        {
            if (pDT.Rows.Count <= 0)
                return "";

            string strPMBillNO = string.Empty;

            K3CloudApiClient client = new K3CloudApiClient(GlobalParameter.K3Inf.C_ERPADDRESS);
            var bLogin = client.Login(GlobalParameter.K3Inf.C_ZTID, GlobalParameter.K3Inf.C_USERNAME, GlobalParameter.K3Inf.C_PASSWORD, 2052);

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
                basedata.Add("FNumber", pDT.Rows[0]["调入库存组织"].ToString());
                model.Add("FSettleOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDT.Rows[0]["调入库存组织"].ToString());
                model.Add("FSaleOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDT.Rows[0]["调入库存组织"].ToString());
                model.Add("FStockOutOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDT.Rows[0]["调入库存组织"].ToString());
                model.Add("FStockOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDT.Rows[0]["领料部门"].ToString());
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
                for (int i = 0; i < pDT.Rows.Count; i++)
                {
                    JObject entryRow = new JObject();
                    entryRows.Add(entryRow);
                    entryRow.Add("FEntryID", 0);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDT.Rows[i]["物料编码"].ToString());
                    entryRow.Add("FMaterialId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDT.Rows[i]["物料编码"].ToString());
                    entryRow.Add("FDestMaterialId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDT.Rows[i]["单位"].ToString());
                    entryRow.Add("FUnitID", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDT.Rows[i]["单位"].ToString());
                    entryRow.Add("FBaseUnitId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDT.Rows[i]["单位"].ToString());
                    entryRow.Add("FPriceUnitID", basedata);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDT.Rows[i]["调出仓库"].ToString());
                    entryRow.Add("FSrcStockId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDT.Rows[i]["调入仓库"].ToString());
                    entryRow.Add("FDestStockId", basedata);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDT.Rows[i]["货主"].ToString());
                    entryRow.Add("FOwnerId", basedata);
                    entryRow.Add("FOwnerTypeId", "BD_OwnerOrg");
                    basedata = new JObject();
                    basedata.Add("FNumber", pDT.Rows[i]["货主"].ToString());
                    entryRow.Add("FOwnerOutId", basedata);
                    entryRow.Add("FOwnerTypeOutId", "BD_OwnerOrg");

                    entryRow.Add("FQty", pDT.Rows[i]["调拨数量"].ToString());
                    entryRow.Add("FPAEZAskQty", 0);
                    entryRow.Add("FBaseQty", pDT.Rows[i]["调拨数量"].ToString());
                    entryRow.Add("FActQty", pDT.Rows[i]["调拨数量"].ToString());
                    entryRow.Add("FPriceQty", pDT.Rows[i]["调拨数量"].ToString());
                    entryRow.Add("FPriceBaseQty", pDT.Rows[i]["调拨数量"].ToString());
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
        /// 更新已经生成调拨单字段状态
        /// </summary>
        /// <param name="pFNeedDate">需求日期</param>
        /// <param name="pDeptNos">部门</param>
        public static void UpdateDirectFields(string pFNeedDate, string pDeptNos)
        {
            strSQL = @"UPDATE T_PRD_PPBOMENTRY
            SET FPAEZHAVEDIRECT = 1
            WHERE FPAEZHAVEDIRECT = 0 AND FENTRYID IN
            (SELECT A.FENTRYID
            FROM T_PRD_PPBOMENTRY A
            INNER JOIN T_PRD_PPBOM E ON A.FID = E.FID AND E.FDOCUMENTSTATUS = 'C'
            INNER JOIN T_PRD_MOENTRY G ON A.FMOENTRYID = G.FENTRYID AND TO_CHAR(G.FPLANSTARTDATE,'yyyy-MM-dd') = TO_CHAR(A.FNEEDDATE,'yyyy-MM-dd')
            INNER JOIN T_PRD_MO H ON G.FID = H.FID AND H.FDOCUMENTSTATUS = 'C'
            INNER JOIN T_PRD_MOENTRY_A I ON A.FMOENTRYID = I.FENTRYID AND I.FSTATUS = 4
            INNER JOIN T_BD_MATERIAL J ON A.FMATERIALID = J.FMATERIALID AND J.FUSEORGID = 100508
            INNER JOIN T_BD_DEPARTMENT L ON G.FWORKSHOPID = L.FDEPTID
            INNER JOIN T_BD_STOCK M ON L.FINSTOCKID = M.FSTOCKID
            INNER JOIN T_AUTO_MSTOCKSETTING N ON A.FMATERIALID = N.FMATERIALID AND L.FDEPTID = N.FDEPTID
            INNER JOIN T_BD_STOCK O ON N.FSTOCKID = O.FSTOCKID
            WHERE A.FPAEZHAVEDIRECT = 0 AND M.FNUMBER <> O.FNUMBER AND TO_CHAR(A.FNEEDDATE,'yyyy-MM-dd') = '" + pFNeedDate + "' AND L.FNUMBER IN(" + pDeptNos + @")
            GROUP BY J.FNUMBER, M.FNUMBER, O.FNUMBER, L.FNUMBER, A.FENTRYID)";

            ORAHelper.ExecuteNonQuery(strSQL);
        }

        /// <summary>
        /// 检查当前开工日期是否所有物料都设置了默认仓库
        /// </summary>
        /// <param name="pDateTime">开工日期</param>
        /// <returns></returns>
        public static bool SetDefaultStock(DateTime pDateTime)
        {
            strSQL = @"SELECT COUNT(*)
            FROM T_PRD_MO A
            INNER JOIN T_PRD_MOENTRY AE ON A.FID = AE.FID
            INNER JOIN T_PRD_MOENTRY_A AA ON AE.FENTRYID = AA.FENTRYID AND AA.FSTATUS = 4
            INNER JOIN T_BD_DEPARTMENT DEP ON AE.FWORKSHOPID = DEP.FDEPTID
            INNER JOIN T_PRD_PPBOMENTRY PBE ON AE.FENTRYID = PBE.FMOENTRYID
            INNER JOIN T_BD_MATERIAL MTL ON PBE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508
            LEFT JOIN T_AUTO_MSTOCKSETTING MST ON MTL.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID
            WHERE (MST.FMATERIALID IS NULL OR MST.FSTOCKID IS NULL) AND A.FDOCUMENTSTATUS = 'C' AND A.FPRDORGID = 100508 AND TO_CHAR(AE.FPLANSTARTDATE,'yyyy-mm-dd') = '" + pDateTime.ToString("yyyy-MM-dd") + "'";

            obj = ORAHelper.ExecuteScalar(strSQL);

            if (obj == null || int.Parse(obj.ToString()) != 0)
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
            strSQL = @"SELECT COUNT(BE.FENTRYID)
            FROM T_PRD_PPBOM A
            INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID
            LEFT JOIN T_PRD_MOENTRY BE ON AE.FMOENTRYID = BE.FENTRYID
            LEFT JOIN T_PRD_MO B ON BE.FID = B.FID
            WHERE TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') <> TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') AND BE.FPLANSTARTDATE BETWEEN TO_DATE('" + pFrom.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pTo.ToString("yyyy-MM-dd") + "','yyyy-mm-dd')";

            return int.Parse(ORAHelper.ExecuteScalar(strSQL).ToString());
        }

        /// <summary>
        /// 同步用料清单的需求日期为生产订单的计划开工时间
        /// </summary>
        /// <param name="pFrom">开始时间</param>
        /// <param name="pTo">结束时间</param>
        public static void Syn_PPBom_FNeedDate(DateTime pFrom, DateTime pTo)
        {
            strSQL = @"UPDATE T_PRD_PPBOMENTRY AE SET FNEEDDATE = 
            (
            SELECT FPLANSTARTDATE FROM T_PRD_MOENTRY BE WHERE AE.FMOENTRYID = BE.FENTRYID AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') <> TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') AND BE.FPLANSTARTDATE BETWEEN TO_DATE('" + pFrom.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pTo.ToString("yyyy-MM-dd") + @"','yyyy-mm-dd')
            )
            WHERE EXISTS
            (
            SELECT 1 FROM T_PRD_MOENTRY BE WHERE AE.FMOENTRYID = BE.FENTRYID AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') <> TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') AND BE.FPLANSTARTDATE BETWEEN TO_DATE('" + pFrom.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pTo.ToString("yyyy-MM-dd") + @"','yyyy-mm-dd')
            )";
            ORAHelper.ExecuteNonQuery(strSQL);
        }
    }
}
