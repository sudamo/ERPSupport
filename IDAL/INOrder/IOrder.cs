using System;
using System.Data;

namespace ERPSupport.IDAL.INOrder
{
    using Model.INOrder;

    /// <summary>
    /// 接口
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// 导入价格
        /// </summary>
        /// <param name="pEntry"></param>
        /// <returns></returns>
        void MegerPrice(OrderImportInfo pEntry);

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="pDataRow"></param>
        /// <param name="pOrg"></param>
        /// <param name="pSeller"></param>
        string AddCustomer(DataRow pDataRow, string pOrg, string pSeller);

        /// <summary>
        /// 获取中国行政区域信息
        /// </summary>
        /// <param name="pParentId">上级行政区ID</param>
        /// <returns></returns>
        DataTable GetChinaAddByParentId(int pParentId = 0);

        /// <summary>
        /// 添加行政地区信息
        /// </summary>
        /// <param name="pParentId">上级行政地区ID</param>
        /// <param name="pLevel">行政地区级别</param>
        /// <param name="pFirstChar">行政地区名第一个汉字</param>
        /// <param name="pName">行政地区名称</param>
        /// <returns></returns>
        string AddADD(int pParentId, int pLevel, string pFirstChar, string pName);
    }
}
