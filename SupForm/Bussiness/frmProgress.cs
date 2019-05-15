using System.Windows.Forms;

namespace ERPSupport.SupForm.Bussiness
{
    /// <summary>
    /// 滚动条
    /// </summary>
    public partial class frmProgress : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmProgress()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProgress_Load(object sender, System.EventArgs e)
        {
            pgb1.Value = 0;
            lbl1.Text = "";
        }

        /// <summary>
        /// 进度显示刷新
        /// </summary>
        /// <param name="percent">百分比</param>
        /// <param name="message">进度显示信息</param>
        public void SetNotifyInfo(int percent, string message)
        {
            pgb1.Value = percent;
            lbl1.Text = message;
        }
    }
}
