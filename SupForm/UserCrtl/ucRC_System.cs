using System;
using System.Data;
using ERPSupport.SQL.K3Cloud;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// ERP日志
    /// </summary>
    public partial class ucRC_System : UserControl
    {
        /// <summary>
        /// 类型
        /// </summary>
        private string _RecordType;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pUInfo"></param>
        public ucRC_System(string pRecordType)
        {
            InitializeComponent();
            _RecordType = pRecordType;
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
            if (_RecordType == "K3CLOUD")
            {
                if (txtUser.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("请输入操作用户");
                    return;
                }

                dt = CommFunction.ERPLog(txtUser.Text.Trim(), dtpFrom.Value);
                if (dt.Rows.Count > 0)
                    dgv1.DataSource = dt;
                else
                    dgv1.DataSource = null;
            }
            else if (_RecordType == "ASSISTANT")
            {
                dt = CommFunction.GetDM_Log_Local(txtUser.Text.Trim(), dtpFrom.Value);
                if (dt.Rows.Count > 0)
                    dgv1.DataSource = dt;
                else
                    dgv1.DataSource = null;
            }
        }
    }
}