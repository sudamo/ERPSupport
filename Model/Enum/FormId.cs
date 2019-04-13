using System;
using System.ComponentModel;

namespace ERPSupport.Model.Enum
{
    /// <summary>
    /// 窗体标识
    /// </summary>
    public enum FormID : int
    {
        #region 默认设定
        /// <summary>
        /// 生产入库单
        /// </summary>
        [Description("生产入库-倒冲领料")]
        PRD_INSTOCK = 1,
        /// <summary>
        /// 生产用料清单
        /// </summary>
        [Description("生产用料清单-生产调拨")]
        PRD_PPBOM = 2,
        /// <summary>
        /// 销售订单
        /// </summary>
        [Description("销售订单-订单锁库")]
        SAL_SaleOrder = 3,
        /// <summary>
        /// 销售订单
        /// </summary>
        [Description("销售订单-订单运算")]
        SAL_SaleOrderRun = 4,
        #endregion

        #region 供应链

        //----------采购
        /// <summary>
        /// 采购订单
        /// </summary>
        PUR_PurchaseOrder,
        /// <summary>
        /// 采购申请单
        /// </summary>
        PUR_Requisition,
        /// <summary>
        /// 采购入库单
        /// </summary>
        STK_InStock,
        /// <summary>
        /// 采购退料单
        /// </summary>
        PUR_MRB,
        /// <summary>
        /// 收料通知单
        /// </summary>
        PUR_ReceiveBill,

        //----------销售
        /// <summary>
        /// 销售出库
        /// </summary>
        SAL_OUTSTOCK,
        /// <summary>
        /// 发货通知单
        /// </summary>
        SAL_DELIVERYNOTICE,
        /// <summary>
        /// 销售退货单
        /// </summary>
        SAL_RETURNSTOCK,

        //----------库存
        /// <summary>
        /// 直接调拨单
        /// </summary>
        STK_TransferDirect,
        /// <summary>
        /// 即时库存
        /// </summary>
        STK_Inventory,
        /// <summary>
        /// 其他入库单
        /// </summary>
        STK_MISCELLANEOUS,
        /// <summary>
        /// 其他出库单
        /// </summary>
        STK_MisDelivery,
        /// <summary>
        /// 分步式调入单
        /// </summary>
        STK_TRANSFERIN,
        /// <summary>
        /// 分步式调出单
        /// </summary>
        STK_TRANSFEROUT,
        /// <summary>
        /// 库存锁库
        /// </summary>
        STK_LockStock,
        /// <summary>
        /// 锁库日志
        /// </summary>
        STK_LOCKSTOCKLOG,
        /// <summary>
        /// 仓库
        /// </summary>
        BD_STOCK,
        #endregion

        #region 生产制造
        /// <summary>
        /// 物料清单
        /// </summary>
        ENG_BOM,
        /// <summary>
        /// 预留单
        /// </summary>
        PLN_RESERVE,
        /// <summary>
        /// 预留关系
        /// </summary>
        PLN_RESERVELINK,

        /// <summary>
        /// 生产订单
        /// </summary>
        PRD_MO,
        /// <summary>
        /// 生产退料单
        /// </summary>
        PRD_ReturnMtrl,
        /// <summary>
        /// 生产领料单
        /// </summary>
        PRD_PickMtrl,
        #endregion

        #region 财务
        /// <summary>
        /// 收款单
        /// </summary>
        AR_RECEIVEBILL,
        /// <summary>
        /// 付款单
        /// </summary>
        AP_PAYBILL,
        /// <summary>
        /// 应收单
        /// </summary>
        AR_receivable,
        /// <summary>
        /// 其他应收单
        /// </summary>
        AR_OtherRecAble,
        /// <summary>
        /// 应付单
        /// </summary>
        AP_Payable,
        /// <summary>
        /// 其他应付单
        /// </summary>
        AP_OtherPayable,
        #endregion

        #region 基础管理
        /// <summary>
        /// 物料
        /// </summary>
        BD_MATERIAL,
        /// <summary>
        /// 部门
        /// </summary>
        BD_Department,
        /// <summary>
        /// 客户
        /// </summary>
        BD_Customer,
        /// <summary>
        /// 员工
        /// </summary>
        BD_Empinfo,
        /// <summary>
        /// 计量单位
        /// </summary>
        BD_UNIT,
        /// <summary>
        /// 供应商
        /// </summary>
        BD_Supplier,
        /// <summary>
        /// 岗位信息
        /// </summary>
        HR_ORG_HRPOST,

        /// <summary>
        /// 用户
        /// </summary>
        SEC_User,
        /// <summary>
        /// 角色
        /// </summary>
        SEC_KDRoles,
        /// <summary>
        /// 组织机构
        /// </summary>
        ORG_Organizations,
        #endregion
    }
}
