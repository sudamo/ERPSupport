
using System;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// ToolStripDateTimePicker
    /// </summary>
    public class ToolStripDateTimePicker : ToolStripControlHost
    {
        private int _Flag;
        private string _Description;
        //private DateTime _Value;

        /// <summary>
        /// 标识
        /// </summary>
        public int Flag
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
        /// <summary>
        /// Value
        /// </summary>
        public DateTime Value
        {
            get
            {
                return DateTime.Parse(ToString());
                //return ((DateTimePicker)Control).Value;
            }

            set
            {
                ((DateTimePicker)Control).Value = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ToolStripDateTimePicker() : base(new DateTimePicker())
        {
            //((DateTimePicker)Control).ValueChanged += ValueChangedChanged;
        }

        //public event EventHandler ValueChangedChanged;

        public void ValueChangedChanged(object sender, EventArgs e)
        {
            
        }


    }

    /// <summary>
    /// ToolStripCheckBox
    /// </summary>
    public class ToolStripCheckBox : ToolStripControlHost
    {
        private int _Flag;
        private string _Description;

        /// <summary>
        /// 标识
        /// </summary>
        public int Flag
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
        /// <summary>
        /// Checked
        /// </summary>
        public bool Checked
        {
            get
            {
                return ((CheckBox)Control).Checked;
            }

            set
            {
                ((CheckBox)Control).Checked = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ToolStripCheckBox() : base(new CheckBox())
        {

        }
    }

    /// <summary>
    /// ToolStripRaidoButton
    /// </summary>
    public class ToolStripRadioButton : ToolStripControlHost
    {
        private int _Flag;
        private string _Description;

        /// <summary>
        /// 标识
        /// </summary>
        public int Flag
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
        /// <summary>
        /// Checked
        /// </summary>
        public bool Checked
        {
            get
            {
                //return bool.Parse(ToString());
                return ((RadioButton)Control).Checked;
            }

            set
            {
                ((RadioButton)Control).Checked = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ToolStripRadioButton() : base(new RadioButton())
        {
            
        }
    }
}
