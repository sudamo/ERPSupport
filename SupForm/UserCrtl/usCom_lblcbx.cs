using System;
using System.Data;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 下拉框
    /// </summary>
    public partial class usCom_lblcbx : UserControl
    {
        /// <summary>
        /// DisplayMember
        /// </summary>
        private string _Name;
        /// <summary>
        /// ValueMember
        /// </summary>
        private string _Value;
        /// <summary>
        /// SelectedIndex
        /// </summary>
        private int _Index;
        /// <summary>
        /// 下拉框数据
        /// </summary>
        private DataTable _Source;

        private ComboBox _ComBox;

        public ComboBox ComBox
        {
            get
            {
                return _ComBox;
            }

            set
            {
                _ComBox = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pCtrlName">控件名称</param>
        /// <param name="pLabel">标题</param>
        /// <param name="pDataSource">下拉框数据</param>
        /// <param name="pName">DisplayMember</param>
        /// <param name="pValue">ValueMember</param>
        /// <param name="pDefaultIndex">SelectedIndex</param>
        public usCom_lblcbx(string pCtrlName, DataTable pDataSource, string pName, string pValue, int pDefaultIndex = 0)
        {
            InitializeComponent();

            Name = pCtrlName;
            _Source = pDataSource;
            _Name = pName;
            _Value = pValue;
            _Index = pDefaultIndex;

            _ComBox = cbx;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usCom_lblcbx_Load(object sender, EventArgs e)
        {
            if (_Source == null || _Source.Rows.Count == 0)
                return;
            lbl.Text = _Source.Rows[0][0].ToString();
            cbx.DataSource = _Source;
            cbx.DisplayMember = _Name;
            cbx.ValueMember = _Value;
            cbx.SelectedIndex = _Index;
        }
    }
}
