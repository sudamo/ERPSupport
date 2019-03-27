using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ERPSupport.SQL.K3Cloud;
using ERPSupport.Model.Globa;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 快递公司
    /// </summary>
    public partial class ucExpressCompany : UserControl
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
        public ucExpressCompany()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucExpressCompany_Load(object sender, EventArgs e)
        {
            _FID = 0;
            dgv1.DataSource = CommonFunction.NumberMatch("COMPANYNAME");
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
                txtMatchBillno.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                txtNumber.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
                txtECPY.Text = dgv1.CurrentRow.Cells[3].Value.ToString();

                _FID = int.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
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
            if (e.KeyChar != '\b' && txtMatchBillno.Text.Trim().Length - txtMatchBillno.SelectedText.Length >= 8)//控制文本输入长度
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
            if (e.KeyChar != '\b' && txtNumber.Text.Trim().Length - txtNumber.SelectedText.Length >= 2)//控制文本输入长度
                e.Handled = true;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            try
            {
                if (CommonFunction.NumberMatchExists("COMPANYNAME", txtMatchBillno.Text.Trim(), int.Parse(txtNumber.Text), txtECPY.Text.Trim()))
                {
                    MessageBox.Show("不能重复设定匹配规则或公司名称。");
                    return;
                }

                CommonFunction.AddNumberMatch(txtMatchBillno.Text.Trim(), int.Parse(txtNumber.Text), "COMPANYNAME", txtMatchBillno.Text.Trim(), txtECPY.Text.Trim(), "快递公司名称与编码前缀匹配", "0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失败" + ex.Message);
                //操作日志
                CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "快递公司配置", "配置\\快递公司配置", "新增失败：" + ex.Message, "0");
                return;
            }
            //操作日志
            CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "快递公司配置", "配置\\快递公司配置", "新增：" + txtMatchBillno.Text + "|" + txtNumber.Text + "|" + txtECPY.Text, "1");
            MessageBox.Show("新增成功");
            dgv1.DataSource = CommonFunction.NumberMatch("COMPANYNAME");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            try
            {
                if (CommonFunction.NumberMatchExists("COMPANYNAME", _FID, txtMatchBillno.Text.Trim(), int.Parse(txtNumber.Text), txtECPY.Text.Trim()))
                {
                    MessageBox.Show("匹配规则或公司名称已经存在。");
                    return;
                }
                CommonFunction.UpdateNumberMatch(_FID, txtMatchBillno.Text.Trim(), int.Parse(txtNumber.Text), txtECPY.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败" + ex.Message);
                //操作日志
                CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "快递公司配置", "配置\\快递公司配置", "修改失败：" + ex.Message, "0");
                return;
            }
            //操作日志
            CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "快递公司配置", "配置\\快递公司配置", "修改：" + txtMatchBillno.Text + "|" + txtNumber.Text + "|" + txtECPY.Text, "1");
            MessageBox.Show("修改成功");
            dgv1.DataSource = CommonFunction.NumberMatch("COMPANYNAME");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CommonFunction.DelNumberMatch(_FID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败" + ex.Message);
                //操作日志
                CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "快递公司配置", "配置\\快递公司配置", "删除失败：" + ex.Message, "0");
                return;
            }
            //操作日志
            CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "快递公司配置", "配置\\快递公司配置", "删除：" + txtMatchBillno.Text + "|" + txtNumber.Text + "|" + txtECPY.Text, "1");
            MessageBox.Show("删除成功");
            dgv1.DataSource = CommonFunction.NumberMatch("COMPANYNAME");
        }

        /// <summary>
        /// 数据检查
        /// </summary>
        /// <returns></returns>
        private bool CheckData()
        {
            if (txtMatchBillno.Text.Trim() == "")
            {
                MessageBox.Show("匹配运单号不能为空！");
                txtMatchBillno.Focus();
                return false;
            }
            if (txtNumber.Text.Trim() == "")
            {
                MessageBox.Show("运单号位数不能为空！");
                txtNumber.Focus();
                return false;
            }
            if (txtECPY.Text.Trim() == "")
            {
                MessageBox.Show("快递公司不能为空！");
                txtECPY.Focus();
                return false;
            }
            return true;
        }
    }
}