using System;

namespace ERPSupport.Model.Enum
{
    /// <summary>
    /// 功能模块
    /// </summary>
    public enum Foundation : int
    {
        #region 财务

        /// <summary>
        /// 应收管理
        /// </summary>
        A_AR = 1,
        /// <summary>
        /// 应付管理
        /// </summary>
        A_AP = 2,
        /// <summary>
        /// 发票管理
        /// </summary>
        A_IV = 3,
        /// <summary>
        /// 资金管理
        /// </summary>
        A_SC = 4,
        /// <summary>
        /// 报表
        /// </summary>
        A_KDS = 5,
        #endregion

        #region 供应链

        /// <summary>
        /// 采购管理
        /// </summary>
        B_PUR = 6,
        /// <summary>
        /// 销售管理
        /// </summary>
        B_SAL = 7,
        /// <summary>
        /// 信用管理
        /// </summary>
        B_CRE = 8,
        /// <summary>
        /// 库存管理
        /// </summary>
        B_STK = 9,
        /// <summary>
        /// 组织间结算
        /// </summary>
        B_IOS = 10,
        /// <summary>
        /// 条码管理
        /// </summary>
        B_BAR = 11,
        #endregion

        #region 生产制造

        /// <summary>
        /// 工程数据
        /// </summary>
        C_ENG = 12,
        /// <summary>
        /// 计划管理
        /// </summary>
        C_PLN = 13,
        /// <summary>
        /// 生产管理
        /// </summary>
        C_PRD = 14,
        /// <summary>
        /// 委外管理
        /// </summary>
        C_SUB = 15,
        /// <summary>
        /// 生产线生产
        /// </summary>
        C_REM = 16,
        /// <summary>
        /// 车间管理
        /// </summary>
        C_SFC = 17,
        #endregion

        #region 客户关系

        /// <summary>
        /// 客户管理
        /// </summary>
        D_CRM = 18,
        #endregion

        #region 基础管理

        /// <summary>
        /// 基础资料
        /// </summary>
        E_DB = 19
        #endregion
    }
}
