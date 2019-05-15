using System;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Bussiness
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmBillModify : Form
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //private string _FormID;
        /// <summary>
        /// 
        /// </summary>
        private string _FBillNo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFormId"></param>
        /// <param name="pFBillNo"></param>
        public frmBillModify(string pFormId, string pFBillNo)
        {
            InitializeComponent();
            //_FormID = pFormId;
            _FBillNo = pFBillNo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBiliModify_Load(object sender, EventArgs e)
        {
            lblFBillNo.Text = "单据编码：" + _FBillNo;

            txtValue.Visible = true;
            cbxValue.Visible = false;
            dtpValue.Visible = false;
            chbValue.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //修改单据

            //返回
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //返回
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
