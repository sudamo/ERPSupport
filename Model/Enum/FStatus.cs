using System;

namespace ERPSupport.Model.Enum
{
    /// <summary>
    /// 单据状态
    /// </summary>
    public enum DocumentStatus : int
    {
        /// <summary>
        /// 创建
        /// </summary>
        A = 1,
        /// <summary>
        /// 审核中
        /// </summary>
        B = 2,
        /// <summary>
        /// 已审核
        /// </summary>
        C = 3,
        /// <summary>
        /// 重新审核
        /// </summary>
        D = 4,
        /// <summary>
        /// 暂存
        /// </summary>
        Z = -1
    }

    /// <summary>
    /// 关闭状态
    /// </summary>
    public enum CloseStatus : int
    {
        /// <summary>
        /// 正常
        /// </summary>
        A = 1,
        /// <summary>
        /// 已关闭
        /// </summary>
        B = 2
    }

    /// <summary>
    /// 业务关闭
    /// </summary>
    public enum MRPCloseStatus : int
    {
        /// <summary>
        /// 未关闭
        /// </summary>
        A = 1,
        /// <summary>
        /// 业务关闭
        /// </summary>
        B = 2
    }

    /// <summary>
    /// 禁用状态
    /// </summary>
    public enum ForbidStatus : int
    {
        /// <summary>
        /// 否
        /// </summary>
        A = 1,
        /// <summary>
        /// 是
        /// </summary>
        B = 2
    }
}
