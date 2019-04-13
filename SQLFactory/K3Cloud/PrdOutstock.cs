using System.Data;

namespace ERPSupport.SQL.K3Cloud
{
    /// <summary>
    /// 产品出库
    /// </summary>
    public static class PrdOutstock
    {
        #region STATIC
        private static string _SQL;
        //private static object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        static PrdOutstock()
        {
            _SQL = string.Empty;
            //_obj = new object();
        }
        #endregion

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="pBillNo">单据编号</param>
        /// <returns>DataTable</returns>
        public static DataTable DataSource(string pBillNo)
        {
            if (pBillNo.Equals(string.Empty))
                return null;

            if (pBillNo.Contains("XSCKD"))
                _SQL = @"SELECT A.FID 内码,A.FBILLNO 单号,ORGL.FNAME 销售组织,CUSL.FNAME 客户,CUSL2.FNAME 结算方,CUSL3.FNAME 收款方,CUSL4.FNAME 付款方
                FROM T_SAL_OUTSTOCK A
                INNER
                JOIN T_ORG_ORGANIZATIONS_L ORGL ON A.FSALEORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSL ON A.FCUSTOMERID = CUSL.FCUSTID AND CUSL.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSL2 ON A.FSETTLEID = CUSL2.FCUSTID AND CUSL2.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSL3 ON A.FRECEIVERID = CUSL3.FCUSTID AND CUSL3.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSL4 ON A.FPAYERID = CUSL4.FCUSTID AND CUSL4.FLOCALEID = 2052
                WHERE A.FBILLNO LIKE '" + pBillNo + "%'";
            else if (pBillNo.Contains("AR"))
                return null;
            else
                _SQL = @"SELECT A.FID 内码,A.FBILLNO 单号,ORGL.FNAME 销售组织,CUSL.FNAME 客户,CUSL2.FNAME 结算方,CUSL3.FNAME 收款方,CUSL4.FNAME 付款方
                FROM T_SAL_ORDER A
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON A.FSALEORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSL ON A.FCUSTID = CUSL.FCUSTID AND CUSL.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSL2 ON A.FSETTLEID = CUSL2.FCUSTID AND CUSL2.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSL3 ON A.FRECEIVEID = CUSL3.FCUSTID AND CUSL3.FLOCALEID = 2052
                INNER JOIN T_BD_CUSTOMER_L CUSL4 ON A.FCHARGEID = CUSL4.FCUSTID AND CUSL4.FLOCALEID = 2052
                WHERE A.FBILLNO LIKE '" + pBillNo + "%'";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="pBillNo">单据编号</param>
        /// <param name="pUseOrgId">使用组织</param>
        public static void UpdateData(string pBillNo, int pUseOrgId)
        {
            if (pBillNo.Contains("XSCKD"))
                _SQL = "UPDATE T_SAL_OUTSTOCK SET FCUSTOMERID = " + pUseOrgId.ToString() + ", FSETTLEID = " + pUseOrgId.ToString() + ", FRECEIVERID = " + pUseOrgId.ToString() + ", FPAYERID = " + pUseOrgId.ToString() + " WHERE FBILLNO = '" + pBillNo + "'";
            else if (pBillNo.Contains("AR"))
                _SQL = "";
            else
                _SQL = "UPDATE T_SAL_ORDER SET FCUSTID = " + pUseOrgId.ToString() + ", FSETTLEID = " + pUseOrgId.ToString() + ", FRECEIVEID = " + pUseOrgId.ToString() + ", FCHARGEID = " + pUseOrgId.ToString() + " WHERE FBILLNO = '" + pBillNo + "'";

            ORAHelper.ExecuteNonQuery(_SQL);
        }
    }
}
