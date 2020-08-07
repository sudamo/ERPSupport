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
            FormSetting();
        }

        private void FormSetting()
        {
            _Year = DateTime.Now.Year;
            _Month = DateTime.Now.Month;

            FillTextBox();
            FillComboBox();
        }


        private void FillTextBox()
        {
            txtYear.Text = _Year.ToString();
        }

        private void FillComboBox()
        {
            DataTable dt;
            DataRow dr;

            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            for (int i = 0; i < 12; i++)
            {
                dr = dt.NewRow();
                dr["FName"] = (i + 1).ToString();
                dr["FValue"] = i + 1;
                dt.Rows.Add(dr);
            }

            cbxMonth.DataSource = dt;
            cbxMonth.DisplayMember = "FName";
            cbxMonth.ValueMember = "FValue";
            cbxMonth.SelectedIndex = _Month - 1;

            cbxOrg.DataSource = DALFactory.K3Cloud.DALCreator.CommFunction.GetOrganization();
            cbxOrg.DisplayMember = "FName";
            cbxOrg.ValueMember = "FValue";
            cbxOrg.SelectedValue = 100505;
        }

        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSyn_Click(object sender, EventArgs e)
        {
            DALFactory.K3Cloud.DALCreator.PrdOutstock.SynPrice(int.Parse(cbxOrg.SelectedValue.ToString()), int.Parse(txtYear.Text), int.Parse(cbxMonth.SelectedValue.ToString()));
            lblTips.Text = "已执行！";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                return;//退格键

            _reg = new Regex(@"^[1-9]\d*|0$");

            if (!_reg.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
