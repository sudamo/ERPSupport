using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using ERPSupport.DALFactory.K3Cloud;

namespace ERPSupport.SupForm.Menu
{
    public partial class frmPro_K3Data_Bas_Mtl : Form
    {
        /// <summary>
        /// 点击删除键
        /// </summary>
        private bool _bClickDel;
        /// <summary>
        /// 物料集合
        /// </summary>
        private List<string> _lstNumber;
        /// <summary>
        /// 操作的物料集合
        /// </summary>
        private List<string> _lstNumberSyn;
        /// <summary>
        /// 检查结果集合
        /// </summary>
        private List<string> _lstCheck;
        /// <summary>
        /// 执行结果集合
        /// </summary>
        private List<string> _lstResult;
        /// <summary>
        /// 
        /// </summary>
        public frmPro_K3Data_Bas_Mtl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPro_K3Data_Bas_Mtl_Load(object sender, EventArgs e)
        {
            _bClickDel = false;
            _lstNumber = new List<string>();
            _lstCheck = new List<string>();
            _lstResult = new List<string>();

            dgv1.Columns[1].ReadOnly = true;
            dgv1.Columns[2].ReadOnly = true;

            FillComboBox();
        }

        private void FillComboBox()
        {
            //ComboBoxType
            DataTable dtType = new DataTable();
            dtType.Columns.Add("FName");
            dtType.Columns.Add("FValue");

            DataRow drType = dtType.NewRow();
            drType["FName"] = "指定物料编码";
            drType["FValue"] = "0";
            dtType.Rows.Add(drType);

            drType = dtType.NewRow();
            drType["FName"] = "指定修改日期";
            drType["FValue"] = "1";
            dtType.Rows.Add(drType);

            bnTop_cbxType.ComboBox.DataSource = dtType;
            bnTop_cbxType.ComboBox.DisplayMember = "FName";
            bnTop_cbxType.ComboBox.ValueMember = "FValue";

            //ComboBoxYear
            DataTable dtYear = new DataTable();
            dtYear.Columns.Add("FName");
            dtYear.Columns.Add("FValue");

            DataRow drYear;
            int iYear = DateTime.Now.Year;

            for (int i = 0; i < 5; i++)
            {
                drYear = dtYear.NewRow();
                drYear["FName"] = iYear - i;
                drYear["FValue"] = iYear - i;
                dtYear.Rows.Add(drYear);
            }

            bnTop_cbxYear.ComboBox.DataSource = dtYear;
            bnTop_cbxYear.ComboBox.DisplayMember = "FName";
            bnTop_cbxYear.ComboBox.ValueMember = "FValue";

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

            bnTop_cbxMonth.ComboBox.DataSource = dtMonth;
            bnTop_cbxMonth.ComboBox.DisplayMember = "FName";
            bnTop_cbxMonth.ComboBox.ValueMember = "FValue";
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnDel_Click(object sender, EventArgs e)
        {
            //if (_bClickDel)
            //{
            //    bnTop_btnDel.Text = "删除行";
            //    bnTop_btnDel.ForeColor = Color.Black;
            //    _bClickDel = !_bClickDel;
            //}
            //else
            //{
            //    bnTop_btnDel.Text = "选择行,然后按[Del]键(可多选)";
            //    bnTop_btnDel.ForeColor = Color.Red;
            //    _bClickDel = !_bClickDel;
            //}
            dgv1.Focus();
            dgv1.EndEdit();
            SendKeys.Send("{DEL}");
        }

        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnCheck_Click(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;
            dgv1.EndEdit();

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1.Rows[i].Cells[0].Value == null || dgv1.Rows[i].Cells[0].Value.ToString() == string.Empty)
                    continue;

                dgv1.Rows[i].Cells[1].Value = DALCreator.CommFunction.MTLFNameCheck(dgv1.Rows[i].Cells[0].Value.ToString());
            }
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnSyn_Click(object sender, EventArgs e)
        {
            if (bnTop_cbxType.SelectedIndex == 0)
            {
                if (dgv1 == null || dgv1.Rows.Count == 0)
                    return;
                dgv1.EndEdit();
                _lstNumberSyn = new List<string>();

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].Cells[0].Value == null || dgv1.Rows[i].Cells[0].Value.ToString() == string.Empty || (dgv1.Rows[i].Cells[1].Value != null && dgv1.Rows[i].Cells[1].Value.ToString() != "物料待同步"))
                        continue;

                    dgv1.Rows[i].Cells[2].Value = DALCreator.CommFunction.MTLFNameSyn(dgv1.Rows[i].Cells[0].Value.ToString());
                    _lstNumberSyn.Add(dgv1.Rows[i].Cells[0].Value.ToString());
                }
                string strNumbers = string.Empty;
                for (int i = 0; i < _lstNumberSyn.Count; i++)
                    strNumbers += _lstNumberSyn[i];

                //操作日志
                DALCreator.CommFunction.DM_Log_Local("物料名称同步", "项目->k3数据同步->物料", strNumbers);
            }
            else
            {
                string strYM = bnTop_cbxYear.ComboBox.SelectedValue.ToString().Substring(2) + (bnTop_cbxMonth.ComboBox.SelectedValue.ToString().Length == 1 ? "0" + bnTop_cbxMonth.ComboBox.SelectedValue.ToString() : bnTop_cbxMonth.ComboBox.SelectedValue.ToString());

                Cursor = Cursors.WaitCursor;
                string strMessage = DALCreator.CommFunction.MTLFNameSynByYM(strYM);
                MessageBox.Show(strMessage);
                Cursor = Cursors.Default;

                //操作日志
                DALCreator.CommFunction.DM_Log_Local("物料名称同步", "项目->k3数据同步->物料", bnTop_cbxYear.ComboBox.SelectedValue.ToString() + "年" + bnTop_cbxMonth.ComboBox.SelectedValue.ToString() + "月");
            }
        }

        /// <summary>
        /// dgv1_CellMouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            //if (e.Button == MouseButtons.Right && e.RowIndex > -1 && ((DataGridView)sender).CurrentCell.ColumnIndex == 0)
            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                Point _Point = dgv1.PointToClient(Cursor.Position);
                cmsPaste.Show(dgv1, _Point);
            }
        }

        /// <summary>
        /// 块粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsPaste_Area_Click(object sender, EventArgs e)
        {
            try
            {
                object cb = Clipboard.GetData(DataFormats.Text);//获取粘贴板数据
                if (cb == null)
                {
                    MessageBox.Show("没有要复制的物料编码。");
                    return;
                }

                string[] arr = cb.ToString().Replace("\r\n", ",").Split(',');//转换成数据
                int r = dgv1.CurrentRow.Index;//获取当前行序号

                _lstNumber = new List<string>();
                if (r > 0)//把当前行之前的所有物料编码添加到物料编码集合
                    for (int i = 0; i < r; i++)
                    {
                        if (dgv1.Rows[i].Cells[0].Value != null && dgv1.Rows[i].Cells[0].Value.ToString() != string.Empty)
                            _lstNumber.Add(dgv1.Rows[i].Cells[0].Value.ToString());
                    }

                for (int i = 0; i < arr.Length; i++)//把粘贴板的数据也添加到物料编码集合
                    //if (arr[i].Trim().Length > 0)
                        _lstNumber.Add(arr[i]);

                dgv1.Rows.Clear();

                for (int i = 0; i < _lstNumber.Count; i++)//重新填充dgv1
                {
                    dgv1.Rows.Add();
                    dgv1.Rows[i].Cells[0].Value = _lstNumber[i];
                }

                dgv1.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// bnTop_cbxType_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bnTop_cbxType.ComboBox.SelectedValue != null && bnTop_cbxType.ComboBox.SelectedValue.ToString() == "1")
            {
                bnTop_cbxYear.Visible = true;
                bnTop_cbxMonth.Visible = true;
                bnTop_lblYear.Visible = true;
                bnTop_lblMonth.Visible = true;
                bnTop_cbxMonth.ComboBox.SelectedValue = DateTime.Now.Month;

                bnTop_btnDel.Visible = false;
                bnTop_btnCheck.Visible = false;
                dgv1.Visible = false;
                MinimumSize = new Size(500, 100);
                MaximumSize = new Size(500, 100);
                Size = new Size(500, 100);
            }
            else
            {
                bnTop_cbxYear.Visible = false;
                bnTop_cbxMonth.Visible = false;
                bnTop_lblYear.Visible = false;
                bnTop_lblMonth.Visible = false;

                bnTop_btnDel.Visible = true;
                bnTop_btnCheck.Visible = true;
                dgv1.Visible = true;
                MinimumSize = new Size(500, 600);
                MaximumSize = new Size(0, 0);
                Size = new Size(500, 600);
            }
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

        private void dgv1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
