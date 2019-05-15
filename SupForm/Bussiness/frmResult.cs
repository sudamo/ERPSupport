using System.Data;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Bussiness
{
    /// <summary>
    /// 结果显示
    /// </summary>
    public partial class frmResult : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pDT">结果信息</param>
        public frmResult(DataTable pDT)
        {
            InitializeComponent();

            dgv1.DataSource = pDT;
        }

        /// <summary>
        /// dgv1_RowStateChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}