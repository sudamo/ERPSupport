﻿using ERPSupport.Model.Basic;
using ERPSupport.Model.K3Cloud;

namespace ERPSupport.Model.Globa
{
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
    }
}
