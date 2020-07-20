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
    }
}
