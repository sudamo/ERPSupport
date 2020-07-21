﻿using System;
using System.Text;
using System.Data;

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
        private object _obj;
        private string _ConnectionString;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommFunction()
        {
            _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString_Order"].ConnectionString;
        }

        /// <summary>
        /// 导入价格
        /// </summary>
        /// <param name="pEntry"></param>
        /// <returns></returns>
        public void MegerPrice(OrderImportInfo pEntry)
        {
            if (_ConnectionString == null)
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

            SQLHelper.ExecuteNonQuery(_ConnectionString, _SQL);
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="pDataRow"></param>
        /// <param name="pOrg"></param>
        /// <param name="pSeller"></param>
        public string AddCustomer(DataRow pDataRow, string pOrg, string pSeller)
        {
            if (_ConnectionString == null)
                return "请正确设置服务器信息";

            _SQL = string.Format("SELECT COUNT(*) FROM PO_Customer WHERE CustomerName = '{0}'", pDataRow["FNAME"].ToString());
            _obj = SQLHelper.ExecuteScalar(_ConnectionString, _SQL);

            if (_obj != null && int.Parse(_obj.ToString()) >= 1)
                return "网上订单系统已经存在客户[" + pDataRow["FNAME"].ToString() + "],请不要重复添加。";

            _SQL = "BEGIN TRANSACTION ";
            _SQL += string.Format(" INSERT INTO PO_Customer(FCUSTID,CustomerCode,CustomerName,SellerID,CreateOrgName,IsVisible) VALUES({0},'{1}','{2}',{3},{4},0); ", pDataRow["FCUSTID"].ToString(), pDataRow["FNUMBER"].ToString(), pDataRow["FNAME"].ToString(), pSeller, pOrg);
            _SQL += string.Format(" INSERT INTO PO_CustomerCE(CID,ManagementMode,ServiceMode) VALUES({0},1,1); ", pDataRow["FCUSTID"].ToString());
            _SQL += string.Format(" INSERT INTO PO_CustomerDetailInfo(CID,SalesOrg,IsVisible) VALUES({0},{1},1); ", pDataRow["FCUSTID"].ToString(), pOrg);
            _SQL += @"
            IF @@ERROR = 0
            BEGIN
	            COMMIT
	            SELECT '新增成功'
            END
            ELSE
            BEGIN
	            ROLLBACK
	            SELECT '新增出错 请联系管理员'
            END";

            return SQLHelper.ExecuteScalar(_ConnectionString, _SQL).ToString();
        }

        /// <summary>
        /// 添加行政地区信息
        /// </summary>
        /// <param name="pParentId">上级行政地区ID</param>
        /// <param name="pLevel">行政地区级别</param>
        /// <param name="pFirstChar">行政地区名第一个汉字</param>
        /// <param name="pName">行政地区名称</param>
        /// <returns></returns>
        public string AddADD(int pParentId, int pLevel, string pFirstChar, string pName)
        {
            string sFirstLetter = GetSpell(pFirstChar);

            _SQL = "BEGIN TRANSACTION ";
            _SQL += " DECLARE @Code INT ";
            _SQL += string.Format(" SELECT @Code = MAX(CODE) + 1 FROM PO_ChinaCity WHERE Parent_id = {0}; ", pParentId);
            _SQL += " INSERT INTO PO_ChinaCity(Code,Name,Parent_id,First_letter,Level) ";
            _SQL += string.Format(" VALUES(@Code, '{0}', {1}, '{2}', {3}); ", pName, pParentId, sFirstLetter, pLevel);
            _SQL += @"
            IF @@ERROR = 0
            BEGIN
	            COMMIT
	            SELECT '添加成功'
            END
            ELSE
            BEGIN
	            ROLLBACK
	            SELECT '添加出错 请联系管理员'
            END";
            return SQLHelper.ExecuteScalar(_ConnectionString, _SQL).ToString();
        }

        /// <summary>
        /// 获取中国行政区域信息
        /// </summary>
        /// <param name="pParentId">上级行政区ID</param>
        /// <returns></returns>
        public DataTable GetChinaAddByParentId(int pParentId = 0)
        {
            _SQL = string.Format("SELECT ID,Code,Name,Parent_id,First_letter,Level FROM PO_ChinaCity WHERE Parent_id = {0}", pParentId);
            return SQLHelper.ExecuteTable(_ConnectionString, _SQL);
        }

        /// <summary>
        /// 取得一个汉字的拼音首字母
        /// </summary>
        /// <param name="pCNChar">一个汉字</param>
        /// <returns>首字母</returns>
        private string GetSpell(string pCNChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(pCNChar);
            if (arrCN.Length > 1)
            {
                int area = arrCN[0];
                int pos = arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return pCNChar;
        }
    }
}
