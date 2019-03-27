using System;
using System.Data;
using ERPSupport.SQL.K3Cloud;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ERPSupport.Model.Globa;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 锁库仓库
    /// </summary>
    public partial class ucLockStock : UserControl
    {
        /// <summary>
        /// 内码
        /// </summary>
        private int _FID;
        /// <summary>
        /// 类型
        /// </summary>
        private string _Type;
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex _reg;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pType">类型</param>
        public ucLockStock(string pType)
        {
            InitializeComponent();
            _Type = pType;

            _FID = 0;
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucLockStock_Load(object sender, EventArgs e)
        {
            FillComboBox();
            SetDataSource();
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            cbxUseOrg.DataSource = CommonFunction.GetOrganization("LOCKSTOCK");
            cbxUseOrg.DisplayMember = "FName";
            cbxUseOrg.ValueMember = "FValue";
            cbxUseOrg.SelectedIndex = 0;

            FillStock();
        }

        /// <summary>
        /// 填充仓库下拉框
        /// </summary>
        private void FillStock()
        {
            if (cbxUseOrg.SelectedIndex == 0)
                cbxStock.DataSource = CommonFunction.GetStock(1, 0);
            else
                cbxStock.DataSource = CommonFunction.GetStock(2, int.Parse(cbxUseOrg.SelectedValue.ToString()));

            cbxStock.DisplayMember = "FName";
            cbxStock.ValueMember = "FValue";
        }

        /// <summary>
        /// 数据源
        /// </summary>
        private void SetDataSource()
        {
            dgv1.DataSource = CommonFunction.CalculateStock(_Type, cbxUseOrg.SelectedIndex, cbxUseOrg.SelectedIndex == 0 ? 0 : int.Parse(cbxUseOrg.SelectedValue.ToString()));
            dgv1.Columns[3].Visible = false;
        }

        /// <summary>
        /// cbxUseOrg_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxUseOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStock();
            SetDataSource();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxUseOrg.SelectedIndex == 0)
            {
                MessageBox.Show("请选择使用组织");
                return;
            }
            if (txtSEQ.Text == string.Empty)
            {
                MessageBox.Show("请输入序号");
                txtSEQ.Focus();
                return;
            }
            string strStockName = ((DataRowView)cbxStock.SelectedItem).Row.ItemArray[1].ToString();//仓库名称
            if (MessageBox.Show("要添加[" + strStockName + "]仓库吗？", "添加仓库", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            
            int iSEQ = int.Parse(txtSEQ.Text);
            string strStockNo = cbxStock.SelectedValue.ToString();
            int iStockId = int.Parse(strStockNo.Substring(strStockNo.IndexOf("|") + 1));//获取仓库ID
            strStockNo = strStockNo.Substring(0, strStockNo.IndexOf("|"));//获取仓库名称

            //唯一性检查
            if (CommonFunction.CalculateNumberExists(_Type, iSEQ, strStockNo))
            {
                MessageBox.Show("序号或仓库是唯一，不能重复录入。");
                return;
            }

            //新增记录
            CommonFunction.AddCalculateStock(_Type, iSEQ, iStockId, strStockNo, strStockName);

            //操作日志
            string OName;
            if (_Type == "LOCKSTOCK")
                OName = "锁库仓库";
            else
                OName = "运算仓库";
            CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "新增" + OName, "配置\\设置" + OName, txtSEQ.Text + "|" + cbxUseOrg.Text + "|" + cbxStock.Text, "1");

            //重新获取数据
            SetDataSource();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count == 0) return;
            _FID = int.Parse(dgv1.CurrentRow.Cells[3].Value.ToString());

            //根据序号删除数据
            CommonFunction.UpdateCalculateStock(_FID);
            //操作日志
            string OName;
            if (_Type == "LOCKSTOCK")
                OName = "锁库仓库";
            else
                OName = "运算仓库";
            CommonFunction.DM_Log_Local(GlobalParameter.K3Inf, GlobalParameter.LocalInf, "删除" + OName, "配置\\设置" + OName, txtSEQ.Text + "|" + cbxUseOrg.Text + "|" + cbxStock.Text, "1");
            //重新获取数据
            SetDataSource();
        }

        /// <summary>
        /// txtSEQ_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSEQ_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}