using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ERPSupport.SupForm.UserCrtl
{
    using DALFactory.K3Cloud;

    /// <summary>
    /// 快递公司
    /// </summary>
    public partial class ucCS_ExpCompany : UserControl
    {
        /// <summary>
        /// 内码
        /// </summary>
        private int _FID;
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex _reg;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCS_ExpCompany()
        {
            InitializeComponent();
        }

        private void ucCS_ExpCompany_Load(object sender, EventArgs e)
        {
            _FID = 0;
            SetDataSource();
        }
        private void SetDataSource()
        {
            dgv1.DataSource = DALCreator.CommFunction.NumberMatch("COMPANYNAME");
            dgv1.Columns[0].Visible = false;
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
                bnTop_txtMatchBillno.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                bnTop_txtNumber.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
                bnTop_txtECPY.Text = dgv1.CurrentRow.Cells[3].Value.ToString();

                _FID = int.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                bnTop_btnEdit.Enabled = true;
                bnTop_btnDelete.Enabled = true;
            }
        }

        /// <summary>
        /// txtBillno_KeyPress
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
            if (e.KeyChar != '\b' && bnTop_txtMatchBillno.Text.Trim().Length - bnTop_txtMatchBillno.SelectedText.Length >= 8)//控制文本输入长度
                e.Handled = true;
        }

        /// <summary>
        /// txtNumber_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            _reg = new Regex(@"^[1-9]\d*|0$");
            if (e.KeyChar != '\b')
            {
                if (!_reg.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar != '\b' && bnTop_txtNumber.Text.Trim().Length - bnTop_txtNumber.SelectedText.Length >= 2)//控制文本输入长度
                e.Handled = true;
        }

        ///// <summary>
        ///// 新增
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (!CheckData()) return;
        //    try
        //    {
        //        if (CommFunction.NumberMatchExists("COMPANYNAME", txtMatchBillno.Text.Trim(), int.Parse(txtNumber.Text), txtECPY.Text.Trim()))
        //        {
        //            MessageBox.Show("不能重复设定匹配规则或公司名称。");
        //            return;
        //        }

        //        CommFunction.AddNumberMatch(txtMatchBillno.Text.Trim(), int.Parse(txtNumber.Text), "COMPANYNAME", txtMatchBillno.Text.Trim(), txtECPY.Text.Trim(), "快递公司名称与编码前缀匹配", "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("新增失败" + ex.Message);
        //        //操作日志
        //        CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "新增失败：" + ex.Message, "0");
        //        return;
        //    }
        //    //操作日志
        //    CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "新增：" + txtMatchBillno.Text + "|" + txtNumber.Text + "|" + txtECPY.Text, "1");
        //    MessageBox.Show("新增成功");
        //    dgv1.DataSource = CommFunction.NumberMatch("COMPANYNAME");
        //}
        ///// <summary>
        ///// 修改
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    if (!CheckData()) return;
        //    try
        //    {
        //        if (CommFunction.NumberMatchExists("COMPANYNAME", _FID, txtMatchBillno.Text.Trim(), int.Parse(txtNumber.Text), txtECPY.Text.Trim()))
        //        {
        //            MessageBox.Show("匹配规则或公司名称已经存在。");
        //            return;
        //        }
        //        CommFunction.UpdateNumberMatch(_FID, txtMatchBillno.Text.Trim(), int.Parse(txtNumber.Text), txtECPY.Text.Trim());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("修改失败" + ex.Message);
        //        //操作日志
        //        CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "修改失败：" + ex.Message, "0");
        //        return;
        //    }
        //    //操作日志
        //    CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "修改：" + txtMatchBillno.Text + "|" + txtNumber.Text + "|" + txtECPY.Text, "1");
        //    MessageBox.Show("修改成功");
        //    dgv1.DataSource = CommFunction.NumberMatch("COMPANYNAME");
        //}
        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CommFunction.DelNumberMatch(_FID);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("删除失败" + ex.Message);
        //        //操作日志
        //        CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "删除失败：" + ex.Message, "0");
        //        return;
        //    }
        //    //操作日志
        //    CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "删除：" + txtMatchBillno.Text + "|" + txtNumber.Text + "|" + txtECPY.Text, "1");
        //    MessageBox.Show("删除成功");
        //    dgv1.DataSource = CommFunction.NumberMatch("COMPANYNAME");
        //}

        /// <summary>
        /// 数据检查
        /// </summary>
        /// <returns></returns>
        private bool CheckData()
        {
            if (bnTop_txtMatchBillno.Text.Trim() == "")
            {
                MessageBox.Show("匹配运单号不能为空！");
                return false;
            }
            if (bnTop_txtNumber.Text.Trim() == "")
            {
                MessageBox.Show("运单号位数不能为空！");
                //txtNumber.Focus();
                return false;
            }
            if (bnTop_txtECPY.Text.Trim() == "")
            {
                MessageBox.Show("快递公司不能为空！");
                //txtECPY.Focus();
                return false;
            }
            return true;
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
            }
        }

        private void Add()
        {
            if (!CheckData()) return;
            try
            {
                if (DALCreator.CommFunction.NumberMatchExists("COMPANYNAME", bnTop_txtMatchBillno.Text.Trim(), int.Parse(bnTop_txtNumber.Text), bnTop_txtECPY.Text.Trim()))
                {
                    MessageBox.Show("不能重复设定匹配规则或公司名称。");
                    return;
                }

                DALCreator.CommFunction.AddNumberMatch(bnTop_txtMatchBillno.Text.Trim(), int.Parse(bnTop_txtNumber.Text), "COMPANYNAME", bnTop_txtMatchBillno.Text.Trim(), bnTop_txtECPY.Text.Trim(), "快递公司名称与编码前缀匹配", "0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失败" + ex.Message);
                //操作日志
                DALCreator.CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "新增失败：" + ex.Message, "0");
                return;
            }
            //操作日志
            DALCreator.CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "新增：" + bnTop_txtMatchBillno.Text + "|" + bnTop_txtNumber.Text + "|" + bnTop_txtECPY.Text);
            MessageBox.Show("新增成功");
            dgv1.DataSource = DALCreator.CommFunction.NumberMatch("COMPANYNAME");
        }
        private void Edit()
        {
            if (!CheckData()) return;
            try
            {
                if (DALCreator.CommFunction.NumberMatchExists("COMPANYNAME", _FID, bnTop_txtMatchBillno.Text.Trim(), int.Parse(bnTop_txtNumber.Text), bnTop_txtECPY.Text.Trim()))
                {
                    MessageBox.Show("匹配规则或公司名称已经存在。");
                    return;
                }
                DALCreator.CommFunction.UpdateNumberMatch(_FID, bnTop_txtMatchBillno.Text.Trim(), int.Parse(bnTop_txtNumber.Text), bnTop_txtECPY.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败" + ex.Message);
                //操作日志
                DALCreator.CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "修改失败：" + ex.Message, "0");
                return;
            }
            //操作日志
            DALCreator.CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "修改：" + bnTop_txtMatchBillno.Text + "|" + bnTop_txtNumber.Text + "|" + bnTop_txtECPY.Text, "1");
            MessageBox.Show("修改成功");
            dgv1.DataSource = DALCreator.CommFunction.NumberMatch("COMPANYNAME");
        }
        private void Delete()
        {
            try
            {
                DALCreator.CommFunction.DelNumberMatch(_FID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败" + ex.Message);
                //操作日志
                DALCreator.CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "删除失败：" + ex.Message, "0");
                return;
            }
            //操作日志
            DALCreator.CommFunction.DM_Log_Local("快递公司配置", "配置\\快递公司配置", "删除：" + bnTop_txtMatchBillno.Text + "|" + bnTop_txtNumber.Text + "|" + bnTop_txtECPY.Text);
            MessageBox.Show("删除成功");
            dgv1.DataSource = DALCreator.CommFunction.NumberMatch("COMPANYNAME");
        }
        private void RefreshDate()
        {
            SetDataSource();
        }
    }
}
