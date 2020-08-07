using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ERPSupport.SupForm.UserCrtl
{
    using DALFactory.K3Cloud;
    using Model.Globa;

    /// <summary>
    /// 权限设置
    /// </summary>
    public partial class ucSM_UserAcc : UserControl
    {
        /// <summary>
        /// 手动修改节点Checked
        /// </summary>
        private bool _Manual;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucSM_UserAcc()
        {
            InitializeComponent();

            _Manual = true;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucMS_UserAcc_Load(object sender, EventArgs e)
        {
            SetDataSource();
            BindNode();
        }

        /// <summary>
        /// 数据源
        /// </summary>
        private void SetDataSource()
        {
            dgv1.DataSource = DALCreator.CommFunction.Role(1);
            dgv1.Columns[0].Visible = false;
            dgv1.Columns[2].Visible = false;
            dgv1.Columns[3].Visible = false;
        }

        #region 节点设置
        /// <summary>
        /// 添加节点
        /// </summary>
        private void BindNode()
        {
            DataTable dt = new DataTable();
            dt = DALCreator.CommFunction.Navigation();
            if (dt.Rows.Count == 0) return;

            TreeNode root = new TreeNode();
            root.Text = "全部";
            root.Tag = "0";
            trv1.Nodes.Add(root);//添加父节点

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = dt.Rows[i]["NODENAME"].ToString();
                node.Tag = dt.Rows[i]["NODEID"].ToString();
                root.Nodes.Add(node);//添加一级节点

                //在一级节点下添加子节点
                BingChildNode(int.Parse(dt.Rows[i]["NODEID"].ToString()), node);
            }

            trv1.ImageList = imageList1;//关联图片列表
            int iNo = 0;
            trv1.Nodes[0].ImageIndex = iNo;
            iNo++;
            SetNodeImage(trv1.Nodes[0], ref iNo);

            //展开所有节点
            trv1.ExpandAll();
            trv1.CheckBoxes = true;
        }

        /// <summary>
        /// 设置节点图片
        /// </summary>
        /// <param name="pTreeNode"></param>
        /// <param name="pNo"></param>
        private void SetNodeImage(TreeNode pTreeNode, ref int pNo)
        {
            if (pTreeNode.Nodes.Count == 0) return;

            foreach (TreeNode tn in pTreeNode.Nodes)
            {
                tn.ImageIndex = pNo;
                pNo++;
                SetNodeImage(tn, ref pNo);
            }
        }

        /// <summary>
        /// 绑定子节点
        /// </summary>
        /// <param name="pNodeId"></param>
        /// <param name="pNode"></param>
        private void BingChildNode(int pNodeId, TreeNode pNode)
        {
            DataTable dt = new DataTable();
            dt = DALCreator.CommFunction.Navigation(pNodeId);
            if (dt.Rows.Count == 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = dt.Rows[i]["NODENAME"].ToString();
                node.Tag = dt.Rows[i]["NODEID"].ToString();
                pNode.Nodes.Add(node);

                //递归添加子节点
                //BingChildNode(int.Parse(dt.Rows[i]["NODEID"].ToString()), node);
            }
        }
        #endregion

        #region 节点复选框控制

        /// <summary>
        /// 复选框状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trv1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            trv1.BeginUpdate();//禁用TreeView视图重绘的功能。

            if (_Manual)//用户手动修改节点Checked时才执行
            {
                //修改子节点
                SetSubNodeCheck(e.Node);
                //修改父节点
                SetParentCheck(e.Node);
                SetParentNotCheck(e.Node);

                //修改完还原Manual
                _Manual = true;
            }

            trv1.EndUpdate();//启用TreeView视图重绘的功能。
        }

        /// <summary>
        /// 同步子节点的选择状态
        /// </summary>
        /// <param name="pNode"></param>
        private void SetSubNodeCheck(TreeNode pNode)
        {
            _Manual = false;
            foreach (TreeNode tn in pNode.Nodes)
            {
                tn.Checked = pNode.Checked;
                SetSubNodeCheck(tn);
            }
        }

        /// <summary>
        /// 勾选父节点
        /// </summary>
        /// <param name="pNode">节点</param>
        private void SetParentCheck(TreeNode pNode)
        {
            if (pNode.Checked && pNode.Parent != null)
            {
                pNode.Parent.Checked = true;
                SetParentCheck(pNode.Parent);//递归
            }
        }

        /// <summary>
        /// 取消父节点的选择
        /// 当该节点的父节点的其它子节点都未勾选复选框，则修改父节点的Checked为false
        /// </summary>
        /// <param name="pNode">节点</param>
        private void SetParentNotCheck(TreeNode pNode)
        {
            if (!pNode.Checked && pNode.Parent != null)
            {
                foreach (TreeNode tn in pNode.Parent.Nodes)
                {
                    if (tn.Checked) return;//父节点下有其它子节点已经勾选，则不取消父节点的选择
                }
                pNode.Parent.Checked = false;//取消
                SetParentNotCheck(pNode.Parent);//递归
            }
        }

        //---------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trv1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ////    //每次选择一个节点的时候都取到这个节点的名称，名称就是数据库里面的UserGroupID。
            ////    dt_ExistsRole = new BLL.sys_SetRoleManager().GetExistsRole("1", tvUserGroup.SelectedNode.Name);

            //foreach (TreeNode tn in trv1.Nodes)
            //{
            //    FindTreeView(tn);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tn"></param>
        private void FindTreeView(TreeNode tn)
        {
            //tn.Checked = false;
            //string FunctionID_dt = string.Empty;
            //string FunctionID_tv = string.Empty;
            //for (int i = 0; i < dt_ExistsRole.Rows.Count; i++)
            //{
            //    FunctionID_dt = dt_ExistsRole.Rows[i][1].ToString().Trim();
            //    FunctionID_tv = tn.Name.Trim();
            //    if (FunctionID_dt == FunctionID_tv)
            //    {
            //        tn.Checked = true;
            //    }
            //}
            //foreach (TreeNode tnSub in tn.Nodes)
            //{
            //    FindTreeView(tnSub);
            //}
        }
        #endregion

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRoleName.Text.Trim() == string.Empty)
            {
                lblPrompt.Text = "请输入角色名";
                return;
            }

            if (DALCreator.CommFunction.RoleExists(txtRoleName.Text.Trim()))
            {
                lblPrompt.Text = "角色名已经存在";
                return;
            }

            lblPrompt.Text = string.Empty;

            string strMids = string.Empty;
            string sFunctionIds = string.Empty;
            List<string> listF = new List<string>();

            for (int i = 0; i < trv1.Nodes[0].Nodes.Count; i++)
            {
                foreach (TreeNode tn in trv1.Nodes[0].Nodes[i].Nodes)
                {
                    if (tn.Checked)
                    {
                        if (strMids != string.Empty) strMids += ",";
                        strMids += tn.Tag.ToString();
                    }
                }
            }

            //if (chbOccupy.Checked == true)
            //    sFunctionIds += "tsmiTool_Occupy";

            //if (chbOccupy.Checked == true)
            //{
            //    if (sFunctionIds.Trim() == string.Empty)
            //        sFunctionIds += "tsmiTool_Timer";
            //    else
            //        sFunctionIds += ",tsmiTool_Timer";
            //}

            if (chbOccupy.Checked == true)
                listF.Add("tsmiTool_Occupy");
            if (chbTimerPick.Checked)
                listF.Add("tsmiTool_Timer");
            //--
            if (chbDir.Checked)
                listF.Add("tsmiPro_Dir");
            if (chbWMSData.Checked)
                listF.Add("tsmiPro_WMSData");
            if (chbK3Data.Checked)
                listF.Add("tsmiPro_K3Data");
            if (chbINOrder.Checked)
                listF.Add("tsmiPro_INOrder");
            //--
            if (chbImport.Checked)
                listF.Add("Import");
            if (chbExport.Checked)
                listF.Add("Export");

            if (listF.Count > 0)
            {
                for (int i = 0; i < listF.Count; i++)
                {
                    if (i > 0)
                        sFunctionIds += ",";
                    sFunctionIds += listF[i];
                }
            }


            if (strMids.Trim().Equals(string.Empty)) strMids = " ";

            DALCreator.CommFunction.AddRole(txtRoleName.Text.Trim(), strMids, sFunctionIds);
            //操作日志
            DALCreator.CommFunction.DM_Log_Local("权限分配", "系统管理\\权限分配", "创建角色:" + txtRoleName.Text.Trim());
            MessageBox.Show("创建角色成功");
            SetDataSource();
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GlobalParameter.K3Inf.UserName != "Administrator" && GlobalParameter.K3Inf.UserName != "damo")
            {
                MessageBox.Show("请使用Administrator账号删除！");
                return;
            }
            if (dgv1.DataSource == null || dgv1.Rows.Count == 0) return;
            string strName = dgv1.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show("是否删除角色：" + strName, "删除角色", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DALCreator.CommFunction.DelRole(strName);
                //操作日志
                DALCreator.CommFunction.DM_Log_Local("权限分配", "系统管理\\权限分配", "删除角色:" + strName);
                SetDataSource();
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
                //填充用户
                string sRID = dgv1.CurrentRow.Cells[0].Value.ToString();
                lblUserList.Text = "分配用户：\r\n";
                DataTable dt = DALCreator.CommFunction.User_Role(sRID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i % 5 == 0)
                            lblUserList.Text += "\r\n";
                        lblUserList.Text += dt.Rows[i]["FNAME"].ToString() + ",";
                    }
                }
                lblUserList.Text = lblUserList.Text.Substring(0, lblUserList.Text.Length - 1);

                //标记模块
                string sMids = dgv1.CurrentRow.Cells[2].Value.ToString();
                string sFunctionIds = dgv1.CurrentRow.Cells[3].Value.ToString();

                if (sFunctionIds != null && sFunctionIds.Trim() != string.Empty)
                {
                    if (sFunctionIds.Contains("tsmiTool_Occupy"))
                        chbOccupy.Checked = true;
                    else
                        chbOccupy.Checked = false;
                    if (sFunctionIds.Contains("tsmiTool_Timer"))
                        chbTimerPick.Checked = true;
                    else
                        chbTimerPick.Checked = false;
                    //--
                    if (sFunctionIds.Contains("tsmiPro_Dir"))
                        chbDir.Checked = true;
                    else
                        chbDir.Checked = false;
                    if (sFunctionIds.Contains("tsmiPro_WMSData"))
                        chbWMSData.Checked = true;
                    else
                        chbWMSData.Checked = false;
                    if (sFunctionIds.Contains("tsmiPro_K3Data"))
                        chbK3Data.Checked = true;
                    else
                        chbK3Data.Checked = false;
                    if (sFunctionIds.Contains("tsmiPro_INOrder"))
                        chbINOrder.Checked = true;
                    else
                        chbINOrder.Checked = false;
                    //--
                    if (sFunctionIds.Contains("Import"))
                        chbTimerPick.Checked = true;
                    else
                        chbTimerPick.Checked = false;
                    if (sFunctionIds.Contains("Export"))
                        chbTimerPick.Checked = true;
                    else
                        chbTimerPick.Checked = false;
                }
                else
                {
                    //--
                    chbOccupy.Checked = false;
                    chbTimerPick.Checked = false;
                    //--
                    chbDir.Checked = false;
                    chbWMSData.Checked = false;
                    chbK3Data.Checked = false;
                    chbINOrder.Checked = false;
                }

                if (sMids.Trim() == string.Empty)
                    return;

                for (int i = 0; i < trv1.Nodes[0].Nodes.Count; i++)
                {
                    foreach (TreeNode tn in trv1.Nodes[0].Nodes[i].Nodes)
                    {
                        if (sMids.Contains(tn.Tag.ToString()))
                            tn.Checked = true;
                        else
                            tn.Checked = false;
                    }
                }
                txtRoleName.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            }
        }

        /// <summary>
        /// 覆盖权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (GlobalParameter.K3Inf.UserName != "Administrator" && GlobalParameter.K3Inf.UserName != "damo")
            //{
            //    MessageBox.Show("请使用Administrator账号修改！");
            //    return;
            //}

            if (dgv1.DataSource == null || dgv1.Rows.Count == 0) return;

            string strName = dgv1.CurrentRow.Cells[1].Value.ToString();
            string strMids = string.Empty;
            string sFunctionIds = string.Empty;
            List<string> listF = new List<string>();

            for (int i = 0; i < trv1.Nodes[0].Nodes.Count; i++)
            {
                foreach (TreeNode tn in trv1.Nodes[0].Nodes[i].Nodes)
                {
                    if (tn.Checked)
                    {
                        if (strMids != string.Empty) strMids += ",";
                        strMids += tn.Tag.ToString();
                    }
                }
            }


            if (chbOccupy.Checked == true)
                listF.Add("tsmiTool_Occupy");
            if (chbTimerPick.Checked)
                listF.Add("tsmiTool_Timer");
            //--
            if (chbDir.Checked)
                listF.Add("tsmiPro_Dir");
            if (chbWMSData.Checked)
                listF.Add("tsmiPro_WMSData");
            if (chbK3Data.Checked)
                listF.Add("tsmiPro_K3Data");
            if (chbINOrder.Checked)
                listF.Add("tsmiPro_INOrder");
            //--
            if (chbImport.Checked)
                listF.Add("Import");
            if (chbExport.Checked)
                listF.Add("Export");

            if (listF.Count > 0)
            {
                for (int i = 0; i < listF.Count; i++)
                {
                    if (i > 0)
                        sFunctionIds += ",";
                    sFunctionIds += listF[i];
                }
            }

            if (strMids.Trim().Equals(string.Empty)) strMids = " ";
            if (sFunctionIds.Trim().Equals(string.Empty)) sFunctionIds = " ";

            DALCreator.CommFunction.UpdateRole(strName, strMids, sFunctionIds);
            //操作日志
            DALCreator.CommFunction.DM_Log_Local("权限分配", "系统管理\\权限分配", "修改角色:[" + strName + "]" + strMids + "|" + sFunctionIds);
            MessageBox.Show("保存成功");
            SetDataSource();
        }
    }
}