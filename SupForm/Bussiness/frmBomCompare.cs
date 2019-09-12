
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        /// 需求日期
        /// </summary>
        private DateTime _tNeedDate;
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
        /// /// <param name="pdtNew">需求日期</param>
        public frmBomCompare(DataTable pdtOld, DataTable pdtNew, DateTime pNeedDate)
        {
            InitializeComponent();
            _dtOld = pdtOld;
            _dtNew = pdtNew;
            _tNeedDate = pNeedDate;
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
        }

        private void bnBottom_btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            MessageBox.Show("修改成功。");
            Close();
        }

        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
