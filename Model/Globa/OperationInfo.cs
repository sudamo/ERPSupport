using System;

namespace ERPSupport.Model.Globa
{
    /// <summary>
    /// 操作信息
    /// </summary>
    public class OperationInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public OperationInfo()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pOName"></param>
        /// <param name="pOTime"></param>
        /// <param name="pONavi"></param>
        /// <param name="pOContent"></param>
        public OperationInfo(string pOName, DateTime pOTime, string pONavi, string pOContent)
        {
            _OName = pOName;
            _OTime = pOTime;
            _ONavi = pONavi;
            _OContent = pOContent;
        }

        private string _OName;
        private DateTime _OTime;
        private string _ONavi;
        private string _OContent;

        /// <summary>
        /// 操作名称
        /// </summary>
        public string OName
        {
            get
            {
                return _OName;
            }

            set
            {
                _OName = value;
            }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OTime
        {
            get
            {
                return _OTime;
            }

            set
            {
                _OTime = value;
            }
        }
        /// <summary>
        /// 导航位置
        /// </summary>
        public string ONavi
        {
            get
            {
                return _ONavi;
            }

            set
            {
                _ONavi = value;
            }
        }
        /// <summary>
        /// 操作内容简述
        /// </summary>
        public string OContent
        {
            get
            {
                return _OContent;
            }

            set
            {
                _OContent = value;
            }
        }
    }
}
