using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Menu
{
    /// <summary>
    /// K3关联单据数据同步
    /// </summary>
    public partial class frmPro_K3SynData : Form
    {
        /// <summary>
        /// 年
        /// </summary>
        private int _Year;
        /// <summary>
        /// 月
        /// </summary>
        private int _Month;
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex _reg;

        /// <summary>
        /// 
        /// </summary>
        public frmPro_K3SynData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPro_K3SynData_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void FillComboBox()
        {
            //ComboBoxYear
            DataTable dtYear = new DataTable();
            dtYear.Columns.Add("FName");
            dtYear.Columns.Add("FValue");

            DataRow drYear;
            int iYear = DateTime.Now.Year;

            for (int i = 0; i < 3; i++)
            {
                drYear = dtYear.NewRow();
                drYear["FName"] = iYear - i;
                drYear["FValue"] = iYear - i;
                dtYear.Rows.Add(drYear);
            }

            cbxYear.DataSource = dtYear;
            cbxYear.DisplayMember = "FName";
            cbxYear.ValueMember = "FValue";

            //ComboBoxMonth
            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add("FName");
            dtMonth.Columns.Add("FValue");

            DataRow drMonth;

            for (int i = 1; i < 13; i++)
            {
                drMonth = dtMonth.NewRow();
                drMonth["FName"] = i;
                drMonth["FValue"] = i;
                dtMonth.Rows.Add(drMonth);
            }

            cbxMonth.DataSource = dtMonth;
            cbxMonth.DisplayMember = "FName";
            cbxMonth.ValueMember = "FValue";
            cbxMonth.SelectedValue = DateTime.Now.Month - 1;
        }

        private void btnSyn_Click(object sender, EventArgs e)
        {
            string strYM = cbxYear.SelectedValue.ToString().Substring(2) + (cbxMonth.SelectedValue.ToString().Length == 1 ? "0" + cbxMonth.SelectedValue.ToString() : cbxMonth.SelectedValue.ToString());
            Cursor = Cursors.WaitCursor;
            //DALFactory.K3Cloud.DALCreator.PrdOutstock.SynPrice(strYM);
            MessageBox.Show("开发中...");
            //lblTips.Text = "已执行！";
            Cursor = Cursors.Default;
        }

        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
