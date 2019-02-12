using System;
using System.ComponentModel;

namespace ERPSupport.Model.Enum
{
    /// <summary>
    /// 窗体标识
    /// </summary>
    public enum FormID : int
    {
        /// <summary>
        /// 生产入库-倒冲领料
        /// </summary>
        [Description("生产入库-倒冲领料")]
        PRD_INSTOCK = 1,
        /// <summary>
        /// 用料清单-生产调拨
        /// </summary>
        [Description("用料清单-生产调拨")]
        PRD_PPBOM = 2,
        /// <summary>
        /// 销售订单-订单锁库
        /// </summary>
        [Description("销售订单-订单锁库")]
        SAL_SALEORDER = 3,
        /// <summary>
        /// 销售订单-订单运算
        /// </summary>
        [Description("销售订单-订单运算")]
        SAL_SALEORDERRUN = 4
    }
}
