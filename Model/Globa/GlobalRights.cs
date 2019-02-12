using System;

namespace ERPSupport.Model.Globa
{
    /// <summary>
    /// 全局权限ID
    /// </summary>
    public class GlobalRights
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pRIDs"></param>
        /// <param name="pMIDs"></param>
        /// <param name="pFunctionIds"></param>
        public GlobalRights(string pRIDs, string pMIDs, string pFunctionIds)
        {
            _RIDs = pRIDs;
            _MIDs = pMIDs;
            _FunctionIds = pFunctionIds;
        }

        private static string _RIDs;
        private static string _MIDs;
        private static string _FunctionIds;

        /// <summary>
        /// 角色ID
        /// </summary>
        public static string RIDs
        {
            get
            {
                return _RIDs;
            }

            set
            {
                _RIDs = value;
            }
        }
        /// <summary>
        /// 模块ID
        /// </summary>
        public static string MIDs
        {
            get
            {
                return _MIDs;
            }

            set
            {
                _MIDs = value;
            }
        }
        /// <summary>
        /// 其他功能ID
        /// </summary>
        public static string FunctionIds
        {
            get
            {
                return _FunctionIds;
            }

            set
            {
                _FunctionIds = value;
            }
        }
    }
}
