using System;
using System.Data;
using ERPSupport.SQL.K3Cloud;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 设置领料部门
    /// </summary>
    public partial class ucPickMTLDepartment : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucPickMTLDepartment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPickMTLDepartment_Load(object sender, EventArgs e)
        {
            FillComboBox();
            dgv1.DataSource = CommonFunction.PickMTLDepartment();
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            cbxUseOrg.DataSource = CommonFunction.GetOrganization(2);
            cbxUseOrg.DisplayMember = "FName";
            cbxUseOrg.ValueMember = "FValue";
            cbxUseOrg.SelectedIndex = 1;

            //cbxStock
            FillDepartment();
        }

        /// <summary>
        /// 填充部门下拉框
        /// </summary>
        private void FillDepartment()
        {
            cbxDepartment.DataSource = CommonFunction.GetDepartment(cbxUseOrg.SelectedValue.ToString());
            cbxDepartment.DisplayMember = "FName";
            cbxDepartment.ValueMember = "FValue";
        }

        /// <summary>
        /// cbxUseOrg_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxUseOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDepartment();
        }

        /// <summary>
        /// btnAdd_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strNumber = cbxDepartment.SelectedValue.ToString();
            int iDeptId = int.Parse(strNumber.Substring(strNumber.IndexOf("|") + 1));//获取部门ID
            strNumber = strNumber.Substring(0, strNumber.IndexOf("|"));//获取部门编码

            //唯一性检查
            if (CommonFunction.PickMTLDeptExists(strNumber))
            {
                MessageBox.Show("部门不能重复录入。");
                return;
            }
            string strName = ((DataRowView)cbxDepartment.SelectedItem).Row.ItemArray[1].ToString();
            string strUseOrgId = cbxUseOrg.SelectedValue.ToString();

            DialogResult result = MessageBox.Show("确定要添加[" + strName + "]，作为领料部门？", "选择", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK) return;

            //新增记录
            CommonFunction.AddPickMTLDept(iDeptId.ToString(), strNumber, strName, strUseOrgId);

            MessageBox.Show("添加成功");
            //重新获取数据
            dgv1.DataSource = CommonFunction.PickMTLDepartment();
        }

        /// <summary>
        /// btnDelete_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count == 0) return;

            ////根据序号删除数据
            CommonFunction.DelPickMTLDept(dgv1.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("删除成功");
            //重新获取数据
            dgv1.DataSource = CommonFunction.PickMTLDepartment();
        }
    }
}
