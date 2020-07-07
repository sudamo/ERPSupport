using System;

namespace ERPSupport.SQL.INOrder
{
    using Model.INOrder;
    using IDAL.INOrder;

    /// <summary>
    /// 公共方法
    /// </summary>
    public class CommFunction : IOrder
    {
        private string _SQL;
        //private object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommFunction() { }

        /// <summary>
        /// 导入价格
        /// </summary>
        /// <param name="pEntry"></param>
        /// <returns></returns>
        public void MegerPrice(OrderImportInfo pEntry)
        {
            object oConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString_Order"].ConnectionString;
            if (oConnectionString == null)
                return;

            _SQL = string.Format("MERGE INTO pO_PriceConfig T ");
            _SQL += string.Format(" USING ( ");
            _SQL += string.Format(" SELECT B.ERPID BasicDataID,C.ERPID BrandID,D.ERPID SeriesID,E.ERPID CommodityID,F.PricingFactorCode PricingFactorID,A.GeneralFactoryPrice,A.BranchFactoryPrice,A.BeginDate,A.EndDate,1 IsEnable ");
            _SQL += string.Format(" FROM (SELECT '{0}' BasicDataID,'{1}' BrandID,'{2}' SeriesID,'{3}' CommodityID,'{4}' PricingFactorID,{5} GeneralFactoryPrice,{6} BranchFactoryPrice,'{7}' BeginDate,'{8}' EndDate) AS A ", pEntry.BasicDataID, pEntry.BrandID, pEntry.SeriesID, pEntry.CommodityID, pEntry.PricingFactorID, pEntry.GeneralFactoryPrice, pEntry.BranchFactoryPrice, pEntry.TimeBegin, pEntry.TimeEnd);
            _SQL += string.Format(" LEFT JOIN PO_BasicData B ON A.BasicDataID = B.FName AND B.ParentID = '5865fdf403244e' AND B.IsDisable = 1 ");
            _SQL += string.Format(" LEFT JOIN PO_BasicData C ON A.BrandID = C.FName AND C.[Type] = 9 AND C.IsDisable = 1 ");
            _SQL += string.Format(" LEFT JOIN PO_BasicData D ON A.SeriesID = D.FName AND D.[Type] = 10 AND D.IsDisable = 1 ");
            _SQL += string.Format(" LEFT JOIN PO_Commodity E ON A.CommodityID = E.CommodityName AND E.SeriesERPID = D.ERPID ");
            _SQL += string.Format(" LEFT JOIN PO_PricingFactor F ON A.PricingFactorID = F.PricingFactorName AND F.IsDisable = 1 ");
            _SQL += string.Format(" ) AS O ON T.BasicDataID = O.BasicDataID AND T.BrandID = O.BrandID AND T.SeriesID = O.SeriesID AND T.CommodityID = O.CommodityID AND T.PricingFactorID = O.PricingFactorID ");
            _SQL += string.Format(" WHEN MATCHED ");
            _SQL += string.Format(" THEN UPDATE SET ");
            _SQL += string.Format(" GeneralFactoryPrice = O.GeneralFactoryPrice,BranchFactoryPrice = O.BranchFactoryPrice ");
            _SQL += string.Format(" WHEN NOT MATCHED ");
            _SQL += string.Format(" THEN INSERT ");
            _SQL += string.Format(" (BasicDataID,BrandID,SeriesID,CommodityID,PricingFactorID,GeneralFactoryPrice,BranchFactoryPrice,BeginDate,EndDate,IsEnable) ");
            _SQL += string.Format(" VALUES(O.BasicDataID,O.BrandID,O.SeriesID, O.CommodityID, O.PricingFactorID,O.GeneralFactoryPrice,O.BranchFactoryPrice,O.BeginDate,O.EndDate,O.IsEnable);");

            SQLHelper.ExecuteNonQuery(oConnectionString.ToString(), _SQL);
        }
    }
}
