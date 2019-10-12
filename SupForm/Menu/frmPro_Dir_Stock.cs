using System;
using System.Data;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Menu
{
    using SQL.K3Cloud;

    /// <summary>
    /// 设置调拨对应仓库
    /// </summary>
    public partial class frmPro_Dir_Stock : Form
    {
        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable _dtSource;

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmPro_Dir_Stock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPro_Dir_Stock_Load(object sender, EventArgs e)
        {
            FillComboBox();
            SetDataSource();
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            DataTable dtOutStock = CommFunction.GetStock(2);
            bnTop_cbxOutStock.ComboBox.DataSource = dtOutStock;
            bnTop_cbxOutStock.ComboBox.ValueMember = dtOutStock.Columns[0].ColumnName;
            bnTop_cbxOutStock.ComboBox.DisplayMember = dtOutStock.Columns[1].ColumnName;

            DataTable dtInStock = CommFunction.GetStock(2);
            bnTop_cbxInStock.ComboBox.DataSource = dtInStock;
            bnTop_cbxInStock.ComboBox.ValueMember = dtInStock.Columns[0].ColumnName;
            bnTop_cbxInStock.ComboBox.DisplayMember = dtInStock.Columns[1].ColumnName;
        }

        /// <summary>
        /// 设置数据源
        /// </summary>
        private void SetDataSource()
        {
            libStock.Text = string.Empty;
            libStock.Items.Clear();
            _dtSource = CommFunction.GetDM_Dir_Stock();
            if (_dtSource == null || _dtSource.Rows.Count == 0)
                return;
            for (int i = 0; i < _dtSource.Rows.Count; i++)
            {
                libStock.Items.Add((i + 1).ToString() + ": " + _dtSource.Rows[i]["OUTSTOCK"].ToString() + " --> " + _dtSource.Rows[i]["INSTOCK"].ToString());
            }
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnAdd_Click(object sender, EventArgs e)
        {
            string strOutStock = bnTop_cbxOutStock.ComboBox.SelectedValue.ToString();
            int iOutStockId = int.Parse(strOutStock.Substring(strOutStock.IndexOf("|") + 1));
            string strInStock = bnTop_cbxInStock.ComboBox.SelectedValue.ToString();
            int iInStockId = int.Parse(strInStock.Substring(strInStock.IndexOf("|") + 1));

            MessageBox.Show(CommFunction.AddDM_Dir_Stock(iOutStockId, iInStockId));
            SetDataSource();
        }

        /// <summary>
        /// 更改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnEdit_Click(object sender, EventArgs e)
        {
            int iCurrentIndex = libStock.SelectedIndex;
            if (iCurrentIndex < 0)
                return;

            string strOutStock = bnTop_cbxOutStock.ComboBox.SelectedValue.ToString();
            int iOutStockId = int.Parse(strOutStock.Substring(strOutStock.IndexOf("|") + 1));
            string strInStock = bnTop_cbxInStock.ComboBox.SelectedValue.ToString();
            int iInStockId = int.Parse(strInStock.Substring(strInStock.IndexOf("|") + 1));

            if (libStock.Text.Trim() == "" || libStock.Items.Count == 0)
                return;

            int iPID = int.Parse(_dtSource.Rows[iCurrentIndex]["PID"].ToString());

            MessageBox.Show(CommFunction.EditDM_Dir_Stock(iOutStockId, iInStockId, iPID));
            SetDataSource();
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnDelete_Click(object sender, EventArgs e)
        {
            int iCurrentIndex = libStock.SelectedIndex;
            if (iCurrentIndex < 0)
                return;

            if (MessageBox.Show("确定要删除该数据吗？", "删除对应仓库", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int iPID = int.Parse(_dtSource.Rows[iCurrentIndex]["PID"].ToString());
                CommFunction.DelDM_Dir_Stock(iPID);
                MessageBox.Show("删除成功。");
                SetDataSource();
            }
        }

        /// <summary>
        /// 取消并退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void libStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iCurrentIndex = libStock.SelectedIndex;
            if (iCurrentIndex < 0)
                return;

            string strOutStockName = _dtSource.Rows[iCurrentIndex]["OUTSTOCK"].ToString();
            bnTop_cbxOutStock.SelectedIndex = bnTop_cbxOutStock.FindString(strOutStockName) == -1 ? 0 : bnTop_cbxOutStock.FindString(strOutStockName);
            string strInStockName = _dtSource.Rows[iCurrentIndex]["INSTOCK"].ToString();
            bnTop_cbxInStock.SelectedIndex = bnTop_cbxInStock.FindString(strInStockName) == -1 ? 0 : bnTop_cbxInStock.FindString(strInStockName);
        }
    }
}

