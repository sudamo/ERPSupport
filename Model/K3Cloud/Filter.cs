using System;

namespace ERPSupport.Model.K3Cloud
{
    /// <summary>
    /// 筛选条件实体
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Filter() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pParenthesesLeft">左括号</param>
        /// <param name="pParenthesesRight">右括号</param>
        /// <param name="pField">字段</param>
        /// <param name="pCompare">比较</param>
        /// <param name="pFilterValue">值</param>
        /// <param name="pLogic">逻辑</param>
        public Filter(int pParenthesesLeft, int pParenthesesRight, int pField, int pCompare, FilterValue pFilterValue, int pLogic)
        {
            _ParenthesesLeft = pParenthesesLeft;
            _ParenthesesRight = pParenthesesRight;
            _Field = pField;
            _Compare = pCompare;
            _FilterValue = pFilterValue;
            _Logic = pLogic;
        }

        private int _ParenthesesLeft;
        private int _ParenthesesRight;
        private int _Field;
        private int _Compare;
        private FilterValue _FilterValue;
        private int _Logic;
        private bool _Validation = false;// 默认false

        /// <summary>
        /// 左括号
        /// </summary>
        public int ParenthesesLeft
        {
            get
            {
                return _ParenthesesLeft;
            }

            set
            {
                _ParenthesesLeft = value;
            }
        }
        /// <summary>
        /// 右括号
        /// </summary>
        public int ParenthesesRight
        {
            get
            {
                return _ParenthesesRight;
            }

            set
            {
                _ParenthesesRight = value;
            }
        }
        /// <summary>
        /// 字段
        /// </summary>
        public int Field
        {
            get
            {
                return _Field;
            }

            set
            {
                _Field = value;
            }
        }
        /// <summary>
        /// 比较
        /// </summary>
        public int Compare
        {
            get
            {
                return _Compare;
            }

            set
            {
                _Compare = value;
            }
        }
        /// <summary>
        /// 值
        /// </summary>
        public FilterValue FilterValue
        {
            get
            {
                return _FilterValue;
            }

            set
            {
                _FilterValue = value;
            }
        }
        /// <summary>
        /// 逻辑
        /// </summary>
        public int Logic
        {
            get
            {
                return _Logic;
            }

            set
            {
                _Logic = value;
            }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Validation
        {
            get
            {
                return _Validation;
            }

            set
            {
                _Validation = value;
            }
        }
    }

    /// <summary>
    /// 值实体
    /// </summary>
    public class FilterValue
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FilterValue() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pText">文本值</param>
        /// <param name="pDateTime">DateTime值</param>
        /// <param name="pIndex">Index值</param>
        /// <param name="pCheck">布尔值</param>
        public FilterValue(string pText, DateTime pDateTime, int pIndex, bool pCheck)
        {
            _FilterText = pText;
            _FilterDateTime = pDateTime;
            _FilterIndex = pIndex;
            _FilterCheck = pCheck;
        }

        private string _FilterText;
        private DateTime _FilterDateTime;
        private int _FilterIndex;
        private bool _FilterCheck;

        /// <summary>
        /// 文本值
        /// </summary>
        public string FilterText
        {
            get
            {
                return _FilterText;
            }

            set
            {
                _FilterText = value;
            }
        }
        /// <summary>
        /// DateTime值
        /// </summary>
        public DateTime FilterDateTime
        {
            get
            {
                return _FilterDateTime;
            }

            set
            {
                _FilterDateTime = value;
            }
        }
        /// <summary>
        /// Index值
        /// </summary>
        public int FilterIndex
        {
            get
            {
                return _FilterIndex;
            }

            set
            {
                _FilterIndex = value;
            }
        }
        /// <summary>
        /// 布尔值
        /// </summary>
        public bool FilterCheck
        {
            get
            {
                return _FilterCheck;
            }

            set
            {
                _FilterCheck = value;
            }
        }
    }
}
