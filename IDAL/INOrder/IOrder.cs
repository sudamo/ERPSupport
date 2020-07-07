using System;

namespace ERPSupport.IDAL.INOrder
{
    using Model.INOrder;

    /// <summary>
    /// 接口
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEntry"></param>
        /// <returns></returns>
        void MegerPrice(OrderImportInfo pEntry);
    }
}
