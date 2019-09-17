
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using ERPSupport.SupForm.UserCrtl;

namespace ERPSupport.SupForm.Bussiness
{
    /// <summary>
    /// 物料清单修改对照
    /// </summary>
    public partial class frmBomCompare : Form
    {
        /// <summary>
        /// 原数据
        /// </summary>
        private DataTable _dtOld;
        /// <summary>
        /// 修改后数据
        /// </summary>
        private DataTable _dtNew;
        /// <summary>
        /// 产品编码
        /// </summary>
        private string _Number;
        /// <summary>
        /// 需求日期
        /// </summary>
        private DateTime _tNeedDate;
        /// <summary>
        /// 修改行号
        /// </summary>
        private int _Row;
        /// <summary>
        /// ToolStrip日期
        /// </summary>
        private ToolStripDateTimePicker _tsNeedDate;
        /// <summary>
        /// ToolStrip同步更新
        /// </summary>
        private ToolStripCheckBox _chbSyn;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pdtOld">原数据</param>
        /// <param name="pdtNew">修改后数据</param>
        /// <param name="pNumber">产品编码</param>
        /// <param name="pNeedDate">需求日期</param>
        /// <param name="pRow">修改行序号</param>
        /// <param name="pType">是否之修改数量</param>
        public frmBomCompare(DataTable pdtOld, DataTable pdtNew, string pNumber, DateTime pNeedDate, int pRow, bool pType)
        {
            InitializeComponent();
            _dtOld = pdtOld;
            _dtNew = pdtNew;
            _Number = pNumber;
            _tNeedDate = pNeedDate;
            _Row = pRow;
        }

        private void frmBomCompare_Load(object sender, EventArgs e)
        {
            _tsNeedDate = new ToolStripDateTimePicker();
            _tsNeedDate.Size = new Size(120, 21);
            _tsNeedDate.Value = _tNeedDate;
            _tsNeedDate.Enabled = false;
            //((DateTimePicker)_tsNeedDate.Control).ValueChanged += new EventHandler(NeedDate_ValueChanged);

            _chbSyn = new ToolStripCheckBox();
            _chbSyn.Text = "同步修改";
            _chbSyn.ToolTipText = "是否同时修改需求日期[" + _tNeedDate.ToString("yyyy-MM-dd") + "]的其他生产用料清单下的相同子项物料";
            _chbSyn.Checked = false;

            //重新排列Items
            List<ToolStripItem> list = new List<ToolStripItem>();
            list.Add(bnBottom.Items[0]);
            list.Add(bnBottom.Items[1]);
            list.Add(_tsNeedDate);
            list.Add(_chbSyn);
            list.Add(bnBottom.Items[2]);
            list.Add(bnBottom.Items[3]);
            list.Add(bnBottom.Items[4]);
            list.Add(bnBottom.Items[5]);

            bnBottom.Items.Clear();
            foreach (ToolStripItem item in list)
                bnBottom.Items.Add(item);

            dgv1.DataSource = _dtOld;
            dgv2.DataSource = _dtNew;

            dgv1.Rows[_Row].DefaultCellStyle.BackColor = Color.Plum;
            dgv1.Rows[_Row].Selected = true;
            dgv2.Rows[_Row].DefaultCellStyle.BackColor = Color.Plum;
            dgv2.Rows[_Row].Selected = true;

            Text = "物料清单修改对照-产品编码：" + _Number + "[高亮显示的是被修改的子项物料]";
        }

        private void bnBottom_btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            MessageBox.Show("急啥急，开发中呢....");
            Close();
        }

        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            MessageBox.Show("你真的要走了吗？");
            Close();
        }
    }
}
