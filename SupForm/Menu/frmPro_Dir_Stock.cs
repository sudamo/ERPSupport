using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Menu
{
    using SQL.K3Cloud;

    /// <summary>
    /// 设置调拨对应仓库
    /// </summary>
    public partial class frmPro_Dir_Stock : Form
    {
        public frmPro_Dir_Stock()
        {
            InitializeComponent();
        }

        private void frmPro_Dir_Stock_Load(object sender, EventArgs e)
        {
            FillComboBox();
            //for (int i = 0; i < _dtRole.Rows.Count; i++)
            //{
            //    libStock.Items.Add(_dtRole.Rows[i]["RNAME"].ToString());
            //}
        }

        private void FillComboBox()
        {
            DataTable dtOutStock = CommFunction.GetStock();
            bnTop_cbxOutStock.ComboBox.DataSource = dtOutStock;
            bnTop_cbxOutStock.ComboBox.ValueMember = dtOutStock.Columns[0].ColumnName;
            bnTop_cbxOutStock.ComboBox.DisplayMember = dtOutStock.Columns[1].ColumnName;

            DataTable dtInStock = CommFunction.GetStock();
            bnTop_cbxInStock.ComboBox.DataSource = dtInStock;
            bnTop_cbxInStock.ComboBox.ValueMember = dtInStock.Columns[0].ColumnName;
            bnTop_cbxInStock.ComboBox.DisplayMember = dtInStock.Columns[1].ColumnName;
        }

        private void bnBottom_btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void bnBottom_btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void bnBottom_btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该数据吗？", "删除对应仓库", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
        }

        private void bnBottom_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
