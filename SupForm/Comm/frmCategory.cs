using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Comm
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmCategory : Form
    {

        private int _Count;
        private Point _Point;
        private string _Title;
        private List<DataTable> _DataSource;

        private List<object> _returnValues;
        /// <summary>
        /// 返回值
        /// </summary>
        public List<object> ReturnValues
        {
            get
            {
                return _returnValues;
            }

            set
            {
                _returnValues = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public frmCategory(string pTitle, List<DataTable> pDataSource)
        {
            InitializeComponent();

            _Title = pTitle;
            _DataSource = pDataSource;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            Text = _Title;

            if (_DataSource == null || _DataSource.Count == 0)
                return;

            _Count = _DataSource.Count;
            Size = new Size(300, 86 + 24 * _Count);
            _Point = new Point(30, 12);

            for (int i = 0; i < _Count; i++)
            {
                UserCrtl.usCom_lblcbx lc = new UserCrtl.usCom_lblcbx("lblcbx" + (i + 1).ToString(), _DataSource[i], "FName", "FValue");
                lc.Location = _Point;
                Controls.Add(lc);
                _Point.Y += 24;
            }
        }

        private void bnBottom_btnPush_Click(object sender, EventArgs e)
        {
            _returnValues = new List<object>();
            foreach(Control ct in Controls)
            {
                if (ct.Name.Contains("lblcbx"))
                {
                    _returnValues.Add(((UserCrtl.usCom_lblcbx)ct).ComBox.SelectedValue);
                }
            }
            Close();
        }

        private void bnBottom_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
