using System;
using System.Data;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    using DALFactory.K3Cloud;

    /// <summary>
    /// 用户
    /// </summary>
    public partial class ucSM_User : UserControl
    {
        #region  Variable & Constructor

        /// <summary>
        /// 定位次数
        /// </summary>
        private int _Count;
        /// <summary>
        /// 定位字符串
        /// </summary>
        private string _Name;
        /// <summary>
        /// 用户ID
        /// </summary>
        private string _UserId;
        /// <summary>
        /// 角色Table
        /// </summary>
        private DataTable _dtRole;
        /// <summary>
        /// 已分配角色Table
        /// </summary>
        private DataTable _dtOwn;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucSM_User()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucMS_User_Load(object sender, EventArgs e)
        {
            _Count = 0;
            _Name = string.Empty;
            _UserId = string.Empty;
            dgv1.DataSource = DALCreator.CommFunction.User();
            dgv1.Columns[0].Visible = false;

            //填充角色到libRole
            _dtRole = new DataTable();
            _dtRole = DALCreator.CommFunction.Role(0);
            for (int i = 0; i < _dtRole.Rows.Count; i++)
            {
                libRole.Items.Add(_dtRole.Rows[i]["RNAME"].ToString());
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
                for (int i = 0; i < _dtRole.Rows.Count; i++)
                {
                    libRole.Items.Add(_dtRole.Rows[i]["RNAME"].ToString());
                }
            }
            if (dgv1.Rows.Count > 0)//根据用户权限填充ListBox
            {
                grbRole.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                _UserId = dgv1.CurrentRow.Cells[0].Value.ToString();
                object o = DALCreator.CommFunction.GetRIDSByUserId(_UserId);
                if (o != null && o.ToString().Trim() != string.Empty)
                {
                    _dtOwn = new DataTable();
                    _dtOwn = DALCreator.CommFunction.GetRoleByRIDS(o.ToString());
                    for (int i = 0; i < _dtOwn.Rows.Count; i++)
                    {
                        libOwn.Items.Add(_dtOwn.Rows[i]["RNAME"].ToString());//填充已分配的角色到libOwn
                        libRole.Items.Remove(_dtOwn.Rows[i]["RNAME"].ToString());//从libRole移除已分配的角色
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
            if (_UserId.Equals(string.Empty)) return;//未选择用户

            string sRIDS = string.Empty;
            if (libOwn.Items.Count == 0)
                sRIDS = " ";//所选择的用户没有分配任何角色
            else//根据分配的角色获取RIDS
            {
                for (int i = 0; i < libOwn.Items.Count; i++)
                {
                    for (int j = 0; i < _dtRole.Rows.Count; j++)
                    {
                        if (libOwn.Items[i].ToString() == _dtRole.Rows[j]["RNAME"].ToString())
                        {
                            if (i != 0) sRIDS += ",";
                            sRIDS += _dtRole.Rows[j]["RID"].ToString();
                            break;
                        }
                    }
                }
            }

            if (!DALCreator.CommFunction.User_RoleExists(_UserId))//未曾分配角色，新增
            {
                DALCreator.CommFunction.AddUser_Role(_UserId, sRIDS);
            }
            else
            {
                DALCreator.CommFunction.UpdateUser_Role(_UserId, sRIDS);
            }

            //操作日志
            string strContent = "分配角色:";
            if (libOwn.Items.Count == 0)
                strContent = "移除用户[" + grbRole.Text + "]所有角色";
            else
            {
                strContent = "[" + grbRole.Text + "][";
                for (int i = 0; i < libOwn.Items.Count; i++)
                {
                    if (i > 0) strContent += "|";
                    strContent += libOwn.Items[i].ToString();
                }
                strContent += "]";
            }
            DALCreator.CommFunction.DM_Log_Local("用户管理", "系统管理\\用户管理", strContent);
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
                if (_Name.Equals(string.Empty) || _Name != txtName.Text.Trim().ToUpper())//重置strName和iCount
                {
                    _Name = txtName.Text.Trim().ToUpper();
                    _Count = 0;
                }

                for (int i = _Count; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].Cells[1].Value.ToString().ToUpper().Contains(_Name))
                    {
                        dgv1.ClearSelection();
                        dgv1.Rows[i].Selected = true;
                        dgv1.CurrentCell = dgv1.Rows[i].Cells[1];

                        if (i != dgv1.Rows.Count - 1)
                            _Count = i + 1;

                        break;
                    }
                }
            }
        }
    }
}

