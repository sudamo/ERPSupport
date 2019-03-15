using System;

namespace ERPSupport.Model.K3Cloud
{
    /// <summary>
    /// 配置信息实体
    /// </summary>
    public class K3Setting : UserInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public K3Setting() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pC_ERPADDRESS">ERP地址</param>
        /// <param name="pC_DBUSER">数据库库名</param>
        /// <param name="pC_ZTID">帐套ID</param>
        /// <param name="pC_USERNAME">数据库登陆用户名称</param>
        /// <param name="pC_PASSWORD">数据库登陆密码</param>
        /// <param name="pC_ORCLADDRESS">数据库地址</param>
        public K3Setting(string pC_ERPADDRESS, string pC_DBUSER, string pC_ZTID, string pC_USERNAME, string pC_PASSWORD, string pC_ORCLADDRESS)
        {
            _C_ERPADDRESS = pC_ERPADDRESS;
            _C_DBUSER = pC_DBUSER;
            _C_ZTID = pC_ZTID;
            _C_USERNAME = pC_USERNAME;
            _C_PASSWORD = pC_PASSWORD;
            _C_ORCLADDRESS = pC_ORCLADDRESS;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pC_ERPADDRESS">ERP地址</param>
        /// <param name="pC_OWNER">数据库库名</param>
        /// <param name="pC_ZTID">帐套ID</param>
        /// <param name="pC_USERNAME">数据库登陆用户名称</param>
        /// <param name="pC_PASSWORD">数据库登陆密码</param>
        /// <param name="pC_ORCLADDRESS">数据库地址</param>
        /// <param name="pUserId">登陆账户内码</param>
        /// <param name="pUserName">登陆账户名称</param>
        /// <param name="pUserPWD">登陆账户密码</param>
        /// <param name="pLoginTime">登录时间</param>
        /// <param name="pRIDS">角色ID</param>
        /// <param name="pMIDS">功能ID</param>
        public K3Setting(string pC_ERPADDRESS, string pC_OWNER, string pC_ZTID, string pC_USERNAME, string pC_PASSWORD, string pC_ORCLADDRESS, int pUserId, string pUserName, string pUserPWD, DateTime pLoginTime, string pRIDS, string pMIDS,int pDepartmentID,string pDepartmentNumber,string pDepartmentName,string pFPhone)
        {
            _C_ERPADDRESS = pC_ERPADDRESS;
            _C_DBUSER = pC_OWNER;
            _C_ZTID = pC_ZTID;
            _C_USERNAME = pC_USERNAME;
            _C_PASSWORD = pC_PASSWORD;
            _C_ORCLADDRESS = pC_ORCLADDRESS;
            UserId = pUserId;
            UserName = pUserName;
            UserPWD = pUserPWD;
            LoginTime = pLoginTime;
            RIDS = pRIDS;
            MIDS = pMIDS;
            DepartmentID = pDepartmentID;
            DepartmentNumber = pDepartmentNumber;
            DepartmentName = pDepartmentName;
            FPhone = pFPhone;
        }

        private string _C_ERPADDRESS;
        private string _C_DBUSER;
        private string _C_ZTID;
        private string _C_USERNAME;
        private string _C_PASSWORD;
        private string _C_ORCLADDRESS;

        /// <summary>
        /// ERP地址
        /// </summary>
        public string C_ERPADDRESS
        {
            get { return _C_ERPADDRESS; }
            set { _C_ERPADDRESS = value; }
        }
        /// <summary>
        /// 数据库库名
        /// </summary>
        public string C_DBUSER
        {
            get { return _C_DBUSER; }
            set { _C_DBUSER = value; }
        }
        /// <summary>
        /// 账套ID
        /// </summary>
        public string C_ZTID
        {
            get { return _C_ZTID; }
            set { _C_ZTID = value; }
        }
        /// <summary>
        /// 数据库登陆用户名称
        /// </summary>
        public string C_USERNAME
        {
            get { return _C_USERNAME; }
            set { _C_USERNAME = value; }
        }
        /// <summary>
        /// 数据库登陆密码
        /// </summary>
        public string C_PASSWORD
        {
            get { return _C_PASSWORD; }
            set { _C_PASSWORD = value; }
        }
        /// <summary>
        /// 数据库地址
        /// </summary>
        public string C_ORCLADDRESS
        {
            get { return _C_ORCLADDRESS; }
            set { _C_ORCLADDRESS = value; }
        }
    }
}