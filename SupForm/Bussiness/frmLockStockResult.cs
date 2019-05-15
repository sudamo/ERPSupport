using System.Data;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Bussiness
{
    /// <summary>
    /// 结果显示
    /// </summary>
    public partial class frmLockStockResult : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pDT"></param>
        public frmLockStockResult(DataTable pDT)
        {
            InitializeComponent();

            dgv1.DataSource = pDT;
        }
    }
}