﻿using System;
using System.Data;
using ERPSupport.SQL.K3Cloud;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// ERP日志
    /// </summary>
    public partial class ucERPRecord : UserControl
    {
        /// <summary>
        /// 类型
        /// </summary>
        private string strRecordType;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pUInfo"></param>
        public ucERPRecord(string pRecordType)
        {
            InitializeComponent();
            strRecordType = pRecordType;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucERPRecord_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
        }

        /// <summary>
        /// txtUser_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch_Click(null, null);
        }

        /// <summary>
        /// 查找日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (strRecordType == "K3CLOUD")
            {
                if (txtUser.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("请输入操作用户");
                    return;
                }

                dt = CommonFunction.ERPLog(txtUser.Text.Trim(), dtpFrom.Value);
                if (dt.Rows.Count > 0)
                    dgv1.DataSource = dt;
                else
                    dgv1.DataSource = null;
            }
            else if (strRecordType == "ASSISTANT")
            {
                MessageBox.Show("辅助系统操作日志暂未完善。");
                return;
            }
        }
    }
}