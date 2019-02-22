using System;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using System.Text.RegularExpressions;
using ERPSupport.Model.Globa;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 销售出库携带辅料出库规则
    /// </summary>
    public partial class ucUTMTLNumber : UserControl
    {
        #region Fields Properties Variable & Constructor
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex reg;
        /// <summary>
        /// 内码
        /// </summary>
        private int iFID;
        /// <summary>
        /// 匹配状态
        /// </summary>
        private string strIsMatch;
        /// <summary>
        /// 描述
        /// </summary>
        private string strDescription;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucUTMTLNumber()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucUTMTLNumber_Load(object sender, EventArgs e)
        {
            rbtMatch.Checked = true;
            dgv1.DataSource = CommonFunction.NumberMatch("UTMTL");
            dgv1.Columns[0].Visible = false;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMatchBillno.Text.Trim() == "")
            {
                MessageBox.Show("物料编码前缀不能为空！");
                txtMatchBillno.Focus();
                return;
            }
            try
            {
                if (CommonFunction.NumberMatchExists("UTMTL", txtMatchBillno.Text.Trim()))
                {
                    MessageBox.Show("不能重复设定物料编码。");
                    return;
                }
                strIsMatch = rbtMatch.Checked ? "1" : "0";
                strDescription = rbtMatch.Checked ? "携带出库物料" : "不需携带出库物料";
                CommonFunction.AddNumberMatch(txtMatchBillno.Text.Trim(), 0, "UTMTL", txtMatchBillno.Text.Trim(), "物料编码前缀", strDescription, strIsMatch);
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失败" + ex.Message);
                //操作日志
                CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "新增失败" + ex.Message, "0");
                return;
            }
            //操作日志
            string strMatch = rbtMatch.Checked ? "携带" : "排除";
            CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "新增:" + txtMatchBillno.Text + "|" + strMatch, "1");

            MessageBox.Show("新增成功");
            dgv1.DataSource = CommonFunction.NumberMatch("UTMTL");
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtMatchBillno.Text.Trim() == "")
            {
                MessageBox.Show("物料编码前缀不能为空！");
                txtMatchBillno.Focus();
                return;
            }
            try
            {
                if (CommonFunction.NumberMatchExists("UTMTL", iFID, txtMatchBillno.Text.Trim()))
                {
                    MessageBox.Show("物料编码前缀已经存在。");
                    return;
                }
                strIsMatch = rbtMatch.Checked ? "1" : "0";
                strDescription = rbtMatch.Checked ? "携带出库物料" : "不需携带出库物料";
                CommonFunction.UpdateNumberMatch(iFID, txtMatchBillno.Text.Trim(), strDescription, strIsMatch);
            }
            catch (Exception ex)
            {
                //操作日志
                CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "修改失败" + ex.Message, "0");
                MessageBox.Show("修改失败" + ex.Message);
                return;
            }
            //操作日志
            string strMatch = rbtMatch.Checked ? "携带" : "排除";
            CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "修改:" + txtMatchBillno.Text + "|" + strMatch, "1");
            MessageBox.Show("修改成功");
            dgv1.DataSource = CommonFunction.NumberMatch("UTMTL");
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
                CommonFunction.DelNumberMatch(iFID);
            }
            catch (Exception ex)
            {
                //操作日志
                CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "删除失败" + ex.Message, "0");
                MessageBox.Show("删除失败" + ex.Message);
                return;
            }
            //操作日志
            string strMatch = rbtMatch.Checked ? "携带" : "排除";
            CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "出库物料配置", "配置\\出库物料匹配", "删除:" + txtMatchBillno.Text + "|" + strMatch, "1");
            MessageBox.Show("删除成功");
            dgv1.DataSource = CommonFunction.NumberMatch("UTMTL");
        }

        /// <summary>
        /// txtMatchBillno_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMatchBillno_KeyPress(object sender, KeyPressEventArgs e)
        {
            reg = new Regex(@"^[1-9]\d*|0$");
            if (e.KeyChar != '\b')
            {
                if (!reg.IsMatch(e.KeyChar.ToString()))
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
                txtMatchBillno.Text = dgv1.CurrentRow.Cells[1].Value.ToString();

                iFID = int.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                rbtMatch.Checked = dgv1.CurrentRow.Cells[2].Value.ToString() == "携带" ? true : false;
                rbtNotMatch.Checked = dgv1.CurrentRow.Cells[2].Value.ToString() == "排除" ? true : false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        ///// <summary>
        ///// rbtMatch_CheckedChanged
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void rbtMatch_CheckedChanged(object sender, EventArgs e)
        //{
        //    strIsMatch = rbtMatch.Checked ? "1" : "0";
        //    strDescription = rbtMatch.Checked ? "携带出库物料" : "不需携带出库物料";
        //}
    }
}