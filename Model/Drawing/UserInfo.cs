using System;

namespace ERPSupport.Model.Drawing
{
    /// <summary>
    /// 用户Info
    /// </summary>
    public class UserInfo
    {
        public UserInfo() { }

        public UserInfo(string pUserName, string pPassword)
        {
            _UserName = pUserName;
            _Password = pPassword;
        }

        private int _PID;
        private int _UserId;
        private string _UserName;
        private string _Password;
        private int _GroupId;
        private bool _IsUse;
        private bool _LogStatus;
        private string _Creator;
        private DateTime _CreationDate;
        private string _Modifier;
        private DateTime _ModificationDate;
        private DateTime _LastLoginDate;
        private byte _Flag;
        private string _Description;

        /// <summary>
        /// 主键
        /// </summary>
        public int PID
        {
            get
            {
                return _PID;
            }

            set
            {
                _PID = value;
            }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId
        {
            get
            {
                return _UserId;
            }

            set
            {
                _UserId = value;
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return _UserName;
            }

            set
            {
                _UserName = value;
            }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }
        /// <summary>
        /// 班组ID
        /// </summary>
        public int GroupId
        {
            get
            {
                return _GroupId;
            }

            set
            {
                _GroupId = value;
            }
        }
        /// <summary>
        /// 使用状态：1使用中、0禁用
        /// </summary>
        public bool IsUse
        {
            get
            {
                return _IsUse;
            }

            set
            {
                _IsUse = value;
            }
        }
        /// <summary>
        /// 登录状态：1已经登录、0未登录
        /// </summary>
        public bool LogStatus
        {
            get
            {
                return _LogStatus;
            }

            set
            {
                _LogStatus = value;
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator
        {
            get
            {
                return _Creator;
            }

            set
            {
                _Creator = value;
            }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreationDate
        {
            get
            {
                return _CreationDate;
            }

            set
            {
                _CreationDate = value;
            }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public string Modifier
        {
            get
            {
                return _Modifier;
            }

            set
            {
                _Modifier = value;
            }
        }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModificationDate
        {
            get
            {
                return _ModificationDate;
            }

            set
            {
                _ModificationDate = value;
            }
        }
        /// <summary>
        /// 上次登录日期
        /// </summary>
        public DateTime LastLoginDate
        {
            get
            {
                return _LastLoginDate;
            }

            set
            {
                _LastLoginDate = value;
            }
        }
        /// <summary>
        /// 标识
        /// </summary>
        public byte Flag
        {
            get
            {
                return _Flag;
            }

            set
            {
                _Flag = value;
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
            }
        }
    }
}
