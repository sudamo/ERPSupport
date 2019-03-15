using System;

namespace ERPSupport.Model.K3Cloud
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserInfo() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pUserId">登陆账户内码</param>
        /// <param name="pUserName">登陆账户名称</param>
        /// <param name="pUserPWD">登陆账户密码</param>
        /// <param name="pLoginTime">登录时间</param>
        public UserInfo(int pUserId, string pUserName, string pUserPWD, DateTime pLoginTime)
        {
            _UserId = pUserId;
            _UserName = pUserName;
            _UserPWD = pUserPWD;
            _LoginTime = pLoginTime;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pUserId">登陆账户内码</param>
        /// <param name="pUserName">登陆账户名称</param>
        /// <param name="pUserPWD">登陆账户密码</param>
        /// <param name="pLoginTime">登录时间</param>
        /// <param name="pRIDS">角色ID</param>
        /// <param name="pMIDS">功能ID</param>
        public UserInfo(int pUserId, string pUserName, string pUserPWD, DateTime pLoginTime, string pRIDS, string pMIDS, int pDepartmentID, string pDepartmentNumber, string pDepartmentName, string pFPhone)
        {
            _UserId = pUserId;
            _UserName = pUserName;
            _UserPWD = pUserPWD;
            _LoginTime = pLoginTime;
            _RIDS = pRIDS;
            _MIDS = pMIDS;
            _DepartmentID = pDepartmentID;
            _DepartmentNumber = pDepartmentNumber;
            _DepartmentName = pDepartmentName;
            _FPhone = pFPhone;
        }

        //Base
        private int _UserId;
        private string _UserName;
        private string _UserPWD;
        private DateTime _LoginTime;
        //Extend
        private string _RIDS;
        private string _MIDS;
        //Department
        private int _DepartmentID;
        private string _DepartmentNumber;
        private string _DepartmentName;
        //Contact
        private string _FPhone;

        /// <summary>
        /// 登陆账户内码
        /// </summary>
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        /// <summary>
        /// 登陆账户名称
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        /// <summary>
        /// 登陆账户密码
        /// </summary>
        public string UserPWD
        {
            get
            {
                return _UserPWD;
            }

            set
            {
                _UserPWD = value;
            }
        }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime
        {
            get { return _LoginTime; }
            set { _LoginTime = value; }
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RIDS
        {
            get
            {
                return _RIDS;
            }

            set
            {
                _RIDS = value;
            }
        }
        /// <summary>
        /// 功能ID
        /// </summary>
        public string MIDS
        {
            get
            {
                return _MIDS;
            }

            set
            {
                _MIDS = value;
            }
        }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartmentID
        {
            get
            {
                return _DepartmentID;
            }

            set
            {
                _DepartmentID = value;
            }
        }
        /// <summary>
        /// 部门编码
        /// </summary>
        public string DepartmentNumber
        {
            get
            {
                return _DepartmentNumber;
            }

            set
            {
                _DepartmentNumber = value;
            }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName
        {
            get
            {
                return _DepartmentName;
            }

            set
            {
                _DepartmentName = value;
            }
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string FPhone
        {
            get
            {
                return _FPhone;
            }

            set
            {
                _FPhone = value;
            }
        }
    }
}
