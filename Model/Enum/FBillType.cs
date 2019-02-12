using System;

namespace ERPSupport.Model.Enum
{
    /// <summary>
    /// 销售订单
    /// </summary>
    public enum XSDDType : int
    {
        /// <summary>
        /// 标准销售订单
        /// </summary>
        XSDD01_SYS = 1,
        /// <summary>
        /// 寄售销售订单
        /// </summary>
        XSDD02_SYS = 2,
        /// <summary>
        /// 受托加工销售
        /// </summary>
        XSDD03_SYS = 3,
        /// <summary>
        /// 直运销售订单
        /// </summary>
        XSDD04_SYS = 4,
        /// <summary>
        /// 退货订单
        /// </summary>
        XSDD05_SYS = 5,

        /// <summary>
        /// 分销调拨订单
        /// </summary>
        XSDD06_SYS = 6,
        /// <summary>
        /// 分销购销订单
        /// </summary>
        XSDD07_SYS = 7,
        /// <summary>
        /// VMI销售订单
        /// </summary>
        XSDD08_SYS = 8,
        /// <summary>
        /// 现销订单
        /// </summary>
        XSDD09_SYS = 9,
        /// <summary>
        /// 备货销售订单
        /// </summary>
        XSDD10_SYS = 10,

        /// <summary>
        /// 标准销售订单变更单
        /// </summary>
        XSDDBGD01_SYS = 11,
        /// <summary>
        /// 退货订单变更单
        /// </summary>
        XSDDBGD02_SYS = 12

    }

    /// <summary>
    /// 销售出库单
    /// </summary>
    public enum XSCKType : int
    {
        /// <summary>
        /// 标准销售出库单
        /// </summary>
        XSCKD01_SYS = 1,
        /// <summary>
        /// 寄售出库单
        /// </summary>
        XSCKD02_SYS = 2,
        /// <summary>
        /// 零售出库单
        /// </summary>
        XSCKD03_SYS = 3,
        /// <summary>
        /// 分销购销销售出库单
        /// </summary>
        XSCKD04_SYS = 4,
        /// <summary>
        /// VMI出库单
        /// </summary>
        XSCKD05_SYS = 5,

        /// <summary>
        /// 现销出库单
        /// </summary>
        XSCKD06_SYS = 6,
        /// <summary>
        /// B2C销售出库单
        /// </summary>
        XSCKD07_SYS = 7
    }

    /// <summary>
    /// 应收单
    /// </summary>
    public enum YSDType : int
    {
        /// <summary>
        /// 标准应收单
        /// </summary>
        YSD01_SYS = 1,
        /// <summary>
        /// 费用应收单
        /// </summary>
        YSD02_SYS = 2,
        /// <summary>
        /// 资产应收单
        /// </summary>
        YSD03_SYS = 3,
        /// <summary>
        /// 转销应收单
        /// </summary>
        YSD04_SYS = 4,
        /// <summary>
        /// 其他应收单
        /// </summary>
        QTYSD01_SYS = 5,

        /// <summary>
        /// 应收核销单
        /// </summary>
        YSHXD01_SYS = 6
    }
}
