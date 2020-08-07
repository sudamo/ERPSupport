using System.Data;

namespace ERPSupport.SQL.K3Cloud
{
    using IDAL.K3Cloud;

    /// <summary>
    /// 生产入库
    /// </summary>
    public class PrdInstock : IPrdInstock
    {
        private static string _SQL;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PrdInstock()
        {
            _SQL = string.Empty;
        }

        /// <summary>
        /// 根据BIllNo获取信息
        /// </summary>
        /// <param name="pBillNo">入库单编号</param>
        /// <returns></returns>
        public DataTable GetInfo(string pBillNo)
        {
            //_SQL = @"SELECT DISTINCT C.BARCODE 条码,C.CREATEDATE 日期,D.FNUMBER 物料编码,DL.FNAME 物料名称
            //FROM T_PRD_INSTOCK A
            //INNER JOIN T_PRD_INSTOCKENTRY AE ON A.FID = AE.FID
            //INNER JOIN C##BARCODE2.PM_PRODUCETASK B ON AE.FMOENTRYID = B.FENTRYID
            //INNER JOIN C##BARCODE2.PM_BARCODE C ON B.ID = C.TASKID
            //INNER JOIN T_BD_MATERIAL D ON C.KDMTLID = D.FMATERIALID
            //INNER JOIN T_BD_MATERIAL_L DL ON D.FMATERIALID = DL.FMATERIALID AND DL.FLOCALEID = 2052
            //WHERE A.FBILLNO = '" + pBillNo + "' AND C.INSTOCKSTATUS = 0 AND KDINSTOCKID IS NULL";

            //return ORAHelper.ExecuteTable(_SQL);
            return null;
        }

        /// <summary>
        /// 同步条码仓库
        /// </summary>
        /// <param name="pBillNo">入库单编号</param>
        public void UpdateBarcode(string pBillNo)
        {
            //_SQL = @"UPDATE C##BARCODE2.PM_BARCODE
            //SET KDINSTOCKID = (SELECT FID FROM T_PRD_INSTOCK WHERE FBILLNO = '" + pBillNo + @"'),INSTOCKSTATUS = 1
            //WHERE BARCODE IN
            //(SELECT DISTINCT C.BARCODE
            //FROM T_PRD_INSTOCK A
            //INNER JOIN T_PRD_INSTOCKENTRY AE ON A.FID = AE.FID
            //INNER JOIN C##BARCODE2.PM_PRODUCETASK B ON AE.FMOENTRYID = B.FENTRYID
            //INNER JOIN C##BARCODE2.PM_BARCODE C ON B.ID = C.TASKID
            //WHERE A.FBILLNO = '" + pBillNo + "' AND C.INSTOCKSTATUS = 0 AND KDINSTOCKID IS NULL)";

            //ORAHelper.ExecuteNonQuery(_SQL);
        }
        
        /// <summary>
        /// 生产订单信息
        /// </summary>
        /// <param name="pPlanStartDate">计划开工日期</param>
        /// <param name="pFormId">业务标识</param>
        /// <returns></returns>
        public DataTable GetMo(string pPlanStartDate, Model.Enum.FormID pFormId)
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

            _SQL = string.Format("SELECT DISTINCT MTL.FNUMBER 物料编码, MTLL.FNAME 物料名称, DEP.FNUMBER 部门编码, DEPL.FNAME 部门 ");
            _SQL += string.Format(" FROM T_PRD_MO A ");
            _SQL += string.Format(" INNER JOIN T_PRD_MOENTRY AE ON A.FID = AE.FID ");
            _SQL += string.Format(" INNER JOIN T_PRD_MOENTRY_A AA ON AE.FENTRYID = AA.FENTRYID AND AA.FSTATUS IN({0}) ", strOrg == "100508" ? "3,4" : "4");
            _SQL += string.Format(" INNER JOIN T_BD_DEPARTMENT DEP ON AE.FWORKSHOPID = DEP.FDEPTID ");
            _SQL += string.Format(" INNER JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052 ");
            _SQL += string.Format(" INNER JOIN T_PRD_PPBOMENTRY PBE ON AA.FENTRYID = PBE.FMOENTRYID ");
            _SQL += string.Format(" INNER JOIN T_BD_MATERIAL MTL ON PBE.FMATERIALID = MTL.FMATERIALID AND MTL.FUSEORGID = {0} ", strOrg);
            _SQL += string.Format(" INNER JOIN T_BD_MATERIAL_L MTLL ON MTL.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052 ");
            _SQL += string.Format(" LEFT JOIN T_AUTO_MSTOCKSETTING MST ON MTL.FMATERIALID = MST.FMATERIALID AND DEP.FDEPTID = MST.FDEPTID ");
            _SQL += string.Format(" WHERE (MST.FMATERIALID IS NULL OR MST.FSTOCKID IS NULL) AND A.FDOCUMENTSTATUS = 'C' AND A.FPRDORGID = {0} AND TO_CHAR(AE.FPLANSTARTDATE,'yyyy-mm-dd') = '{1}'", strOrg, pPlanStartDate);

            return ORAHelper.ExecuteTable(_SQL);
        }
    }
}
