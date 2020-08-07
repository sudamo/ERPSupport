using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Kingdee.BOS.WebApi.Client;

namespace ERPSupport.SQL.K3Cloud
{
    using Model.Enum;
    using Model.Globa;
    using Model.K3Cloud;
    using IDAL.K3Cloud;

    /// <summary>
    /// 销售订单
    /// </summary>
    public class SalOrder : ISalOrder
    {
        #region STATIC
        private static string _SQL;
        private static object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SalOrder()
        {
            _SQL = string.Empty;
            _obj = new object();
        }
        #endregion

        /// <summary>
        /// 锁库失败操作日志
        /// </summary>
        /// <param name="pEntry">订单实体</param>
        /// <param name="pType">类型：1、锁库；其他、解锁</param>
        /// <param name="pRemark">失败信息</param>
        public void Log_OrderLock(OrderInfo pEntry, int pType, string pRemark)
        {
            _SQL = string.Format("INSERT INTO DM_LOG_ORDERLOCK(FENTRYID,FBILLNO,FMTLNUMBER,FREMARK,FTYPE,FFLAG,FOPERATOR) ");
            _SQL += string.Format(" VALUES({0},'{1}','{2}','{3}','1','0','{4}')", pEntry.FEntryId, pEntry.FBillNo, pEntry.FMaterialNo, pRemark, GlobalParameter.K3Inf.UserName);

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 锁库成功操作日志
        /// </summary>
        /// <param name="pDR">数据行</param>
        /// <param name="pType">类型：1、锁库；其他、解锁</param>
        public void Log_OrderLock(DataRow pDR, int pType)
        {
            if (pDR == null)
                return;
            string FFLAG;

            if (pType == 1)
                _SQL = @"INSERT INTO DM_LOG_ORDERLOCK(FID,FENTRYID,FINID,FBILLNO,FMTLNUMBER,FUNTNUMBER,FORGNUMBER,FSALQTY,FLOCKQTY,FLEFTQTY,FMAXLOCKQTY,FSEQ,FSTOCKNUMBER,FSTOCK,FSTOCKQTY,FSTOCKAVBQTY,FREMARK,FTYPE,FOPERATOR)
                VALUES(" + pDR["FID"].ToString() + "," + pDR["FENTRYID"].ToString() + ",'" + pDR["FINID"].ToString() + "','" + pDR["单据编号"].ToString() + "','" + pDR["物料编码"].ToString() + "','" + pDR["基本单位"].ToString() + "','" + pDR["需求组织"].ToString() + "'," + pDR["销售数量"].ToString() + "," + pDR["锁库数量"].ToString() + "," + pDR["待锁库"].ToString() + "," + pDR["最大可锁数量"].ToString() + "," + pDR["序号"].ToString() + ",'" + pDR["仓库编码"].ToString() + "','" + pDR["仓库"].ToString() + "'," + pDR["库存量"].ToString() + "," + pDR["可用量"].ToString() + ",'" + pDR["备注"].ToString() + "',1,'" + GlobalParameter.K3Inf.UserName + "')";
            else
            {
                FFLAG = pDR["操作"].ToString().Contains("成功") ? "1" : "0";
                _SQL = @"INSERT INTO DM_LOG_ORDERLOCK(FBILLNO,FMTLNUMBER,FLOCKQTY,FTYPE,FOPERATOR,FREMARK,FFLAG)
                VALUES('" + pDR["销售订单"].ToString() + "','" + pDR["物料编码"].ToString() + "'," + pDR["信息"].ToString().Substring(5) + ",0,'" + GlobalParameter.K3Inf.UserName + "','" + pDR["操作"].ToString() + "','" + FFLAG + "')";
            }

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 根据FormId数据查询
        /// </summary>
        /// <param name="pFormId">FormId</param>
        /// <param name="pFilter">Filter</param>
        /// <returns></returns>
        public DataTable GetDataSource(FormID pFormId, string pFilter)
        {
            if (pFormId == FormID.PRD_INSTOCK)//倒冲领料
            {
                _SQL = string.Format(@"SELECT A.FDATE 日期, BILL.FNAME 单据类型, A.FBILLNO 单据编号, '已审核' 单据状态, ORGL.FNAME 入库组织, ORGL2.FNAME 生产组织,MTL.FNUMBER 物料编码, MTLL.FNAME 物料名称, UNTL.FNAME 单位, AE.FMUSTQTY 应收数量, AE.FREALQTY 实收数量,STKL.FNAME 仓库 ");
                _SQL += string.Format(" FROM T_PRD_INSTOCK A ");
                _SQL += string.Format(" INNER JOIN T_PRD_INSTOCKENTRY AE ON A.FID = AE.FID ");
                _SQL += string.Format(" INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID ");
                _SQL += string.Format(" INNER JOIN T_BD_MATERIAL_L MTLL ON AE.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BAS_BILLTYPE_L BILL ON A.FBILLTYPE = BILL.FBILLTYPEID AND BILL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON A.FSTOCKORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_ORG_ORGANIZATIONS_L ORGL2 ON A.FPRDORGID = ORGL2.FORGID AND ORGL2.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_UNIT_L UNTL ON AE.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCK_L STKL ON AE.FSTOCKID = STKL.FSTOCKID AND STKL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_DEPARTMENT_L DEPL ON AE.FWORKSHOPID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052 ");
                _SQL += string.Format(" LEFT JOIN T_PRD_PICKMTRLDATA_A PICA ON AE.FENTRYID = PICA.FSRCBIZENTRYID ");
                _SQL += string.Format(" WHERE {0} A.FDOCUMENTSTATUS = 'C' AND PICA.FSRCBIZBILLNO IS NULL ORDER BY A.FID DESC", pFilter);
            }
            else if (pFormId == FormID.PRD_PPBOM || pFormId == FormID.PRD_PPBOM_DX)
            {
                string strOrg;
                switch (pFormId)
                {
                    case FormID.PRD_PPBOM://河南工厂调拨
                        strOrg = "100508";
                        break;
                    case FormID.PRD_PPBOM_DX://德旭调拨
                        strOrg = "492501088";
                        break;
                    default:
                        strOrg = "100508";
                        break;
                }

                _SQL = string.Format("SELECT MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称,UNTL.FNAME 单位,SUM(A.FMUSTQTY) 实发数量,DEPL.FNAME 领料部门,STKL2.FNAME 调出仓库,NVL(INV2.FAVBQTY, 0) 调出仓库存,NVL(STKL3.FNAME,' ') 中间仓库,STKL.FNAME 调入仓库,NVL(INV.FAVBQTY, 0) 调入仓库存 ");
                _SQL += string.Format(" FROM T_PRD_PPBOMENTRY A ");
                _SQL += string.Format(" INNER JOIN T_PRD_MOENTRY BE ON A.FMOENTRYID = BE.FENTRYID AND TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') = TO_CHAR(A.FNEEDDATE,'yyyy-mm-dd') ");
                _SQL += string.Format(" INNER JOIN T_PRD_MOENTRY_A BA ON BE.FENTRYID = BA.FENTRYID AND BA.FSTATUS IN({0}) ", strOrg == "100508" ? "3,4" : "4");
                _SQL += string.Format(" INNER JOIN T_PRD_MO B ON BE.FID = B.FID AND B.FDOCUMENTSTATUS = 'C' AND B.FPRDORGID = {0} ", strOrg);
                _SQL += string.Format(" INNER JOIN T_BD_MATERIAL MTL ON A.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = {0} ", strOrg);
                _SQL += string.Format(" INNER JOIN T_BD_MATERIAL_L MTLL ON A.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_UNIT_L UNTL ON A.FUNITID = UNTL.FUNITID AND UNTL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_DEPARTMENT DEP ON BE.FWORKSHOPID = DEP.FDEPTID ");
                _SQL += string.Format(" INNER JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCK_L STKL ON DEP.FINSTOCKID = STKL.FSTOCKID AND STKL.FLOCALEID = 2052 ");
                _SQL += string.Format(" INNER JOIN T_AUTO_MSTOCKSETTING MSG ON A.FMATERIALID = MSG.FMATERIALID AND DEPL.FDEPTID = MSG.FDEPTID ");
                _SQL += string.Format(" INNER JOIN T_BD_STOCK_L STKL2 ON MSG.FSTOCKID = STKL2.FSTOCKID AND STKL2.FLOCALEID = 2052 ");
                _SQL += string.Format(" LEFT JOIN T_BD_STOCK_L STKL3 ON MSG.FTRANSTOCKID = STKL3.FSTOCKID AND STKL3.FLOCALEID = 2052 ");
                _SQL += string.Format(" LEFT JOIN T_STK_INVENTORY INV ON A.FMATERIALID = INV.FMATERIALID AND DEP.FINSTOCKID = INV.FSTOCKID AND INV.FSTOCKSTATUSID = 10000 AND INV.FSTOCKORGID = {0} AND INV.FOWNERID = {0} AND INV.FISEFFECTIVED = 1 ", strOrg);
                _SQL += string.Format(" LEFT JOIN T_STK_INVENTORY INV2 ON A.FMATERIALID = INV2.FMATERIALID AND MSG.FSTOCKID = INV2.FSTOCKID AND INV2.FSTOCKSTATUSID = 10000 AND INV2.FSTOCKORGID = {0} AND INV2.FOWNERID = {0} AND INV2.FISEFFECTIVED = 1 ", strOrg);
                _SQL += string.Format(" WHERE {0} A.FPAEZHAVEDIRECT = 0 AND A.F_PAEZ_PICKTOWMS = 0 AND STKL.FNAME <> STKL2.FNAME GROUP BY MTL.FNUMBER,MTLL.FNAME,UNTL.FNAME,STKL.FNAME,INV.FAVBQTY,STKL2.FNAME,STKL3.FNAME,INV2.FAVBQTY,DEPL.FNAME ORDER BY MTL.FNUMBER", pFilter);
            }
            else if (pFormId == FormID.SAL_SaleOrder)//锁库
            {
                _SQL = @"SELECT A.FBILLNO 单据编号,BILL.FNAME 单据类型,A.FAPPROVEDATE 审核日期,ORGL3.FNAME 销售组织,ORGL.FNAME 库存组织
                    ,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称,UNTL.FNAME 单位,AE.FQTY 销售数量,AE.FLOCKQTY 锁库数量
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
                WHERE " + pFilter + @" A.FDOCUMENTSTATUS = 'C' AND A.FCLOSESTATUS = 'A' AND AE.FMRPCLOSESTATUS = 'A' AND AE.FMRPTERMINATESTATUS = 'A' AND A.F_PAEZ_FACTORGID = 100508
                ORDER BY TO_CHAR(A.FAPPROVEDATE, 'YYYY'),TO_CHAR(A.FAPPROVEDATE, 'MM'),TO_CHAR(A.FAPPROVEDATE, 'DD'), ASSDL.FDATAVALUE,AE.FQTY,A.FID";
            }
            else if (pFormId == FormID.SAL_SaleOrderRun)//订单运算
            {
                _SQL = @"SELECT A.FBILLNO 单据编号,BILL.FNAME 单据类型,A.FAPPROVEDATE 审核日期,ORGL3.FNAME 销售组织,ORGL.FNAME 库存组织
                    ,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称,UNTL.FNAME 单位,AE.FQTY 销售数量,AE.FLOCKQTY 锁库数量
                    ,AE.FLEFTQTY 待锁库,ORGL2.FNAME 货主,CASE WHEN AE.FLOCKFLAG = '0'  THEN '否' ELSE '是' END 锁库,CASE WHEN A.FFULLLOCK = '0' THEN '否' ELSE '是' END 完全锁库,CASE WHEN AE.FBATCHFLAG = '0' THEN '否' ELSE '是' END 批量锁库
                    ,ASSDL.FDATAVALUE 发货类别,CURL.FNAME 客户,BOM.FNUMBER BOM,CASE WHEN MTL.F_PAEZ_CUSTOMIZATION + MTL.F_PAEZ_SPECIALUSE + MTL.F_PAEZ_ARTS > 0 THEN 1 ELSE 0 END 特殊,AE.FENTRYID 订单内码
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
                INNER JOIN T_ENG_BOM BOM ON AE.FBOMID = BOM.FID
                WHERE " + pFilter + @" A.FDOCUMENTSTATUS = 'C' AND A.FCLOSESTATUS = 'A' AND AE.FMRPCLOSESTATUS = 'A' AND A.F_PAEZ_FACTORGID = 100508
                ORDER BY CASE WHEN BILL.FNAME = '备货销售订单' THEN 1 ELSE 0 END,TO_CHAR(A.FAPPROVEDATE, 'YYYY') ASC,TO_CHAR(A.FAPPROVEDATE, 'MM'),TO_CHAR(A.FAPPROVEDATE, 'DD'), ASSDL.FDATAVALUE,A.FID,AE.FQTY,AE.FENTRYID";
            }

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 根据销售订单内码获取可锁库信息
        /// </summary>
        /// <param name="pFEntryId">FEntryId</param>
        /// <returns></returns>
        public DataTable GetOrderLockByFEntryId(int pFEntryId)
        {
            _SQL = @"SELECT A.FID,AE.FENTRYID,XINV.FID FINID,A.FBILLNO 单据编号,MTL.FNUMBER 物料编码,E.FNUMBER 基本单位,D.FNUMBER 需求组织,C.FNUMBER || CL.FNAME 备注,AE.FQTY 销售数量,AE.FLOCKQTY 锁库数量,AE.FLEFTQTY 待锁库,AR.FBASECANOUTQTY - AR.FBASEPURJOINQTY - AE.FLOCKQTY 最大可锁数量--可出数量-关联采购/生产数量
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
            INNER JOIN DM_CALCULATESTOCK CST ON INV.FSTOCKID = CST.FSTOCKID AND CST.FTYPE = 'LOCKSTOCK' AND ISDELETE = '0'
            INNER JOIN T_BD_STOCK_L STOL ON CST.FSTOCKID = STOL.FSTOCKID AND STOL.FLOCALEID = 2052
            INNER JOIN T_BD_MATERIAL MTL ON INV.FMATERIALID = MTL.FMATERIALID
            LEFT JOIN
            (
            SELECT MTL.FNUMBER,SUM(NVL(RES.FBASEQTY,0)) FBASEQTY,RES.FSTOCKID
            FROM T_PLN_RESERVELINKENTRY RES
            INNER JOIN T_BD_MATERIAL MTL ON RES.FMATERIALID = MTL.FMATERIALID
            WHERE RES.FBASEQTY > 0 AND RES.FSUPPLYFORMID = 'STK_Inventory'
            GROUP BY MTL.FNUMBER,RES.FSTOCKID
            ) LRES ON MTL.FNUMBER = LRES.FNUMBER AND CST.FSTOCKID = LRES.FSTOCKID
            WHERE INV.FISEFFECTIVED = 1 AND INV.FSTOCKSTATUSID = 10000
            GROUP BY INV.FID,MTL.FNUMBER,lRES.FBASEQTY,CST.FSEQ,CST.FNUMBER,STOL.FNAME
            )XINV ON MTL.FNUMBER = XINV.FNUMBER
            WHERE AE.FENTRYID = " + pFEntryId.ToString();

            return ORAHelper.ExecuteTable(_SQL);//根据销售订单内码获取可锁库信息
        }

        /// <summary>
        /// 锁库反写销售订单
        /// </summary>
        /// <param name="pCanLockQty">可锁数量</param>
        /// <param name="pFID">销售订单ID</param>
        /// <param name="pFEntryId">销售订单分录ID</param>
        public void UpdateOrderLock(string pCanLockQty, int pFID, int pFEntryId)
        {
            _SQL = @"DECLARE
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

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 解锁反写销售订单
        /// </summary>
        /// <param name="pLockQty">解锁数量</param>
        /// <param name="pFEntryId">销售订单分录ID</param>
        public void UnLockSalOrder(string pLockQty, int pFEntryId)
        {
            _SQL = @"BEGIN
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

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 锁库后反写销售订单
        /// </summary>
        /// <param name="pCanLockQty">可锁数量</param>
        /// <param name="pFEntryId">销售订单分录ID</param>
        public void UpdateOrderLock(string pCanLockQty, int pFEntryId)
        {
            _SQL = string.Format("UPDATE T_SAL_ORDERENTRY SET FLOCKQTY = FLOCKQTY + {0},FLEFTQTY = CASE WHEN FLEFTQTY = 0 THEN 0 ELSE FLEFTQTY - {0} END,FBATCHFLAG = '1' WHERE FENTRYID = {1}", pCanLockQty, pFEntryId);

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 修改执行过锁库订单的批量锁库标识
        /// </summary>
        /// <param name="pList">列表</param>
        public void UpdateBatchFlag(IList pList)
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

            _SQL = @"UPDATE T_SAL_ORDERENTRY SET FBATCHFLAG = '1' WHERE FENTRYID IN (" + strFEntryIds + ")";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 添加预留关系
        /// </summary>
        /// <param name="pDR">数据行</param>
        /// <param name="pQTY">数量</param>
        /// <returns></returns>
        public string AddReserveLink(DataRow pDR, double pQTY)
        {
            string strRetrunValue = string.Empty;
            K3CloudApiClient client = new K3CloudApiClient(GlobalParameter.K3Inf.C_ERPADDRESS);
            var bLogin = client.Login(GlobalParameter.K3Inf.C_ZTID, GlobalParameter.K3Inf.UserName, GlobalParameter.K3Inf.UserPWD, 2052);

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
        public DataTable GetInventoryInfByMaterialId(string pFMaterialId)
        {
            _SQL = @"SELECT FID FINID,FNUMBER STOCK,SUM(FAVBQTY) FAVBQTY
            FROM
            (
            SELECT INV.FID,INV.FMATERIALID,CST.FNUMBER,CST.FSEQ,INV.FBASEQTY - SUM(NVL(RES.FBASEQTY,0)) FAVBQTY
            FROM T_STK_INVENTORY INV
            INNER JOIN DM_CALCULATESTOCK CST ON INV.FSTOCKID = CST.FSTOCKID AND CST.FTYPE = 'RUNSTOCK' AND ISDELETE = '0'
            LEFT JOIN T_PLN_RESERVELINKENTRY RES ON INV.FMATERIALID = RES.FMATERIALID AND INV.FSTOCKID = RES.FSTOCKID AND RES.FBASEQTY > 0 AND RES.FSUPPLYFORMID = 'STK_INVENTORY'
            WHERE INV.FISEFFECTIVED = 1 AND INV.FSTOCKSTATUSID = 10000
            GROUP BY INV.FID,INV.FMATERIALID,CST.FNUMBER,CST.FSEQ,INV.FBASEQTY
            HAVING INV.FBASEQTY - SUM(NVL(RES.FBASEQTY,0)) > 0
            )XINV
            WHERE FMATERIALID = " + pFMaterialId + @"
            GROUP BY FID,FMATERIALID,FNUMBER,FSEQ
            ORDER BY FSEQ";

            return ORAHelper.ExecuteTable(_SQL);
        }

        //--
        /// <summary>
        /// 成品运算
        /// </summary>
        /// <param name="pDtRun"></param>
        /// <param name="pJoinQty">关联采购生产数量是否参与运算</param>
        /// <returns></returns>
        public DataTable OrderRun(DataTable pDtRun, bool pJoinQty)
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
                _SQL = @"SELECT DISTINCT A.FID,AE.FENTRYID,A.FBILLNO 单据编号,BILL.FNAME 单据类型,ASSDL.FDATAVALUE 发货类别,A.FAPPROVEDATE 审核日期,MTL.FNUMBER 物料编码
                    ,MTLL.FNAME 物料名称,CUSTL.FNAME 客户名称,UNTL.FNAME 单位,AE.FQTY 订单数量,AE.FLOCKQTY 锁库数量,AE.FQTY - AE.FLOCKQTY 订单需求
                    ,AR.FREMAINOUTQTY 未出库数量,AR.FSTOCKOUTQTY 已出库数量,AR.FBASECANOUTQTY 可出库数量,SUM(NVL(BE.FQTY,0)) 已经下达任务单数量,AE.FQTY - SUM(NVL(BE.FQTY,0)) 未下达任务单数量
                    ,FBASEPURJOINQTY 关联采购生产数量,BOM.FNUMBER BOM版本,AE.F_PAEZ_RUNTIME + 1 运算次数
                    ,CASE WHEN AR.FBASECANOUTQTY - AE.FLOCKQTY - AR.FBASEPURJOINQTY > 0 THEN '是' ELSE '否' END 是否欠料
                    ,CASE WHEN AR.FBASECANOUTQTY - AE.FLOCKQTY - AR.FBASEPURJOINQTY > 0 THEN ' ' ELSE '无需生产' END 欠料等级
                    ,CASE WHEN AE.FBATCHFLAG = 1 THEN '是' ELSE '否' END 批量锁库,CASE WHEN AE.FLOCKFLAG = 0 THEN '否' ELSE '是' END 锁库,CASE WHEN A.FFULLLOCK = 0 THEN '否' ELSE '是' END 完全锁库,A.FNOTE 备注,U.FNAME 提交人
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
                INNER JOIN T_SEC_USER U ON A.F_PAEZ_SUBMITUSERID = U.FUSERID
                LEFT JOIN T_PRD_MOENTRY BE ON AE.FENTRYID = BE.FSALEORDERENTRYID
                LEFT JOIN T_PRD_MOENTRY_A BEA ON BE.FENTRYID = BEA.FENTRYID AND BEA.FSTATUS IN(3,4)
                LEFT JOIN (SELECT FNUMBER,FMATERIALID FROM T_ENG_BOM BOM1 WHERE FID = (SELECT MAX(FID) FROM T_ENG_BOM BOM2 WHERE BOM1.FMATERIALID = BOM2.FMATERIALID AND BOM2.FDOCUMENTSTATUS = 'C' AND BOM2.FFORBIDSTATUS = 'A' AND BOM2.FBOMUSE NOT IN(3,4))) BOM ON MTL2.FMATERIALID = BOM.FMATERIALID
                WHERE AE.FENTRYID IN(" + strFEntryIds + @")
                GROUP BY  A.FID,AE.FENTRYID,A.FBILLNO,BILL.FNAME,ASSDL.FDATAVALUE,A.FAPPROVEDATE,MTL.FNUMBER,MTLL.FNAME,CUSTL.FNAME,UNTL.FNAME,AE.FQTY,AE.FLOCKQTY,AR.FREMAINOUTQTY,AR.FSTOCKOUTQTY,AR.FBASECANOUTQTY,AR.FBASEPURJOINQTY,BOM.FNUMBER,AE.F_PAEZ_RUNTIME,AE.FBATCHFLAG,AE.FLOCKFLAG,A.FFULLLOCK,A.FNOTE,U.FNAME
                ORDER BY CASE WHEN BILL.FNAME = '备货销售订单' THEN 1 ELSE 0 END,TO_CHAR(A.FAPPROVEDATE, 'YYYY') ASC,TO_CHAR(A.FAPPROVEDATE, 'MM'),TO_CHAR(A.FAPPROVEDATE, 'DD'),ASSDL.FDATAVALUE,A.FID,AE.FQTY,AE.FENTRYID";
            else
                _SQL = @"SELECT DISTINCT A.FID,AE.FENTRYID,A.FBILLNO 单据编号,BILL.FNAME 单据类型,ASSDL.FDATAVALUE 发货类别,A.FAPPROVEDATE 审核日期,MTL.FNUMBER 物料编码
                    ,MTLL.FNAME 物料名称,CUSTL.FNAME 客户名称,UNTL.FNAME 单位,AE.FQTY 订单数量,AE.FLOCKQTY 锁库数量,AE.FQTY - AE.FLOCKQTY 订单需求
                    ,AR.FREMAINOUTQTY 未出库数量,AR.FSTOCKOUTQTY 已出库数量,AR.FBASECANOUTQTY 可出库数量,SUM(NVL(BE.FQTY,0)) 已经下达任务单数量,AE.FQTY - SUM(NVL(BE.FQTY,0)) 未下达任务单数量
                    ,0 关联采购生产数量,BOM.FNUMBER BOM版本,AE.F_PAEZ_RUNTIME + 1 运算次数
                    ,CASE WHEN AR.FBASECANOUTQTY - AE.FLOCKQTY > 0 THEN '是' ELSE '否' END 是否欠料
                    ,CASE WHEN AR.FBASECANOUTQTY - AE.FLOCKQTY > 0 THEN ' ' ELSE '无需生产' END 欠料等级
                    ,CASE WHEN AE.FBATCHFLAG = 1 THEN '是' ELSE '否' END 批量锁库,CASE WHEN AE.FLOCKFLAG = 0 THEN '否' ELSE '是' END 锁库,CASE WHEN A.FFULLLOCK = 0 THEN '否' ELSE '是' END 完全锁库,A.FNOTE 备注,U.FNAME 提交人
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
                INNER JOIN T_SEC_USER U ON A.F_PAEZ_SUBMITUSERID = U.FUSERID
                LEFT JOIN T_PRD_MOENTRY BE ON AE.FENTRYID = BE.FSALEORDERENTRYID
                LEFT JOIN T_PRD_MOENTRY_A BEA ON BE.FENTRYID = BEA.FENTRYID AND BEA.FSTATUS IN(3,4)
                LEFT JOIN (SELECT FNUMBER,FMATERIALID FROM T_ENG_BOM BOM1 WHERE FID = (SELECT MAX(FID) FROM T_ENG_BOM BOM2 WHERE BOM1.FMATERIALID = BOM2.FMATERIALID AND BOM2.FDOCUMENTSTATUS = 'C' AND BOM2.FFORBIDSTATUS = 'A' AND BOM2.FBOMUSE NOT IN(3,4))) BOM ON MTL2.FMATERIALID = BOM.FMATERIALID
                WHERE AE.FENTRYID IN(" + strFEntryIds + @")
                GROUP BY  A.FID,AE.FENTRYID,A.FBILLNO,BILL.FNAME,ASSDL.FDATAVALUE,A.FAPPROVEDATE,MTL.FNUMBER,MTLL.FNAME,CUSTL.FNAME,UNTL.FNAME,AE.FQTY,AE.FLOCKQTY,AR.FREMAINOUTQTY,AR.FSTOCKOUTQTY,AR.FBASECANOUTQTY,BOM.FNUMBER,AE.F_PAEZ_RUNTIME,AE.FBATCHFLAG,AE.FLOCKFLAG,A.FFULLLOCK,A.FNOTE,U.FNAME
                ORDER BY CASE WHEN BILL.FNAME = '备货销售订单' THEN 1 ELSE 0 END,TO_CHAR(A.FAPPROVEDATE, 'YYYY') ASC,TO_CHAR(A.FAPPROVEDATE, 'MM'),TO_CHAR(A.FAPPROVEDATE, 'DD'),ASSDL.FDATAVALUE,A.FID,AE.FQTY,AE.FENTRYID";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 子项运算
        /// </summary>
        /// <param name="pRunEntryId">销售订单分录ID</param>
        /// <param name="pStarTime">开始时间</param>
        /// <param name="pEndTime">结束时间</param>
        /// <param name="pJoinQty"></param>
        /// <returns></returns>
        public DataTable OrderRun(List<int> pRunEntryId, DateTime pStarTime, DateTime pEndTime, bool pJoinQty)
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
                _SQL = @"SELECT DISTINCT A.FID,AE.FENTRYID,A.FBILLNO,MTL.FNUMBER PFNUMBER,MTLL.FNAME PFNAME,MTLC.FNUMBER,  MTLLC.FNAME,UNI.FNUMBER UNIT,BOM2.FNUMBER BOM,AE.FQTY,AE.FLOCKQTY
                    ,(AR.FBASECANOUTQTY - AR.FBASEPURJOINQTY - AE.FLOCKQTY) * BOMC.FNUMERATOR/BOMC.FDENOMINATOR * (100+BOMC.FSCRAPRATE)/100 FSUBQTY,NVL(XINVC.FQTY,0) STOCKQTY,NVL(XINVC.FAVBQTY,0) STOCKAVBQTY,MTLB.FERPCLSID,NVL(XPO.FREMAINSTOCKINQTY,0) FPOQTY,  NVL(XMO.FQTY,0) FMOQTY,MTLS.FMINSTOCK,MTLS.FMAXSTOCK,MTLS.F_PAEZ_SAFEDAYS,F_PAEZ_LOGISTICSDAYS
                    ,MTLS.F_PAEZ_LOWQTY,MTLS.F_PAEZ_MINQTY,MTLS.F_PAEZ_REPLENISHMENT,NVL(XPIC.FACTUALQTY,0) FACTUALQTY,NVL(D.FGROUPLEVEL,' ') FGROUPLEVEL,ORG.FNUMBER SALORG,BOMC.FMATERIALID,CUSTL.FNAME FCUSTID,U.FNAME F_PAEZ_SUBMITUSERID
                FROM T_SAL_ORDER A
                INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIAL MTL2 ON MTL.FNUMBER = MTL2.FNUMBER AND MTL2.FUSEORGID = 100508
                INNER JOIN (SELECT FID,FNUMBER,FMATERIALID,FBOMUSE FROM T_ENG_BOM BOM1 WHERE BOM1.FID = (SELECT MAX(FID) FROM T_ENG_BOM BOM2 WHERE BOM1.FMATERIALID = BOM2.FMATERIALID AND BOM2.FDOCUMENTSTATUS = 'C' AND BOM2.FFORBIDSTATUS = 'A' AND BOM2.FBOMUSE NOT IN(3,4)))BOM ON  MTL2.FMATERIALID = BOM.FMATERIALID --FBOMUSE 99:通用;2:自制;3:委外;4:组装
                INNER JOIN T_ENG_BOMCHILD BOMC ON BOM.FID = BOMC.FID
                INNER JOIN T_BD_MATERIALBASE MTLB ON BOMC.FMATERIALID = MTLB.FMATERIALID
                INNER JOIN T_BD_UNIT UNI ON MTLB.FBASEUNITID = UNI.FUNITID
                INNER JOIN T_BD_MATERIAL MTLC ON BOMC.FMATERIALID = MTLC.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLLC ON MTLC.FMATERIALID = MTLLC.FMATERIALID AND MTLLC.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIALSTOCK MTLS ON MTLC.FMATERIALID = MTLS.FMATERIALID
                LEFT JOIN T_ENG_BOM BOM2 ON MTLC.FMATERIALID = BOM2.FMATERIALID AND BOM.FBOMUSE = BOM2.FBOMUSE
                LEFT JOIN T_BD_MATERIALGROUP D ON D.FNUMBER = CASE WHEN SUBSTR(MTLC.FNUMBER,0,1) IN(1,3,5,7) THEN SUBSTR(MTLC.FNUMBER,0,2) ELSE SUBSTR(MTLC.FNUMBER,0,3) END--1:原材料;2:半成品;3:产成品;4:曾品;5:呆滞物料;6:周转材料;9.30:郑州办外购
                INNER JOIN T_ORG_ORGANIZATIONS ORG ON A.FSALEORGID = ORG.FORGID
                INNER JOIN T_BD_CUSTOMER_L CUSTL ON A.FCUSTID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052
                INNER JOIN T_SEC_USER U ON A.F_PAEZ_SUBMITUSERID = U.FUSERID
                LEFT JOIN
                (
                    SELECT FMATERIALID,SUM(FQTY) FQTY,SUM(FAVBQTY) FAVBQTY
                    FROM
                    (
                        SELECT INV.FMATERIALID,INV.FSTOCKID,INV.FBASEQTY FQTY,INV.FBASEQTY - SUM(NVL(RES.FBASEQTY,0)) FAVBQTY
                        FROM T_STK_INVENTORY INV
                        INNER JOIN DM_CALCULATESTOCK CST ON INV.FSTOCKID = CST.FSTOCKID AND CST.FTYPE = 'RUNSTOCK' AND ISDELETE = '0'
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
                _SQL = @"SELECT DISTINCT A.FID,AE.FENTRYID,A.FBILLNO,MTL.FNUMBER PFNUMBER,MTLL.FNAME PFNAME,MTLC.FNUMBER,  MTLLC.FNAME,UNI.FNUMBER UNIT,BOM2.FNUMBER BOM,AE.FQTY,AE.FLOCKQTY
                        ,(AR.FBASECANOUTQTY - AE.FLOCKQTY) * BOMC.FNUMERATOR/BOMC.FDENOMINATOR * (100+BOMC.FSCRAPRATE)/100 FSUBQTY,NVL(XINVC.FQTY,0) STOCKQTY,NVL(XINVC.FAVBQTY,0) STOCKAVBQTY,MTLB.FERPCLSID,NVL(XPO.FREMAINSTOCKINQTY,0) FPOQTY,  NVL(XMO.FQTY,0) FMOQTY,MTLS.FMINSTOCK,MTLS.FMAXSTOCK,MTLS.F_PAEZ_SAFEDAYS,F_PAEZ_LOGISTICSDAYS
                        ,MTLS.F_PAEZ_LOWQTY,MTLS.F_PAEZ_MINQTY,MTLS.F_PAEZ_REPLENISHMENT,NVL(XPIC.FACTUALQTY,0) FACTUALQTY,NVL(D.FGROUPLEVEL,' ') FGROUPLEVEL,ORG.FNUMBER SALORG,BOMC.FMATERIALID,CUSTL.FNAME FCUSTID,U.FNAME F_PAEZ_SUBMITUSERID
                FROM T_SAL_ORDER A
                INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
                INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIAL MTL2 ON MTL.FNUMBER = MTL2.FNUMBER AND MTL2.FUSEORGID = 100508
                INNER JOIN (SELECT FID,FNUMBER,FMATERIALID,FBOMUSE FROM T_ENG_BOM BOM1 WHERE BOM1.FID = (SELECT MAX(FID) FROM T_ENG_BOM BOM2 WHERE BOM1.FMATERIALID = BOM2.FMATERIALID AND BOM2.FDOCUMENTSTATUS = 'C' AND BOM2.FFORBIDSTATUS = 'A' AND BOM2.FBOMUSE NOT IN(3,4)))BOM ON  MTL2.FMATERIALID = BOM.FMATERIALID
                INNER JOIN T_ENG_BOMCHILD BOMC ON BOM.FID = BOMC.FID
                INNER JOIN T_BD_MATERIALBASE MTLB ON BOMC.FMATERIALID = MTLB.FMATERIALID
                INNER JOIN T_BD_UNIT UNI ON MTLB.FBASEUNITID = UNI.FUNITID
                INNER JOIN T_BD_MATERIAL MTLC ON BOMC.FMATERIALID = MTLC.FMATERIALID
                INNER JOIN T_BD_MATERIAL_L MTLLC ON MTLC.FMATERIALID = MTLLC.FMATERIALID AND MTLLC.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIALSTOCK MTLS ON MTLC.FMATERIALID = MTLS.FMATERIALID
                LEFT JOIN T_ENG_BOM BOM2 ON MTLC.FMATERIALID = BOM2.FMATERIALID AND BOM.FBOMUSE = BOM2.FBOMUSE
                LEFT JOIN T_BD_MATERIALGROUP D ON D.FNUMBER = CASE WHEN SUBSTR(MTLC.FNUMBER,0,1) IN(1,3,5,7) THEN SUBSTR(MTLC.FNUMBER,0,2) ELSE SUBSTR(MTLC.FNUMBER,0,3) END--1:原材料;2:半成品;3:产成品;4:曾品;5:呆滞物料;6:周转材料;9.30:郑州办外购
                INNER JOIN T_ORG_ORGANIZATIONS ORG ON A.FSALEORGID = ORG.FORGID
                INNER JOIN T_BD_CUSTOMER_L CUSTL ON A.FCUSTID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052
                INNER JOIN T_SEC_USER U ON A.F_PAEZ_SUBMITUSERID = U.FUSERID
                LEFT JOIN
                (
                    SELECT FMATERIALID,SUM(FQTY) FQTY,SUM(FAVBQTY) FAVBQTY
                    FROM
                    (
                        SELECT INV.FMATERIALID,INV.FSTOCKID,INV.FBASEQTY FQTY,INV.FBASEQTY - SUM(NVL(RES.FBASEQTY,0)) FAVBQTY
                        FROM T_STK_INVENTORY INV
                        INNER JOIN DM_CALCULATESTOCK CST ON INV.FSTOCKID = CST.FSTOCKID AND CST.FTYPE = 'RUNSTOCK' AND ISDELETE = '0'
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

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveOrderRun(DataRow pDr, string pBillNo, int pSEQ)
        {
            _SQL = "INSERT INTO DM_LOG_ORDERRUN(YSBILLNO,FID,FENTRYID,FBILLNO,FBILLTYPE,FMTLNUMBER,FMTLNAME,FCUSTNAME,F_PAEZ_SUBMITUSERID,FUNIT,FQTY,FLOCKQTY,FDEMANDQTY,BOM,FLACKLEVEL,ISLACK,FSEQ) VALUES('" + pBillNo + "'," + pDr["FID"].ToString() + "," + pDr["FENTRYID"].ToString() + ",'" + pDr["单据编号"].ToString() + "','" + pDr["单据类型"].ToString() + "','" + pDr["物料编码"].ToString() + "','" + pDr["物料名称"].ToString() + "','" + pDr["客户名称"].ToString() + "','" + pDr["提交人"].ToString() + "','" + pDr["单位"].ToString() + "'," + pDr["订单数量"].ToString() + "," + pDr["锁库数量"].ToString() + "," + pDr["订单需求"].ToString() + ",'" + pDr["BOM版本"].ToString() + "','" + pDr["欠料等级"].ToString() + "'," + (pDr["是否欠料"].ToString() == "是" ? "1" : "0") + "," + pSEQ + ")";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pFEntryId"></param>
        public void SaveOrderRunDetail(DataTable pDt, string pFEntryId)
        {

            int iPID = GetMaxID("LOG_ORDERRUN", 1);
            int iSEQ = 0;
            string strSQL = "INSERT ALL ";

            for (int i = 0; i < pDt.Rows.Count; i++)
            {
                if (pDt.Rows[i]["FENTRYID"].ToString() == pFEntryId)
                {
                    iSEQ++;
                    strSQL += " INTO DM_LOG_ORDERRUNSUB(PID,FID,FENTRYID,FPMTLNUMBER,FPMTLNAME,FMTLNUMBER,FMTLNAME,FNUIT,BOM,FQTY,FLOCKQTY,FSUBQTY,FSTOCKQTY,FSTOCKAVBQTY,FSTOCKDEMANDQTY,FNETDEMANDQTY,FPICQTY,FMINSTOCK,FMAXSTOCK,FSAFESTOCK,FSTOCKDAYS,FORDERQTY,FOCCUPYQTY,FOCCUPYSUMQTY,FLACKQTY,FLACKLEVEL,FSEQ) VALUES(" + iPID + "," + pDt.Rows[i]["FID"].ToString() + "," + pDt.Rows[i]["FENTRYID"].ToString() + ",'" + pDt.Rows[i]["父项物料"].ToString() + "','" + pDt.Rows[i]["父项名称"].ToString() + "','" + pDt.Rows[i]["物料编码"].ToString() + "','" + pDt.Rows[i]["物料名称"].ToString() + "','" + pDt.Rows[i]["单位"].ToString() + "','" + pDt.Rows[i]["BOM"].ToString() + "'," + pDt.Rows[i]["订单数量"].ToString() + "," + pDt.Rows[i]["锁库数量"].ToString() + "," + pDt.Rows[i]["子项需求"].ToString() + "," + pDt.Rows[i]["库存数量"].ToString() + "," + pDt.Rows[i]["库存可用数量"].ToString() + "," + pDt.Rows[i]["库存需求"].ToString() + "," + pDt.Rows[i]["净需求"].ToString() + "," + pDt.Rows[i]["领料数量"].ToString() + "," + pDt.Rows[i]["最小库存"].ToString() + "," + pDt.Rows[i]["最大库存"].ToString() + "," + pDt.Rows[i]["安全库存"].ToString() + "," + pDt.Rows[i]["库存可用天数"].ToString() + "," + pDt.Rows[i]["下单点"].ToString() + "," + pDt.Rows[i]["本次占用数量"].ToString() + "," + pDt.Rows[i]["累计占用数量"].ToString() + "," + pDt.Rows[i]["欠料数量"].ToString() + ",'" + pDt.Rows[i]["欠料等级"].ToString() + "'," + iSEQ + ")";
                }
            }

            ORAHelper.ExecuteNonQuery(strSQL + " SELECT * FROM DUAL;");

            ////添加预留关系 --不修改库存可用量
            //if (decimal.Parse(FOCCUPYQTY) > 0)
            //{
            //    AddReserveLink(dtDtlResult.Rows[i], decimal.Parse(FOCCUPYQTY));
            //}
        }

        /// <summary>
        /// 获取表内码最大值
        /// </summary>
        /// <param name="pFormID">表标识</param>
        /// <param name="pType">类型：0、系统表；1、其他</param>
        /// <returns></returns>
        private int GetMaxID(string pFormID, int pType)
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

            _SQL = string.Format("SELECT MAX({0}) FROM {1}", strKey, strTableName);
            _obj = ORAHelper.ExecuteScalar(_SQL);

            if (_obj == null)
                return 1;
            else
                return int.Parse(_obj.ToString());
        }

        /// <summary>
        /// 运算后反写销售订单
        /// </summary>
        /// <param name="pFEntryID">销售订单分录ID</param>
        /// <param name="pBillOwe">整单是否欠料：1 是；2 否</param>弃用参数
        /// <param name="pOweLevel">欠料等级</param>
        public void UpdateOrderFields(int pFEntryID, string pOweLevel)
        {
            //首先更新销售订单分录的运算次数和欠料等级。
            _SQL = string.Format("UPDATE T_SAL_ORDERENTRY SET F_PAEZ_RUNTIME = F_PAEZ_RUNTIME + 1,F_PAEZ_OWELEVEL = '{0}' WHERE FENTRYID = {1}", pOweLevel, pFEntryID);

            ORAHelper.ExecuteNonQuery(_SQL);

            //然后根据同一销售订单下所有分录的欠料等级判断是否有分录欠料、一旦有分录欠料则修改同一销售订单下所有分录的整单是否欠料字段为：1、否则为：2
            _SQL = @"UPDATE T_SAL_ORDERENTRY SET F_PAEZ_BILLOWE = 
            CASE(
            SELECT SUM(CASE INSTR(AE.F_PAEZ_OWELEVEL,'欠料') WHEN 1 THEN 1 ELSE 0 END)--一旦有欠料则累计，不欠料则不累计
            FROM T_SAL_ORDER A
            INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
            INNER JOIN T_SAL_ORDERENTRY AE2 ON A.FID = AE2.FID
            WHERE AE2.FENTRYID = " + pFEntryID.ToString() + @"
            GROUP BY A.FID) WHEN 0 THEN 2 ELSE 1 END
            WHERE FID = (SELECT FID FROM T_SAL_ORDERENTRY WHERE FENTRYID = " + pFEntryID.ToString() + ")";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pType"></param>
        /// <param name="pFBillNo"></param>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <returns></returns>
        public DataTable GetBillInfo(string pType, string pFBillNo)
        {
            switch (pType.ToUpper())
            {
                case "SAL_SALEORDER":
                    _SQL = string.Format(@"SELECT A.FBILLNO 单据编号,A.FDATE 日期,ORGL.FNAME 销售组织,CUSTL.FNAME 客户,CASE A.F_PAEZ_SINGLESHIPMENT WHEN '1' THEN '是' ELSE '否' END 整单发货,CASE WHEN A.FCLOSESTATUS = 'A' THEN '正常' ELSE '已关闭' END 关闭状态,AE.FSEQ 序号,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称,AE.FQTY 销售数量,AR.FCANOUTQTY 可出数量,CASE WHEN AE.FMRPCLOSESTATUS = 'A' THEN '未关闭' ELSE '业务关闭' END 业务关闭,A.FID,AE.FENTRYID,A.FSALEORGID
                    FROM T_SAL_ORDER A
                    INNER JOIN T_SAL_ORDERENTRY AE ON A.FID = AE.FID
                    INNER JOIN T_SAL_ORDERENTRY_R AR ON AE.FENTRYID = AR.FENTRYID
                    INNER JOIN T_BD_CUSTOMER_L CUSTL ON A.FCUSTID = CUSTL.FCUSTID AND CUSTL.FLOCALEID = 2052
                    INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON A.FSALEORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                    INNER JOIN T_BD_MATERIAL MTL ON AE.FMATERIALID = MTL.FMATERIALID
                    INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID and MTLL.FLOCALEID = 2052
                    WHERE A.FBILLNO = '{0}'", pFBillNo);
                    break;
                case "PRD_MO":
                case "PRD_INSTOCK":
                case "SAL_OUTSTOCK":
                case "AR_RECEIVABLE":
                default:
                    _SQL = "SELECT 'ERROR' FROM DUAL";
                    break;
            }
            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 修改销售订单整单发过标识
        /// </summary>
        /// <param name="pFBillNo">销售订单编号</param>
        /// <param name="pSingle">整单发货标识</param>
        /// <returns></returns>
        public string UpdateSingle(string pFBillNo, bool pSingle)
        {
            if (!pFBillNo.Contains("XSDD") && !pFBillNo.Contains("SEORD") && !pFBillNo.Contains("W"))
                return "[" + pFBillNo + "]并非销售订单";

            _SQL = string.Format("SELECT F_PAEZ_SINGLESHIPMENT FROM T_SAL_ORDER WHERE FBILLNO = '{0}'", pFBillNo);

            _obj = ORAHelper.ExecuteScalar(_SQL);

            if (_obj == null)
                return "[" + pFBillNo + "]单号不存在，可能被删除。";
            else if (_obj.ToString() == "1" && pSingle)
                return "[" + pFBillNo + "]已经是整单发货。";
            else if (_obj.ToString() == "0" && !pSingle)
                return "[" + pFBillNo + "]已经是非整单发货。";

            if (pSingle)
                _SQL = string.Format("UPDATE T_SAL_ORDER SET F_PAEZ_SINGLESHIPMENT = '1' WHERE FBILLNO ='{0}'", pFBillNo);
            else
                _SQL = string.Format("UPDATE T_SAL_ORDER SET F_PAEZ_SINGLESHIPMENT = '0' WHERE FBILLNO ='{0}'", pFBillNo);

            ORAHelper.ExecuteNonQuery(_SQL);

            return "[" + pFBillNo + "]修改成功。";
        }

        /// <summary>
        /// 更新销售订单的可出数量
        /// </summary>
        /// <param name="pFEntryId">销售订单分录内码</param>
        /// <param name="pCanOutQty">可出数量</param>
        public void UpdateOrderCanOutQty(string pFEntryId, decimal pCanOutQty)
        {
            _SQL = string.Format("UPDATE T_SAL_ORDERENTRY_R SET FCANOUTQTY = {0}, FBASECANOUTQTY = {0}, FSTOCKBASECANOUTQTY = {0} WHERE FENTRYID = {1}", pCanOutQty, pFEntryId);
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 修改单据的客户
        /// </summary>
        /// <param name="pFBillNo">销售订单编号</param>
        /// <param name="pFEntryId">销售订分录内码</param>
        /// <param name="pCustomerId">客户内码</param>
        /// <param name="pOutStock">是否关联修改出库单</param>
        /// <param name="pReceivable">是否关联修改应收单</param>
        /// <param name="pReturnNotice">是否关联修改退货通知单</param>
        ///<param name="pReturnStock">是否关联修改销售退货单</param>
        public void UpdateCustomer(string pFBillNo, int pFEntryId, int pCustomerId, bool pOutStock, bool pReceivable, bool pReturnNotice, bool pReturnStock)
        {
            _SQL = string.Format("DECLARE V_CUSTID NUMBER(10);  BEGIN  SELECT FCUSTID INTO V_CUSTID FROM T_SAL_ORDER WHERE FBILLNO = '{0}'; ", pFBillNo);
            _SQL += string.Format(" UPDATE T_SAL_ORDER SET FCUSTID = {0},FSETTLEID = {0} WHERE FBILLNO = '{1}';  ", pCustomerId, pFBillNo);

            if (pOutStock && !pReceivable)//只更新出库单
            {
                _SQL += string.Format(" UPDATE T_SAL_OUTSTOCK SET FCUSTOMERID = {0},FSETTLEID = {0} WHERE FCUSTOMERID = V_CUSTID AND FBILLNO IN(SELECT A.FBILLNO FROM T_SAL_OUTSTOCK A INNER JOIN T_SAL_OUTSTOCKENTRY_R AR ON A.FID = AR.FID WHERE AR.FSOENTRYID = {1}); ", pCustomerId, pFEntryId);
            }
            else if (pOutStock && pReceivable)//更新出库单和应收单
            {
                _SQL += string.Format(" UPDATE T_SAL_OUTSTOCK SET FCUSTOMERID = {0} WHERE FCUSTOMERID = V_CUSTID AND FBILLNO IN(SELECT DISTINCT A.FBILLNO FROM T_SAL_OUTSTOCK A INNER JOIN T_SAL_OUTSTOCKENTRY_R AR ON A.FID = AR.FID WHERE AR.FSOENTRYID = {1}); ", pCustomerId, pFEntryId);

                _SQL += string.Format(" UPDATE T_AR_RECEIVABLE SET FCUSTOMERID = {0} WHERE FCUSTOMERID = V_CUSTID AND FBILLNO IN(SELECT DISTINCT A.FBILLNO FROM T_AR_RECEIVABLE A INNER JOIN T_AR_RECEIVABLEENTRY AE ON A.FID = AE.FID WHERE AE.FORDERENTRYID = {1}); ", pCustomerId, pFEntryId);
            }
            if (pReturnNotice)
                _SQL += string.Format(" UPDATE T_SAL_RETURNNOTICE SET FRETCUSTID = {0} WHERE FRETCUSTID = V_CUSTID AND FID IN(SELECT DISTINCT A.FID FROM T_SAL_RETURNNOTICE A INNER JOIN T_SAL_RETURNNOTICEENTRY AE ON A.FID = AE.FID WHERE AE.FSOENTRYID = {1}); ", pCustomerId, pFEntryId);
            if (pReturnStock)
                _SQL += string.Format(" UPDATE T_SAL_RETURNSTOCK SET FRETCUSTID = {0} WHERE FRETCUSTID = V_CUSTID AND FID IN(SELECT DISTINCT A.FID FROM T_SAL_RETURNSTOCK A INNER JOIN T_SAL_RETURNSTOCKENTRY AE ON A.FID = AE.FID WHERE AE.FSOENTRYID = {1}); ", pCustomerId, pFEntryId);

            _SQL += " END;";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// UiCity对接单据调整
        /// </summary>
        /// <param name="pFBillNos"></param>
        public void UpdateUiCityOrders(int pFactoryOrgId, int pSaleOrgId, int pSaleDeptId, int pSalerId, List<string> pFBillNos)
        {
            string strFBillNos = string.Empty;
            if (pFBillNos == null || pFBillNos.Count == 0)
                return;
            for (int i = 0; i < pFBillNos.Count; i++)
            {
                if (i > 0)
                    strFBillNos += ",";
                strFBillNos += "'" + pFBillNos[i] + "'";
            }

            _SQL = @"BEGIN 
                    ";
            _SQL += string.Format("UPDATE T_SAL_ORDER SET FSALEORGID = {0},F_PAEZ_FACTORGID = {1},FSALEDEPTID = {2},FSALERID = {3} WHERE FBILLNO IN({4});", pSaleOrgId, pFactoryOrgId, pSaleDeptId, pSalerId, strFBillNos);
            _SQL += string.Format("UPDATE T_SAL_ORDERENTRY SET FSTOCKORGID = {0},FOWNERID = {0} WHERE FID IN(SELECT FID FROM T_SAL_ORDER WHERE FBILLNO IN({1}));", pFactoryOrgId, strFBillNos);
            _SQL += string.Format("UPDATE T_SAL_ORDERENTRY_F SET FSETTLEORGID = {0} WHERE FID IN(SELECT FID FROM T_SAL_ORDER WHERE FBILLNO IN({1}));", pSaleOrgId, strFBillNos);
            _SQL += "END;";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 根据销售组织查找单价为零的销售订单
        /// </summary>
        /// <param name="pSaleOrg"></param>
        /// <returns></returns>
        public DataTable NoPriceOrders(string pSaleOrgs)
        {
            _SQL = string.Format("SELECT O.FBILLNO 单据编号,O.FDATE 日期,OE.FSEQ 序号,MTL.FNUMBER 物料编码,MTLL.FNAME 物料名称,F.FPRICE 单价,OE.FENTRYID ");
            _SQL += string.Format(" FROM T_SAL_ORDER O ");
            _SQL += string.Format(" INNER JOIN T_SAL_ORDERENTRY OE ON O.FID = OE.FID ");
            _SQL += string.Format(" INNER JOIN T_SAL_ORDERENTRY_F F ON OE.FENTRYID = F.FENTRYID ");
            _SQL += string.Format(" INNER JOIN T_BD_MATERIAL MTL ON OE.FMATERIALID = MTL.FMATERIALID ");
            _SQL += string.Format(" INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052 ");
            _SQL += string.Format(" WHERE O.FDOCUMENTSTATUS = 'A' AND F.FPRICE = 0 AND O.FSALEORGID IN({0}) ", pSaleOrgs);
            _SQL += string.Format(" ORDER BY O.FBILLNO,OE.FSEQ ");

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 更新销售订单单价
        /// </summary>
        /// <param name="pOrders"></param>
        /// <returns></returns>
        public string UpdateOrderPirce(DataTable pOrders)
        {
            if (pOrders == null || pOrders.Rows.Count == 0)
                return "没有数据更新。";

            int iRows = 0;
            object oPrice;
            object oConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString_Order"].ConnectionString;
            if (oConnectionString == null)
                return "获取配置信息失败。";

            for (int i = 0; i < pOrders.Rows.Count; i++)
            {
                _SQL = string.Format("SELECT TOP 1 AL.Price ");
                _SQL += string.Format(" FROM PO_PurchaseOrder A ");
                _SQL += string.Format(" INNER JOIN PO_ProductList AL ON A.ID = AL.PurchaseOrderID ");
                _SQL += string.Format(" INNER JOIN PO_Materiel M ON AL.MaterielID = M.ERPFItemID ");
                _SQL += string.Format(" WHERE A.K3PurchaseOrder = '{0}' AND M.FNumber = '{1}' ", pOrders.Rows[i]["FBillNo"].ToString(), pOrders.Rows[i]["FNumber"].ToString());

                oPrice = SQLHelper.ExecuteScalar(oConnectionString.ToString(), _SQL);

                try
                {
                    if (oPrice == null || oPrice.ToString() == string.Empty)
                        continue;
                    oPrice = decimal.Parse(oPrice.ToString());

                    _SQL = string.Format("UPDATE T_SAL_ORDERENTRY_F SET FPRICE = {0},FTAXPRICE = {0},FTAXNETPRICE = {0}, FAMOUNT = {0} * FPRICEBASEQTY,FAMOUNT_LC = {0} * FPRICEBASEQTY,FALLAMOUNT = {0} * FPRICEBASEQTY WHERE FENTRYID = {1}", oPrice, pOrders.Rows[i]["FEntryId"]);
                    ORAHelper.ExecuteNonQuery(_SQL);

                    iRows++;
                }
                catch
                {
                    continue;
                }
            }

            if (iRows == 0)
                return "没有任何行更新，或许销售订单已经删除。";
            else if (iRows == pOrders.Rows.Count)
                return "成功更新了" + iRows + "行信息。";
            else
                return "成功更新了" + iRows + "行信息," + (pOrders.Rows.Count - iRows) + "行更新失败。";
        }
    }
}
