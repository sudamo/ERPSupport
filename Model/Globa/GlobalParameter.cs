using ERPSupport.Model.Basic;
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
        /// <param name="pK3Inf">配置信息</param>
        public GlobalParameter(K3Setting pK3Inf, SQLConfig pSQLInf)
        {
            _K3Inf = pK3Inf;
            _SQLInf = pSQLInf;
        }

        private static K3Setting _K3Inf;
        private static SQLConfig _SQLInf;


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
    }
}
