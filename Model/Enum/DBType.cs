using System;
using System.ComponentModel;

namespace ERPSupport.Model.Enum
{
    /// <summary>
    /// 数据库标识
    /// </summary>
    public enum DBType
    {
        [Description("SQLServer数据库")]
        SQLServer,
        [Description("Oracle数据库")]
        Oracle
    }
}
