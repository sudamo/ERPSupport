using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using ERPSupport.Model.Enum;
using ERPSupport.Model.Globa;
using ERPSupport.Model.K3Cloud;
using Newtonsoft.Json.Linq;
using Kingdee.BOS.WebApi.Client;

namespace ERPSupport.SQL.K3Cloud
{
    /// <summary>
    /// 销售订单
    /// </summary>
    public static class SalOrder
    {
        #region STATIC
        private static string strSQL;
        private static object obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        static SalOrder()
        {
            strSQL = string.Empty;
            obj = new object();
        }
        #endregion

        /// <summary>
        /// 锁库失败操作日志
        /// </summary>
        /// <param name="pEntry">订单实体</param>
        /// <param name="pType">类型：1、锁库；其他、解锁</param>
        /// <param name="pRemark">失败信息</param>
        public static void Log_OrderLock(OrderInfo pEntry, int pType, string pRemark)
        {
            strSQL = @"INSERT INTO DM_LOG_ORDERLOCK(FENTRYID,FBILLNO,FMTLNUMBER,FREMARK,FTYPE,FFLAG,FOPERATOR)
            VALUES(" + pEntry.FEntryId.ToString() + ",'" + pEntry.FBillNo + "','" + pEntry.FMaterialNo + "','" + pRemark + "','1','0','" + GlobalParameter.K3Inf.UserName + "')";

            ORAHelper.ExecuteNonQuery(strSQL);
        }

        /// <summary>
        /// 锁库成功操作日志
        /// </summary>
        /// <param name="pDR">数据行</param>
        /// <param name="pType">类型：1、锁库；其他、解锁</param>
        public static void Log_OrderLock(DataRow pDR, int pType)
        {
            if (pDR == null)
                return;
            string FFLAG;

            if (pType == 1)
                strSQL = @"INSERT INTO DM_LOG_ORDERLOCK(FID,FENTRYID,FINID,FBILLNO,FMTLNUMBER,FUNTNUMBER,FORGNUMBER,FSALQTY,FLOCKQTY,FLEFTQTY,FMAXLOCKQTY,FSEQ,FSTOCKNUMBER,FSTOCK,FSTOCKQTY,FSTOCKAVBQTY,FREMARK,FTYPE,FOPERATOR)
                VALUES(" + pDR["FID"].ToString() + "," + pDR["FENTRYID"].ToString() + ",'" + pDR["FINID"].ToString() + "','" + pDR["单据编号"].ToString() + "','" + pDR["物料编码"].ToString() + "','" + pDR["基本单位"].ToString() + "','" + pDR["需求组织"].ToString() + "'," + pDR["销售数量"].ToString() + "," + pDR["锁库数量"].ToString() + "," + pDR["待锁库"].ToString() + "," + pDR["最大可锁数量"].ToString() + "," + pDR["序号"].ToString() + ",'" + pDR["仓库编码"].ToString() + "','" + pDR["仓库"].ToString() + "'," + pDR["库存量"].ToString() + "," + pDR["可用量"].ToString() + ",'" + pDR["备注"].ToString() + "',1,'" + GlobalParameter.K3Inf.UserName + "')";
            else
            {
                FFLAG = pDR["操作"].ToString().Contains("成功") ? "1" : "0";
                strSQL = @"INSERT INTO DM_LOG_ORDERLOCK(FBILLNO,FMTLNUMBER,FLOCKQTY,FTYPE,FOPERATOR,FREMARK,FFLAG)
                VALUES('" + pDR["销售订单"].ToString() + "','" + pDR["物料编码"].ToString() + "'," + pDR["信息"].ToString().Substring(5) + ",0,'" + GlobalParameter.K3Inf.UserName + "','" + pDR["操作"].ToString() + "','" + FFLAG + "')";
            }

            ORAHelper.ExecuteNonQuery(strSQL);
        }

        /// <summary>
        /// 根据FormId数据查询
        /// </summary>
        /// <param name="pFormId">FormId</param>
        /// <param name="pFilter">Filter</param>
        /// <returns></returns>
        public static DataTable GetDataSource(FormID pFormId, string pFilter)
        {
            if (pFormId == FormID.PRD_INSTOCK)//倒冲领料
            {
                strSQL = @"SELECT A.FDATE 日期, BILL.FNAME 单据类型, A.FBILLNO 单据编号, '已审核' 单据状态, ORGL.FNAME 入库组织, ORGL2.FNAME 生产组织
                    ,MTL.FNUMBER 物料编码, MTLL.FNAME 物料名称, UNTL.FNAME 单位, AE.FMUSTQTY 应收数量, AE.FREALQTY 实收数量
                    ,STKL.FNAME 仓库
                FROM T_PRD_INSTOCK A
                INNER JOIN T_PRD_INSTOCKENTRY AE ON A.FID = AE.FID
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLL ON AE.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BAS_BILLTYPE_L BILL ON A.FBILLTYPE = BILL.FBILLTYPEID AND BILL.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON A.FSTOCKORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL2 ON A.FPRDORGID = ORGL2.FORGID AND ORGL2.FLOCALEID = 2052
                INNER JOIN T_BD_UNIT_L UNTL ON AE.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
                INNER JOIN T_BD_STOCK_L STKL ON AE.FSTOCKID = STKL.FSTOCKID AND STKL.FLOCALEID = 2052
                INNER JOIN T_BD_DEPARTMENT_L DEPL ON AE.FWORKSHOPID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052
                LEFT JOIN T_PRD_PICKMTRLDATA_A BA ON A.FID = BA.FSRCBIZINTERID
                WHERE " + pFilter + " A.FDOCUMENTSTATUS = 'C' AND BA.FSRCBIZBILLNO IS NULL ORDER BY A.FID DESC";
            }
            else if (pFormId == FormID.PRD_PPBOM)//调拨
            {
                strSQL = @"SELECT MTL.FNUMBER 物料编码, MTLL.FNAME 物料名称, UNTL.FNAME 单位, SUM(A.FMUSTQTY) 实发数量, DEPL.FNAME 领料部门, STK.FNAME 调入仓库, NVL(INV.FAVBQTY, 0) 调入仓库存, STKL.FNAME 调出仓库, NVL(INV2.FAVBQTY, 0) 调出仓库存
                FROM T_PRD_PPBOMENTRY A
                INNER JOIN T_PRD_MOENTRY BE ON A.FMOENTRYID = BE.FENTRYID AND TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') = TO_CHAR(A.FNEEDDATE,'yyyy-mm-dd')
                INNER JOIN T_PRD_MOENTRY_A BA ON BE.FENTRYID = BA.FENTRYID AND BA.FSTATUS IN(3,4)
                INNER JOIN T_PRD_MO B ON BE.FID = B.FID AND B.FDOCUMENTSTATUS = 'C' AND B.FPRDORGID = 100508
                INNER JOIN T_BD_MATERIAL MTL ON A.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508
                INNER JOIN T_BD_MATERIAL_L MTLL ON A.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BD_UNIT_L UNTL ON A.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
                INNER JOIN T_BD_DEPARTMENT DEP ON BE.FWORKSHOPID = DEP.FDEPTID
                INNER JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052
                INNER JOIN T_BD_STOCK_L STK ON DEP.FINSTOCKID = STK.FSTOCKID AND STK.FLOCALEID = 2052
                LEFT JOIN T_STK_INVENTORY INV ON A.FMATERIALID = INV.FMATERIALID AND DEP.FINSTOCKID = INV.FSTOCKID AND INV.FSTOCKSTATUSID = 10000 AND INV.FSTOCKORGID = 100508 AND INV.FOWNERID = 100508 AND INV.FISEFFECTIVED = 1
                INNER JOIN T_AUTO_MSTOCKSETTING MSG ON A.FMATERIALID = MSG.FMATERIALID AND DEPL.FDEPTID = MSG.FDEPTID
                INNER JOIN T_BD_STOCK_L STKL ON MSG.FSTOCKID = STKL.FSTOCKID AND STKL.FLOCALEID = 2052
                LEFT JOIN T_STK_INVENTORY INV2 ON A.FMATERIALID = INV2.FMATERIALID AND MSG.FSTOCKID = INV2.FSTOCKID AND INV2.FSTOCKSTATUSID = 10000 AND INV2.FSTOCKORGID = 100508 AND INV2.FOWNERID = 100508 AND INV2.FISEFFECTIVED = 1
                WHERE " + pFilter + " A.FPAEZHAVEDIRECT = 0 AND STK.FNAME <> STKL.FNAME GROUP BY MTL.FNUMBER, MTLL.FNAME, UNTL.FNAME, STK.FNAME, INV.FAVBQTY, STKL.FNAME, INV2.FAVBQTY, DEPL.FNAME ORDER BY MTL.FNUMBER";
            }
            else if (pFormId == FormID.SAL_SALEORDER)//锁库
            {
                strSQL = @"SELECT A.FBILLNO 单据编号,BILL.FNAME 单据类型,A.FAPPROVEDATE 审核日期,ORGL3.FNAME 销售组织,ORGL.FNAME 库存组织
                    ,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称, UNTL.FNAME 单位, AE.FQTY 销售数量, AE.FLOCKQTY 锁库数量
                    ,AE.FLEFTQTY 待锁库
                    ,CASE WHEN AR.FBASECANOUTQTY >= AR.FBASEPURJOINQTY THEN AR.FBASECANOUTQTY - AR.FBASEPURJOINQTY ELSE 0 END 最大可锁数量
                    ,ORGL2.FNAME 货主,CASE WHEN A.FFULLLOCK = '0' THEN '否' ELSE '是' END 完全锁库,ASSDL.FDATAVALUE 发货类别
                    ,CURL.FNAME 客户,CASE WHEN AE.FBATCHFLAG = '0' THEN '否' ELSE '是' END 批量锁库,AE.FENTRYID 订单内码
                FROM T_SAL_ORDER A
                INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                INNER JOIN T_BD_MATERIALBASE MTLB ON AE.FMATERIALID = MTLB.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLL ON AE.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BAS_BILLTYPE_L BILL ON A.FBILLTYPEID = BILL.FBILLTYPEID AND BILL.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON AE.FSTOCKORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL2 ON AE.FOWNERID = ORGL2.FORGID AND ORGL2.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL3 ON A.FSALEORGID = ORGL3.FORGID AND ORGL3.FLOCALEID = 2052
                INNER JOIN T_BD_UNIT_L UNTL ON MTLB.FBASEUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
                INNER JOIN T_BAS_ASSISTANTDATAENTRY_L ASSDL ON A.FHEADDELIVERYWAY = ASSDL.FENTRYID AND ASSDL.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CURL ON A.FCUSTID = CURL.FCUSTID AND CURL.FLOCALEID = 2052
                WHERE " + pFilter + @" A.FDOCUMENTSTATUS = 'C' AND A.FCLOSESTATUS = 'A' AND AE.FMRPCLOSESTATUS = 'A' AND AE.FMRPTERMINATESTATUS = 'A' AND A.F_PAEZ_FACTORGID = 100508 --AND A.FBILLTYPEID <> '5923fa20686d66'--备货销售订单类型--AND A.FFULLLOCK = '0' AND AE.FLOCKFLAG = '0'
                ORDER BY TO_CHAR(A.FAPPROVEDATE, 'YYYY'),TO_CHAR(A.FAPPROVEDATE, 'MM'),TO_CHAR(A.FAPPROVEDATE, 'DD'), ASSDL.FDATAVALUE,AE.FQTY,A.FID";
            }
            else if (pFormId == FormID.SAL_SALEORDERRUN)//订单运算
            {
                strSQL = @"SELECT A.FBILLNO 单据编号,BILL.FNAME 单据类型,A.FAPPROVEDATE 审核日期,ORGL3.FNAME 销售组织,ORGL.FNAME 库存组织
                    ,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称, UNTL.FNAME 单位, AE.FQTY 销售数量,AE.FLOCKQTY 锁库数量
                    ,AE.FLEFTQTY 待锁库,ORGL2.FNAME 货主,CASE WHEN AE.FLOCKFLAG = '0'  THEN '否' ELSE '是' END 锁库,CASE WHEN A.FFULLLOCK = '0' THEN '否' ELSE '是' END 完全锁库,CASE WHEN AE.FBATCHFLAG = '0' THEN '否' ELSE '是' END 批量锁库
                    ,ASSDL.FDATAVALUE 发货类别,CURL.FNAME 客户,NVL(BOM.FNUMBER,' ') BOM, AE.FENTRYID 订单内码
                FROM T_SAL_ORDER A
                INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                INNER JOIN T_BD_MATERIALBASE MTLB ON AE.FMATERIALID = MTLB.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLL ON AE.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BAS_BILLTYPE_L BILL ON A.FBILLTYPEID = BILL.FBILLTYPEID AND BILL.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON AE.FSTOCKORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL2 ON AE.FOWNERID = ORGL2.FORGID AND ORGL2.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL3 ON A.FSALEORGID = ORGL3.FORGID AND ORGL3.FLOCALEID = 2052
                INNER JOIN T_BD_UNIT_L UNTL ON MTLB.FBASEUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
                INNER JOIN T_BAS_ASSISTANTDATAENTRY_L ASSDL ON A.FHEADDELIVERYWAY = ASSDL.FENTRYID AND ASSDL.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CURL ON A.FCUSTID = CURL.FCUSTID AND CURL.FLOCALEID = 2052
                LEFT JOIN T_ENG_BOM BOM ON AE.FBOMID = BOM.FID
                WHERE " + pFilter + @" A.FDOCUMENTSTATUS = 'C' AND A.FCLOSESTATUS = 'A' AND AE.FMRPCLOSESTATUS = 'A' AND A.F_PAEZ_FACTORGID = 100508 --AND A.FFULLLOCK <> 1 AND AE.FLOCKFLAG <> 1 AND AE.FBATCHFLAG = 1
                ORDER BY CASE WHEN BILL.FNAME = '备货销售订单' THEN 1 ELSE 0 END,TO_CHAR(A.FAPPROVEDATE, 'YYYY') ASC,TO_CHAR(A.FAPPROVEDATE, 'MM'),TO_CHAR(A.FAPPROVEDATE, 'DD'), ASSDL.FDATAVALUE,A.FID,AE.FQTY,AE.FENTRYID";
            }

            return ORAHelper.ExecuteTable(strSQL);
        }

        /// <summary>
        /// 根据销售订单内码获取可锁库信息
        /// </summary>
        /// <param name="pFEntryId">FEntryId</param>
        /// <returns></returns>
        public static DataTable GetOrderLockByFEntryId(int pFEntryId)
        {
            strSQL = @"SELECT A.FID,AE.FENTRYID,XINV.FID FINID,A.FBILLNO 单据编号,MTL.FNUMBER 物料编码,E.FNUMBER 基本单位,D.FNUMBER 需求组织,C.FNUMBER || CL.FNAME 备注,AE.FQTY 销售数量,AE.FLOCKQTY 锁库数量,AE.FLEFTQTY 待锁库,AR.FBASECANOUTQTY - AR.FBASEPURJOINQTY - AE.FLOCKQTY 最大可锁数量--可出数量-关联采购/生产数量
                    ,XINV.FSEQ 序号,XINV.STOCK 仓库编码,XINV.FNAME 仓库,NVL(XINV.FQTY,0) 库存量,NVL(XINV.FAVBQTY,0) 可用量
            FROM T_SAL_ORDER A
            INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
            INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
            INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
            INNER JOIN T_BD_MATERIAL MTL2 ON MTL.FNUMBER = MTL2.FNUMBER AND MTL2.FUSEORGID = 100508
            INNER JOIN T_BD_MATERIALBASE MTLB ON MTL.FMATERIALID = MTLB.FMATERIALID
            INNER JOIN T_BD_CUSTOMER C ON A.FCUSTID = C.FCUSTID
            INNER JOIN T_BD_CUSTOMER_L CL ON C.FCUSTID = CL.FCUSTID AND CL.FLOCALEID = 2052
            INNER JOIN T_ORG_ORGANIZATIONS D ON A.FSALEORGID = D.FORGID
            INNER JOIN T_BD_UNIT E ON MTLB.FBASEUNITID = E.FUNITID
            LEFT JOIN
            (
                SELECT DISTINCT INV.FID,MTL.FNUMBER,MAX(INV.FBASEQTY) FQTY,MAX(INV.FBASEQTY) - NVL(lRES.FBASEQTY,0) FAVBQTY,CST.FSEQ,CST.FNUMBER STOCK,STOL.FNAME
                FROM T_STK_INVENTORY INV
                INNER JOIN DM_CALCULATESTOCK CST ON INV.FSTOCKID = CST.FSTOCKID AND CST.FTYPE = 'LOCKSTOCK'
                INNER JOIN T_BD_STOCK_L STOL ON CST.FSTOCKID = STOL.FSTOCKID AND STOL.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIAL MTL ON INV.FMATERIALID = MTL.FMATERIALID
                LEFT JOIN
                (
                SELECT MTL.FNUMBER,SUM(NVL(RES.FBASEQTY,0)) FBASEQTY
                FROM T_PLN_RESERVELINKENTRY RES
                INNER JOIN T_BD_MATERIAL MTL ON RES.FMATERIALID = MTL.FMATERIALID
                WHERE RES.FBASEQTY > 0 AND RES.FSUPPLYFORMID = 'STK_Inventory'
                GROUP BY MTL.FNUMBER
                ) LRES ON MTL.FNUMBER = LRES.FNUMBER
                WHERE INV.FISEFFECTIVED = 1 AND INV.FSTOCKSTATUSID = 10000
                GROUP BY INV.FID,MTL.FNUMBER,lRES.FBASEQTY,CST.FSEQ,CST.FNUMBER,STOL.FNAME
            )XINV ON MTL.FNUMBER = XINV.FNUMBER
            WHERE AE.FENTRYID = " + pFEntryId.ToString();

            return ORAHelper.ExecuteTable(strSQL);//根据销售订单内码获取可锁库信息
        }

        /// <summary>
        /// 锁库反写销售订单
        /// </summary>
        /// <param name="pCanLockQty">可锁数量</param>
        /// <param name="pFID">销售订单ID</param>
        /// <param name="pFEntryId">销售订单分录ID</param>
        public static void UpdateOrderLock(string pCanLockQty, int pFID, int pFEntryId)
        {
            strSQL = @"DECLARE
                   iTemp NUMBER(10);
            BEGIN    
              UPDATE T_SAL_ORDERENTRY SET FLOCKQTY = FLOCKQTY + " + pCanLockQty + ",FLEFTQTY = CASE WHEN FLEFTQTY = 0 THEN 0 ELSE FLEFTQTY - " + pCanLockQty + " END,FBATCHFLAG = '1' WHERE FENTRYID = " + pFEntryId.ToString() + @";
  
              SELECT CASE WHEN FQTY - FLOCKQTY = 0 THEN 1 ELSE 0 END INTO iTemp FROM T_SAL_ORDERENTRY WHERE FENTRYID = " + pFEntryId.ToString() + @";
  
              IF iTemp = 1 THEN
                 UPDATE T_SAL_ORDERENTRY SET Flockflag = '1' WHERE FENTRYID = " + pFEntryId.ToString() + @";
              END IF;
  
              SELECT CASE WHEN COUNT(1) - SUM(NVL(AE.FLOCKFLAG,0)) = 0 THEN 1 ELSE 0 END INTO iTemp
              FROM T_SAL_ORDERENTRY AE
              LEFT JOIN T_BD_MATERIAL B ON AE.FMATERIALID = B.FMATERIALID AND B.FNUMBER NOT LIKE '40101%' AND B.FNUMBER NOT LIKE '40104%' AND B.FNUMBER NOT LIKE '40201%' AND B.FNUMBER NOT LIKE '40301%' AND B.FNUMBER NOT LIKE '1801%' AND B.FNUMBER NOT LIKE '1802%'-- AND B.FNUMBER NOT LIKE '311%' AND B.FNUMBER NOT LIKE '312%' AND B.FNUMBER NOT LIKE '313%' AND B.FNUMBER NOT LIKE '315%'
              WHERE FID = " + pFID.ToString() + @";
  
              IF iTemp = 1 THEN
                 UPDATE T_SAL_ORDER SET FFULLLOCK = '1' WHERE FID =  " + pFID.ToString() + @";
              END IF;
  
              COMMIT;
              DBMS_OUTPUT.PUT_LINE('更新成功');

              EXCEPTION
                WHEN OTHERS THEN 
                  ROLLBACK;
                  DBMS_OUTPUT.PUT_LINE('更新失败：');
                  DBMS_OUTPUT.PUT_LINE(SQLERRM);
            END;";

            ORAHelper.ExecuteNonQuery(strSQL);
        }

        /// <summary>
        /// 解锁反写销售订单
        /// </summary>
        /// <param name="pLockQty">解锁数量</param>
        /// <param name="pFEntryId">销售订单分录ID</param>
        public static void UnLockSalOrder(string pLockQty, int pFEntryId)
        {
            strSQL = @"BEGIN
            DELETE FROM T_PLN_RESERVELINKENTRY AE WHERE EXISTS(SELECT 1 FROM T_PLN_RESERVELINK A WHERE A.FID = AE.FID AND A.FSRCENTRYID = " + pFEntryId.ToString() + @");
            DELETE FROM T_PLN_RESERVELINK WHERE FSRCENTRYID = " + pFEntryId.ToString() + @";
    
            UPDATE T_SAL_ORDERENTRY
            SET FLOCKFLAG = 0,FLOCKQTY = 0, FLEFTQTY = FLEFTQTY + " + pLockQty + @"
            WHERE FENTRYID = " + pFEntryId.ToString() + @";
    
            UPDATE T_SAL_ORDER
            SET FFULLLOCK = 0
            WHERE FID = (SELECT FID FROM T_SAL_ORDERENTRY WHERE FENTRYID = " + pFEntryId.ToString() + @") AND FFULLLOCK = 1;
  
            COMMIT;
            DBMS_OUTPUT.PUT_LINE('更新成功');

            EXCEPTION
                WHEN OTHERS THEN 
                ROLLBACK;
                DBMS_OUTPUT.PUT_LINE('更新失败：');
                DBMS_OUTPUT.PUT_LINE(SQLERRM);
            END;";

            ORAHelper.ExecuteNonQuery(strSQL);
        }

        /// <summary>
        /// 锁库后反写销售订单
        /// </summary>
        /// <param name="pCanLockQty">可锁数量</param>
        /// <param name="pFEntryId">销售订单分录ID</param>
        public static void UpdateOrderLock(string pCanLockQty, int pFEntryId)
        {
            ORAHelper.ExecuteNonQuery("UPDATE T_SAL_ORDERENTRY SET FLOCKQTY = FLOCKQTY + " + pCanLockQty.ToString() + ",FLEFTQTY = CASE WHEN FLEFTQTY = 0 THEN 0 ELSE FLEFTQTY - " + pCanLockQty.ToString() + @" END,FBATCHFLAG = '1' WHERE FENTRYID = " + pFEntryId.ToString());
        }

        /// <summary>
        /// 修改执行过锁库订单的批量锁库标识
        /// </summary>
        /// <param name="pList">列表</param>
        public static void UpdateBatchFlag(IList pList)
        {
            string strFEntryIds = string.Empty;

            if (pList.Count == 0)
                return;

            for (int i = 0; i < pList.Count; i++)
            {
                if (i < 1000)
                {
                    if (i > 0) strFEntryIds += ",";
                    strFEntryIds += ((OrderInfo)pList[i]).FEntryId.ToString();
                }
                else if (i < 2000)
                {
                    if (i == 1000)
                        strFEntryIds += ") OR FENTRYID IN(" + ((OrderInfo)pList[i]).FEntryId.ToString();
                    else
                        strFEntryIds += "," + ((OrderInfo)pList[i]).FEntryId.ToString();
                }
                else
                {
                    if (i == 2000)
                        strFEntryIds += ") OR FENTRYID IN(" + ((OrderInfo)pList[i]).FEntryId.ToString();
                    else
                        strFEntryIds += "," + ((OrderInfo)pList[i]).FEntryId.ToString();
                }
            }

            strSQL = @"UPDATE T_SAL_ORDERENTRY SET FBATCHFLAG = '1' WHERE FENTRYID IN (" + strFEntryIds + ")";

            ORAHelper.ExecuteNonQuery(strSQL);
        }

        /// <summary>
        /// 添加预留关系
        /// </summary>
        /// <param name="pDR">数据行</param>
        /// <param name="pQTY">数量</param>
        /// <returns></returns>
        public static string AddReserveLink(DataRow pDR, double pQTY)
        {
            string strRetrunValue = string.Empty;
            K3CloudApiClient client = new K3CloudApiClient(GlobalParameter.K3Inf.C_ERPADDRESS);
            var bLogin = client.Login(GlobalParameter.K3Inf.C_ZTID, "damo", "111111", 2052);

            if (bLogin)
            {
                JObject jsonRoot = new JObject();
                jsonRoot.Add("Creator", "");
                jsonRoot.Add("NeedUpDateFields", new JArray(""));
                jsonRoot.Add("NeedReturnFields", new JArray(""));
                jsonRoot.Add("IsDeleteEntry", "True");
                jsonRoot.Add("IsVerifyBaseDataField", "false");
                jsonRoot.Add("SubSystemId", "");

                JObject model = new JObject();
                jsonRoot.Add("Model", model);
                model.Add("FID", 0);

                model.Add("FPARENTBILLNO", pDR["单据编号"].ToString());
                model.Add("FSRCBILLNO", pDR["单据编号"].ToString());
                model.Add("FDEMANDBILLNO", pDR["单据编号"].ToString());
                model.Add("FBASEDEMANDQTY", pDR["销售数量"].ToString());
                model.Add("FDosageType", "2");
                model.Add("FRESERVETYPE", "3");
                model.Add("FSRCENTRYID", pDR["FENTRYID"].ToString());
                model.Add("FSRCINTERID", pDR["FID"].ToString());
                model.Add("FDemandENTRYID", pDR["FENTRYID"].ToString());
                model.Add("FDEMANDINTERID", pDR["FID"].ToString());

                model.Add("FSupRate", 100.0);
                model.Add("FScrapRate", 0.0);
                model.Add("FBaseFixScrapQty", 0.0);
                model.Add("FBASENUMERATOR", 1);
                model.Add("FBASEDENOMINATOR", 1);

                model.Add("FRemarks", pDR["备注"].ToString());

                JObject basedata = new JObject();
                basedata.Add("FNumber", pDR["基本单位"].ToString());
                model.Add("FBASEDEMANDUNITID", basedata);

                basedata = new JObject();
                basedata.Add("FID", "SAL_SaleOrder");
                model.Add("FSRCFORMID", basedata);

                basedata = new JObject();
                basedata.Add("FID", "SAL_SaleOrder");
                model.Add("FDEMANDFORMID", basedata);

                basedata = new JObject();
                basedata.Add("FNumber", pDR["物料编码"].ToString());
                model.Add("FMATERIALID", basedata);

                model.Add("FDate", DateTime.Today);

                //--Detail
                JArray entryRows = new JArray();

                string entityKey = "FEntity";
                model.Add(entityKey, entryRows);

                JObject entryRow = new JObject();
                entryRows.Add(entryRow);

                entryRow.Add("FEntryID", 0);

                basedata = new JObject();
                basedata.Add("FID", "STK_Inventory");
                entryRow.Add("FSUPPLYFORMID", basedata);

                entryRow.Add("FSUPPLYINTERID", pDR["FINID"].ToString());
                entryRow.Add("FBASESUPPLYQTY", pQTY);
                entryRow.Add("FLINKTYPE", "4");
                entryRow.Add("FSupplyRemarks", pDR["备注"].ToString());

                basedata = new JObject();
                basedata.Add("FNumber", pDR["物料编码"].ToString());
                entryRow.Add("FSUPPLYMATERIALID", basedata);

                basedata = new JObject();
                basedata.Add("FNumber", pDR["需求组织"].ToString());
                entryRow.Add("FSUPPLYORGID", basedata);

                basedata = new JObject();
                basedata.Add("FNumber", pDR["仓库编码"].ToString());
                entryRow.Add("FSUPPLYSTOCKID", basedata);

                basedata = new JObject();
                basedata.Add("FNumber", pDR["基本单位"].ToString());
                entryRow.Add("FBASESUPPLYUNITID", basedata);

                //调用Web API接口服务，保存采购订单
                strRetrunValue = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "PLN_RESERVELINK", jsonRoot.ToString() });
                JObject jo = JObject.Parse(strRetrunValue);

                if (!jo["Result"]["ResponseStatus"]["IsSuccess"].Value<bool>())
                {
                    strRetrunValue = string.Empty;
                    for (int i = 0; i < ((IList)jo["Result"]["ResponseStatus"]["Errors"]).Count; i++)
                        strRetrunValue += jo["Result"]["ResponseStatus"]["Errors"][i]["FieldName"].Value<string>() + "\r\n";//保存不成功返错误信息
                }
                else
                {
                    strRetrunValue = "FID:" + jo["Result"]["Id"].Value<string>();//保存成功返回单据编号FBILLNO
                }
            }

            return strRetrunValue;
        }

        /// <summary>
        /// 根据物料ID获取即时库存信息
        /// </summary>
        /// <param name="pFMaterialId">物料ID</param>
        /// <returns></returns>
        public static DataTable GetInventoryInfByMaterialId(string pFMaterialId)
        {
            strSQL = @"SELECT FID FINID,FNUMBER STOCK,SUM(FAVBQTY) FAVBQTY
            FROM
            (
                SELECT INV.FID,INV.FMATERIALID,CST.FNUMBER,CST.FSEQ,INV.FBASEQTY - SUM(NVL(RES.FBASEQTY,0)) FAVBQTY
                FROM T_STK_INVENTORY INV
                INNER JOIN DM_CALCULATESTOCK CST ON INV.FSTOCKID = CST.FSTOCKID AND CST.FTYPE = 'RUNSTOCK'
                LEFT JOIN T_PLN_RESERVELINKENTRY RES ON INV.FMATERIALID = RES.FMATERIALID AND INV.FSTOCKID = RES.FSTOCKID AND RES.FBASEQTY > 0 AND RES.FSUPPLYFORMID = 'STK_INVENTORY'
                WHERE INV.FISEFFECTIVED = 1 AND INV.FSTOCKSTATUSID = 10000
                GROUP BY INV.FID,INV.FMATERIALID,CST.FNUMBER,CST.FSEQ,INV.FBASEQTY
                HAVING INV.FBASEQTY - SUM(NVL(RES.FBASEQTY,0)) > 0
            )XINV
            WHERE FMATERIALID = " + pFMaterialId + @"
            GROUP BY FID,FMATERIALID,FNUMBER,FSEQ
            ORDER BY FSEQ";

            return ORAHelper.ExecuteTable(strSQL);
        }

        //--
        /// <summary>
        /// 成品运算
        /// </summary>
        /// <param name="pDtRun">运算DataTable</param>
        /// <returns></returns>
        public static DataTable OrderRun(DataTable pDtRun, bool pJoinQty)
        {
            string strFEntryIds = string.Empty;

            for (int i = 0; i < pDtRun.Rows.Count; i++)
            {
                if (i < 1000)
                {
                    if (i > 0) strFEntryIds += ",";
                    strFEntryIds += pDtRun.Rows[i]["订单内码"].ToString();
                }
                else if (i < 2000)
                {
                    if (i == 1000)
                        strFEntryIds += ") OR AE.FENTRYID IN(" + pDtRun.Rows[i]["订单内码"].ToString();
                    else
                        strFEntryIds += "," + pDtRun.Rows[i]["订单内码"].ToString();
                }
                else
                {
                    if (i == 2000)
                        strFEntryIds += ") OR AE.FENTRYID IN(" + pDtRun.Rows[i]["订单内码"].ToString();
                    else
                        strFEntryIds += "," + pDtRun.Rows[i]["订单内码"].ToString();
                }
            }

            if (pJoinQty)
                strSQL = @"SELECT DISTINCT A.FID,AE.FENTRYID,A.FBILLNO 单据编号,BILL.FNAME 单据类型,ASSDL.FDATAVALUE 发货类别,A.FAPPROVEDATE 审核日期,MTL.FNUMBER 物料编码
                    ,MTLL.FNAME 物料名称,CUSTL.FNAME 客户名称,UNTL.FNAME 单位,AE.FQTY 订单数量,AE.FLOCKQTY 锁库数量,AE.FQTY - AE.FLOCKQTY 订单需求
                    ,AR.FREMAINOUTQTY 未出库数量,AR.FSTOCKOUTQTY 已出库数量,AR.FBASECANOUTQTY 可出库数量,SUM(NVL(BE.FQTY,0)) 已经下达任务单数量,AE.FQTY - SUM(NVL(BE.FQTY,0)) 未下达任务单数量
                    ,FBASEPURJOINQTY 关联采购生产数量,BOM.FNUMBER BOM版本,AE.F_PAEZ_RUNTIME + 1 运算次数
                    ,CASE WHEN AR.FBASECANOUTQTY - AE.FLOCKQTY - AR.FBASEPURJOINQTY > 0 THEN '是' ELSE '否' END 是否欠料
                    ,CASE WHEN AR.FBASECANOUTQTY - AE.FLOCKQTY - AR.FBASEPURJOINQTY > 0 THEN ' ' ELSE '无需生产' END 欠料等级
                    ,CASE WHEN AE.FBATCHFLAG = 1 THEN '是' ELSE '否' END 批量锁库,CASE WHEN AE.FLOCKFLAG = 0 THEN '否' ELSE '是' END 锁库,CASE WHEN A.FFULLLOCK = 0 THEN '否' ELSE '是' END 完全锁库,A.FNOTE 备注
                FROM T_SAL_ORDER A
                INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                INNER JOIN T_BD_MATERIAL MTL2 ON MTL.FNUMBER = MTL2.FNUMBER AND MTL2.FUSEORGID = 100508
                INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIALBASE MTLB ON MTL.FMATERIALID = MTLB.FMATERIALID
                INNER JOIN T_BD_UNIT_L UNTL ON MTLB.FBASEUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
                INNER JOIN T_BAS_BILLTYPE_L BILL ON A.FBILLTYPEID = BILL.FBILLTYPEID AND BILL.FLOCALEID = 2052
                INNER JOIN T_BAS_ASSISTANTDATAENTRY_L ASSDL ON A.FHEADDELIVERYWAY = ASSDL.FENTRYID AND ASSDL.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSTL ON A.FCUSTID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052
                LEFT JOIN T_PRD_MOENTRY BE ON AE.FENTRYID = BE.FSALEORDERENTRYID
                LEFT JOIN T_PRD_MOENTRY_A BEA ON BE.FENTRYID = BEA.FENTRYID AND BEA.FSTATUS IN(3,4)
                --LEFT JOIN T_ENG_BOM BOM ON MTL2.FMATERIALID = BOM.FMATERIALID AND BOM.FBOMUSE NOT IN(3,4) AND BOM.FDOCUMENTSTATUS = 'C' AND BOM.FFORBIDSTATUS = 'A'
                LEFT JOIN
                (
                 SELECT FNUMBER,FMATERIALID FROM T_ENG_BOM BOM1 WHERE BOM1.FID = (SELECT MAX(FID) FID FROM T_ENG_BOM BOM2 WHERE BOM1.FBOMUSE NOT IN(3,4) AND BOM1.FDOCUMENTSTATUS = 'C' AND BOM1.FFORBIDSTATUS = 'A' AND BOM1.FMATERIALID = BOM2.FMATERIALID)
                ) BOM ON  MTL2.FMATERIALID = BOM.FMATERIALID
                WHERE AE.FENTRYID IN(" + strFEntryIds + @")
                GROUP BY  A.FID,AE.FENTRYID,A.FBILLNO,BILL.FNAME,ASSDL.FDATAVALUE,A.FAPPROVEDATE,MTL.FNUMBER,MTLL.FNAME,CUSTL.FNAME,UNTL.FNAME,AE.FQTY,AE.FLOCKQTY,AR.FREMAINOUTQTY,AR.FSTOCKOUTQTY,AR.FBASECANOUTQTY,AR.FBASEPURJOINQTY,BOM.FNUMBER,AE.F_PAEZ_RUNTIME,AE.FBATCHFLAG,AE.FLOCKFLAG,A.FFULLLOCK,A.FNOTE
                ORDER BY CASE WHEN BILL.FNAME = '备货销售订单' THEN 1 ELSE 0 END,TO_CHAR(A.FAPPROVEDATE, 'YYYY') ASC,TO_CHAR(A.FAPPROVEDATE, 'MM'),TO_CHAR(A.FAPPROVEDATE, 'DD'),ASSDL.FDATAVALUE,A.FID,AE.FQTY,AE.FENTRYID";
            else
                strSQL = @"SELECT DISTINCT A.FID,AE.FENTRYID,A.FBILLNO 单据编号,BILL.FNAME 单据类型,ASSDL.FDATAVALUE 发货类别,A.FAPPROVEDATE 审核日期,MTL.FNUMBER 物料编码
                    ,MTLL.FNAME 物料名称,CUSTL.FNAME 客户名称,UNTL.FNAME 单位,AE.FQTY 订单数量,AE.FLOCKQTY 锁库数量,AE.FQTY - AE.FLOCKQTY 订单需求
                    ,AR.FREMAINOUTQTY 未出库数量,AR.FSTOCKOUTQTY 已出库数量,AR.FBASECANOUTQTY 可出库数量,SUM(NVL(BE.FQTY,0)) 已经下达任务单数量,AE.FQTY - SUM(NVL(BE.FQTY,0)) 未下达任务单数量
                    ,0 关联采购生产数量,BOM.FNUMBER BOM版本,AE.F_PAEZ_RUNTIME + 1 运算次数
                    ,CASE WHEN AR.FBASECANOUTQTY - AE.FLOCKQTY > 0 THEN '是' ELSE '否' END 是否欠料
                    ,CASE WHEN AR.FBASECANOUTQTY - AE.FLOCKQTY > 0 THEN ' ' ELSE '无需生产' END 欠料等级
                    ,CASE WHEN AE.FBATCHFLAG = 1 THEN '是' ELSE '否' END 批量锁库,CASE WHEN AE.FLOCKFLAG = 0 THEN '否' ELSE '是' END 锁库,CASE WHEN A.FFULLLOCK = 0 THEN '否' ELSE '是' END 完全锁库,A.FNOTE 备注
                FROM T_SAL_ORDER A
                INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                INNER JOIN T_BD_MATERIAL MTL2 ON MTL.FNUMBER = MTL2.FNUMBER AND MTL2.FUSEORGID = 100508
                INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIALBASE MTLB ON MTL.FMATERIALID = MTLB.FMATERIALID
                INNER JOIN T_BD_UNIT_L UNTL ON MTLB.FBASEUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052
                INNER JOIN T_BAS_BILLTYPE_L BILL ON A.FBILLTYPEID = BILL.FBILLTYPEID AND BILL.FLOCALEID = 2052
                INNER JOIN T_BAS_ASSISTANTDATAENTRY_L ASSDL ON A.FHEADDELIVERYWAY = ASSDL.FENTRYID AND ASSDL.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSTL ON A.FCUSTID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052
                LEFT JOIN T_PRD_MOENTRY BE ON AE.FENTRYID = BE.FSALEORDERENTRYID
                LEFT JOIN T_PRD_MOENTRY_A BEA ON BE.FENTRYID = BEA.FENTRYID AND BEA.FSTATUS IN(3,4)
                --LEFT JOIN T_ENG_BOM BOM ON MTL2.FMATERIALID = BOM.FMATERIALID AND BOM.FBOMUSE NOT IN(3,4) AND BOM.FDOCUMENTSTATUS = 'C' AND BOM.FFORBIDSTATUS = 'A'
                LEFT JOIN
                (
                 SELECT FNUMBER,FMATERIALID FROM T_ENG_BOM BOM1 WHERE BOM1.FID = (SELECT MAX(FID) FID FROM T_ENG_BOM BOM2 WHERE BOM1.FBOMUSE NOT IN(3,4) AND BOM1.FDOCUMENTSTATUS = 'C' AND BOM1.FFORBIDSTATUS = 'A' AND BOM1.FMATERIALID = BOM2.FMATERIALID)
                ) BOM ON  MTL2.FMATERIALID = BOM.FMATERIALID
                WHERE AE.FENTRYID IN(" + strFEntryIds + @")
                GROUP BY  A.FID,AE.FENTRYID,A.FBILLNO,BILL.FNAME,ASSDL.FDATAVALUE,A.FAPPROVEDATE,MTL.FNUMBER,MTLL.FNAME,CUSTL.FNAME,UNTL.FNAME,AE.FQTY,AE.FLOCKQTY,AR.FREMAINOUTQTY,AR.FSTOCKOUTQTY,AR.FBASECANOUTQTY,BOM.FNUMBER,AE.F_PAEZ_RUNTIME,AE.FBATCHFLAG,AE.FLOCKFLAG,A.FFULLLOCK,A.FNOTE
                ORDER BY CASE WHEN BILL.FNAME = '备货销售订单' THEN 1 ELSE 0 END,TO_CHAR(A.FAPPROVEDATE, 'YYYY') ASC,TO_CHAR(A.FAPPROVEDATE, 'MM'),TO_CHAR(A.FAPPROVEDATE, 'DD'),ASSDL.FDATAVALUE,A.FID,AE.FQTY,AE.FENTRYID";

            return ORAHelper.ExecuteTable(strSQL);
        }

        /// <summary>
        /// 子项运算
        /// </summary>
        /// <param name="pRunEntryId">销售订单分录ID</param>
        /// <param name="pStarTime">开始时间</param>
        /// <param name="pEndTime">结束时间</param>
        /// <returns></returns>
        public static DataTable OrderRun(List<int> pRunEntryId, DateTime pStarTime, DateTime pEndTime, bool pJoinQty)
        {
            string strFEntryIds = string.Empty;

            for (int i = 0; i < pRunEntryId.Count; i++)
            {
                if (i < 1000)
                {
                    if (i > 0) strFEntryIds += ",";
                    strFEntryIds += pRunEntryId[i].ToString();
                }
                else if (i < 2000)
                {
                    if (i == 1000)
                        strFEntryIds += ") OR AE.FENTRYID IN(" + pRunEntryId[i].ToString();
                    else
                        strFEntryIds += "," + pRunEntryId[i].ToString();
                }
                else
                {
                    if (i == 2000)
                        strFEntryIds += ") OR AE.FENTRYID IN(" + pRunEntryId[i].ToString();
                    else
                        strFEntryIds += "," + pRunEntryId[i].ToString();
                }
            }

            if (pJoinQty)
                strSQL = @"SELECT DISTINCT A.FID,AE.FENTRYID,A.FBILLNO,MTL.FNUMBER PFNUMBER,MTLL.FNAME PFNAME,MTLC.FNUMBER,  MTLLC.FNAME,UNI.FNUMBER UNIT,BOM2.FNUMBER BOM,AE.FQTY,AE.FLOCKQTY
                        ,(AR.FBASECANOUTQTY - AR.FBASEPURJOINQTY - AE.FLOCKQTY) * BOMC.FNUMERATOR/BOMC.FDENOMINATOR * (100+BOMC.FSCRAPRATE)/100 FSUBQTY,NVL(XINVC.FQTY,0) STOCKQTY,NVL(XINVC.FAVBQTY,0) STOCKAVBQTY,MTLB.FERPCLSID,NVL(XPO.FREMAINSTOCKINQTY,0) FPOQTY,  NVL(XMO.FQTY,0) FMOQTY,MTLS.FMINSTOCK,MTLS.FMAXSTOCK,MTLS.F_PAEZ_SAFEDAYS,F_PAEZ_LOGISTICSDAYS
                        ,MTLS.F_PAEZ_LOWQTY,MTLS.F_PAEZ_MINQTY,MTLS.F_PAEZ_REPLENISHMENT,NVL(XPIC.FACTUALQTY,0) FACTUALQTY,NVL(D.FGROUPLEVEL,' ') FGROUPLEVEL,ORG.FNUMBER SALORG,BOMC.FMATERIALID
                FROM T_SAL_ORDER A
                INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIAL MTL2 ON MTL.FNUMBER = MTL2.FNUMBER AND MTL2.FUSEORGID = 100508
                --INNER JOIN T_ENG_BOM BOM ON MTL2.FMATERIALID = BOM.FMATERIALID
                INNER JOIN
                (
                 SELECT FID,FNUMBER,FMATERIALID,FBOMUSE FROM T_ENG_BOM BOM1 WHERE BOM1.FID = (SELECT MAX(FID) FID FROM T_ENG_BOM BOM2 WHERE BOM1.FBOMUSE NOT IN(3,4) AND BOM1.FDOCUMENTSTATUS = 'C' AND BOM1.FFORBIDSTATUS = 'A' AND BOM1.FMATERIALID = BOM2.FMATERIALID)--FBOMUSE 99:通用;2:自制;3:委外;4:组装
                )BOM ON  MTL2.FMATERIALID = BOM.FMATERIALID
                INNER JOIN T_ENG_BOMCHILD BOMC ON BOM.FID = BOMC.FID
                INNER JOIN T_BD_MATERIALBASE MTLB ON BOMC.FMATERIALID = MTLB.FMATERIALID
                INNER JOIN T_BD_UNIT UNI ON MTLB.FBASEUNITID = UNI.FUNITID
                INNER JOIN T_BD_MATERIAL MTLC ON BOMC.FMATERIALID = MTLC.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLLC ON MTLC.FMATERIALID = MTLLC.FMATERIALID AND MTLLC.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIALSTOCK MTLS ON MTLC.FMATERIALID = MTLS.FMATERIALID
                LEFT JOIN T_ENG_BOM BOM2 ON MTLC.FMATERIALID = BOM2.FMATERIALID AND BOM.FBOMUSE = BOM2.FBOMUSE--FBOMUSE 99:通用;2:自制;3:委外;4:组装
                LEFT JOIN T_BD_MATERIALGROUP D ON D.FNUMBER = CASE WHEN SUBSTR(MTLC.FNUMBER,0,1) IN(1,3,5,7) THEN SUBSTR(MTLC.FNUMBER,0,2) ELSE SUBSTR(MTLC.FNUMBER,0,3) END--1:原材料;2:半成品;3:产成品;4:曾品;5:呆滞物料;6:周转材料;9.30:郑州办外购
                INNER JOIN T_ORG_ORGANIZATIONS ORG ON A.FSALEORGID = ORG.FORGID
                LEFT JOIN
                (
                    SELECT FMATERIALID,SUM(FQTY) FQTY,SUM(FAVBQTY) FAVBQTY
                    FROM
                    (
                        SELECT INV.FMATERIALID,INV.FSTOCKID,INV.FBASEQTY FQTY,INV.FBASEQTY - SUM(NVL(RES.FBASEQTY,0)) FAVBQTY
                        FROM T_STK_INVENTORY INV
                        INNER JOIN DM_CALCULATESTOCK CST ON INV.FSTOCKID = CST.FSTOCKID AND CST.FTYPE = 'RUNSTOCK'
                        LEFT JOIN T_PLN_RESERVELINKENTRY RES ON INV.FMATERIALID = RES.FMATERIALID AND INV.FSTOCKID = RES.FSTOCKID AND RES.FBASEQTY > 0 AND RES.FSUPPLYFORMID = 'STK_Inventory'
                        WHERE INV.FISEFFECTIVED = 1 AND INV.FSTOCKSTATUSID = 10000--FSTOCKSTATUSID 10000:可用;10001:待检;10002:冻结;10003:退回冻结;10004:在途;10005:收货冻结;10006:废品;10257:不良
                        GROUP BY INV.FMATERIALID,INV.FSTOCKID,INV.FBASEQTY
                    )XINV
                    GROUP BY FMATERIALID
                )XINVC ON BOMC.FMATERIALID = XINVC.FMATERIALID
                LEFT JOIN
                (
                    SELECT POE.FMATERIALID,SUM(POR.FREMAINSTOCKINQTY) FREMAINSTOCKINQTY
                    FROM T_PUR_POORDER PO
                    INNER JOIN T_PUR_POORDERENTRY POE ON PO.FID = POE.FID
                    INNER JOIN T_PUR_POORDERENTRY_R POR ON POE.FENTRYID = POR.FENTRYID
                    GROUP BY POE.FMATERIALID
                )XPO ON BOMC.FMATERIALID = XPO.FMATERIALID
                LEFT JOIN
                (
                    SELECT MOE.FMATERIALID,SUM(MOE.FQTY) FQTY
                    FROM T_PRD_MO MO
                    INNER JOIN T_PRD_MOENTRY MOE ON MO.FID = MOE.FID
                    INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID
                    WHERE MOA.FSTATUS IN(3,4)--1:计划;2:计划确认;3:下达;4:开工;5:完工;6:结案;7:结算。
                    GROUP BY MOE.FMATERIALID
                )XMO ON BOMC.FMATERIALID = XMO.FMATERIALID
                LEFT JOIN
                (
                    SELECT PICA.FMATERIALID, SUM(PICA.FACTUALQTY) FACTUALQTY
                    FROM T_PRD_PICKMTRL PIC
                    INNER JOIN T_PRD_PICKMTRLDATA PICA ON PIC.FID = PICA.FID
                    WHERE PIC.FDATE BETWEEN TO_DATE('" + pStarTime.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pEndTime.ToString("yyyy-MM-dd") + @"','yyyy-mm-dd')
                    GROUP BY PICA.FMATERIALID
                ) XPIC ON BOMC.FMATERIALID = XPIC.FMATERIALID
                WHERE AE.FENTRYID IN(" + strFEntryIds + ")";
            else
                strSQL = @"SELECT DISTINCT A.FID,AE.FENTRYID,A.FBILLNO,MTL.FNUMBER PFNUMBER,MTLL.FNAME PFNAME,MTLC.FNUMBER,  MTLLC.FNAME,UNI.FNUMBER UNIT,BOM2.FNUMBER BOM,AE.FQTY,AE.FLOCKQTY
                        ,(AR.FBASECANOUTQTY - AE.FLOCKQTY) * BOMC.FNUMERATOR/BOMC.FDENOMINATOR * (100+BOMC.FSCRAPRATE)/100 FSUBQTY,NVL(XINVC.FQTY,0) STOCKQTY,NVL(XINVC.FAVBQTY,0) STOCKAVBQTY,MTLB.FERPCLSID,NVL(XPO.FREMAINSTOCKINQTY,0) FPOQTY,  NVL(XMO.FQTY,0) FMOQTY,MTLS.FMINSTOCK,MTLS.FMAXSTOCK,MTLS.F_PAEZ_SAFEDAYS,F_PAEZ_LOGISTICSDAYS
                        ,MTLS.F_PAEZ_LOWQTY,MTLS.F_PAEZ_MINQTY,MTLS.F_PAEZ_REPLENISHMENT,NVL(XPIC.FACTUALQTY,0) FACTUALQTY,NVL(D.FGROUPLEVEL,' ') FGROUPLEVEL,ORG.FNUMBER SALORG,BOMC.FMATERIALID
                FROM T_SAL_ORDER A
                INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIAL MTL2 ON MTL.FNUMBER = MTL2.FNUMBER AND MTL2.FUSEORGID = 100508
                --INNER JOIN T_ENG_BOM BOM ON MTL2.FMATERIALID = BOM.FMATERIALID
                INNER JOIN
                (
                 SELECT FID,FNUMBER,FMATERIALID,FBOMUSE FROM T_ENG_BOM BOM1 WHERE BOM1.FID = (SELECT MAX(FID) FID FROM T_ENG_BOM BOM2 WHERE BOM1.FBOMUSE NOT IN(3,4) AND BOM1.FDOCUMENTSTATUS = 'C' AND BOM1.FFORBIDSTATUS = 'A' AND BOM1.FMATERIALID = BOM2.FMATERIALID)--FBOMUSE 99:通用;2:自制;3:委外;4:组装
                )BOM ON  MTL2.FMATERIALID = BOM.FMATERIALID
                INNER JOIN T_ENG_BOMCHILD BOMC ON BOM.FID = BOMC.FID
                INNER JOIN T_BD_MATERIALBASE MTLB ON BOMC.FMATERIALID = MTLB.FMATERIALID
                INNER JOIN T_BD_UNIT UNI ON MTLB.FBASEUNITID = UNI.FUNITID
                INNER JOIN T_BD_MATERIAL MTLC ON BOMC.FMATERIALID = MTLC.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLLC ON MTLC.FMATERIALID = MTLLC.FMATERIALID AND MTLLC.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIALSTOCK MTLS ON MTLC.FMATERIALID = MTLS.FMATERIALID
                LEFT JOIN T_ENG_BOM BOM2 ON MTLC.FMATERIALID = BOM2.FMATERIALID AND BOM.FBOMUSE = BOM2.FBOMUSE--FBOMUSE 99:通用;2:自制;3:委外;4:组装
                LEFT JOIN T_BD_MATERIALGROUP D ON D.FNUMBER = CASE WHEN SUBSTR(MTLC.FNUMBER,0,1) IN(1,3,5,7) THEN SUBSTR(MTLC.FNUMBER,0,2) ELSE SUBSTR(MTLC.FNUMBER,0,3) END--1:原材料;2:半成品;3:产成品;4:曾品;5:呆滞物料;6:周转材料;9.30:郑州办外购
                INNER JOIN T_ORG_ORGANIZATIONS ORG ON A.FSALEORGID = ORG.FORGID
                LEFT JOIN
                (
                    SELECT FMATERIALID,SUM(FQTY) FQTY,SUM(FAVBQTY) FAVBQTY
                    FROM
                    (
                        SELECT INV.FMATERIALID,INV.FSTOCKID,INV.FBASEQTY FQTY,INV.FBASEQTY - SUM(NVL(RES.FBASEQTY,0)) FAVBQTY
                        FROM T_STK_INVENTORY INV
                        INNER JOIN DM_CALCULATESTOCK CST ON INV.FSTOCKID = CST.FSTOCKID AND CST.FTYPE = 'RUNSTOCK'
                        LEFT JOIN T_PLN_RESERVELINKENTRY RES ON INV.FMATERIALID = RES.FMATERIALID AND INV.FSTOCKID = RES.FSTOCKID AND RES.FBASEQTY > 0 AND RES.FSUPPLYFORMID = 'STK_Inventory'
                        WHERE INV.FISEFFECTIVED = 1 AND INV.FSTOCKSTATUSID = 10000--FSTOCKSTATUSID 10000:可用;10001:待检;10002:冻结;10003:退回冻结;10004:在途;10005:收货冻结;10006:废品;10257:不良
                        GROUP BY INV.FMATERIALID,INV.FSTOCKID,INV.FBASEQTY
                    )XINV
                    GROUP BY FMATERIALID
                )XINVC ON BOMC.FMATERIALID = XINVC.FMATERIALID
                LEFT JOIN
                (
                    SELECT POE.FMATERIALID,SUM(POR.FREMAINSTOCKINQTY) FREMAINSTOCKINQTY
                    FROM T_PUR_POORDER PO
                    INNER JOIN T_PUR_POORDERENTRY POE ON PO.FID = POE.FID
                    INNER JOIN T_PUR_POORDERENTRY_R POR ON POE.FENTRYID = POR.FENTRYID
                    GROUP BY POE.FMATERIALID
                )XPO ON BOMC.FMATERIALID = XPO.FMATERIALID
                LEFT JOIN
                (
                    SELECT MOE.FMATERIALID,SUM(MOE.FQTY) FQTY
                    FROM T_PRD_MO MO
                    INNER JOIN T_PRD_MOENTRY MOE ON MO.FID = MOE.FID
                    INNER JOIN T_PRD_MOENTRY_A MOA ON MOE.FENTRYID = MOA.FENTRYID
                    WHERE MOA.FSTATUS IN(3,4)--1:计划;2:计划确认;3:下达;4:开工;5:完工;6:结案;7:结算。
                    GROUP BY MOE.FMATERIALID
                )XMO ON BOMC.FMATERIALID = XMO.FMATERIALID
                LEFT JOIN
                (
                    SELECT PICA.FMATERIALID, SUM(PICA.FACTUALQTY) FACTUALQTY
                    FROM T_PRD_PICKMTRL PIC
                    INNER JOIN T_PRD_PICKMTRLDATA PICA ON PIC.FID = PICA.FID
                    WHERE PIC.FDATE BETWEEN TO_DATE('" + pStarTime.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pEndTime.ToString("yyyy-MM-dd") + @"','yyyy-mm-dd')
                    GROUP BY PICA.FMATERIALID
                ) XPIC ON BOMC.FMATERIALID = XPIC.FMATERIALID
                WHERE AE.FENTRYID IN(" + strFEntryIds + ")";

            return ORAHelper.ExecuteTable(strSQL);
        }

        /// <summary>
        /// 获取表内码最大值
        /// </summary>
        /// <param name="pFormID">表标识</param>
        /// <param name="pType">类型：0、系统表；1、其他</param>
        /// <returns></returns>
        public static int GetMaxID(string pFormID, int pType)
        {
            string strTableName, strKey;

            if (pType == 0)
            {
                strKey = "FID";
                strTableName = "T_" + pFormID;
            }
            else
            {
                strKey = "PID";
                strTableName = "DM_" + pFormID;
            }

            obj = ORAHelper.ExecuteScalar("SELECT MAX(" + strKey + ") FROM " + strTableName);

            if (obj == null)
                return 1;
            else
                return int.Parse(obj.ToString());
        }

        /// <summary>
        /// 运算后反写销售订单
        /// </summary>
        /// <param name="pFEntryID">销售订单分录ID</param>
        /// <param name="pBillOwe">整单是否欠料：1 是；2 否</param>弃用参数
        /// <param name="pOweLevel">欠料等级</param>
        public static void UpdateOrderFields(int pFEntryID, string pOweLevel)
        {
            //首先更新销售订单分录的运算次数和欠料等级。
            strSQL = "UPDATE T_SAL_ORDERENTRY SET F_PAEZ_RUNTIME = F_PAEZ_RUNTIME + 1,F_PAEZ_OWELEVEL = '" + pOweLevel + "' WHERE FENTRYID = " + pFEntryID.ToString();

            ORAHelper.ExecuteNonQuery(strSQL);

            //然后根据同一销售订单下所有分录的欠料等级判断是否有分录欠料、一旦有分录欠料则修改同一销售订单下所有分录的整单是否欠料字段为：1、否则为：2
            strSQL = @"UPDATE T_SAL_ORDERENTRY SET F_PAEZ_BILLOWE = 
            CASE(
            SELECT SUM(CASE INSTR(AE.F_PAEZ_OWELEVEL,'欠料') WHEN 1 THEN 1 ELSE 0 END)--一旦有欠料则累计，不欠料则不累计
            FROM T_SAL_ORDER A
            INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
            INNER JOIN T_SAL_ORDERENTRY AE2 ON A.FID = AE2.FID
            WHERE AE2.FENTRYID = " + pFEntryID.ToString() + @"
            GROUP BY A.FID) WHEN 0 THEN 2 ELSE 1 END
            WHERE FID = (SELECT FID FROM T_SAL_ORDERENTRY WHERE FENTRYID = " + pFEntryID.ToString() + ")";

            ORAHelper.ExecuteNonQuery(strSQL);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pType"></param>
        /// <param name="pFBillNo"></param>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <returns></returns>
        public static DataTable GetBillInfo(string pType, string pFBillNo, DateTime pFrom, DateTime pTo)
        {
            switch (pType)
            {
                case "SAL_ORDER":
                    strSQL = @"SELECT A.FBILLNO 单据编号,A.FDATE 日期,CASE WHEN A.FCLOSESTATUS = 'A' THEN '正常' ELSE '已关闭' END 关闭状态,NVL(CUSTL.FNAME,' ') 客户
                           ,NVL(ORGL.FNAME,' ') 销售组织,NVL(DPTL.FNAME,' ') 销售部门,NVL(SEC.FNAME,' ') 创建人,A.FCREATEDATE 创建日期,NVL(SEC2.FNAME,' ') 修改人,A.FMODIFYDATE 修改日期
                           ,NVL(MTL.FNUMBER,' ') 物料编码,NVL(MTLL.FNAME,' ') 物料名称,AE.FQTY 销售数量,CASE WHEN AE.FMRPCLOSESTATUS = 'A' THEN '未关闭' ELSE '业务关闭' END 业务关闭
                    FROM T_SAL_ORDER A
                    INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                    LEFT JOIN T_BD_CUSTOMER_L CUSTL ON A.FCUSTID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052
                    LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL ON A.FSALEORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                    LEFT JOIN T_BD_DEPARTMENT_L DPTL ON A.FSALEDEPTID = DPTL.FDEPTID AND DPTL.FLOCALEID = 2052
                    LEFT JOIN T_SEC_USER SEC ON A.FCREATORID = SEC.FUSERID
                    LEFT JOIN T_SEC_USER SEC2 ON A.FMODIFIERID = SEC2.FUSERID
                    LEFT JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                    LEFT JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052";
                    strSQL += " WHERE A.FDOCUMENTSTATUS = 'C' AND A.FBILLNO LIKE '%" + pFBillNo + "%'";
                    strSQL += " AND A.FDATE BETWEEN TO_DATE('" + pFrom.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pTo.ToString("yyyy-MM-dd") + "','yyyy-mm-dd')";
                    break;
                case "PRD_MO":
                    strSQL = "";
                    break;
                case "PRD_INSTOCK":
                    strSQL = "";
                    break;
                case "SAL_OUTSTOCK":
                    strSQL = "";
                    break;
                case "AR_RECEIVABLE":
                    strSQL = "";
                    break;
                default:
                    strSQL = "SELECT 'ERROR' FROM DUAL";
                    break;
            }
            return ORAHelper.ExecuteTable(strSQL);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pType"></param>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <returns></returns>
        public static DataTable GetBillInfo(string pType, DateTime pFrom, DateTime pTo)
        {
            switch (pType)
            {
                case "SAL_ORDER":
                    strSQL = @"SELECT A.FBILLNO 单据编号,A.FDATE 日期,CASE WHEN A.FCLOSESTATUS = 'A' THEN '正常' ELSE '已关闭' END 关闭状态,NVL(CUSTL.FNAME,' ') 客户
                           ,NVL(ORGL.FNAME,' ') 销售组织,NVL(DPTL.FNAME,' ') 销售部门,NVL(SEC.FNAME,' ') 创建人,A.FCREATEDATE 创建日期,NVL(SEC2.FNAME,' ') 修改人,A.FMODIFYDATE 修改日期
                           ,NVL(MTL.FNUMBER,' ') 物料编码,NVL(MTLL.FNAME,' ') 物料名称,AE.FQTY 销售数量,CASE WHEN AE.FMRPCLOSESTATUS = 'A' THEN '未关闭' ELSE '业务关闭' END 业务关闭
                    FROM T_SAL_ORDER A
                    INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                    LEFT JOIN T_BD_CUSTOMER_L CUSTL ON A.FCUSTID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052
                    LEFT JOIN T_ORG_ORGANIZATIONS_L ORGL ON A.FSALEORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                    LEFT JOIN T_BD_DEPARTMENT_L DPTL ON A.FSALEDEPTID = DPTL.FDEPTID AND DPTL.FLOCALEID = 2052
                    LEFT JOIN T_SEC_USER SEC ON A.FCREATORID = SEC.FUSERID
                    LEFT JOIN T_SEC_USER SEC2 ON A.FMODIFIERID = SEC2.FUSERID
                    LEFT JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                    LEFT JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052";
                    strSQL += " WHERE A.FDOCUMENTSTATUS = 'C' AND A.FDATE BETWEEN TO_DATE('" + pFrom.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pTo.ToString("yyyy-MM-dd") + "','yyyy-mm-dd')";
                    break;
                case "PRD_MO":
                    strSQL = "";
                    break;
                case "PRD_INSTOCK":
                    strSQL = "";
                    break;
                case "SAL_OUTSTOCK":
                    strSQL = "";
                    break;
                case "AR_RECEIVABLE":
                    strSQL = "";
                    break;
                default:
                    strSQL = "SELECT 'ERROR' FROM DUAL";
                    break;
            }
            return ORAHelper.ExecuteTable(strSQL);
        }
    }
}
