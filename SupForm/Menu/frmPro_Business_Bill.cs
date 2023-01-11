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
    using Model.Enum;
    using DALFactory.K3Cloud;

    public partial class frmPro_Business_Bill : Form
    {
        public frmPro_Business_Bill()
        {
            InitializeComponent();
        }

        private void frmPro_Business_Bill_Load(object sender, EventArgs e)
        {

        }

        private void bnTop_btnCheck_Click(object sender, EventArgs e)
        {
            dgv1.EndEdit();

            for (int i = 0; i < dgv1.Rows.Count - 1; i++)
            {
                object o = dgv1.Rows[i].Cells[0].Value;
                if (o == null || o.ToString() == "")
                {
                    dgv1.Rows[i].Cells[6].Value = "";
                    dgv1.Rows[i].Cells[6].Style.BackColor = Color.White;
                    continue;
                }
                string billno = o.ToString();
                if (!DALCreator.SalOrder.CheckBillByBillNo(FormID.SAL_SaleOrder, billno))
                {
                    dgv1.Rows[i].Cells[6].Value = "销售订单不存在";
                    dgv1.Rows[i].Cells[6].Style.BackColor = Color.MistyRose;
                    continue;
                }
                //
                if (dgv1.Rows[i].Cells[1].Value != null)
                {
                    string datavalue = dgv1.Rows[i].Cells[1].Value.ToString();
                    if (!DALCreator.CommFunction.CheckAssistantByName("58709cf996a15c", datavalue))
                    {
                        dgv1.Rows[i].Cells[6].Value = "物流公司不存在";
                        dgv1.Rows[i].Cells[6].Style.BackColor = Color.MistyRose;
                        continue;
                    }
                }
                //
                if (dgv1.Rows[i].Cells[2].Value == null || dgv1.Rows[i].Cells[2].Value.ToString() == "")
                {
                    dgv1.Rows[i].Cells[6].Value = "运输单号不能为空";
                    dgv1.Rows[i].Cells[6].Style.BackColor = Color.MistyRose;
                    continue;
                }
                //
                //
                DataTable dt = DALCreator.SalOrder.GetOutStockByOrder(billno);
                if (dt == null || dt.Rows.Count == 0)
                {
                    dgv1.Rows[i].Cells[6].Value = "未关联到出库单";
                    dgv1.Rows[i].Cells[6].Style.BackColor = Color.MistyRose;
                    continue;
                }
                dgv1.Rows[i].Cells[3].Value = dt.Rows[0]["CKD"];
                dgv1.Rows[i].Cells[4].Value = dt.Rows[0]["WL"] == null ? "" : dt.Rows[0]["WL"];
                dgv1.Rows[i].Cells[5].Value = dt.Rows[0]["YSD"] == null ? "" : dt.Rows[0]["YSD"];

                dgv1.Rows[i].Cells[6].Value = "检查通过";
            }
        }

        private void bnTop_btnModify_Click(object sender, EventArgs e)
        {
            bnTop_btnCheck_Click(null, null);

            for (int i = 0; i < dgv1.Rows.Count - 1; i++)
            {
                if (dgv1.Rows[i].Cells[6].Value.ToString() == "检查通过")
                {
                    string strResult = DALCreator.SalOrder.UpdateOutStock(dgv1.Rows[i].Cells[0].Value.ToString(), dgv1.Rows[i].Cells[1].Value.ToString(), dgv1.Rows[i].Cells[2].Value.ToString(), dgv1.Rows[i].Cells[4].Value.ToString(), dgv1.Rows[i].Cells[5].Value.ToString());

                    dgv1.Rows[i].Cells[6].Value = strResult;

                    if (strResult == "更新成功")
                        dgv1.Rows[i].Cells[6].Style.BackColor = Color.White;
                    else
                        dgv1.Rows[i].Cells[6].Style.BackColor = Color.MistyRose;
                }
            }
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
                    int cMax = col.Length <= 6 - c ? col.Length : (6 - c);

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

        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
