using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Kingdee.BOS.WebApi.Client;

namespace ERPSupport.SQL.K3Cloud
{
    using Model.Globa;
    using IDAL.K3Cloud;

    /// <summary>
    /// 调拨
    /// </summary>
    public class PrdAllocation : IPrdAllocation
    {
        #region STATIC
        private static string _SQL;
        private static object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PrdAllocation()
        {
            _SQL = string.Empty;
            _obj = new object();
        }
        #endregion

        /// <summary>
        /// 获取调拨单数据-PZ-WMS
        /// </summary>
        /// <param name="pFNeedDate">需求日期</param>
        /// <param name="pStockID">调出仓库</param>
        /// <param name="pDeptID">领料部门</param>
        /// <returns></returns>
        public DataTable GetTransPZ(string pFNeedDate, int pStockID, int pDeptID)//盆子仓
        {
            _SQL = "SELECT AC.FOWNERID 货主,NVL(ORG.FNUMBER, 'HN02') 货主编码,NVL(ORGL.FNAME, '河南工厂') 货主名称, AC.FOWNERTYPEID 货主类型,AE.FMATERIALID 物料,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称, AE.FUNITID 单位,UNT.FNUMBER 单位编码,UNTL.FNAME 单位名称,MOE.FWORKSHOPID 领料部门,DEP.FNUMBER 领料部门编码,DEPL.FNAME 领料部门名称, AC.FSUPPLYORG 调入库存组织,NVL(ORG2.FNUMBER,' ') 调入库存组织编码,NVL(ORGL2.FNAME,' ') 调入库存组织名称,DEP.FINSTOCKID 调入仓库,STK2.FNUMBER 调入仓库编码,STKL2.FNAME 调入仓库名称,STK2.FDEFSTOCKSTATUSID 调入库存状态,STT2.FNUMBER 调入库存状态编码,STTL2.FNAME 调入库存状态名称, AC.FSRCTRANSORGID 调出库存组织,NVL(ORG3.FNUMBER,' ') 调出库存组织编码,NVL(ORGL3.FNAME,' ') 调出库存组织名称,MST.FSTOCKID 调出仓库,STK3.FNUMBER 调出仓库编码,STKL3.FNAME 调出仓库名称,STK3.FDEFSTOCKSTATUSID 调出库存状态,STT3.FNUMBER 调出库存状态编码,STTL3.FNAME 调出库存状态名称, AC.FLOT 批号,MOE.FQTY 调拨数量,NVL(MOE.FPRODUCTIONSEQ, ' ') 生产顺序号,TO_CHAR(MOE.F_PAEZ_DESCRIPTION) 生产订单备注,NVL(MTLSK.F_PAEZ_FMinsendQty,0) 最小批量,MTL.F_PAEZ_SENDPERCENT 发料百分比, NVL(ASS.FNUMBER,' ') 调拨类型,NVL(ASSL2.FDATAVALUE,' ') 启用批次,NVL(ASSL3.FDATAVALUE,' ') 启用序列号,NVL(ASSL4.FDATAVALUE,' ') 发货类别";
            _SQL += string.Format(" ,CASE WHEN A.FUNITID = 101045 THEN CEIL(MOE.FQTY/{0}) ELSE A.FQTY END 合并数量,CASE WHEN MOE.FHeadDeliveryWay = '58709fcc96a192' AND MOE.FQTY >= 10 THEN 1 ELSE 0 END 大单 ", GlobalParameter.Dir_DPQtyPZ);
            _SQL += @" FROM T_PRD_PPBOM A
INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID AND AE.F_PAEZ_PICKTOWMS = 0 AND AE.FPAEZHAVEDIRECT = 0
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
INNER JOIN T_BD_STOCKSTATUS_L STTL3 ON STT3.FSTOCKSTATUSID = STTL3.FSTOCKSTATUSID AND STTL3.FLOCALEID = 2052 ";
            _SQL += string.Format(" WHERE A.FDOCUMENTSTATUS = 'C' AND STK2.FNUMBER <> STK3.FNUMBER AND MST.FSTOCKID = 897784 AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') = '{0}'", pFNeedDate);

            if (pStockID != 0)
                _SQL += string.Format(" AND MST.FSTOCKID = {0}", pStockID);
            if (pDeptID != 0)
                _SQL += string.Format(" AND MOE.FWORKSHOPID = {0}", pDeptID);

            _SQL += " ORDER BY MOE.FPRODUCTIONSEQ";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取调拨单数据-CL-ERP
        /// </summary>
        /// <param name="pFNeedDate">需求日期</param>
        /// <param name="pStockID">调出仓库</param>
        /// <param name="pDeptID">领料部门</param>
        /// <param name="pCondition">指定条件</param>
        /// <returns></returns>
        public DataTable GetTransCL(string pFNeedDate, int pStockID, int pDeptID, string pCondition)
        {
            _SQL = "SELECT AC.FOWNERID 货主,NVL(ORG.FNUMBER, 'HN02') 货主编码,NVL(ORGL.FNAME, '河南工厂') 货主名称, AC.FOWNERTYPEID 货主类型,AE.FMATERIALID 物料,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称,AE.FUNITID 单位,UNT.FNUMBER 单位编码,UNTL.FNAME 单位名称,MOE.FWORKSHOPID 领料部门,DEP.FNUMBER 领料部门编码,DEPL.FNAME 领料部门名称,AC.FSUPPLYORG 调入库存组织,NVL(ORG2.FNUMBER,' ') 调入库存组织编码,NVL(ORGL2.FNAME,' ') 调入库存组织名称,DEP.FINSTOCKID 调入仓库,STK2.FNUMBER 调入仓库编码,STKL2.FNAME 调入仓库名称,STK2.FDEFSTOCKSTATUSID 调入库存状态,STT2.FNUMBER 调入库存状态编码,STTL2.FNAME 调入库存状态名称,AC.FSRCTRANSORGID 调出库存组织,NVL(ORG3.FNUMBER,' ') 调出库存组织编码,NVL(ORGL3.FNAME,' ') 调出库存组织名称,MST.FSTOCKID 中间仓库,STK3.FNUMBER 中间仓库编码,STKL3.FNAME 中间仓库名称,STK3.FDEFSTOCKSTATUSID 调出库存状态,STT3.FNUMBER 调出库存状态编码,STTL3.FNAME 调出库存状态名称,AC.FLOT 批号,SUM(AE.FMUSTQTY) 调拨数量,N' ' 生产顺序号,' ' 生产订单备注,NVL(MTLSK.F_PAEZ_FMinsendQty,0) 最小批量,MTL.F_PAEZ_SENDPERCENT 发料百分比,NVL(ASS.FNUMBER,' ') 调拨类型,NVL(ASSL2.FDATAVALUE,' ') 启用批次,NVL(ASSL3.FDATAVALUE,' ') 启用序列号,N' ' 发货类别 ";
            _SQL += " FROM T_PRD_PPBOM A ";
            _SQL += " INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID AND AE.F_PAEZ_PICKTOWMS = 0 AND AE.FPAEZHAVEDIRECT = 0 ";
            _SQL += " INNER JOIN T_PRD_PPBOMENTRY_C AC ON AE.FENTRYID = AC.FENTRYID ";
            _SQL += " INNER JOIN T_PRD_PPBOMENTRY_Q AQ ON AE.FENTRYID = AQ.FENTRYID ";
            _SQL += " INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID AND TO_CHAR(MOE.FPLANSTARTDATE,'yyyy-mm-dd') = TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') ";
            _SQL += " INNER JOIN T_PRD_MO MO ON MO.FID = MOE.FID AND MO.FDOCUMENTSTATUS = 'C' ";
            _SQL += " INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID AND MOA.FSTATUS IN(3,4) ";
            _SQL += " INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508 ";
            _SQL += " INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052 ";
            _SQL += " LEFT JOIN T_BD_MATERIALSTOCK MTLSK ON MTL.FMATERIALID = MTLSK.FMATERIALID ";
            _SQL += " INNER JOIN T_BD_UNIT UNT ON AE.FUNITID = UNT.FUNITID ";
            _SQL += " INNER JOIN T_BD_UNIT_L UNTL ON UNT.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052 ";
            _SQL += " INNER JOIN T_BD_DEPARTMENT DEP ON MOE.FWORKSHOPID = DEP.FDEPTID ";
            _SQL += " INNER JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052 ";
            _SQL += " LEFT JOIN T_ORG_ORGANIZATIONS ORG ON AC.FOWNERID = ORG.FORGID ";
            _SQL += " LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL ON ORG.FORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052 ";
            _SQL += " LEFT JOIN T_ORG_ORGANIZATIONS ORG2 ON AC.FSUPPLYORG = ORG2.FORGID ";
            _SQL += " LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL2 ON ORG2.FORGID = ORGL2.FORGID AND ORGL2.FLOCALEID = 2052 ";
            _SQL += " LEFT JOIN T_ORG_ORGANIZATIONS ORG3 ON AC.FSRCTRANSORGID = ORG3.FORGID ";
            _SQL += " LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL3 ON ORG3.FORGID = ORGL3.FORGID AND ORGL3.FLOCALEID = 2052 ";
            _SQL += " LEFT JOIN T_BAS_ASSISTANTDATAENTRY ASS ON MTL.F_PAEZ_SENDTYPE = ASS.FENTRYID ";
            _SQL += " LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL2 ON MTL.F_ISBATCHMANAGER = ASSL2.FENTRYID AND ASSL2.FLOCALEID = 2052 ";
            _SQL += " LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL3 ON MTL.F_ISSNMANAGER = ASSL3.FENTRYID AND ASSL3.FLOCALEID = 2052 ";
            _SQL += " LEFT JOIN T_SAL_ORDER O ON MOE.FSALEORDERID = O.FID ";
            _SQL += " LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL4 ON O.FHEADDELIVERYWAY = ASSL4.FENTRYID AND ASSL4.FLOCALEID = 2052 ";
            _SQL += " INNER JOIN T_BD_STOCK STK2 ON DEP.FINSTOCKID = STK2.FSTOCKID ";
            _SQL += " INNER JOIN T_BD_STOCK_L STKL2 ON STK2.FSTOCKID = STKL2.FSTOCKID AND STKL2.FLOCALEID = 2052 ";
            _SQL += " INNER JOIN T_BD_STOCKSTATUS STT2 ON STK2.FDEFSTOCKSTATUSID = STT2.FSTOCKSTATUSID ";
            _SQL += " INNER JOIN T_BD_STOCKSTATUS_L STTL2 ON STT2.FSTOCKSTATUSID = STTL2.FSTOCKSTATUSID AND STTL2.FLOCALEID = 2052 ";
            _SQL += " INNER JOIN T_AUTO_MSTOCKSETTING MST ON AE.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID AND MST.FTRANSTOCKID = 0 ";
            _SQL += " INNER JOIN T_BD_STOCK STK3 ON MST.FSTOCKID = STK3.FSTOCKID ";
            _SQL += " INNER JOIN T_BD_STOCK_L STKL3 ON STK3.FSTOCKID = STKL3.FSTOCKID AND STKL3.FLOCALEID = 2052 ";
            _SQL += " INNER JOIN T_BD_STOCKSTATUS STT3 ON STK3.FDEFSTOCKSTATUSID = STT3.FSTOCKSTATUSID ";
            _SQL += " INNER JOIN T_BD_STOCKSTATUS_L STTL3 ON STT3.FSTOCKSTATUSID = STTL3.FSTOCKSTATUSID AND STTL3.FLOCALEID = 2052 ";
            _SQL += string.Format(" WHERE A.FDOCUMENTSTATUS = 'C' AND STK2.FNUMBER <> STK3.FNUMBER AND MST.FSTOCKID != 897784 AND STK3.FALLOWSUM = '1' AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') = '{0}'", pFNeedDate);

            if (pStockID != 0)
                _SQL += " AND MST.FSTOCKID = " + pStockID;
            if (pDeptID != 0)
                _SQL += " AND MOE.FWORKSHOPID = " + pDeptID;
            if (pCondition != string.Empty)
                _SQL += " AND" + pCondition;

            _SQL += " GROUP BY AC.FOWNERID,ORG.FNUMBER,ORGL.FNAME, AC.FOWNERTYPEID,AE.FMATERIALID,MTL.FNUMBER,MTLL.FNAME,AE.FUNITID,UNT.FNUMBER,UNTL.FNAME,MOE.FWORKSHOPID,DEP.FNUMBER,DEPL.FNAME,AC.FSUPPLYORG,ORG2.FNUMBER,ORGL2.FNAME,DEP.FINSTOCKID,STK2.FNUMBER,STKL2.FNAME,STK2.FDEFSTOCKSTATUSID,STT2.FNUMBER,STTL2.FNAME,AC.FSRCTRANSORGID,ORG3.FNUMBER,ORGL3.FNAME,MST.FSTOCKID,STK3.FNUMBER,STKL3.FNAME,STK3.FDEFSTOCKSTATUSID,STT3.FNUMBER,STTL3.FNAME,AC.FLOT,MTLSK.F_PAEZ_FMinsendQty,MTL.F_PAEZ_SENDPERCENT,ASS.FNUMBER,ASSL2.FDATAVALUE,ASSL3.FDATAVALUE";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取调拨单数据-CL-WMS|ERP
        /// </summary>
        /// <param name="pFNeedDate">需求日期</param>
        /// <param name="pStockID">调出仓库</param>
        /// <param name="pDeptID">领料部门</param>
        /// <param name="pCondition">指定条件</param>
        /// <param name="pIsTran">是否存在中间仓调拨</param>
        /// <returns></returns>
        public DataTable GetTransCL(string pFNeedDate, int pStockID, int pDeptID, string pCondition, bool pIsTran, int pOrgId = 100508)//根据仓库属性-是否汇总 判断汇总信息。
        {
            if (pIsTran)
            {
                _SQL = @"SELECT AC.FOWNERID 货主,NVL(ORG.FNUMBER, 'HN02') 货主编码,NVL(ORGL.FNAME, '河南工厂') 货主名称, AC.FOWNERTYPEID 货主类型,AE.FMATERIALID 物料,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称
,AE.FUNITID 单位,UNT.FNUMBER 单位编码,UNTL.FNAME 单位名称,MOE.FWORKSHOPID 领料部门,DEP.FNUMBER 领料部门编码,DEPL.FNAME 领料部门名称,DEPP.FNUMBER 领料部门分组编码
,AC.FSUPPLYORG 调入库存组织,NVL(ORG2.FNUMBER,' ') 调入库存组织编码,NVL(ORGL2.FNAME,' ') 调入库存组织名称,DEP.FINSTOCKID 调入仓库,STK2.FNUMBER 调入仓库编码,STKL2.FNAME 调入仓库名称,STK2.FDEFSTOCKSTATUSID 调入库存状态,STT2.FNUMBER 调入库存状态编码,STTL2.FNAME 调入库存状态名称
,AC.FSRCTRANSORGID 调出库存组织,NVL(ORG3.FNUMBER,' ') 调出库存组织编码,NVL(ORGL3.FNAME,' ') 调出库存组织名称,MST.FSTOCKID 调出仓库,STK3.FNUMBER 调出仓库编码,STKL3.FNAME 调出仓库名称,STK3.FDEFSTOCKSTATUSID 调出库存状态,STT3.FNUMBER 调出库存状态编码,STTL3.FNAME 调出库存状态名称
,MST.FTRANSTOCKID 中间仓库,STK4.FNUMBER 中间仓库编码,STKL4.FNAME 中间仓库名称,STK4.FDEFSTOCKSTATUSID 中间库存状态,STT4.FNUMBER 中间库存状态编码,STTL4.FNAME 中间库存状态名称
,AC.FLOT 批号,SUM(AE.FMUSTQTY) 调拨数量,N' ' 生产顺序号,' ' 生产订单备注,NVL(MTLSK.F_PAEZ_FMinsendQty,0) 最小批量,MTL.F_PAEZ_SENDPERCENT 发料百分比
,NVL(ASS.FNUMBER,' ') 调拨类型,NVL(ASSL2.FDATAVALUE,' ') 启用批次,NVL(ASSL3.FDATAVALUE,' ') 启用序列号,N' ' 发货类别
FROM T_PRD_PPBOM A
INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID AND AE.F_PAEZ_PICKTOWMS = 0 AND AE.FPAEZHAVEDIRECT = 0
INNER JOIN T_PRD_PPBOMENTRY_C AC ON AE.FENTRYID = AC.FENTRYID
INNER JOIN T_PRD_PPBOMENTRY_Q AQ ON AE.FENTRYID = AQ.FENTRYID
INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID AND TO_CHAR(MOE.FPLANSTARTDATE,'yyyy-mm-dd') = TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd')
INNER JOIN T_PRD_MO MO ON MO.FID = MOE.FID AND MO.FDOCUMENTSTATUS = 'C'
INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID AND MOA.FSTATUS IN(3,4) ";
                _SQL += string.Format(" INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = {0} ", pOrgId);
                _SQL += @" INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
LEFT JOIN T_BD_MATERIALSTOCK MTLSK ON MTL.FMATERIALID = MTLSK.FMATERIALID
INNER JOIN T_BD_UNIT UNT ON AE.FUNITID = UNT.FUNITID
INNER JOIN T_BD_UNIT_L UNTL ON UNT.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
INNER JOIN T_BD_DEPARTMENT DEP ON MOE.FWORKSHOPID = DEP.FDEPTID
INNER JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052
INNER JOIN T_BD_DEPARTMENT DEPP ON DEP.FPARENTID = DEPP.FDEPTID
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
INNER JOIN T_AUTO_MSTOCKSETTING MST ON AE.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID AND MST.FTRANSTOCKID != 0
INNER JOIN T_BD_STOCK STK3 ON MST.FSTOCKID = STK3.FSTOCKID
INNER JOIN T_BD_STOCK_L STKL3 ON STK3.FSTOCKID = STKL3.FSTOCKID AND STKL3.FLOCALEID = 2052
INNER JOIN T_BD_STOCKSTATUS STT3 ON STK3.FDEFSTOCKSTATUSID = STT3.FSTOCKSTATUSID
INNER JOIN T_BD_STOCKSTATUS_L STTL3 ON STT3.FSTOCKSTATUSID = STTL3.FSTOCKSTATUSID AND STTL3.FLOCALEID = 2052
INNER JOIN T_BD_STOCK STK4 ON MST.FTRANSTOCKID = STK4.FSTOCKID
INNER JOIN T_BD_STOCK_L STKL4 ON STK4.FSTOCKID = STKL4.FSTOCKID AND STKL4.FLOCALEID = 2052
INNER JOIN T_BD_STOCKSTATUS STT4 ON STK4.FDEFSTOCKSTATUSID = STT4.FSTOCKSTATUSID
INNER JOIN T_BD_STOCKSTATUS_L STTL4 ON STT4.FSTOCKSTATUSID = STTL4.FSTOCKSTATUSID AND STTL3.FLOCALEID = 2052 ";

                _SQL += string.Format(" WHERE A.FDOCUMENTSTATUS = 'C' AND STK2.FNUMBER <> STK3.FNUMBER AND MST.FSTOCKID != 897784 AND STK3.FALLOWSUM = '1' AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') = '{0}'", pFNeedDate);

                if (pStockID != 0)
                    _SQL += " AND MST.FSTOCKID = " + pStockID;
                if (pDeptID != 0)
                    _SQL += " AND MOE.FWORKSHOPID = " + pDeptID;
                if (pCondition != string.Empty)
                    _SQL += " AND" + pCondition;

                _SQL += " GROUP BY AC.FOWNERID,ORG.FNUMBER,ORGL.FNAME, AC.FOWNERTYPEID,AE.FMATERIALID,MTL.FNUMBER,MTLL.FNAME,AE.FUNITID,UNT.FNUMBER,UNTL.FNAME,MOE.FWORKSHOPID,DEP.FNUMBER,DEPL.FNAME,AC.FSUPPLYORG,ORG2.FNUMBER,ORGL2.FNAME,DEP.FINSTOCKID,STK2.FNUMBER,STKL2.FNAME,STK2.FDEFSTOCKSTATUSID,STT2.FNUMBER,STTL2.FNAME,AC.FSRCTRANSORGID,ORG3.FNUMBER,ORGL3.FNAME,MST.FSTOCKID,STK3.FNUMBER,STKL3.FNAME,STK3.FDEFSTOCKSTATUSID,STT3.FNUMBER,STTL3.FNAME,MST.FTRANSTOCKID,STK4.FNUMBER,STKL4.FNAME,STK4.FDEFSTOCKSTATUSID,STT4.FNUMBER,STTL4.FNAME,AC.FLOT,MTLSK.F_PAEZ_FMinsendQty,MTL.F_PAEZ_SENDPERCENT,ASS.FNUMBER,ASSL2.FDATAVALUE,ASSL3.FDATAVALUE,DEPP.FNUMBER";
            }
            else
            {
                _SQL = string.Format("SELECT AC.FOWNERID 货主,NVL(ORG.FNUMBER, 'HN02') 货主编码,NVL(ORGL.FNAME, '河南工厂') 货主名称, AC.FOWNERTYPEID 货主类型,AE.FMATERIALID 物料,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称 ");
                _SQL += string.Format(" , AE.FUNITID 单位,UNT.FNUMBER 单位编码,UNTL.FNAME 单位名称,MOE.FWORKSHOPID 领料部门,DEP.FNUMBER 领料部门编码,DEPL.FNAME 领料部门名称,DEPP.FNUMBER 领料部门分组编码 ");
                _SQL += string.Format(" , AC.FSUPPLYORG 调入库存组织,NVL(ORG2.FNUMBER,' ') 调入库存组织编码,NVL(ORGL2.FNAME,' ') 调入库存组织名称,DEP.FINSTOCKID 调入仓库,STK2.FNUMBER 调入仓库编码,STKL2.FNAME 调入仓库名称,STK2.FDEFSTOCKSTATUSID 调入库存状态,STT2.FNUMBER 调入库存状态编码,STTL2.FNAME 调入库存状态名称 ");
                _SQL += string.Format(" , AC.FSRCTRANSORGID 调出库存组织,NVL(ORG3.FNUMBER,' ') 调出库存组织编码,NVL(ORGL3.FNAME,' ') 调出库存组织名称,MST.FSTOCKID 调出仓库,STK3.FNUMBER 调出仓库编码,STKL3.FNAME 调出仓库名称,STK3.FDEFSTOCKSTATUSID 调出库存状态,STT3.FNUMBER 调出库存状态编码,STTL3.FNAME 调出库存状态名称 ");
                _SQL += string.Format(" , AC.FLOT 批号,SUM(AE.FMUSTQTY) 调拨数量,N' ' 生产顺序号,' ' 生产订单备注,NVL(MTLSK.F_PAEZ_FMinsendQty,0) 最小批量,MTL.F_PAEZ_SENDPERCENT 发料百分比 ");
                _SQL += string.Format(" , NVL(ASS.FNUMBER,' ') 调拨类型,NVL(ASSL2.FDATAVALUE,' ') 启用批次,NVL(ASSL3.FDATAVALUE,' ') 启用序列号,N' ' 发货类别 ");
                _SQL += string.Format(" FROM T_PRD_PPBOM A ");
                _SQL += string.Format(" INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID AND AE.F_PAEZ_PICKTOWMS = 0 AND AE.FPAEZHAVEDIRECT = 0 ");
                _SQL += string.Format(" INNER JOIN T_PRD_PPBOMENTRY_C AC ON AE.FENTRYID = AC.FENTRYID ");
                _SQL += string.Format(" INNER JOIN T_PRD_PPBOMENTRY_Q AQ ON AE.FENTRYID = AQ.FENTRYID ");
                _SQL += string.Format(" INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID AND TO_CHAR(MOE.FPLANSTARTDATE,'yyyy-mm-dd') = TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') ");
                _SQL += string.Format(" INNER JOIN T_PRD_MO MO ON MO.FID = MOE.FID AND MO.FDOCUMENTSTATUS = 'C' ");
                _SQL += string.Format(" INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID AND MOA.FSTATUS IN({0}) ", pOrgId == 100508 ? "3,4" : "4");
                _SQL += string.Format(" INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = {0} ", pOrgId);
                _SQL += string.Format(" INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052 ");
                _SQL += string.Format(" LEFT JOIN T_BD_MATERIALSTOCK MTLSK ON MTL.FMATERIALID = MTLSK.FMATERIALID ");
                _SQL += string.Format(" INNER JOIN T_BD_UNIT UNT ON AE.FUNITID = UNT.FUNITID ");
                _SQL += string.Format(" INNER JOIN T_BD_UNIT_L UNTL ON UNT.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_DEPARTMENT DEP ON MOE.FWORKSHOPID = DEP.FDEPTID ");
                _SQL += string.Format(" INNER JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_DEPARTMENT DEPP ON DEP.FPARENTID = DEPP.FDEPTID ");
                _SQL += string.Format(" LEFT JOIN T_ORG_ORGANIZATIONS ORG ON AC.FOWNERID = ORG.FORGID ");
                _SQL += string.Format(" LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL ON ORG.FORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052 ");
                _SQL += string.Format(" LEFT JOIN T_ORG_ORGANIZATIONS ORG2 ON AC.FSUPPLYORG = ORG2.FORGID ");
                _SQL += string.Format(" LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL2 ON ORG2.FORGID = ORGL2.FORGID AND ORGL2.FLOCALEID = 2052 ");
                _SQL += string.Format(" LEFT JOIN T_ORG_ORGANIZATIONS ORG3 ON AC.FSRCTRANSORGID = ORG3.FORGID ");
                _SQL += string.Format(" LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL3 ON ORG3.FORGID = ORGL3.FORGID AND ORGL3.FLOCALEID = 2052 ");
                _SQL += string.Format(" LEFT JOIN T_BAS_ASSISTANTDATAENTRY ASS ON MTL.F_PAEZ_SENDTYPE = ASS.FENTRYID ");
                _SQL += string.Format(" LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL2 ON MTL.F_ISBATCHMANAGER = ASSL2.FENTRYID AND ASSL2.FLOCALEID = 2052 ");
                _SQL += string.Format(" LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL3 ON MTL.F_ISSNMANAGER = ASSL3.FENTRYID AND ASSL3.FLOCALEID = 2052 ");
                _SQL += string.Format(" LEFT JOIN T_SAL_ORDER O ON MOE.FSALEORDERID = O.FID ");
                _SQL += string.Format(" LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL4 ON O.FHEADDELIVERYWAY = ASSL4.FENTRYID AND ASSL4.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCK STK2 ON DEP.FINSTOCKID = STK2.FSTOCKID ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCK_L STKL2 ON STK2.FSTOCKID = STKL2.FSTOCKID AND STKL2.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCKSTATUS STT2 ON STK2.FDEFSTOCKSTATUSID = STT2.FSTOCKSTATUSID ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCKSTATUS_L STTL2 ON STT2.FSTOCKSTATUSID = STTL2.FSTOCKSTATUSID AND STTL2.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_AUTO_MSTOCKSETTING MST ON AE.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID AND MST.FTRANSTOCKID = 0 ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCK STK3 ON MST.FSTOCKID = STK3.FSTOCKID ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCK_L STKL3 ON STK3.FSTOCKID = STKL3.FSTOCKID AND STKL3.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCKSTATUS STT3 ON STK3.FDEFSTOCKSTATUSID = STT3.FSTOCKSTATUSID ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCKSTATUS_L STTL3 ON STT3.FSTOCKSTATUSID = STTL3.FSTOCKSTATUSID AND STTL3.FLOCALEID = 2052  ");
                _SQL += string.Format(" WHERE A.FDOCUMENTSTATUS = 'C' AND STK2.FNUMBER <> STK3.FNUMBER AND MST.FSTOCKID != 897784 AND STK3.FALLOWSUM = '1' AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') = '{0}'", pFNeedDate);

                if (pStockID != 0)
                    _SQL += string.Format(" AND MST.FSTOCKID = {0} ", pStockID);
                if (pDeptID != 0)
                    _SQL += string.Format(" AND MOE.FWORKSHOPID = {0} ", pDeptID);
                if (pCondition != string.Empty)
                    _SQL += string.Format(" AND {0} ", pCondition);

                _SQL += " GROUP BY AC.FOWNERID,ORG.FNUMBER,ORGL.FNAME, AC.FOWNERTYPEID,AE.FMATERIALID,MTL.FNUMBER,MTLL.FNAME,AE.FUNITID,UNT.FNUMBER,UNTL.FNAME,MOE.FWORKSHOPID,DEP.FNUMBER,DEPL.FNAME,AC.FSUPPLYORG,ORG2.FNUMBER,ORGL2.FNAME,DEP.FINSTOCKID,STK2.FNUMBER,STKL2.FNAME,STK2.FDEFSTOCKSTATUSID,STT2.FNUMBER,STTL2.FNAME,AC.FSRCTRANSORGID,ORG3.FNUMBER,ORGL3.FNAME,MST.FSTOCKID,STK3.FNUMBER,STKL3.FNAME,STK3.FDEFSTOCKSTATUSID,STT3.FNUMBER,STTL3.FNAME,AC.FLOT,MTLSK.F_PAEZ_FMinsendQty,MTL.F_PAEZ_SENDPERCENT,ASS.FNUMBER,ASSL2.FDATAVALUE,ASSL3.FDATAVALUE,DEPP.FNUMBER";
            }
            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 半成品调拨ERP
        /// </summary>
        /// <param name="pDataTable">数据表</param>
        /// <param name="pDate">日期</param>
        /// <returns></returns>
        public string TransferDirERP(DataTable pDataTable, string pDate)
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
                basedata.Add("FNumber", pDataTable.Rows[0]["调入库存组织编码"].ToString());
                model.Add("FSettleOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDataTable.Rows[0]["调入库存组织编码"].ToString());
                model.Add("FSaleOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDataTable.Rows[0]["调入库存组织编码"].ToString());
                model.Add("FStockOutOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDataTable.Rows[0]["调入库存组织编码"].ToString());
                model.Add("FStockOrgId", basedata);
                basedata = new JObject();
                basedata.Add("FNumber", pDataTable.Rows[0]["领料部门编码"].ToString());
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
                    basedata.Add("FNumber", pDataTable.Rows[i]["单位编码"].ToString());
                    entryRow.Add("FUnitID", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["单位编码"].ToString());
                    entryRow.Add("FBaseUnitId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["单位编码"].ToString());
                    entryRow.Add("FPriceUnitID", basedata);

                    //if (pFormId == Model.Enum.FormID.PRD_PPBOM)
                    //{
                    //    //basedata = new JObject();
                    //    //basedata.Add("FNumber", pDataTable.Rows[i]["中间仓库编码"].ToString());
                    //    //entryRow.Add("FSrcStockId", basedata);
                    //    basedata = new JObject();
                    //    basedata.Add("FNumber", pDataTable.Rows[i]["调出仓库编码"].ToString());
                    //    entryRow.Add("FSrcStockId", basedata);
                    //}
                    //else
                    //{
                        basedata = new JObject();
                        basedata.Add("FNumber", pDataTable.Rows[i]["调出仓库编码"].ToString());
                        entryRow.Add("FSrcStockId", basedata);
                    //}

                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["调入仓库编码"].ToString());
                    entryRow.Add("FDestStockId", basedata);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["货主编码"].ToString());
                    entryRow.Add("FOwnerId", basedata);
                    entryRow.Add("FOwnerTypeId", "BD_OwnerOrg");
                    basedata = new JObject();
                    basedata.Add("FNumber", pDataTable.Rows[i]["货主编码"].ToString());
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
                        strPMBillNO += "物料" + pDataTable.Rows[i]["物料编码"].ToString() + " " + jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>() + "\r\n";//保存不成功返错误信息
                }
                else
                {
                    strPMBillNO = jo["Result"]["Number"].Value<string>();
                }
            }

            return strPMBillNO;
        }

        /// <summary>
        /// 半成品调拨-WMS（没有中间仓）
        /// </summary>
        /// <param name="pDataTable">数据源</param>
        /// <param name="pDate">单据日期</param>
        /// <returns></returns>
        public string TransferDirWMS(DataTable pDataTable, string pDate)
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

            string strTemp = pDataTable.Rows[0]["调拨类型"].ToString() == "1" ? ",0,1" : ",NULL,0";

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
                INSERT INTO t_StkTransferOutEntry(stkBillId,mtlId,mtlFnumber,mtlFname,inStockId,inStockNumber,inStockName,inStockStatusId,inStockStatusNumber,inStockStatusName,outStockId,outStockNumber,outStockName,outStockStatusId,outStockStatusNumber,outStockStatusName,unitId,unitFumber,unitFname,fqty,applicationQty,needFqty,pickFqty,batchCode,FPRODUCTIONSEQ,FMONote,deliveryWayName,passQty,entryPassStatus)
                VALUES(@stkBillId," + int.Parse(pDataTable.Rows[i]["物料"].ToString()) + ",'" + pDataTable.Rows[i]["物料编码"].ToString() + "','" + pDataTable.Rows[i]["物料名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调入仓库"].ToString()) + ",'" + pDataTable.Rows[i]["调入仓库编码"].ToString() + "','" + pDataTable.Rows[i]["调入仓库名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调入库存状态"].ToString()) + ",'" + pDataTable.Rows[i]["调入库存状态编码"].ToString() + "','" + pDataTable.Rows[i]["调入库存状态名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调出仓库"].ToString()) + ",'" + pDataTable.Rows[i]["调出仓库编码"].ToString() + "','" + pDataTable.Rows[i]["调出仓库名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调出库存状态"].ToString()) + ",'" + pDataTable.Rows[i]["调出库存状态编码"].ToString() + "','" + pDataTable.Rows[i]["调出库存状态名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["单位"].ToString()) + ",'" + pDataTable.Rows[i]["单位编码"].ToString() + "','" + pDataTable.Rows[i]["单位名称"].ToString() + "'," + fqty.ToString() + "," + fqty.ToString() + "," + decimal.Parse(pDataTable.Rows[i]["调拨数量"].ToString()) + ",0,'" + pDataTable.Rows[i]["批号"].ToString() + "','" + pDataTable.Rows[i]["生产顺序号"].ToString() + "','" + pDataTable.Rows[i]["生产订单备注"].ToString() + "','" + pDataTable.Rows[i]["发货类别"].ToString() + "'" + strTemp + ");";
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
        /// 半成品调拨-WMS（有中间仓）
        /// </summary>
        /// <param name="pDataTable">数据源</param>
        /// <param name="pDate">单据日期</param>
        /// <param name="pIsTran">用于区别没有中间仓方法</param>
        /// <returns></returns>
        public string TransferDirWMS(DataTable pDataTable, string pDate, bool pIsTran)
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

            string strTemp = pDataTable.Rows[0]["调拨类型"].ToString() == "1" ? ",0,1" : ",NULL,0";

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
                INSERT INTO t_StkTransferOutEntry(stkBillId,mtlId,mtlFnumber,mtlFname,inStockId,inStockNumber,inStockName,inStockStatusId,inStockStatusNumber,inStockStatusName,outStockId,outStockNumber,outStockName,outStockStatusId,outStockStatusNumber,outStockStatusName,unitId,unitFumber,unitFname,fqty,applicationQty,needFqty,pickFqty,batchCode,FPRODUCTIONSEQ,FMONote,deliveryWayName,passQty,entryPassStatus)
                VALUES(@stkBillId," + int.Parse(pDataTable.Rows[i]["物料"].ToString()) + ",'" + pDataTable.Rows[i]["物料编码"].ToString() + "','" + pDataTable.Rows[i]["物料名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["中间仓库"].ToString()) + ",'" + pDataTable.Rows[i]["中间仓库编码"].ToString() + "','" + pDataTable.Rows[i]["中间仓库名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["中间库存状态"].ToString()) + ",'" + pDataTable.Rows[i]["中间库存状态编码"].ToString() + "','" + pDataTable.Rows[i]["中间库存状态名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调出仓库"].ToString()) + ",'" + pDataTable.Rows[i]["调出仓库编码"].ToString() + "','" + pDataTable.Rows[i]["调出仓库名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["调出库存状态"].ToString()) + ",'" + pDataTable.Rows[i]["调出库存状态编码"].ToString() + "','" + pDataTable.Rows[i]["调出库存状态名称"].ToString() + "'," + int.Parse(pDataTable.Rows[i]["单位"].ToString()) + ",'" + pDataTable.Rows[i]["单位编码"].ToString() + "','" + pDataTable.Rows[i]["单位名称"].ToString() + "'," + fqty.ToString() + "," + fqty.ToString() + "," + decimal.Parse(pDataTable.Rows[i]["调拨数量"].ToString()) + ",0,'" + pDataTable.Rows[i]["批号"].ToString() + "','" + pDataTable.Rows[i]["生产顺序号"].ToString() + "','" + pDataTable.Rows[i]["生产订单备注"].ToString() + "','" + pDataTable.Rows[i]["发货类别"].ToString() + "'" + strTemp + ");";
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
        /// 成品调拨数据WMS-销售订单
        /// </summary>
        /// <param name="pFilter"></param>
        /// <returns></returns>
        public DataTable GetTransForP(string pFilter)
        {
            _SQL = @"SELECT 0 chb,O.* FROM
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
        /// 成品调拨数据WMS-发货通知单
        /// </summary>
        /// <param name="pList">发货通知单号</param>
        /// <returns></returns>
        public DataTable GetTransForP(List<string> pList)
        {
            if (pList == null || pList.Count == 0)
                return new DataTable();

            string strBillNos = string.Empty;
            for (int i = 0; i < pList.Count; i++)
            {
                if (i > 0)
                    strBillNos += ",";
                strBillNos += "'" + pList[i] + "'";
            }

            _SQL = @"SELECT DISTINCT A.FBILLNO 订单编号,O.FDATE 订单日期,A.FOWNERID 货主ID,ORG.FNUMBER 货主代码,ORGL.FNAME 货主名称,A.FOWNERTYPEID 货主类型
                ,AE.FMATERIALID 物料ID,MTL.FNUMBER 物料代码,MTLL.FNAME 物料名称,MTLB.FBASEUNITID 单位ID,UNT.FNUMBER 单位代码,UNTL.FNAME 单位名称,AE.FLOCKQTY 锁库数量,OE.F_PAEZ_LOCKALLOTQTY 锁库调拨数量,AE.FQTY 发货通知数量
                ,MTL.F_PAEZ_SENDPERCENT 发料百分比,MTLS.F_PAEZ_FMINSENDQTY 最小发出数量,AE.FSHIPMENTSTOCKID 调出仓库ID,STK.FNUMBER 调出仓库代码,STKL.FNAME 调出仓库名称,CUST.FNUMBER 客户代码,CUSTL.FNAME 客户名称
                ,NVL(ASS.FNUMBER,' ') 调拨类型,NVL(ASSL2.FDATAVALUE,' ') 启用批次,NVL(ASSL3.FDATAVALUE,' ') 启用序列号,NVL(ASSL4.FDATAVALUE,' ') 发货类别,NVL(ASSL5.FDATAVALUE,' ') 品牌,NVL(ASSL6.FDATAVALUE,' ') 系列,NVL(ASSL7.FDATAVALUE,' ') 商品名,NVL(ASSL8.FDATAVALUE,' ') 颜色,NVL(ASSL9.FDATAVALUE,' ') 车系,NVL(ASSL10.FDATAVALUE,' ') 车型
                ,O.FID,OE.FENTRYID
            FROM T_SAL_DELIVERYNOTICE A
            INNER JOIN T_SAL_DELIVERYNOTICEENTRY AE ON A.FID = AE.FID
            INNER JOIN T_SAL_DELIVERYNOTICEENTRY_E AEE ON AE.FENTRYID = AEE.FENTRYID
            INNER JOIN T_SAL_ORDERENTRY OE ON AEE.FSOENTRYID = OE.FENTRYID
            INNER JOIN T_SAL_ORDER O ON OE.FID = O.FID
            INNER JOIN T_ORG_ORGANIZATIONS ORG ON A.FOWNERID = ORG.FORGID
            INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON ORG.FORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
            INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
            INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
            INNER JOIN T_BD_MATERIALSTOCK MTLS ON MTL.FMATERIALID = MTLS.FMATERIALID
            INNER JOIN T_BD_MATERIALbase MTLB ON MTL.FMATERIALID = MTLB.FMATERIALID
            INNER JOIN T_BD_UNIT UNT ON MTLB.FBASEUNITID = UNT.FUNITID
            INNER JOIN T_BD_UNIT_L UNTL ON UNT.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
            INNER JOIN T_BD_STOCK STK ON AE.FSHIPMENTSTOCKID = STK.FSTOCKID
            INNER JOIN T_BD_STOCK_L STKL ON STK.FSTOCKID = STKL.FSTOCKID AND STKL.FLOCALEID = 2052
            INNER JOIN T_BD_CUSTOMER CUST ON A.FCUSTOMERID = CUST.FCUSTID
            INNER JOIN T_BD_CUSTOMER_L CUSTL ON CUST.FCUSTID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052 
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
            WHERE A.FBILLNO IN(" + strBillNos + ")";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 成品直接调拨单WMS
        /// </summary>
        /// <param name="pDataTable">数据源</param>
        /// <param name="pList">部门和日期</param>
        /// <param name="pIsDepart">是否按照调出仓库分单</param>
        /// <returns></returns>
        public string TransferDir(DataTable pDataTable, List<string> pList, bool pIsDepart)
        {
            if (pDataTable == null || pDataTable.Rows.Count == 0)
                return "";

            string strBillNo = string.Empty, strBillNos = string.Empty;
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);

            if (pIsDepart)//根据不同的调出仓库分组生成调拨单
            {
                //统计调出仓库
                List<string> lstOutStock = new List<string>();
                for (int i = 0; i < pDataTable.Rows.Count; i++)
                {
                    if (!lstOutStock.Contains(pDataTable.Rows[i]["调出仓库代码"].ToString()))
                        lstOutStock.Add(pDataTable.Rows[i]["调出仓库代码"].ToString());
                }

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
            }
            else//一次生成在同一张调拨单
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
        /// 更新已经生成调拨单字段状态（半成品）
        /// </summary>
        /// <param name="pFNeedDate">需求日期</param>
        /// <param name="pList">已弃用</param>
        public void UpdateDirFieldsCL(string pFNeedDate, int pOrgId = 100508)
        {
            _SQL = "UPDATE T_PRD_PPBOMENTRY ";
            _SQL += " SET FPAEZHAVEDIRECT = 1,F_PAEZ_PICKTOWMS = 1 ";
            _SQL += " WHERE FPAEZHAVEDIRECT = 0 AND F_PAEZ_PICKTOWMS = 0 AND FENTRYID IN( ";
            _SQL += " SELECT A.FENTRYID ";
            _SQL += " FROM T_PRD_PPBOMENTRY A ";
            _SQL += " INNER JOIN T_PRD_PPBOM E ON A.FID = E.FID AND E.FDOCUMENTSTATUS = 'C' ";
            _SQL += " INNER JOIN T_PRD_MOENTRY G ON A.FMOENTRYID = G.FENTRYID AND TO_CHAR(G.FPLANSTARTDATE,'yyyy-mm-dd') = TO_CHAR(A.FNEEDDATE,'yyyy-mm-dd') ";
            _SQL += " INNER JOIN T_PRD_MO H ON G.FID = H.FID AND H.FDOCUMENTSTATUS = 'C' ";
            _SQL += string.Format(" INNER JOIN T_PRD_MOENTRY_A I ON A.FMOENTRYID = I.FENTRYID AND I.FSTATUS IN({0}) ", pOrgId == 100508 ? "3,4" : "4");
            _SQL += string.Format(" INNER JOIN T_BD_MATERIAL J ON A.FMATERIALID = J.FMATERIALID AND J.FUSEORGID = {0}", pOrgId);
            _SQL += " INNER JOIN T_BD_DEPARTMENT L ON G.FWORKSHOPID = L.FDEPTID ";
            _SQL += " INNER JOIN T_BD_STOCK M ON L.FINSTOCKID = M.FSTOCKID ";
            _SQL += " INNER JOIN T_AUTO_MSTOCKSETTING N ON A.FMATERIALID = N.FMATERIALID AND L.FDEPTID = N.FDEPTID ";
            _SQL += " INNER JOIN T_BD_STOCK O ON N.FSTOCKID = O.FSTOCKID ";
            _SQL += string.Format(" WHERE A.FPAEZHAVEDIRECT = 0 AND M.FNUMBER <> O.FNUMBER AND TO_CHAR(A.FNEEDDATE,'yyyy-mm-dd') = '{0}' GROUP BY J.FNUMBER,M.FNUMBER,O.FNUMBER,L.FNUMBER,A.FENTRYID )", pFNeedDate);

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 检查当前开工日期是否所有物料都设置了默认仓库
        /// </summary>
        /// <param name="pDateTime">开工日期</param>
        /// <returns></returns>
        public bool SetDefaultStock(DateTime pDateTime, Model.Enum.FormID pFormId)
        {
            string strOrg;
            switch (pFormId)
            {
                case Model.Enum.FormID.PRD_PPBOM:
                    strOrg = "100508";
                    break;
                case Model.Enum.FormID.PRD_PPBOM_DX:
                    strOrg = "492501088";
                    break;
                default:
                    strOrg = "100508";
                    break;
            }

            _SQL = string.Format("SELECT COUNT(*) ");
            _SQL += string.Format(" FROM T_PRD_MO A ");
            _SQL += string.Format(" INNER JOIN T_PRD_MOENTRY AE ON A.FID = AE.FID ");
            _SQL += string.Format(" INNER JOIN T_PRD_MOENTRY_A AA ON AE.FENTRYID = AA.FENTRYID AND AA.FSTATUS IN({0}) ", strOrg == "100508" ? "3,4" : "4");
            _SQL += string.Format(" INNER JOIN T_BD_DEPARTMENT DEP ON AE.FWORKSHOPID = DEP.FDEPTID ");
            _SQL += string.Format(" INNER JOIN T_PRD_PPBOMENTRY PBE ON AE.FENTRYID = PBE.FMOENTRYID ");
            _SQL += string.Format(" INNER JOIN T_BD_MATERIAL MTL ON PBE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = {0} ", strOrg);
            _SQL += string.Format(" LEFT JOIN T_AUTO_MSTOCKSETTING MST ON MTL.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID ");
            _SQL += string.Format(" WHERE (MST.FMATERIALID IS NULL OR MST.FSTOCKID IS NULL) AND A.FDOCUMENTSTATUS = 'C' AND A.FPRDORGID = {0} AND TO_CHAR(AE.FPLANSTARTDATE,'yyyy-mm-dd') = '{1}'", strOrg, pDateTime.ToString("yyyy-MM-dd"));

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
        public int Asyn_PPBom_FNeedDate(DateTime pFrom, DateTime pTo)
        {
            _SQL = "SELECT COUNT(BE.FENTRYID) ";
            _SQL += " FROM T_PRD_PPBOM A ";
            _SQL += " INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID ";
            _SQL += " LEFT JOIN T_PRD_MOENTRY BE ON AE.FMOENTRYID = BE.FENTRYID ";
            _SQL += " LEFT JOIN T_PRD_MO B ON BE.FID = B.FID ";
            _SQL += string.Format(" WHERE TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') <> TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') AND BE.FPLANSTARTDATE BETWEEN TO_DATE('{0}','yyyy-mm-dd') AND TO_DATE('{1}','yyyy-mm-dd')", pFrom.ToString("yyyy-MM-dd"), pTo.ToString("yyyy-MM-dd"));

            return int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString());
        }

        /// <summary>
        /// 同步用料清单的需求日期为生产订单的计划开工时间
        /// </summary>
        /// <param name="pFrom">开始时间</param>
        /// <param name="pTo">结束时间</param>
        public void Syn_PPBom_FNeedDate(DateTime pFrom, DateTime pTo)
        {
            _SQL = "UPDATE T_PRD_PPBOMENTRY AE SET FNEEDDATE = ( ";
            _SQL += " SELECT FPLANSTARTDATE  ";
            _SQL += string.Format(" FROM T_PRD_MOENTRY BE WHERE AE.FMOENTRYID = BE.FENTRYID AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') <> TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') AND BE.FPLANSTARTDATE BETWEEN TO_DATE('{0}','yyyy-mm-dd') AND TO_DATE('{1}','yyyy-mm-dd')) ", pFrom.ToString("yyyy-MM-dd"), pTo.ToString("yyyy-MM-dd"));
            _SQL += " WHERE EXISTS( ";
            _SQL += " SELECT 1  ";
            _SQL += string.Format(" FROM T_PRD_MOENTRY BE WHERE AE.FMOENTRYID = BE.FENTRYID AND TO_CHAR(AE.FNEEDDATE,'yyyy-mm-dd') <> TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') AND BE.FPLANSTARTDATE BETWEEN TO_DATE('{0}','yyyy-mm-dd') AND TO_DATE('{1}','yyyy-mm-dd')) ", pFrom.ToString("yyyy-MM-dd"), pTo.ToString("yyyy-MM-dd"));
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 物料默认设置-中间仓调整
        /// </summary>
        public void UpdateMST_Tran()
        {
            _SQL = "BEGIN ";
            _SQL += " UPDATE T_AUTO_MSTOCKSETTING SET FSTOCKID = 467795671,FSTOCKNUMBER = 'HWL29',FTRANSTOCKID = 897782,FMODIFYDATE = SYSDATE WHERE FSTOCKID = 897782; ";
            _SQL += " UPDATE T_AUTO_MSTOCKSETTING SET FTRANSTOCKID = 897782,FMODIFYDATE = SYSDATE WHERE FSTOCKID = 467795671 AND FTRANSTOCKID = 0 AND FDEPTID IN(100684,100685,100686,100687,100688,100707,465531838,467909049; ";
            _SQL += " END;";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 根据单号获取生产用料清单信息
        /// </summary>
        /// <param name="pBillNo">产用料清单单号</param>
        /// <returns></returns>
        public DataTable GetPPBomByBillNo(string pBillNo)
        {
            _SQL = @"SELECT AE.FENTRYID,MTL.FNUMBER 产品编码,BOM.FNUMBER BOM版本,MTLL.FNAME 产品名称,ORGL.FNAME 生产组织,DEPL.FNAME 生产车间,UNTL.FNAME 单位,A.FQTY 数量
                ,MO.FBILLNO 生产订单编号,CASE MOA.FSTATUS WHEN '1' THEN '计划' WHEN '2' THEN '计划确认' WHEN '3' THEN '下达' WHEN '4' THEN '开工' WHEN '5' THEN '完工' WHEN '6' THEN '结案' WHEN '7' THEN '结算' END 生产订单状态,MOE.FSEQ 生产订单行号
                ,AE.FSEQ 序号,MTLC.FNUMBER 子项物料编码,MTLLC.FNAME 子项物料名称,AE.FMUSTQTY 应发数量,AE.FNUMERATOR 分子,AE.FDENOMINATOR 分母,AE.FNEEDDATE 需求日期
            FROM T_PRD_PPBOM A
            INNER JOIN T_PRD_PPBOMENTRY AE ON A.FID = AE.FID
            INNER JOIN T_BD_MATERIAL MTL ON A.FMATERIALID = MTL.FMATERIALID
            INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
            INNER JOIN T_ENG_BOM BOM ON MTL.FMATERIALID = BOM.FMATERIALID
            INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON A.FPRDORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
            INNER JOIN T_BD_DEPARTMENT_L DEPL ON A.FWORKSHOPID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052
            INNER JOIN T_BD_UNIT_L UNTL ON A.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
            INNER JOIN T_PRD_MOENTRY MOE ON AE.FMOENTRYID = MOE.FENTRYID
            INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID
            INNER JOIN T_PRD_MO MO ON MOE.FID = MO.FID
            INNER JOIN T_BD_MATERIAL MTLC ON AE.FMATERIALID = MTLC.FMATERIALID
            INNER JOIN T_BD_MATERIAL_L MTLLC ON MTLC.FMATERIALID = MTLLC.FMATERIALID AND MTLLC.FLOCALEID = 2052
            WHERE A.FBILLNO = '" + pBillNo + "' ORDER BY A.FID,AE.FSEQ";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 更新生产用料清单
        /// </summary>
        /// <param name="pSyn">同步更新</param>
        /// <param name="pType">是否只修改数量</param>
        /// <param name="pFEntryId">生产用量清单内码</param>
        /// <param name="pMTLNumber">用于替换的子项物料编码</param>
        /// <param name="pFZ">分子</param>
        /// <param name="pMustQty">应发数量</param>
        /// <param name="pNeedDate">需求日期</param>
        /// <returns></returns>
        public void UpdatePPBom(bool pSyn, bool pType, int pFEntryId, string pMTLNumber, string pNewMTLNumber, decimal pFZ, decimal pMustQty, DateTime pNeedDate)
        {
            if (pSyn)
            {
                if (pType)
                    _SQL = "UPDATE T_PRD_PPBOMENTRY SET FNUMERATOR = " + pFZ + ",FMUSTQTY = " + pMustQty + " WHERE FMATERIALID = (SELECT FMATERIALID FROM T_BD_MATERIAL WHERE FUSEORGID = 100508 AND FNUMBER = '" + pMTLNumber + "') AND TO_CHAR(FNEEDDATE,'yyyy-mm-dd') = '" + pNeedDate.ToString("yyyy-MM-dd") + "'";
                else
                    _SQL = "UPDATE T_PRD_PPBOMENTRY SET FMATERIALID = (SELECT FMATERIALID FROM T_BD_MATERIAL WHERE FUSEORGID = 100508 AND FNUMBER = '" + pNewMTLNumber + "'),FNUMERATOR = " + pFZ + ",FMUSTQTY = " + pMustQty + " WHERE FMATERIALID = (SELECT FMATERIALID FROM T_BD_MATERIAL WHERE FUSEORGID = 100508 AND FNUMBER = '" + pMTLNumber + "') AND TO_CHAR(FNEEDDATE,'yyyy-mm-dd') = '" + pNeedDate.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                if (pType)
                    _SQL = "UPDATE T_PRD_PPBOMENTRY SET FNUMERATOR = " + pFZ + ",FMUSTQTY = " + pMustQty + " WHERE FENTRYID = " + pFEntryId;
                else
                    _SQL = @"UPDATE T_PRD_PPBOMENTRY SET FMATERIALID = (SELECT FMATERIALID FROM T_BD_MATERIAL WHERE FUSEORGID = 100508 AND FNUMBER = '" + pNewMTLNumber + "'),FNUMERATOR = " + pFZ + ",FMUSTQTY = " + pMustQty + " WHERE FENTRYID = " + pFEntryId;
            }

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 更新生产用料清单生成调拨单状态
        /// </summary>
        /// <param name="pMoBillNos">生产订单编号</param>
        /// <param name="pDir">是否生成调拨单</param>
        public void UpdatePPBom(string pMoBillNos, bool pDir)
        {
            if (pDir)
                _SQL = @"UPDATE T_PRD_PPBOMENTRY
                SET FPAEZHAVEDIRECT = 1,F_PAEZ_PICKTOWMS = 1
                WHERE (FPAEZHAVEDIRECT = 0 OR F_PAEZ_PICKTOWMS = 0) AND FENTRYID IN(SELECT A.FENTRYID
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
                WHERE (A.FPAEZHAVEDIRECT = 0 OR A.F_PAEZ_PICKTOWMS = 0) AND M.FNUMBER <> O.FNUMBER AND H.FBILLNO IN(" + pMoBillNos + ") GROUP BY J.FNUMBER,M.FNUMBER,O.FNUMBER,L.FNUMBER,A.FENTRYID)";
            else
                _SQL = @"UPDATE T_PRD_PPBOMENTRY
                SET FPAEZHAVEDIRECT = 0,F_PAEZ_PICKTOWMS = 0
                WHERE (FPAEZHAVEDIRECT = 1 OR F_PAEZ_PICKTOWMS = 1) AND FENTRYID IN(SELECT A.FENTRYID
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
                WHERE (A.FPAEZHAVEDIRECT = 1 OR A.F_PAEZ_PICKTOWMS = 1) AND M.FNUMBER <> O.FNUMBER AND H.FBILLNO IN(" + pMoBillNos + ") GROUP BY J.FNUMBER,M.FNUMBER,O.FNUMBER,L.FNUMBER,A.FENTRYID)";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 获取发货通知单信息
        /// </summary>
        /// <param name="pFDate"></param>
        /// <param name="pFBillNo"></param>
        /// <returns></returns>
        public DataTable GetNotice(DateTime pFDate, string pFBillNo)
        {
            _SQL = @"SELECT 0 CHB,A.FDATE 日期,A.FBILLNO 单据编号,CASE A.FDOCUMENTSTATUS WHEN 'A' THEN '创建' WHEN 'B' THEN '审核中' WHEN 'C' THEN '已审核' WHEN 'D' THEN '重新审核' WHEN 'Z' THEN '暂存' END 数据状态,CUSTL.FNAME 客户
                ,MTL.FNUMBER 物料代码,MTLL.FNAME 物料名称,UNTL.FNAME 单位名称,AE.FQTY 发货通知数量
                ,NVL(ASSL.FDATAVALUE,' ') 大类,NVL(ASSL2.FDATAVALUE,' ') 中类,NVL(ASSL3.FDATAVALUE,' ') 小类,NVL(ASSL4.FDATAVALUE,' ') 细类,NVL(ASSL5.FDATAVALUE,' ') 品牌,NVL(ASSL6.FDATAVALUE,' ') 系列,NVL(ASSL7.FDATAVALUE,' ') 商品名,NVL(ASSL8.FDATAVALUE,' ') 颜色
            FROM T_SAL_DELIVERYNOTICE A
            INNER JOIN T_SAL_DELIVERYNOTICEENTRY AE ON A.FID = AE.FID
            INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
            INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
            INNER JOIN T_BD_MATERIALBASE MTLB ON MTL.FMATERIALID = MTLB.FMATERIALID
            INNER JOIN T_BD_UNIT_L UNTL ON MTLB.FBASEUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
            INNER JOIN T_BD_CUSTOMER_L CUSTL ON A.FCUSTOMERID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052
            LEFT JOIN K3ERP0903.T_BAS_ASSISTANTDATAENTRY_L ASSL ON MTL.F_PAEZ_MAJOR = ASSL.FENTRYID AND ASSL.FLOCALEID = 2052
            LEFT JOIN K3ERP0903.T_BAS_ASSISTANTDATAENTRY_L ASSL2 ON MTL.F_PAEZ_MEDIUM = ASSL2.FENTRYID AND ASSL2.FLOCALEID = 2052
            LEFT JOIN K3ERP0903.T_BAS_ASSISTANTDATAENTRY_L ASSL3 ON MTL.F_PAEZ_MINOR = ASSL3.FENTRYID AND ASSL3.FLOCALEID = 2052
            LEFT JOIN K3ERP0903.T_BAS_ASSISTANTDATAENTRY_L ASSL4 ON MTL.F_PAEZ_SUBCLASS = ASSL4.FENTRYID AND ASSL4.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL5 ON MTL.F_PAEZ_BRAND = ASSL5.FENTRYID AND ASSL5.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL6 ON MTL.F_PAEZ_SERIES = ASSL6.FENTRYID AND ASSL6.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL7 ON MTL.F_PAEZ_TRADE = ASSL7.FENTRYID AND ASSL7.FLOCALEID = 2052
            LEFT JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL8 ON MTL.F_PAEZ_COLOR = ASSL8.FENTRYID AND ASSL8.FLOCALEID = 2052 ";
            if (pFBillNo.Trim().Equals(string.Empty))
                _SQL += "WHERE TO_CHAR(A.FDATE, 'YYYYMMDD') = '" + pFDate.ToString("yyyyMMdd") + "' AND A.FID IN(SELECT NE.FID FROM T_SAL_DELIVERYNOTICE NE INNER JOIN T_SAL_DELIVERYNOTICEENTRY NEE ON NE.FID = NEE.FID WHERE TO_CHAR(NE.FDATE, 'YYYYMMDD') = '" + pFDate.ToString("yyyyMMdd") + "' GROUP BY NE.FID HAVING SUM(CASE WHEN NEE.FBASETRANSFERQTY > 0 THEN 1 ELSE 0 END) = 0) ORDER BY A.FBILLNO";
            else
                _SQL += "WHERE A.FBILLNO = '" + pFBillNo + "' AND EXISTS(SELECT 1 FROM T_SAL_DELIVERYNOTICE NE INNER JOIN T_SAL_DELIVERYNOTICEENTRY NEE ON NE.FID = NEE.FID WHERE NE.FBILLNO = '" + pFBillNo + "' GROUP BY NE.FID HAVING SUM(CASE WHEN NEE.FBASETRANSFERQTY > 0 THEN 1 ELSE 0 END) = 0)";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 反写发货通知单关联调拨数量
        /// </summary>
        /// <param name="pList"></param>
        public void UpdateNotice(List<string> pList)
        {
            string strBillNos = string.Empty;
            for (int i = 0; i < pList.Count; i++)
            {
                if (i > 0)
                    strBillNos += ",";
                strBillNos += "'" + pList[i] + "'";
            }

            _SQL = @"BEGIN
            UPDATE T_SAL_DELIVERYNOTICEENTRY SET FTRANSFERQTY = FQTY,FBASETRANSFERQTY = FQTY WHERE FID IN(SELECT FID FROM T_SAL_DELIVERYNOTICE WHERE FBILLNO IN(" + strBillNos + @"));
            UPDATE T_SAL_DELIVERYNOTICEENTRY_E AEE SET FSTOCKBASETRANSQTY = (SELECT FQTY FROM T_SAL_DELIVERYNOTICEENTRY AE WHERE AEE.FENTRYID = AE.FENTRYID) WHERE FID IN(SELECT FID FROM T_SAL_DELIVERYNOTICE WHERE FBILLNO IN(" + strBillNos + @")) AND EXISTS (SELECT 1 FROM T_SAL_DELIVERYNOTICEENTRY AE WHERE AEE.FENTRYID = AE.FENTRYID);
            END;";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 获取WMS系统所有仓位
        /// </summary>
        /// <returns></returns>
        public DataTable GetWMSSP()
        {
            _SQL = "SELECT FNUMBER 物料编码,FNAME 物料名称,PNUMBER 仓位,SNAME 仓库,FMATERIALID FROM V_DM_MTLPosition ORDER BY FNUMBER,PNUMBER";

            return SQLHelper.ExecuteTable(_SQL);
        }


        /// <summary>
        /// 同步物料的仓位到ERP
        /// </summary>
        /// <param name="pData"></param>
        public void SynSPToERP(DataTable pData)
        {
            int iTimes = 1;
            _SQL = "BEGIN ";

            for (int i = 0; i < pData.Rows.Count; i++)
            {
                if (i < 200 * iTimes)
                {
                    _SQL += string.Format(" UPDATE T_BD_MATERIAL SET F_m_stockplosition = '{0}' WHERE FMATERIALID = {1}; ", pData.Rows[i]["仓位"].ToString(), pData.Rows[i]["FMATERIALID"].ToString());

                    if (i == pData.Rows.Count - 1)//当前是最后一条数据，提交SQL
                    {
                        _SQL += " END;";
                        ORAHelper.ExecuteNonQuery(_SQL);
                        return;
                    }
                }
                else
                {
                    _SQL += " END;";
                    ORAHelper.ExecuteNonQuery(_SQL);//提交前一批SQL

                    iTimes++;
                    _SQL = "BEGIN ";
                }
            }
        }
    }
}
