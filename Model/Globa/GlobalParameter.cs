﻿using System;

namespace ERPSupport.Model.Globa
{
    using Basic;
    using K3Cloud;

    /// <summary>
    /// 全局参数实体
    /// </summary>
    public class GlobalParameter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public GlobalParameter()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pK3Inf"></param>
        public GlobalParameter(K3Setting pK3Inf)
        {
            _K3Inf = pK3Inf;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pSQLInf"></param>
        public GlobalParameter(SQLConfig pSQLInf)
        {
            _SQLInf = pSQLInf;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pLocalInf"></param>
        public GlobalParameter(LocalInfo pLocalInf)
        {
            _LocalInf = pLocalInf;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pOperationInf"></param>
        public GlobalParameter(OperationInfo pOperationInf)
        {
            _OperationInf = pOperationInf;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pK3Inf">配置信息</param>
        public GlobalParameter(K3Setting pK3Inf, SQLConfig pSQLInf)
        {
            _K3Inf = pK3Inf;
            _SQLInf = pSQLInf;
        }

        private static object _Tmp_Params;
        private static bool _IsJournal;
        private static int _Dir_DPQtyPZ;
        private static int _Dir_MinQtyPZ;
        private static string _Dir_CPDB_Department;
        private static string _Dir_CPDB_Stock;
        private static K3Setting _K3Inf;
        private static SQLConfig _SQLInf;
        private static LocalInfo _LocalInf;
        private static OperationInfo _OperationInf;


        /// <summary>
        /// K3配置信息
        /// </summary>
        public static K3Setting K3Inf
        {
            get
            {
                return _K3Inf;
            }

            set
            {
                _K3Inf = value;
            }
        }

        /// <summary>
        /// SQLServer配置信息
        /// </summary>
        public static SQLConfig SQLInf
        {
            get
            {
                return _SQLInf;
            }

            set
            {
                _SQLInf = value;
            }
        }

        /// <summary>
        /// 本地信息
        /// </summary>
        public static LocalInfo LocalInf
        {
            get
            {
                return _LocalInf;
            }

            set
            {
                _LocalInf = value;
            }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public static OperationInfo OperationInf
        {
            get
            {
                return _OperationInf;
            }

            set
            {
                _OperationInf = value;
            }
        }

        /// <summary>
        /// 通用参数
        /// </summary>
        public static object Tmp_Params
        {
            get
            {
                return _Tmp_Params;
            }

            set
            {
                _Tmp_Params = value;
            }
        }

        /// <summary>
        /// 是否记录操作日志
        /// </summary>
        public static bool IsJournal
        {
            get
            {
                return _IsJournal;
            }

            set
            {
                _IsJournal = value;
            }
        }

        /// <summary>
        /// 单片合计数量
        /// </summary>
        public static int Dir_DPQtyPZ
        {
            get
            {
                return _Dir_DPQtyPZ;
            }

            set
            {
                _Dir_DPQtyPZ = value;
            }
        }

        /// <summary>
        /// 大单统计数量
        /// </summary>
        public static int Dir_MinQtyPZ
        {
            get
            {
                return _Dir_MinQtyPZ;
            }

            set
            {
                _Dir_MinQtyPZ = value;
            }
        }
        /// <summary>
        /// 成品调拨默认部门
        /// </summary>
        public static string Dir_CPDB_Department
        {
            get
            {
                return _Dir_CPDB_Department;
            }

            set
            {
                _Dir_CPDB_Department = value;
            }
        }
        /// <summary>
        /// 成品调拨默认仓库
        /// </summary>
        public static string Dir_CPDB_Stock
        {
            get
            {
                return _Dir_CPDB_Stock;
            }

            set
            {
                _Dir_CPDB_Stock = value;
            }
        }
    }
}
