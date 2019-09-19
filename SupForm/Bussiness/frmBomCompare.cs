using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ERPSupport.SupForm.Bussiness
{
    using UserCrtl;

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
        /// 产品编码
        /// </summary>
        private string _Number;
        /// <summary>
        /// 修改行号
        /// </summary>
        private int _Row;
        /// <summary>
        /// 是否只修改数量
        /// </summary>
        private bool _Type;
        /// <summary>
        /// 生产用量清单内码
        /// </summary>
        private int _FentryId;
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
        /// <param name="pNeedDate">需求日期</param>
        /// <param name="pNumber">产品编码</param>
        /// <param name="pRow">修改行序号</param>
        /// <param name="pType">是否只修改数量</param>
        /// <param name="pFEntryId">生产用量清单内码</param>
        public frmBomCompare(DataTable pdtOld, DataTable pdtNew, DateTime pNeedDate, string pNumber, int pRow, bool pType, int pFEntryId)
        {
            InitializeComponent();
            _dtOld = pdtOld;
            _dtNew = pdtNew;
            _tNeedDate = pNeedDate;
            _Number = pNumber;
            _Row = pRow;
            _Type = pType;
            _FentryId = pFEntryId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBomCompare_Load(object sender, EventArgs e)
        {
            _tsNeedDate = new ToolStripDateTimePicker();
            _tsNeedDate.Size = new Size(120, 21);
            _tsNeedDate.Value = _tNeedDate;
            _tsNeedDate.Enabled = false;

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
            //dgv1.Rows[_Row].Selected = true;
            dgv2.Rows[_Row].DefaultCellStyle.BackColor = Color.Plum;
            //dgv2.Rows[_Row].Selected = true;

            if (_Type)
                Text = "物料清单修改对照-产品编码：" + _Number + "[修改子项物料用量]";
            else
                Text = "物料清单修改对照-产品编码：" + _Number + "[替换子项物料]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnOK_Click(object sender, EventArgs e)
        {
            string strMTLNumber = dgv1.Rows[_Row].Cells[1].Value.ToString();
            decimal dFZ = decimal.Parse(dgv1.Rows[_Row].Cells[3].Value.ToString());
            decimal dMustQty = decimal.Parse(dgv1.Rows[_Row].Cells[5].Value.ToString());

            string strNewMTLNumber = dgv2.Rows[_Row].Cells[1].Value.ToString();
            decimal dNewFZ = decimal.Parse(dgv2.Rows[_Row].Cells[3].Value.ToString());
            decimal dNewMustQty = decimal.Parse(dgv2.Rows[_Row].Cells[5].Value.ToString());

            DateTime tNeedDate = _tsNeedDate.Value;
            bool bSyn = _chbSyn.Checked;

            SQL.K3Cloud.PrdAllocation.UpdatePPBom(bSyn, _Type, _FentryId, strMTLNumber, strNewMTLNumber, dNewFZ, dNewMustQty, tNeedDate);

            //日志
            string strConTent = _Type ? "修改生产用料清单子项物料用量,子项物料:[" + strMTLNumber + "],应发数量:[" + dMustQty + "->" + dNewMustQty + "],分子:[" + dFZ + "->" + dNewFZ + "]." : "替换生产用料清单子项物料,子项物料:[" + strMTLNumber + "->" + strNewMTLNumber + "],应发数量:[" + dMustQty + "->" + dNewMustQty + "],分子:[" + dFZ + "->" + dNewFZ + "].";
            if (bSyn)
                strConTent += " 并同步需求日期：" + tNeedDate.ToString("yyyy-MM-dd") + "的数据.";
            SQL.K3Cloud.CommFunction.DM_Log_Local("生产用料清单修改", "配置//单据信息调整", strConTent, "1");

            DialogResult = DialogResult.OK;
            MessageBox.Show("数据已经更新。");
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}