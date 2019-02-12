using System;

namespace ERPSupport.Model.Enum
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum SupOperations : int
    {
        /// <summary>
        /// 新增
        /// </summary>
        New,
        /// <summary>
        /// 修改
        /// </summary>
        Edit,
        /// <summary>
        /// 删除
        /// </summary>
        Delete,
        /// <summary>
        /// 复制
        /// </summary>
        Copy,
        /// <summary>
        /// 查看
        /// </summary>
        View,

        /// <summary>
        /// 暂存
        /// </summary>
        Draft,
        /// <summary>
        /// 保存
        /// </summary>
        Save,
        /// <summary>
        /// 提交
        /// </summary>
        Submit,
        /// <summary>
        /// 第一
        /// </summary>
        First,
        /// <summary>
        /// 前一
        /// </summary>
        Previous,

        /// <summary>
        /// 后一
        /// </summary>
        Next,
        /// <summary>
        /// 最后
        /// </summary>
        Last,
        /// <summary>
        /// 关闭
        /// </summary>
        Close,
        /// <summary>
        /// 刷新
        /// </summary>
        Refesh,
        /// <summary>
        /// 返回数据
        /// </summary>
        ReturnData,

        /// <summary>
        /// 过滤
        /// </summary>
        Filter,
        /// <summary>
        /// 审核
        /// </summary>
        Audit,
        /// <summary>
        /// 反审核
        /// </summary>
        UnAudit,
        /// <summary>
        /// 禁用
        /// </summary>
        Forbid,
        /// <summary>
        /// 反禁用
        /// </summary>
        Enable,

        /// <summary>
        /// 按列表引出
        /// </summary>
        Export,
        /// <summary>
        /// 打印预览
        /// </summary>
        PrintPreview,
        /// <summary>
        /// 打印
        /// </summary>
        Print,
        /// <summary>
        /// 引入
        /// </summary>
        ImportData,
        /// <summary>
        /// 按模板引出
        /// </summary>
        ExportData,

        /// <summary>
        /// 附件管理
        /// </summary>
        AttachmentMgr,
        /// <summary>
        /// 套打模板设置
        /// </summary>
        NoteTemplateSetting,
        /// <summary>
        /// 打印设置
        /// </summary>
        PrintSetting,
        /// <summary>
        /// 参数设置
        /// </summary>
        UserParameterSetting,
        /// <summary>
        /// 待办任务处理
        /// </summary>
        WorkflowAssign,

        /// <summary>
        /// 批量修改
        /// </summary>
        BulkEdit,
        /// <summary>
        /// 调用列表
        /// </summary>
        CallList,
        /// <summary>
        /// 弹性域关闭
        /// </summary>
        FlexClose,
        /// <summary>
        /// 引入模板设置
        /// </summary>
        ImportTemplateSetting,
        /// <summary>
        /// 查看流程图
        /// </summary>
        ShowFlowChart,

        /// <summary>
        /// 撤销
        /// </summary>
        CancelAssign,
        /// <summary>
        /// 按引入模板引出数据
        /// </summary>
        ExportDataByImportTemplate,
        /// <summary>
        /// 新增分录（流程设置）
        /// </summary>
        NewEntry,
        /// <summary>
        /// 删除分录（流程设置）
        /// </summary>
        DeleteEntry,
        /// <summary>
        /// 插入分录（流程设置）
        /// </summary>
        InsertEntry
    }
}
