using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ERPSupport.SupForm.UserCrtl
{
    using SQL.K3Cloud;

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
        /// 日期
        /// </summary>
        private ToolStripDateTimePicker _date;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pUInfo"></param>
        public ucRC_System(string pRecordType)
        {
            InitializeComponent();
            _RecordType = pRecordType;
        }

        private void ucRC_System_Load(object sender, EventArgs e)
        {
            _date = new ToolStripDateTimePicker();
            _date.Size = new Size(120, 21);

            //重新排列Items
            List<ToolStripItem> list = new List<ToolStripItem>();
            list.Add(bnTop.Items[0]);
            list.Add(_date);
            list.Add(bnTop.Items[1]);
            list.Add(bnTop.Items[2]);
            list.Add(bnTop.Items[3]);
            list.Add(bnTop.Items[4]);
            list.Add(bnTop.Items[5]);

            bnTop.Items.Clear();
            foreach (ToolStripItem item in list)
                bnTop.Items.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetDataSource()
        {
            DataTable dt = new DataTable();
            if (_RecordType == "K3CLOUD")
            {
                if (bnTop_txtUser.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("请输入操作用户");
                    return;
                }

                dt = CommFunction.ERPLog(bnTop_txtUser.Text.Trim(), _date.Value);
                if (dt.Rows.Count > 0)
                    dgv1.DataSource = dt;
                else
                    dgv1.DataSource = null;
            }
            else if (_RecordType == "ASSISTANT")
            {
                dt = CommFunction.GetDM_Log_Local(bnTop_txtUser.Text.Trim(), _date.Value);
                if (dt.Rows.Count > 0)
                    dgv1.DataSource = dt;
                else
                    dgv1.DataSource = null;
            }
        }

        /// <summary>
        /// txtUser_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SetDataSource();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    Search();
                    break;
            }
        }
        private void Search()
        {
            SetDataSource();
        }
    }
}