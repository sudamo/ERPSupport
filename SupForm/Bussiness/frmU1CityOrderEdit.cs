using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.Bussiness
{
    using DALFactory.K3Cloud;

    /// <summary>
    /// UiCity对接单据调整
    /// </summary>
    public partial class frmU1CityOrderEdit : Form
    {
        private string _FilePath;

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        /// <summary>
        /// 
        /// </summary>
        public frmU1CityOrderEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmU1CityOrderEdit_Load(object sender, EventArgs e)
        {
            _FilePath = string.Empty;
            FillComboBox();
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            DataTable dt, dt2;
            dt = DALCreator.CommFunction.GetOrganization();

            cbxFacOrg.DataSource = dt;
            cbxFacOrg.DisplayMember = "FNAME";
            cbxFacOrg.ValueMember = "FVALUE";
            cbxFacOrg.SelectedIndex = 24;

            dt2 = DALCreator.CommFunction.GetOrganization();
            cbxSaleOrg.DataSource = dt2;
            cbxSaleOrg.DisplayMember = "FNAME";
            cbxSaleOrg.ValueMember = "FVALUE";
            cbxSaleOrg.SelectedIndex = 24;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedIndexChange(object sender,EventArgs e)
        {
            if (((ComboBox)sender).Name == "cbxSaleOrg")
            {
                int iOrgId;
                try
                {
                    iOrgId = int.Parse(cbxSaleOrg.SelectedValue.ToString());
                }
                catch { return; }

                DataTable dt = DALCreator.CommFunction.GetDepartment(5, iOrgId, null);
                if (dt == null)
                    return;

                cbxDep.DataSource = dt;
                cbxDep.DisplayMember = "FNAME";
                cbxDep.ValueMember = "FVALUE";

                dt = DALCreator.CommFunction.GetSellerList(iOrgId);
                if (dt == null)
                    return;

                cbxSaler.DataSource = dt;
                cbxSaler.DisplayMember = "FNAME";
                cbxSaler.ValueMember = "FVALUE";
                if (iOrgId == 491946332)
                    cbxSaler.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// 选取文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strError = string.Empty;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择Excel文件";
            fileDialog.Filter = "Excel报表(*.xls;*.xlsx)|*.xls;*.xlsx";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _FilePath = fileDialog.FileName;
            }

            txtPath.Text = _FilePath;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnOK_Click(object sender, EventArgs e)
        {
            if(_FilePath.Equals(string.Empty))
            {
                MessageBox.Show("请选择需要修改的订单Excel文件！");
                return;
            }

            string FBillNo, FBillNos = string.Empty;
            List<string> list = new List<string>();

            object missing = Type.Missing;
            Excel.Application myApp = new Excel.Application();
            myApp.DisplayAlerts = false;
            Excel.Workbook workBook = myApp.Workbooks.Open(_FilePath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Excel.Worksheet worksheet = workBook.Worksheets[1] as Excel.Worksheet;
            myApp.Visible = false;

            if (worksheet.Cells[1, 1].Text != "对接订单")
            {
                MessageBox.Show("请选择[对接系统订单修改模板]");
                workBook.Close();
                goto A;
            }
            for (int i = 2; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                FBillNo = worksheet.Cells[i, 1].Text == null ? "" : worksheet.Cells[i, 1].Text;
                if (FBillNo != "")
                {
                    list.Add(FBillNo);
                    FBillNos += FBillNo;
                }
            }

            int iSaleOrg, iFacOrg, iDep, iSaler;
            try
            {
                iSaleOrg = int.Parse(cbxSaleOrg.SelectedValue.ToString());
                iFacOrg = int.Parse(cbxFacOrg.SelectedValue.ToString());
                iDep = int.Parse(cbxDep.SelectedValue.ToString());
                iSaler = int.Parse(cbxSaler.SelectedValue.ToString());
            }
            catch { goto A; }

            DALFactory.K3Cloud.DALCreator.SalOrder.UpdateUiCityOrders(iFacOrg, iSaleOrg, iDep, iSaler, list);
            //日志
            string strMessage = string.Format("调整U1City销售订单:", FBillNos);
            DALCreator.CommFunction.DM_Log_Local("单据信息调整", "辅助功能//配置//单据信息调整", strMessage);

            A:
            myApp.Quit();

            IntPtr t = new IntPtr(myApp.Hwnd);
            int k = 0;
            GetWindowThreadProcessId(t, out k);
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
            p.Kill();

            MessageBox.Show("更新完成");
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
