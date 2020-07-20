using System;
using System.Data;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Bussiness
{
    using SQL.K3Cloud;

    /// <summary>
    /// 根据入库单同步条码
    /// </summary>
    public partial class frmInstockSynchr : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmInstockSynchr()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt = PrdInstock.GetInfo(txtBillno.Text.Trim());

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    btnSynchr.Enabled = true;
            //    MessageBox.Show("入库单[" + txtBillno.Text + "]有 " + dt.Rows.Count.ToString() + " 条未同步");
            //}
            //else
            //{
            //    btnSynchr.Enabled = false;
            //    MessageBox.Show("此入库单在系统上没找到未同步的条码");
            //    return;
            //}

            //dgv1.DataSource = dt;
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSynchr_Click(object sender, EventArgs e)
        {
            //PrdInstock.UpdateBarcode(txtBillno.Text.Trim());
            //MessageBox.Show("同步成功");
            //dgv1.DataSource = null;
        }

        /// <summary>
        /// txtBillno_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBillno_TextChanged(object sender, EventArgs e)
        {
            //if (btnSynchr.Enabled == true)
            //    btnSynchr.Enabled = false;
        }
    }
}