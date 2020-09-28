using System;
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

            
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnDel_Click(object sender, EventArgs e)
        {
            if (_bClickDel)
            {
                bnTop_btnDel.Text = "删除行";
                bnTop_btnDel.ForeColor = Color.Black;
                _bClickDel = !_bClickDel;
            }
            else
            {
                bnTop_btnDel.Text = "选择需要删除的行(可多选)，然后按[Delete]键";
                bnTop_btnDel.ForeColor = Color.Red;
                _bClickDel = !_bClickDel;
            }
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
            DALCreator.CommFunction.DM_Log_Local("物料名称同步", "项目->k3数据同步->基础资料->物料修改", strNumbers);
        }


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

        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
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
    }
}
