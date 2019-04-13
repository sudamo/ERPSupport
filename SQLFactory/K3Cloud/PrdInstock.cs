using System.Data;

namespace ERPSupport.SQL.K3Cloud
{
    /// <summary>
    /// 生产入库
    /// </summary>
    public static class PrdInstock
    {
        #region STATIC
        private static string _SQL;
        //private static object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        static PrdInstock()
        {
            _SQL = string.Empty;
            //_obj = new object();
        }
        #endregion

        /// <summary>
        /// 根据BIllNo获取信息
        /// </summary>
        /// <param name="pBillNo">入库单编号</param>
        /// <returns></returns>
        public static DataTable GetInfo(string pBillNo)
        {
            _SQL = @"SELECT DISTINCT C.BARCODE 条码,C.CREATEDATE 日期,D.FNUMBER 物料编码,DL.FNAME 物料名称
            FROM T_PRD_INSTOCK A
            INNER JOIN T_PRD_INSTOCKENTRY AE ON A.FID = AE.FID
            INNER JOIN C##BARCODE2.PM_PRODUCETASK B ON AE.FMOENTRYID = B.FENTRYID
            INNER JOIN C##BARCODE2.PM_BARCODE C ON B.ID = C.TASKID
            INNER JOIN T_BD_MATERIAL D ON C.KDMTLID = D.FMATERIALID
            INNER JOIN T_BD_MATERIAL_L DL ON D.FMATERIALID = DL.FMATERIALID AND DL.FLOCALEID = 2052
            WHERE A.FBILLNO = '" + pBillNo + "' AND C.INSTOCKSTATUS = 0 AND KDINSTOCKID IS NULL";

            return ORAHelper.ExecuteTable(_SQL);
        }


        /// <summary>
        /// 同步条码仓库
        /// </summary>
        /// <param name="pBillNo">入库单编号</param>
        public static void UpdateBarcode(string pBillNo)
        {
            _SQL = @"UPDATE C##BARCODE2.PM_BARCODE
            SET KDINSTOCKID = (SELECT FID FROM T_PRD_INSTOCK WHERE FBILLNO = '" + pBillNo + @"'),INSTOCKSTATUS = 1
            WHERE BARCODE IN
            (SELECT DISTINCT C.BARCODE
            FROM T_PRD_INSTOCK A
            INNER JOIN T_PRD_INSTOCKENTRY AE ON A.FID = AE.FID
            INNER JOIN C##BARCODE2.PM_PRODUCETASK B ON AE.FMOENTRYID = B.FENTRYID
            INNER JOIN C##BARCODE2.PM_BARCODE C ON B.ID = C.TASKID
            WHERE A.FBILLNO = '" + pBillNo + "' AND C.INSTOCKSTATUS = 0 AND KDINSTOCKID IS NULL)";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 生产订单信息
        /// </summary>
        /// <param name="pPlanStartDate">计划开工日期</param>
        /// <returns></returns>
        public static DataTable GetMo(string pPlanStartDate)
        {
            _SQL = @"SELECT DISTINCT MTL.FNUMBER 物料编码, MTLL.FNAME 物料名称, DEP.FNUMBER 部门编码, DEPL.FNAME 部门--, MST.FSTOCKID 仓库
            FROM T_PRD_MO A
            INNER JOIN T_PRD_MOENTRY AE ON A.FID = AE.FID
            INNER JOIN T_PRD_MOENTRY_A AA ON AE.FENTRYID = AA.FENTRYID AND AA.FSTATUS IN(3,4)
            INNER JOIN T_BD_DEPARTMENT DEP ON AE.FWORKSHOPID = DEP.FDEPTID
            INNER JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052
            INNER JOIN T_PRD_PPBOMENTRY PBE ON AA.FENTRYID = PBE.FMOENTRYID
            INNER JOIN T_BD_MATERIAL MTL ON PBE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = 100508
            INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
            LEFT JOIN T_AUTO_MSTOCKSETTING MST ON MTL.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID
            WHERE (MST.FMATERIALID IS NULL OR MST.FSTOCKID IS NULL) AND A.FDOCUMENTSTATUS = 'C' AND A.FPRDORGID = 100508 AND TO_CHAR(AE.FPLANSTARTDATE,'yyyy-mm-dd') = '" + pPlanStartDate + "'";

            return ORAHelper.ExecuteTable(_SQL);
        }
    }
}
