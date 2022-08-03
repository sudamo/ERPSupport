using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Menu
{
    using Model.Enum;
    using DALFactory.K3Cloud;

    public partial class frmPro_K3DataModify_Sal : Form
    {
        public frmPro_K3DataModify_Sal()
        {
            InitializeComponent();
        }

        private void frmPro_K3DataModify_Sal_Load(object sender, EventArgs e)
        {

        }

        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void tsmiPaste_Area_Click(object sender, EventArgs e)
        {
            try
            {
                object cb = Clipboard.GetData(DataFormats.Text);//获取粘贴板数据
                int r = dgv1.CurrentRow.Index;//获取当前行
                int c = dgv1.CurrentCell.ColumnIndex;//获取当前列
                int count = dgv1.Rows.Count;//获取dgv初始行数

                if (cb == null) return;
                string[] arr = cb.ToString().Replace("\r\n", "|").Split('|');//拆分行数据

                for (int i = 0; i < arr.Length; i++)
                {
                    string[] col = arr[i].ToString().Replace("\t", "|").Split('|');//拆分列
                    int cMax = col.Length <= 4 - c ? col.Length : (4 - c);

                    if (i < arr.Length - 1 && count <= r + i + 1)
                        dgv1.Rows.Add();

                    for (int j = 0; j < cMax; j++)
                    {
                        dgv1.Rows[r + i].Cells[c + j].Value = col[j];
                    }
                }

                dgv1.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            dgv1.Focus();
            dgv1.EndEdit();
            SendKeys.Send("{DEL}");
        }

        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                Point _Point = dgv1.PointToClient(Cursor.Position);
                cms.Show(dgv1, _Point);
            }
        }

        private void bnTop_btnCheck_Click(object sender, EventArgs e)
        {
            dgv1.EndEdit();

            for (int i = 0; i < dgv1.Rows.Count - 1; i++)
            {
                object o = dgv1.Rows[i].Cells[0].Value;
                if (o == null || o.ToString() == "")
                {
                    dgv1.Rows[i].Cells[4].Value = "";
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.White;
                    continue;
                }
                string billno = o.ToString();
                if (billno.Length < 4)
                {
                    dgv1.Rows[i].Cells[4].Value = "无效单据编号";
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.MistyRose;
                    continue;
                }
                if (dgv1.Rows[i].Cells[1].Value == null || dgv1.Rows[i].Cells[1].Value.ToString() == "")
                {
                    dgv1.Rows[i].Cells[4].Value = "快递单号不能为空";
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.MistyRose;
                    continue;
                }
                if (dgv1.Rows[i].Cells[2].Value == null || dgv1.Rows[i].Cells[2].Value.ToString() == "")
                {
                    dgv1.Rows[i].Cells[4].Value = "快递公司不能为空";
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.MistyRose;
                    continue;
                }
                if (dgv1.Rows[i].Cells[3].Value == null || dgv1.Rows[i].Cells[3].Value.ToString() == "")
                {
                    dgv1.Rows[i].Cells[4].Value = "发货日期不能为空";
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.MistyRose;
                    continue;
                }

                FormID FormId;

                switch (billno.Substring(0, 4))
                {
                    case "XSDD":
                        FormId = FormID.SAL_SaleOrder;
                        break;
                    case "XSCK":
                        FormId = FormID.SAL_OUTSTOCK;
                        break;
                    default:
                        FormId = FormID.SAL_SaleOrder;
                        break;
                }
                if (!DALCreator.SalOrder.CheckBillByBillNo(FormId, billno))
                {
                    dgv1.Rows[i].Cells[4].Value = "单据不存在";
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.MistyRose;
                    continue;
                }


                string datavalue = dgv1.Rows[i].Cells[2].Value.ToString();
                if (!DALCreator.CommFunction.CheckAssistantByName("58709cf996a15c", datavalue))
                {
                    dgv1.Rows[i].Cells[4].Value = "快递公司不存在";
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.MistyRose;
                    continue;
                }

                try
                {
                    DateTime.Parse(dgv1.Rows[i].Cells[3].Value.ToString());
                }
                catch
                {
                    dgv1.Rows[i].Cells[4].Value = "发货日期无效";
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.MistyRose;
                    continue;
                }

                dgv1.Rows[i].Cells[4].Value = "";
                dgv1.Rows[i].Cells[4].Style.BackColor = Color.White;
            }
        }

        private void bnTop_btnModify_Click(object sender, EventArgs e)
        {
            bnTop_btnCheck_Click(null, null);

            for (int i = 0; i < dgv1.Rows.Count - 1; i++)
            {
                if (dgv1.Rows[i].Cells[0].Value.ToString() == "" || dgv1.Rows[i].Cells[4].Value.ToString() != "")
                    continue;
                string strResult = DALCreator.SalOrder.UpdateBills(dgv1.Rows[i].Cells[0].Value.ToString(), dgv1.Rows[i].Cells[1].Value.ToString(), dgv1.Rows[i].Cells[2].Value.ToString(), dgv1.Rows[i].Cells[3].Value.ToString());
                dgv1.Rows[i].Cells[4].Value = strResult;
                if (strResult == "更新成功")
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.White;
                else
                    dgv1.Rows[i].Cells[4].Style.BackColor = Color.MistyRose;
            }
        }
    }
}
