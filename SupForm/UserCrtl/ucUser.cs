using System;
using System.Data;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 用户
    /// </summary>
    public partial class ucUser : UserControl
    {
        #region  Variable & Constructor

        /// <summary>
        /// 定位次数
        /// </summary>
        private int iCount;
        /// <summary>
        /// 定位字符串
        /// </summary>
        private string strName;
        /// <summary>
        /// 用户ID
        /// </summary>
        private string sUserId;
        /// <summary>
        /// 角色Table
        /// </summary>
        private DataTable dtRole;
        /// <summary>
        /// 已分配角色Table
        /// </summary>
        private DataTable dtOwn;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucUser()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucUser_Load(object sender, EventArgs e)
        {
            iCount = 0;
            strName = string.Empty;
            sUserId = string.Empty;
            dgv1.DataSource = CommonFunction.User();
            dgv1.Columns[0].Visible = false;

            //填充角色到libRole
            dtRole = new DataTable();
            dtRole = CommonFunction.Role(0);
            for (int i = 0; i < dtRole.Rows.Count; i++)
            {
                libRole.Items.Add(dtRole.Rows[i]["RNAME"].ToString());
            }
        }

        /// <summary>
        /// dgv1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_Click(object sender, EventArgs e)
        {
            if (libOwn.Items.Count > 0)//先清空现有项 并重新填充所有角色到libRole
            {
                libOwn.Items.Clear();
                libRole.Items.Clear();
                for (int i = 0; i < dtRole.Rows.Count; i++)
                {
                    libRole.Items.Add(dtRole.Rows[i]["RNAME"].ToString());
                }
            }
            if (dgv1.Rows.Count > 0)//根据用户权限填充ListBox
            {
                grbRole.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                sUserId = dgv1.CurrentRow.Cells[0].Value.ToString();
                object o = CommonFunction.GetRIDSByUserId(sUserId);
                if (o != null && o.ToString().Trim() != string.Empty)
                {
                    dtOwn = new DataTable();
                    dtOwn = CommonFunction.GetRoleByRIDS(o.ToString());
                    for (int i = 0; i < dtOwn.Rows.Count; i++)
                    {
                        libOwn.Items.Add(dtOwn.Rows[i]["RNAME"].ToString());//填充已分配的角色到libOwn
                        libRole.Items.Remove(dtOwn.Rows[i]["RNAME"].ToString());//从libRole移除已分配的角色
                    }
                }
            }
        }

        /// <summary>
        /// 给用户添加角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (libRole.SelectedIndex < 0) return;
            libOwn.Items.Add(libRole.SelectedItem);
            libRole.Items.RemoveAt(libRole.SelectedIndex);
        }

        /// <summary>
        /// 移除用户角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (libOwn.SelectedIndex < 0) return;
            libRole.Items.Add(libOwn.SelectedItem);
            libOwn.Items.RemoveAt(libOwn.SelectedIndex);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sUserId.Equals(string.Empty)) return;//未选择用户

            string sRIDS = string.Empty;
            if (libOwn.Items.Count == 0)
                sRIDS = " ";//所选择的用户没有分配任何角色
            else//根据分配的角色获取RIDS
            {
                for (int i = 0; i < libOwn.Items.Count; i++)
                {
                    for (int j = 0; i < dtRole.Rows.Count; j++)
                    {
                        if (libOwn.Items[i].ToString() == dtRole.Rows[j]["RNAME"].ToString())
                        {
                            if (i != 0) sRIDS += ",";
                            sRIDS += dtRole.Rows[j]["RID"].ToString();
                            break;
                        }
                    }
                }
            }

            if (!CommonFunction.User_RoleExists(sUserId))//未曾分配角色，新增
            {
                CommonFunction.AddUser_Role(sUserId, sRIDS);
            }
            else
            {
                CommonFunction.UpdateUser_Role(sUserId, sRIDS);
            }

            MessageBox.Show("保存成功！");
        }

        /// <summary>
        /// 定位用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtName.Text.Trim() != string.Empty && dgv1 != null && dgv1.Rows.Count > 0)
            {
                if (strName.Equals(string.Empty) || strName != txtName.Text.Trim().ToUpper())//重置strName和iCount
                {
                    strName = txtName.Text.Trim().ToUpper();
                    iCount = 0;
                }

                for (int i = iCount; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].Cells[1].Value.ToString().ToUpper().Contains(strName))
                    {
                        dgv1.ClearSelection();
                        dgv1.Rows[i].Selected = true;
                        dgv1.CurrentCell = dgv1.Rows[i].Cells[1];

                        if (i != dgv1.Rows.Count - 1)
                            iCount = i + 1;

                        break;
                    }
                }
            }
        }
    }
}
