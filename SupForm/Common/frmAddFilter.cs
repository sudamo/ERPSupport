using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using ERPSupport.Model.Globa;
using ERPSupport.Model.K3Cloud;

namespace ERPSupport.SupForm.Common
{
    /// <summary>
    /// 添加筛选条件
    /// </summary>
    public partial class frmAddFilter : Form
    {
        private string _strFilterName;
        /// <summary>
        /// 方案名称
        /// </summary>
        public string StrFilterName
        {
            get
            {
                return _strFilterName;
            }

            set
            {
                _strFilterName = value;
            }
        }
        /// <summary>
        /// 过滤条件
        /// </summary>
        public List<Filter> lstFilter;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pListFilter"></param>
        public frmAddFilter(List<Filter> pListFilter)
        {
            InitializeComponent();
            lstFilter = pListFilter;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddFilter_Load(object sender, EventArgs e)
        {
            txtName.Text = GlobalParameter.K3Inf.UserName + "的方案";
            txtName.Focus();
            txtName.SelectAll();
        }

        /// <summary>
        /// 添加方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim().Equals(string.Empty))
            {
                lblTips.Text = "请输入方案名";
                return;
            }
            if (CommonFunction.SolutionName(txtName.Text) != 0)
            {
                lblTips.Text = "此方案名已经存在";
                return;
            }

            lblTips.Text = string.Empty;

            string sContent = string.Empty;
            int iRows = 0;
            for (int i = 0; i < lstFilter.Count; i++)
            {
                if (lstFilter[i].Validation)
                {
                    sContent += "[" + lstFilter[i].ParenthesesLeft.ToString() + "|" + lstFilter[i].Field.ToString() + "|" + lstFilter[i].Compare.ToString() + "|" + lstFilter[i].FilterValue.FilterDateTime.ToString() + "|" + lstFilter[i].FilterValue.FilterText.ToString() + "|" + lstFilter[i].FilterValue.FilterIndex.ToString() + "|" + (lstFilter[i].FilterValue.FilterCheck ? "1" : "0") + "|" + lstFilter[i].ParenthesesRight.ToString() + "|" + lstFilter[i].Logic.ToString() + "]";
                    iRows++;
                }
            }
            if (sContent.Equals(string.Empty)) sContent = " ";

            CommonFunction.SaveSolution(txtName.Text, chbShare.Checked, sContent, iRows);
            _strFilterName = txtName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 勾选共享方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbShare_CheckedChanged(object sender, EventArgs e)
        {
            string sShare = "_共享";
            if (chbShare.Checked)
            {
                if (txtName.Text.IndexOf(sShare) < 0)
                    txtName.Text = txtName.Text + sShare;
            }
            else
            {
                if (txtName.Text.IndexOf(sShare) >= 0)
                    txtName.Text = txtName.Text.Remove(txtName.Text.IndexOf(sShare), 3);
            }
        }
    }
}
