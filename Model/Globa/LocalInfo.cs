using System;

namespace ERPSupport.Model.Globa
{
    /// <summary>
    /// 本地信息
    /// </summary>
    public class LocalInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LocalInfo()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pIP"></param>
        /// <param name="pMAC"></param>
        /// <param name="pHostName"></param>
        /// <param name="pLoginTime"></param>
        /// <param name="pLogoutTime"></param>
        public LocalInfo(string pIP, string pMAC, string pHostName, DateTime pLoginTime, DateTime pLogoutTime)
        {
            _IP = pIP;
            _MAC = pMAC;
            _HostName = pHostName;
            _LoginTiem = pLoginTime;
            _LogoutTime = pLogoutTime;
        }

        private string _IP;
        private string _MAC;
        private string _HostName;
        private DateTime _LoginTiem;
        private DateTime _LogoutTime;


        /// <summary>
        /// IP地址
        /// </summary>
        public string IP
        {
            get
            {
                return _IP;
            }

            set
            {
                _IP = value;
            }
        }
        /// <summary>
        /// MAC机器码
        /// </summary>
        public string MAC
        {
            get
            {
                return _MAC;
            }

            set
            {
                _MAC = value;
            }
        }
        /// <summary>
        /// 计算机名
        /// </summary>
        public string HostName
        {
            get
            {
                return _HostName;
            }

            set
            {
                _HostName = value;
            }
        }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime
        {
            get
            {
                return _LoginTiem;
            }

            set
            {
                _LoginTiem = value;
            }
        }
        /// <summary>
        /// 登出时间
        /// </summary>
        public DateTime LogoutTime
        {
            get
            {
                return _LogoutTime;
            }

            set
            {
                _LogoutTime = value;
            }
        }
    }
}
