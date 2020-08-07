using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    using Model.Globa;
    using DALFactory.K3Cloud;

    /// <summary>
    /// 单据修改
    /// </summary>
    public partial class ucCS_BillEdit : UserControl
    {
        /// <summary>
        /// ToolStrip日期从
        /// </summary>
        private ToolStripDateTimePicker _dateFrom;
        /// <summary>
        /// ToolStrip日期到
        /// </summary>
        private ToolStripDateTimePicker _dateTo;
        /// <summary>
        /// ToolStrip整单发货标识
        /// </summary>
        private ToolStripCheckBox _chbSingle;
        /// <summary>
        /// ToolStrip销售出库单
        /// </summary>
        private ToolStripCheckBox _chbSo;
        /// <summary>
        /// ToolStrip应收单
        /// </summary>
        private ToolStripCheckBox _chbAr;
        /// <summary>
        /// ToolStrip销售退货通知单
        /// </summary>
        private ToolStripCheckBox _chbSn;
        /// <summary>
        /// ToolStrip销售退货单
        /// </summary>
        private ToolStripCheckBox _chbSr;
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex _reg;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCS_BillEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCS_BillEdit_Load(object sender, EventArgs e)
        {
            //-----bnTop
            _dateFrom = new ToolStripDateTimePicker();
            _dateFrom.Size = new Size(120, 21);
            _dateFrom.Value = DateTime.Now.AddDays(-3);
            _dateFrom.Visible = false;
            _dateTo = new ToolStripDateTimePicker();
            _dateTo.Size = new Size(120, 21);
            _dateTo.Value = DateTime.Now;
            _dateTo.Visible = false;
            //重新排列Items
            List<ToolStripItem> list = new List<ToolStripItem>();
            list.Add(bnTop.Items[0]);
            list.Add(bnTop.Items[1]);
            list.Add(bnTop.Items[2]);
            list.Add(bnTop.Items[3]);
            list.Add(bnTop.Items[4]);
            list.Add(_dateFrom);
            list.Add(bnTop.Items[5]);
            list.Add(_dateTo);
            list.Add(bnTop.Items[6]);
            list.Add(bnTop.Items[7]);
            list.Add(bnTop.Items[8]);
            list.Add(bnTop.Items[9]);
            list.Add(bnTop.Items[10]);
            list.Add(bnTop.Items[11]);
            list.Add(bnTop.Items[12]);
            //list.Add(bnTop.Items[13]);

            bnTop.Items.Clear();
            foreach (ToolStripItem item in list)
                bnTop.Items.Add(item);

            //-----bnR1
            _chbSingle = new ToolStripCheckBox();
            _chbSingle.Text = "整单发货";
            //重新排列Items
            list = new List<ToolStripItem>();
            list.Add(_chbSingle);
            list.Add(bnR1.Items[0]);
            list.Add(bnR1.Items[1]);
            bnR1.Items.Clear();
            foreach (ToolStripItem item in list)
                bnR1.Items.Add(item);
            //-----bnR3
            _chbSo = new ToolStripCheckBox();
            _chbSo.Text = "销售出库单";
            _chbSo.ToolTipText = "同时修改关联的销售出库单";
            ((CheckBox)_chbSo.Control).CheckedChanged += new EventHandler(OutStockCheckedChanged);
            _chbAr = new ToolStripCheckBox();
            _chbAr.Text = "应收单";
            _chbAr.ToolTipText = "同时修改关联的应收单";
            ((CheckBox)_chbAr.Control).CheckedChanged += new EventHandler(ArCheckedChanged);
            _chbSn = new ToolStripCheckBox();
            _chbSn.Text = "退货通知单";
            _chbSn.ToolTipText = "同时修改关联的退货通知单";
            _chbSr = new ToolStripCheckBox();
            _chbSr.Text = "销售退货单";
            _chbSr.ToolTipText = "同时修改关联的销售退货单";
            //重新排列Items
            list = new List<ToolStripItem>();
            list.Add(bnR3.Items[0]);
            list.Add(bnR3.Items[1]);
            list.Add(bnR3.Items[2]);
            list.Add(_chbSo);
            list.Add(_chbAr);
            list.Add(_chbSn);
            list.Add(_chbSr);
            list.Add(bnR3.Items[3]);
            list.Add(bnR3.Items[4]);
            bnR3.Items.Clear();
            foreach (ToolStripItem item in list)
                bnR3.Items.Add(item);

            tpl1.Visible = false;
            tpl1.Enabled = false;

            FillCombobox();
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillCombobox()
        {
            DataTable dt;
            DataRow dr;

            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            dr = dt.NewRow();
            dr["FName"] = "请选择";
            dr["FValue"] = "-1";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "销售订单";
            dr["FValue"] = "SAL_SaleOrder";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "生产订单";
            dr["FValue"] = "PRD_MO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "投料单";
            dr["FValue"] = "PRD_PPBOM";
            dt.Rows.Add(dr);

            bnTop_cbxType.ComboBox.DataSource = dt;
            bnTop_cbxType.ComboBox.DisplayMember = "FName";
            bnTop_cbxType.ComboBox.ValueMember = "FValue";
        }

        private void bnTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    SetDataSource();
                    break;
                case "2":
                    Synchro();
                    break;
                case "3":
                    Bussiness.frmPPBomDir frmDir = new Bussiness.frmPPBomDir();
                    frmDir.Show(this);
                    break;
                case "4":
                    Bussiness.frmPPBom frm = new Bussiness.frmPPBom();
                    frm.ShowDialog();
                    break;
                case "5":
                    MessageBox.Show("BOM批改功能还未开发，请联系信息部。");
                    break;
                case "6":
                    Bussiness.frmU1CityOrderEdit frmU = new Bussiness.frmU1CityOrderEdit();
                    frmU.Show(this);
                    break;
            }
        }

        /// <summary>
        /// 设置数据源
        /// </summary>
        private void SetDataSource()
        {
            if (bnTop_txtBillNo.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入单据编号。");
                return;
            }

            DataTable dtTemp = DALCreator.SalOrder.GetBillInfo(bnTop_cbxType.ComboBox.SelectedValue.ToString(), bnTop_txtBillNo.Text);
            if (dtTemp == null || dtTemp.Rows.Count == 0)
            {
                MessageBox.Show("没有查询到数据。");
                if (dgv1.DataSource == null)
                {
                    tpl1.Enabled = false;
                }
                bnTop_txtBillNo.Text = "";
                return;
            }
            else
            {
                tpl1.Enabled = true;
                dgv1.DataSource = dtTemp;
                dgv1.Columns[12].Visible = false;
                dgv1.Columns[13].Visible = false;
                dgv1.Columns[14].Visible = false;

                bnR2_txtMTLNumber.Text = "";
                bnR2_txtCanOutQty.Text = "";
            }
        }
        private void Synchro()
        {
            if (MessageBox.Show("此时间段：" + _dateFrom.Value.ToString("yyyy-MM-dd") + "至" + _dateTo.Value.ToString("yyyy-MM-dd") + "\n 共有" + DALCreator.PrdAllocation.Asyn_PPBom_FNeedDate(_dateFrom.Value, _dateTo.Value).ToString() + "不同步，确定同步吗？", "同步确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DALCreator.PrdAllocation.Syn_PPBom_FNeedDate(_dateFrom.Value, _dateTo.Value);
                //操作日志
                DALCreator.CommFunction.DM_Log_Local("同步需求日期", "配置\\单据信息调整", "时间段：" + _dateFrom.Value.ToString("yyyy-MM-dd") + "至" + _dateTo.Value.ToString("yyyy-MM-dd"));
            }
        }

        private void bnR1_btnEidt_Click(object sender, EventArgs e)
        {
            string strBillNo = dgv1.Rows[0].Cells[0].Value.ToString();
            bool bSingle = _chbSingle.Checked;

            if (strBillNo.Equals(string.Empty))
            {
                MessageBox.Show("请输入销售订单编号。");
                return;
            }

            MessageBox.Show(DALCreator.SalOrder.UpdateSingle(strBillNo, bSingle));
            SetDataSource();
        }
        private void bnR2_btnEdit_Click(object sender, EventArgs e)
        {
            if (bnR2_txtMTLNumber.Text.Trim().Equals(string.Empty) || bnR2_txtCanOutQty.Text.Trim().Equals(string.Empty))
                return;

            if (MessageBox.Show("你确定要修改单据[" + bnTop_txtBillNo.Text + "]第[" + dgv1.CurrentRow.Cells[6].Value.ToString() + "]行分录，物料[" + dgv1.CurrentRow.Cells[8].Value.ToString() + "]的可出数量为[" + bnR2_txtCanOutQty.Text.ToString() + "]吗？", "修改可出数量", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string strFEntryId = dgv1.CurrentRow.Cells[13].Value.ToString();
                decimal deCanOutQty = decimal.Parse(bnR2_txtCanOutQty.Text.ToString());
                DALCreator.SalOrder.UpdateOrderCanOutQty(strFEntryId, deCanOutQty);

                MessageBox.Show("修改成功。");
                SetDataSource();
                return;
            }
        }
        private void bnR3_btnEdit_Click(object sender, EventArgs e)
        {
            if (bnR2_txtCustomer.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入客户。");
                return;
            }

            int iUseOrgId = int.Parse(dgv1.Rows[0].Cells[14].Value.ToString());
            int iCustomerId = DALCreator.CommFunction.GetCustomerId(bnR2_txtCustomer.Text.Trim(), iUseOrgId);

            if (iCustomerId == 0)
            {
                MessageBox.Show("单据的销售组织下不存在此客户。");
                return;
            }

            string strBillNo = dgv1.Rows[0].Cells[0].Value.ToString();
            int iFEntryId = int.Parse(dgv1.Rows[0].Cells[13].Value.ToString());
            DALCreator.SalOrder.UpdateCustomer(strBillNo, iFEntryId, iCustomerId, _chbSo.Checked, _chbAr.Checked, _chbSn.Checked, _chbSr.Checked);
            MessageBox.Show("修改成功。");
            SetDataSource();
        }

        /// <summary>
        /// cbxType_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bnTop_cbxType.SelectedIndex == 0)
            {
                tpl1.Visible = false;
                bnTop_lblBillNo.Visible = false;
                bnTop_txtBillNo.Visible = false;
                bnTop_Search.Visible = false;

                bnTop_Syn.Visible = false;
                bnTop_ChangeDB.Visible = false;
                _dateFrom.Visible = false;
                bnTop_lblDash.Visible = false;
                _dateTo.Visible = false;

                bnTop_PPBom.Visible = false;
                bnTop_Bom.Visible = false;
                //bnTop_Price.Visible = false;
            }
            if (bnTop_cbxType.ComboBox.SelectedValue.ToString() == "SAL_SaleOrder" && (GlobalParameter.K3Inf.DepartmentName.Contains("信息部") || GlobalParameter.K3Inf.DepartmentName == "客服部"))
            {
                if (dgv1 != null)
                    tpl1.Visible = true;
                else
                    tpl1.Visible = false;
                bnTop_lblBillNo.Visible = true;
                bnTop_txtBillNo.Visible = true;
                bnTop_Search.Visible = true;
                bnTop_Org.Visible = true;
                //bnTop_Price.Visible = true;

                bnTop_Syn.Visible = false;
                bnTop_ChangeDB.Visible = false;
                _dateFrom.Visible = false;
                bnTop_lblDash.Visible = false;
                _dateTo.Visible = false;

                bnTop_PPBom.Visible = false;
                bnTop_Bom.Visible = false;
            }
            else if (bnTop_cbxType.ComboBox.SelectedValue.ToString() == "PRD_MO")
            {
                tpl1.Visible = false;
                bnTop_lblBillNo.Visible = false;
                bnTop_txtBillNo.Visible = false;
                bnTop_Search.Visible = false;
                bnTop_Org.Visible = false;
                //bnTop_Price.Visible = false;

                bnTop_Syn.Visible = true;
                bnTop_ChangeDB.Visible = true;
                _dateFrom.Visible = true;
                bnTop_lblDash.Visible = true;
                _dateTo.Visible = true;

                bnTop_PPBom.Visible = false;
                bnTop_Bom.Visible = false;
            }
            else if (bnTop_cbxType.ComboBox.SelectedValue.ToString() == "PRD_PPBOM")
            {
                tpl1.Visible = false;
                bnTop_lblBillNo.Visible = false;
                bnTop_txtBillNo.Visible = false;
                bnTop_Search.Visible = false;
                bnTop_Org.Visible = false;
                //bnTop_Price.Visible = false;

                bnTop_Syn.Visible = false;
                bnTop_ChangeDB.Visible = false;
                _dateFrom.Visible = false;
                bnTop_lblDash.Visible = false;
                _dateTo.Visible = false;

                bnTop_PPBom.Visible = true;
                bnTop_Bom.Visible = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_Click(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count <= 0)
                return;

            _chbSingle.Checked = dgv1.CurrentRow.Cells[4].Value.ToString() == "是" ? true : false;

            bnR2_txtMTLNumber.Text = dgv1.CurrentRow.Cells[7].Value.ToString();
            bnR2_txtCanOutQty.Text = dgv1.CurrentRow.Cells[10].Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnR2_txtCanOutQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //_reg = new Regex(@"^([0-9]{1,}[.][0-9]*)$");//匹配小数的正则表达式
            //_reg = new Regex(@"^[1-9]\d{0,13}(\.\d{0,4})?$");//匹配小数的正则表达式,这个适应于decimal（18，4）
            _reg = new Regex(@"^[1-9]\d*|0$");//匹配整数的正则表达式

            if (e.KeyChar == '\b')//忽略退格键
                return;

            if (e.KeyChar != '.')//非小数点输入
            {
                if (!_reg.IsMatch(e.KeyChar.ToString()))//忽略非数字输入
                    e.Handled = true;
                else if (e.KeyChar == '0' && ((TextBox)sender).Text.IndexOf(".") < 0 && ((TextBox)sender).Text.IndexOf("0") == 0)//最左边不能连续输入零
                    e.Handled = true;
            }
            else if (((TextBox)sender).Text.IndexOf(".") >= 0 || ((TextBox)sender).Text.Length == 0)//已经有小数点或第一位数不能输入小数点
                e.Handled = true;
        }

        private void OutStockCheckedChanged(object sender, EventArgs e)
        {
            if (!_chbSo.Checked)
                _chbAr.Checked = false;
        }
        private void ArCheckedChanged(object sender, EventArgs e)
        {
            if (_chbAr.Checked)
                _chbSo.Checked = true;
        }
    }
}

