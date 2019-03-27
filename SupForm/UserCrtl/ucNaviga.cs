using System;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 导航控件
    /// </summary>
    public partial class ucNaviga : UserControl
    {
        private int _NodeId;
        private int _ParentId;
        private string _Conr;

        /// <summary>
        /// 节点ID
        /// </summary>
        public int NodeId
        {
            get
            {
                return _NodeId;
            }

            set
            {
                _NodeId = value;
            }
        }
        /// <summary>
        /// 父类ID
        /// </summary>
        public int ParentId
        {
            get
            {
                return _ParentId;
            }

            set
            {
                _ParentId = value;
            }
        }
        /// <summary>
        /// 控件级别
        /// </summary>
        public string Conr
        {
            get
            {
                return _Conr;
            }

            set
            {
                _Conr = value;
            }
        }
        /// <summary>
        /// 委托 Click
        /// </summary>
        public event EventHandler _BtnClick;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucNaviga()
        {
            InitializeComponent();
        }

        /// <summary>
        /// button1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Name.Substring(2, 1) == "P")
            {
                _Conr = "P";
                _ParentId = 0;
                _NodeId = 0;
            }
            else
            {
                _Conr = "C";
                _ParentId = int.Parse(Name.Substring(3, 1));
                _NodeId = int.Parse(Name.Substring(3, 3));
            }
            _BtnClick?.Invoke(sender, e);
        }
    }
}