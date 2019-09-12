using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ERPSupport.SQL.K3Cloud;
using System.Collections.Generic;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 销售出库携带辅料出库规则
    /// </summary>
    public partial class ucCS_OutStockMaterial : UserControl
    {
        #region Fields Properties Variable & Constructor
        /// <summary>
        /// 内码
        /// </summary>
        private int _FID;
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex _reg;
        /// <summary>
        /// ToolStrip携带
        /// </summary>
        private ToolStripRadioButton _rbtMatch;
        /// <summary>
        /// ToolStrip排除
        /// </summary>
        private ToolStripRadioButton _rbtNotMatch;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCS_OutStockMaterial()
        {
            InitializeComponent();
        }

        private void ucCS_OutStockMaterial_Load(object sender, EventArgs e)
        {
            _FID = 0;
            //-----
            _rbtMatch = new ToolStripRadioButton();
            _rbtNotMatch = new ToolStripRadioButton();
            _rbtMatch.Checked = true;
            _rbtMatch.Text = "携带";
            _rbtMatch.Tag = 5;
            _rbtNotMatch.Checked = false;
            _rbtNotMatch.Text = "排除";
            _rbtNotMatch.Tag = 6;

            bnTop.Items.Add(_rbtMatch);
            bnTop.Items.Add(_rbtNotMatch);

            //重新排列Items
            List<ToolStripItem> list = new List<ToolStripItem>();
            list.Add(bnTop.Items[0]);
            list.Add(bnTop.Items[1]);
            list.Add(bnTop.Items[2]);
            list.Add(bnTop.Items[8]);
            list.Add(bnTop.Items[9]);
            list.Add(bnTop.Items[3]);
            list.Add(bnTop.Items[4]);
            list.Add(bnTop.Items[5]);
            list.Add(bnTop.Items[6]);
            list.Add(bnTop.Items[7]);

            bnTop.Items.Clear();
            foreach (ToolStripItem item in list)
            {
                bnTop.Items.Add(item);
            }

            SetDataSource();
        }
        #endregion


        /// <summary>
        /// 数据源
        /// </summary>
        private void SetDataSource()
        {
            dgv1.DataSource = CommFunction.NumberMatch("UTMTL");
            dgv1.Columns[0].Visible = false;
        }

        /// <summary>
        /// txtMatchBillno_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMatchBillno_KeyPress(object sender, KeyPressEventArgs e)
        {
            _reg = new Regex(@"^[1-9]\d*|0$");
            if (e.KeyChar != '\b')
            {
                if (!_reg.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// dgv1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count > 0)
            {
                bnTop_txtMatchBillNo.Text = dgv1.CurrentRow.Cells[1].Value.ToString();

                _FID = int.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                _rbtMatch.Checked = dgv1.CurrentRow.Cells[2].Value.ToString() == "携带" ? true : false;
                //((RadioButton)_rbtMatch.Control).Checked = _rbtMatch.Checked;
                _rbtNotMatch.Checked = dgv1.CurrentRow.Cells[2].Value.ToString() == "排除" ? true : false;
                //((RadioButton)_rbtNotMatch.Control).Checked = _rbtNotMatch.Checked;
                bnTop_btnEdit.Enabled = true;
                bnTop_btnDelete.Enabled = true;
            }
        }
        private void bnTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Edit();
                    break;
                case "3":
                    Delete();
                    break;
                case "4":
                    RefreshDate();
                    break;
                //case "5":
                //    _rbtMatch.Checked = true;
                //    _rbtNotMatch.Checked = false;
                //    break;
                //case "6":
                //    _rbtMatch.Checked = false;
                //    _rbtNotMatch.Checked = true;
                //    break;
            }
        }

        private void Add()
        {
            //if (bnTop_txtMatchBillNo.Text.Trim() == "")
            //{
            //    MessageBox.Show("物料编码前缀不能为空！");
            //    //bnTop_txtMatchBillNo.Focus();
            //    return;
            //}
            //try
            //{
            //    if (CommFunction.NumberMatchExists("UTMTL", bnTop_txtMatchBillNo.Text.Trim()))
            //    {
            //        MessageBox.Show("不能重复设定物料编码。");
            //        return;
            //    }
            //    _IsMatch = _rbtMatch.Checked ? "1" : "0";
            //    _Description = _rbtMatch.Checked ? "携带出库物料" : "不需携带出库物料";
            //    CommFunction.AddNumberMatch(bnTop_txtMatchBillNo.Text.Trim(), 0, "UTMTL", bnTop_txtMatchBillNo.Text.Trim(), "物料编码前缀", _Description, _IsMatch);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("新增失败" + ex.Message);
            //    //操作日志
            //    //CommFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "新增失败" + ex.Message, "0");
            //    return;
            //}
            ////操作日志
            //string strMatch = _rbtMatch.Checked ? "携带" : "排除";
            ////CommFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "新增:" + txtMatchBillno.Text + "|" + strMatch, "1");

            //MessageBox.Show("新增成功");
            //SetDataSource();
        }
        private void Edit()
        {
            //if (bnTop_txtMatchBillNo.Text.Trim() == "")
            //{
            //    MessageBox.Show("物料编码前缀不能为空！");
            //    return;
            //}
            //try
            //{
            //    if (CommFunction.NumberMatchExists("UTMTL", _FID, bnTop_txtMatchBillNo.Text.Trim()))
            //    {
            //        MessageBox.Show("物料编码前缀已经存在。");
            //        return;
            //    }
            //    _IsMatch = _rbtMatch.Checked ? "1" : "0";
            //    _Description = _rbtMatch.Checked ? "携带出库物料" : "不需携带出库物料";
            //    CommFunction.UpdateNumberMatch(_FID, bnTop_txtMatchBillNo.Text.Trim(), _Description, _IsMatch);
            //}
            //catch (Exception ex)
            //{
            //    //操作日志
            //    //CommFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "修改失败" + ex.Message, "0");
            //    MessageBox.Show("修改失败" + ex.Message);
            //    return;
            //}
            ////操作日志
            //string strMatch = _rbtMatch.Checked ? "携带" : "排除";
            ////CommFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "修改:" + txtMatchBillno.Text + "|" + strMatch, "1");
            //MessageBox.Show("修改成功");
            //SetDataSource();
        }
        private void Delete()
        {
            //try
            //{
            //    CommFunction.DelNumberMatch(_FID);
            //}
            //catch (Exception ex)
            //{
            //    //操作日志
            //    //CommFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "删除失败" + ex.Message, "0");
            //    MessageBox.Show("删除失败" + ex.Message);
            //    return;
            //}
            ////操作日志
            //string strMatch = _rbtMatch.Checked ? "携带" : "排除";
            ////CommFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "删除:" + txtMatchBillno.Text + "|" + strMatch, "1");
            //MessageBox.Show("删除成功");
            //SetDataSource();
        }
        private void RefreshDate()
        {
            SetDataSource();
        }
    }
}