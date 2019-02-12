﻿using System;

namespace ERPSupport.Model.Drawing
{
    /// <summary>
    /// 图纸Info
    /// </summary>
    public class DrawingInfo
    {
        public DrawingInfo() { }

        private int _PID;
        private int _FMaterialId;
        private string _FNumber;
        private string _FPath;
        private string _FName;
        private string _Suffix;
        private int _FSize;
        private string _Creator;
        private DateTime _CreationDate;
        private string _Modifier;
        private DateTime _ModificationDate;
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
        /// 物料ID
        /// </summary>
        public int FMaterialId
        {
            get
            {
                return _FMaterialId;
            }

            set
            {
                _FMaterialId = value;
            }
        }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string FNumber
        {
            get
            {
                return _FNumber;
            }

            set
            {
                _FNumber = value;
            }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FPath
        {
            get
            {
                return _FPath;
            }

            set
            {
                _FPath = value;
            }
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FName
        {
            get
            {
                return _FName;
            }

            set
            {
                _FName = value;
            }
        }
        /// <summary>
        /// 后缀
        /// </summary>
        public string Suffix
        {
            get
            {
                return _Suffix;
            }

            set
            {
                _Suffix = value;
            }
        }
        /// <summary>
        /// 文件大小（KB）
        /// </summary>
        public int FSize
        {
            get
            {
                return _FSize;
            }

            set
            {
                _FSize = value;
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
