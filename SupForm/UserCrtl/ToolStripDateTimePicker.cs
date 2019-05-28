
using System;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// ToolStripDateTimePicker
    /// </summary>
    public class ToolStripDateTimePicker : ToolStripControlHost
    {
        private bool _Flag;
        private string _Description;
        private DateTime _Value;

        /// <summary>
        /// 标识
        /// </summary>
        public bool Flag
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

        public DateTime Value
        {
            get
            {
                return DateTime.Parse(ToString());
            }

            set
            {
                _Value = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ToolStripDateTimePicker() : base(new DateTimePicker())
        {

        }
    }

    /// <summary>
    /// ToolStripCheckBox
    /// </summary>
    public class ToolStripCheckBox : ToolStripControlHost
    {
        private bool _Flag;
        /// <summary>
        /// 标识
        /// </summary>
        public bool Flag
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
        /// 构造函数
        /// </summary>
        public ToolStripCheckBox() : base(new CheckBox())
        {

        }
    }
}
