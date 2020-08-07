using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ERPSupport.SupForm.Bussiness
{
    /// <summary>
    /// 修改生产用料清单信息
    /// </summary>
    public partial class frmPPBom : Form
    {
        ///// <summary>
        ///// 子项物料ID；
        ///// </summary>
        //private int _MaterialId;
        /// <summary>
        /// 原数据
        /// </summary>
        private DataTable _dtDataSource;
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex _reg;

        /// <summary>
        /// 
        /// </summary>
        public frmPPBom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPPBom_Load(object sender, EventArgs e)
        {
            //不允许重新排列
            DGVSort(dgv1, false);

            Text = "修改生产用料清单信息 - " + Model.Globa.GlobalParameter.K3Inf.UserName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnSearch_Click(object sender, EventArgs e)
        {
            if (bnTop_txtBillNo.Text.Trim().Equals(string.Empty))
                return;

            _dtDataSource = DALFactory.K3Cloud.DALCreator.PrdAllocation.GetPPBomByBillNo(bnTop_txtBillNo.Text.Trim());
            if (_dtDataSource == null || _dtDataSource.Rows.Count == 0)
                return;

            dgv1.DataSource = _dtDataSource;
            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].Visible = false;
            dgv1.Columns[2].Visible = false;
            dgv1.Columns[3].Visible = false;
            dgv1.Columns[4].Visible = false;

            dgv1.Columns[5].Visible = false;
            dgv1.Columns[6].Visible = false;
            dgv1.Columns[7].Visible = false;
            dgv1.Columns[8].Visible = false;
            dgv1.Columns[9].Visible = false;

            dgv1.Columns[10].Visible = false;

            txtNumber.Text = "";
            txtBom.Text = "";
            txtName.Text = "";
            txtOrg.Text = "";
            txtDep.Text = "";
            txtUnit.Text = "";
            txtQty.Text = "";
            txtMoBillNo.Text = "";
            txtStatus.Text = "";
            txtMoSeq.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_Click(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            txtNumber.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            txtBom.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
            txtName.Text = dgv1.CurrentRow.Cells[3].Value.ToString();

            txtOrg.Text = dgv1.CurrentRow.Cells[4].Value.ToString();
            txtDep.Text = dgv1.CurrentRow.Cells[5].Value.ToString();

            txtUnit.Text = dgv1.CurrentRow.Cells[6].Value.ToString();
            txtQty.Text = dgv1.CurrentRow.Cells[7].Value.ToString();

            txtMoBillNo.Text = dgv1.CurrentRow.Cells[8].Value.ToString();
            txtStatus.Text = dgv1.CurrentRow.Cells[9].Value.ToString();
            txtMoSeq.Text = dgv1.CurrentRow.Cells[10].Value.ToString();

            lblSeq.Text = "序号：" + dgv1.CurrentRow.Cells[11].Value.ToString();
            lblCNumber2.Text = "子项物料编码：" + dgv1.CurrentRow.Cells[12].Value.ToString();
            txtCName2.Text = dgv1.CurrentRow.Cells[13].Value.ToString();

            lblMustQty2.Text = "应发数量：" + dgv1.CurrentRow.Cells[14].Value.ToString();
            txtMustQty.Text = dgv1.CurrentRow.Cells[14].Value.ToString();

            txtFZ.Text = dgv1.CurrentRow.Cells[15].Value.ToString();
            lblFZ2.Text = "分子：" + dgv1.CurrentRow.Cells[15].Value.ToString();

            txtFM.Text = dgv1.CurrentRow.Cells[16].Value.ToString();
            lblFM2.Text = "分母：" + dgv1.CurrentRow.Cells[16].Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnC_btnSearch_Click(object sender, EventArgs e)
        {
            if (bnC_txtMTLNumber.Text.Trim().Equals(string.Empty))
            {
                txtCName.Text = string.Empty;
                return;
            }

            string strMTL = DALFactory.K3Cloud.DALCreator.CommFunction.GetMTLByMTLNumber(bnC_txtMTLNumber.Text.Trim());
            if (strMTL.Equals(string.Empty))
            {
                MessageBox.Show("未找到物料信息。");
                txtCName.Text = string.Empty;
                return;
            }

            //int iMaterialid = int.Parse(strMTL.Substring(0, strMTL.IndexOf("|")));
            //string strName = strMTL.Substring(strMTL.IndexOf("|") + 1);
            //txtCName.Text = strName;
            txtCName.Text = strMTL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnC_bntChange_Click(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0 || txtCName2.Text.Equals(string.Empty))
            {
                MessageBox.Show("请选择被替换的子项物料。");
                return;
            }
            if (txtMustQty.Text == "" || txtFZ.Text == "")
            {
                MessageBox.Show("应发数量和分子不能为空。");
                return;
            }

            DataTable dtOld, dtNew;
            DataRow dr;
            dtOld = new DataTable();
            dtOld.Columns.Add("序号");
            dtOld.Columns.Add("子项物料编码");
            dtOld.Columns.Add("子项物料名称");
            dtOld.Columns.Add("分子");
            dtOld.Columns.Add("分母");
            dtOld.Columns.Add("应发数量");

            dtNew = new DataTable();
            dtNew.Columns.Add("序号");
            dtNew.Columns.Add("子项物料编码");
            dtNew.Columns.Add("子项物料名称");
            dtNew.Columns.Add("分子");
            dtNew.Columns.Add("分母");
            dtNew.Columns.Add("应发数量");

            int iRow = dgv1.CurrentRow.Index;//当前选择行序号
            int iFEntryId = int.Parse(_dtDataSource.Rows[iRow]["FENTRYID"].ToString());
            bool bType;

            //修改前信息
            for (int i = 0; i < _dtDataSource.Rows.Count; i++)
            {
                dr = dtOld.NewRow();
                dr["序号"] = _dtDataSource.Rows[i]["序号"];
                dr["子项物料编码"] = _dtDataSource.Rows[i]["子项物料编码"];
                dr["子项物料名称"] = _dtDataSource.Rows[i]["子项物料名称"];
                dr["分子"] = _dtDataSource.Rows[i]["分子"];
                dr["分母"] = _dtDataSource.Rows[i]["分母"];
                dr["应发数量"] = _dtDataSource.Rows[i]["应发数量"];

                dtOld.Rows.Add(dr);
            }

            if (txtCName.Text == string.Empty)
            {
                if (MessageBox.Show("是否只修改子项物料用量？", "物料修改", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < _dtDataSource.Rows.Count; i++)
                    {
                        dr = dtNew.NewRow();
                        if (i == iRow)
                        {
                            dr["序号"] = _dtDataSource.Rows[i]["序号"];
                            dr["子项物料编码"] = _dtDataSource.Rows[i]["子项物料编码"];
                            dr["子项物料名称"] = _dtDataSource.Rows[i]["子项物料名称"];
                            dr["分子"] = txtFZ.Text;
                            dr["分母"] = _dtDataSource.Rows[i]["分母"];
                            dr["应发数量"] = txtMustQty.Text;

                            dtNew.Rows.Add(dr);
                        }
                        else
                        {
                            dr["序号"] = _dtDataSource.Rows[i]["序号"];
                            dr["子项物料编码"] = _dtDataSource.Rows[i]["子项物料编码"];
                            dr["子项物料名称"] = _dtDataSource.Rows[i]["子项物料名称"];
                            dr["分子"] = _dtDataSource.Rows[i]["分子"];
                            dr["分母"] = _dtDataSource.Rows[i]["分母"];
                            dr["应发数量"] = _dtDataSource.Rows[i]["应发数量"];
                            dtNew.Rows.Add(dr);
                        }
                    }

                    bType = true;
                }
                else
                    return;
            }
            else
            {
                for (int i = 0; i < _dtDataSource.Rows.Count; i++)
                {
                    dr = dtNew.NewRow();
                    if (i == iRow)
                    {
                        dr["序号"] = _dtDataSource.Rows[i]["序号"];
                        dr["子项物料编码"] = bnC_txtMTLNumber.Text;
                        dr["子项物料名称"] = txtCName.Text;
                        dr["分子"] = txtFZ.Text;
                        dr["分母"] = _dtDataSource.Rows[i]["分母"];
                        dr["应发数量"] = txtMustQty.Text;

                        dtNew.Rows.Add(dr);
                    }
                    else
                    {
                        dr["序号"] = _dtDataSource.Rows[i]["序号"];
                        dr["子项物料编码"] = _dtDataSource.Rows[i]["子项物料编码"];
                        dr["子项物料名称"] = _dtDataSource.Rows[i]["子项物料名称"];
                        dr["分子"] = _dtDataSource.Rows[i]["分子"];
                        dr["分母"] = _dtDataSource.Rows[i]["分母"];
                        dr["应发数量"] = _dtDataSource.Rows[i]["应发数量"];
                        dtNew.Rows.Add(dr);
                    }
                }

                bType = false;
            }

            DateTime tNeedDate = DateTime.Parse(dgv1.CurrentRow.Cells[17].Value.ToString());
            frmBomCompare frm = new frmBomCompare(dtOld, dtNew, tNeedDate, dgv1.CurrentRow.Cells[1].Value.ToString(), iRow, bType, iFEntryId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bnTop_btnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// 文本框小数输入限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxCheck_Decimal(object sender, KeyPressEventArgs e)
        {
            //_reg = new Regex(@"^([0-9]{1,}[.][0-9]*)$");//匹配小数的正则表达式
            //_reg = new Regex(@"^[1-9]\d{0,13}(\.\d{0,4})?$");//匹配小数的正则表达式,这个适应于decimal（18，4）
            _reg = new Regex(@"^[1-9]\d*|0$");//匹配整数的正则表达式

            if (e.KeyChar == '\b')//忽略退格键
                return;

            if (e.KeyChar != '.')//非小数点输入
            {
                if (!_reg.IsMatch(e.KeyChar.ToString()))//忽略非数字输入
                    e.Handled = true;
                else if (e.KeyChar == '0' && ((TextBox)sender).Text.IndexOf(".") < 0 && ((TextBox)sender).Text.IndexOf("0") == 0)//最左边不能连续输入零
                    e.Handled = true;
            }
            else if (((TextBox)sender).Text.IndexOf(".") >= 0 || ((TextBox)sender).Text.Length == 0)//已经有小数点或第一位数不能输入小数点
                e.Handled = true;
        }

        /// <summary>
        /// 是否允许DataGridView column 排序
        /// </summary>
        /// <param name="pDGV"></param>
        /// <param name="pSort"></param>
        private void DGVSort(DataGridView pDGV, bool pSort)
        {
            DataGridViewColumnSortMode tempMode = pSort ? DataGridViewColumnSortMode.Automatic : DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < pDGV.Columns.Count; i++)
                pDGV.Columns[i].SortMode = tempMode;
        }
    }
}
