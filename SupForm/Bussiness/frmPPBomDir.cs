using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ERPSupport.SupForm.Bussiness
{
    using UserCrtl;

    /// <summary>
    /// 修改生产用料清单生成调拨单状态
    /// </summary>
    public partial class frmPPBomDir : Form
    {
        /// <summary>
        /// ToolStrip生成
        /// </summary>
        private ToolStripRadioButton _rbtDir;
        /// <summary>
        /// ToolStrip未生成
        /// </summary>
        private ToolStripRadioButton _rbtNotDir;

        public frmPPBomDir()
        {
            InitializeComponent();
        }

        private void frmPPBomDir_Load(object sender, EventArgs e)
        {
            //-----
            _rbtDir = new ToolStripRadioButton();
            _rbtDir.Text = "已生成";
            _rbtNotDir = new ToolStripRadioButton();
            _rbtNotDir.Text = "未生成";
            _rbtNotDir.Checked = true;

            //重新排列Items
            List<ToolStripItem> list = new List<ToolStripItem>();
            list.Add(_rbtDir);
            list.Add(_rbtNotDir);
            list.Add(bnBottom.Items[0]);
            list.Add(bnBottom.Items[1]);
            list.Add(bnBottom.Items[2]);

            bnBottom.Items.Clear();
            foreach (ToolStripItem item in list)
                bnBottom.Items.Add(item);
        }

        private void bnBottom_btnEidt_Click(object sender, EventArgs e)
        {
            string strBillNos = txtBillNos.Text.Trim();
            if (strBillNos.Equals(string.Empty))
                return;

            if (strBillNos.ToUpper().IndexOf("MO") < 0)
            {
                MessageBox.Show("生产订单号输入有误。");
                return;
            }

            strBillNos = strBillNos.Replace('，', ',');

            if (strBillNos.Substring(strBillNos.Length - 1, 1) == ",")
                strBillNos = strBillNos.Substring(0, strBillNos.Length - 1);

            strBillNos = "'" + strBillNos.Replace(",", "','").Replace(Convert.ToChar(10).ToString(), "").Replace(Convert.ToChar(13).ToString(), "").ToUpper() + "'";

            DALFactory.K3Cloud.DALCreator.PrdAllocation.UpdatePPBom(strBillNos, _rbtDir.Checked);

            MessageBox.Show("修改成功。");
            Close();
        }

        private void bnBottom_btnCancle_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
