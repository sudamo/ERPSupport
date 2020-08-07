using System;
using System.Data;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    using DALFactory.K3Cloud;

    /// <summary>
    /// 设置领料部门
    /// </summary>
    public partial class ucCS_PickDepartment : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCS_PickDepartment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCS_PickDepartment_Load(object sender, EventArgs e)
        {
            FillComboBox();
            SetDataSource();
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            //cbxOrg
            bnTop_cbxOrg.ComboBox.DataSource = DALCreator.CommFunction.GetOrganization(2, true);
            bnTop_cbxOrg.ComboBox.DisplayMember = "FName";
            bnTop_cbxOrg.ComboBox.ValueMember = "FValue";
            bnTop_cbxOrg.SelectedIndex = 1;

            //cbxStock
            FillDepartment();
        }

        /// <summary>
        /// 填充部门下拉框
        /// </summary>
        private void FillDepartment()
        {
            if (bnTop_cbxOrg == null)
                return;
            int iUseOrgID = 0;
            try
            {
                iUseOrgID = int.Parse(bnTop_cbxOrg.ComboBox.SelectedValue.ToString());
            }
            catch
            {
                return;
            }
            bnTop_cbxDepartment.ComboBox.DataSource = DALCreator.CommFunction.GetDepartment(3, iUseOrgID, "");
            bnTop_cbxDepartment.ComboBox.DisplayMember = "FName";
            bnTop_cbxDepartment.ComboBox.ValueMember = "FValue";
        }

        private void SetDataSource()
        {
            dgv1.DataSource = DALCreator.CommFunction.PickMTLDepartment();
        }

        /// <summary>
        /// cbxUseOrg_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDepartment();
        }

        ///// <summary>
        ///// btnAdd_Click
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    string strNumber = cbxDepartment.SelectedValue.ToString();
        //    int iDeptId = int.Parse(strNumber.Substring(strNumber.IndexOf("|") + 1));//获取部门ID
        //    strNumber = strNumber.Substring(0, strNumber.IndexOf("|"));//获取部门编码

        //    //唯一性检查
        //    if (CommFunction.PickMTLDeptExists(strNumber))
        //    {
        //        MessageBox.Show("部门不能重复录入。");
        //        return;
        //    }
        //    string strName = ((DataRowView)cbxDepartment.SelectedItem).Row.ItemArray[1].ToString();
        //    string strUseOrgId = cbxUseOrg.SelectedValue.ToString();

        //    DialogResult result = MessageBox.Show("确定要添加[" + strName + "]，作为领料部门？", "选择", MessageBoxButtons.OKCancel);
        //    if (result != DialogResult.OK) return;

        //    //新增记录
        //    CommFunction.AddPickMTLDept(iDeptId.ToString(), strNumber, strName, strUseOrgId);
        //    //操作日志
        //    CommFunction.DM_Log_Local("新增领料部门", "配置\\设置领料部门", cbxUseOrg.Text + ":" + cbxDepartment.Text, "1");
        //    MessageBox.Show("添加成功");
        //    //重新获取数据
        //    dgv1.DataSource = CommFunction.PickMTLDepartment();
        //}
        ///// <summary>
        ///// btnDelete_Click
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (dgv1.Rows.Count == 0) return;

        //    //根据序号删除数据
        //    CommFunction.DelPickMTLDept(dgv1.CurrentRow.Cells[0].Value.ToString());
        //    //操作日志
        //    CommFunction.DM_Log_Local("删除领料部门", "配置\\设置领料部门", dgv1.CurrentRow.Cells[0].Value.ToString(), "1");
        //    MessageBox.Show("删除成功");
        //    //重新获取数据
        //    dgv1.DataSource = CommFunction.PickMTLDepartment();
        //}

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
                    Delete();
                    break;
                case "3":
                    RefreshDate();
                    break;
            }
        }
        private void Add()
        {
            string strNumber = bnTop_cbxDepartment.ComboBox.SelectedValue.ToString();
            int iDeptId = int.Parse(strNumber.Substring(strNumber.IndexOf("|") + 1));//获取部门ID
            strNumber = strNumber.Substring(0, strNumber.IndexOf("|"));//获取部门编码

            //唯一性检查
            if (DALCreator.CommFunction.PickMTLDeptExists(strNumber))
            {
                MessageBox.Show("部门不能重复录入。");
                return;
            }
            string strName = ((DataRowView)bnTop_cbxDepartment.SelectedItem).Row.ItemArray[1].ToString();
            //string strName = bnTop_cbxDepartment.Text;
            string strUseOrgId = bnTop_cbxOrg.ComboBox.SelectedValue.ToString();

            DialogResult result = MessageBox.Show("确定要添加[" + strName + "]，作为领料部门？", "选择", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK) return;

            //新增记录
            DALCreator.CommFunction.AddPickMTLDept(iDeptId.ToString(), strNumber, strName, strUseOrgId);
            //操作日志
            DALCreator.CommFunction.DM_Log_Local("新增领料部门", "配置\\设置领料部门", bnTop_cbxOrg.Text + ":" + bnTop_cbxDepartment.Text);
            MessageBox.Show("添加成功");
            //重新获取数据
            dgv1.DataSource = DALCreator.CommFunction.PickMTLDepartment();
        }
        private void Delete()
        {
            if (dgv1.Rows.Count == 0) return;

            //根据序号删除数据
            DALCreator.CommFunction.DelPickMTLDept(dgv1.CurrentRow.Cells[0].Value.ToString());
            //操作日志
            DALCreator.CommFunction.DM_Log_Local("删除领料部门", "配置\\设置领料部门", dgv1.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("删除成功");
            //重新获取数据
            dgv1.DataSource = DALCreator.CommFunction.PickMTLDepartment();
        }
        private void RefreshDate()
        {
            SetDataSource();
        }
    }
}


