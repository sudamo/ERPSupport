using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.Menu
{
    using SQL.K3Cloud;
    using Model.K3Cloud;

    /// <summary>
    /// 物料参数设置
    /// </summary>
    public partial class frmTool_Parameter : Form
    {
        #region Variable & Constructor
        /// <summary>
        /// 正则表达式
        /// </summary>
        Regex reg;

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmTool_Parameter()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTool_Parameter_Load(object sender, EventArgs e)
        {
            rbtNumber.Checked = true;
            //
            txtSafeStockDays.Text = UserClass.AppConfig.ReadValue("ORP_SafeStockDays", "AppSettings");
            txtLogisticsDays.Text = UserClass.AppConfig.ReadValue("ORP_LogisticsDays", "AppSettings");
            txtAddGoodsDays.Text = UserClass.AppConfig.ReadValue("ORP_AddGoodsDays", "AppSettings");
            txtLowBook.Text = UserClass.AppConfig.ReadValue("ORP_LowGoods", "AppSettings");
            txtMinBats.Text = UserClass.AppConfig.ReadValue("ORP_MinBats", "AppSettings");

            dtpStar.Value = DateTime.Parse(UserClass.AppConfig.ReadValue("ORP_StarTime", "AppSettings"));
            dtpEnd.Value = DateTime.Parse(UserClass.AppConfig.ReadValue("ORP_EndTime", "AppSettings"));
            txtSumDays.Text = UserClass.AppConfig.ReadValue("ORP_SumMoonths", "AppSettings");
            chbJoin.Checked = UserClass.AppConfig.ReadValue("ORP_AddJoinQty", "AppSettings") == "0" ? false : true;
            //
            if (UserClass.AppConfig.ReadValue("LSP_LockType", "AppSettings") == "1")
                rbtNumber.Checked = true;
            else
                rbtNumber.Checked = false;
            if (UserClass.AppConfig.ReadValue("LSP_IsUse", "AppSettings") == "1")
                chbIsUse.Checked = true;
            else
                chbIsUse.Checked = false;

            txtNumber.Text = UserClass.AppConfig.ReadValue("LSP_LockNumber", "AppSettings");
            txtPercent.Text = UserClass.AppConfig.ReadValue("LSP_LockPercent", "AppSettings");
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string LockType = rbtNumber.Checked ? "1" : "2";
            string IsUse = chbIsUse.Checked ? "1" : "0";
            string AddJoinQty = chbJoin.Checked ? "1" : "0";

            UserClass.AppConfig.WriteValue("LSP_LockType", LockType);
            UserClass.AppConfig.WriteValue("LSP_IsUse", IsUse);
            UserClass.AppConfig.WriteValue("LSP_LockNumber", txtNumber.Text);
            UserClass.AppConfig.WriteValue("LSP_LockPercent", txtPercent.Text);

            UserClass.AppConfig.WriteValue("ORP_SafeStockDays", txtSafeStockDays.Text);
            UserClass.AppConfig.WriteValue("ORP_LogisticsDays", txtLogisticsDays.Text);
            UserClass.AppConfig.WriteValue("ORP_AddGoodsDays", txtAddGoodsDays.Text);
            UserClass.AppConfig.WriteValue("ORP_LowGoods", txtLowBook.Text);
            UserClass.AppConfig.WriteValue("ORP_MinBats", txtMinBats.Text);

            UserClass.AppConfig.WriteValue("ORP_StarTime", dtpStar.Value.ToString());
            UserClass.AppConfig.WriteValue("ORP_EndTime", dtpEnd.Value.ToString());
            UserClass.AppConfig.WriteValue("ORP_SumMoonths", txtSumDays.Text);
            UserClass.AppConfig.WriteValue("ORP_AddJoinQty", AddJoinQty);

            //操作日志
            string OContent = string.Format("LockType:{0}|IsUse:{1}|LockNumber:{2}|LockPercent:{3}|SafeStockDays:{4}|LogisticsDays:{5}|AddGoodsDays:{6}|LowGoods:{7}|MinBats:{8}|StarTime:{9}|EndTime:{10}|SumMoonths:{11}|AddJoinQty:{12}", LockType, IsUse, txtNumber.Text, txtPercent.Text, txtSafeStockDays.Text, txtLogisticsDays.Text, txtAddGoodsDays.Text, txtLowBook.Text, txtMinBats.Text, dtpStar.Value.ToString(), dtpEnd.Value.ToString(), txtSumDays.Text, AddJoinQty);
            CommFunction.DM_Log_Local("参数设定", "菜单->工具->参数", OContent);

            MessageBox.Show("保存成功");
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 导入参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInport_Click(object sender, EventArgs e)
        {
            ImportReceivable();
        }

        /// <summary>
        /// ImportReceivable
        /// </summary>
        private void ImportReceivable()
        {
            string filePath = string.Empty;
            string strError = string.Empty;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择Excel文件";
            fileDialog.Filter = "Excel报表(*.xlsx)|*.xlsx|Excel其他文件(*.xls)|*.xls|所有文件(*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
            }
            if (filePath.Length <= 0) return;

            //导入
            object missing = Type.Missing;
            Excel.Application myApp = new Excel.Application();
            myApp.DisplayAlerts = false;
            Excel.Workbook workBook = myApp.Workbooks.Open(filePath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Excel.Worksheet worksheet = workBook.Worksheets[1] as Excel.Worksheet;
            myApp.Visible = false;

            object FNumber = string.Empty;
            string F_PAEZ_SAFEDAYS = string.Empty;//安全库存天数
            string F_PAEZ_LOGISTICSDAYS = string.Empty;//物流天数
            string F_PAEZ_LOWQTY = string.Empty;//最低订货量
            string F_PAEZ_MINQTY = string.Empty;//最小批量
            string F_PAEZ_REPLENISHMENT = string.Empty;//补货量（天数）

            if (worksheet.Cells[1, 1].Text != "物料基础参数设置")
            {
                MessageBox.Show("请选择物料基础参数设置报表导入。");
                workBook.Close();
                return;
            }

            if (worksheet.Cells[2, 1].Text != "物料编码" || worksheet.Cells[2, 2].Text != "安全库存天数")
            {
                MessageBox.Show("请选择物料安全库存天数的参数报表导入。");
                workBook.Close();
                return;
            }

            for (int i = 3; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                try
                {
                    FNumber = worksheet.Cells[i, 1].Text;
                    FNumber = CommFunction.GetMTLIDByNumber(100508, FNumber.ToString());
                    if (FNumber == null) continue;
                    F_PAEZ_SAFEDAYS = worksheet.Cells[i, 2].Text;
                    F_PAEZ_LOGISTICSDAYS = worksheet.Cells[i, 3].Text;
                    F_PAEZ_LOWQTY = worksheet.Cells[i, 4].Text;
                    F_PAEZ_MINQTY = worksheet.Cells[i, 5].Text;
                    F_PAEZ_REPLENISHMENT = worksheet.Cells[i, 6].Text;

                    CommFunction.UpdateMTLPara(new MaterialParameter(int.Parse(F_PAEZ_SAFEDAYS), int.Parse(F_PAEZ_LOGISTICSDAYS), int.Parse(F_PAEZ_REPLENISHMENT), decimal.Parse(F_PAEZ_LOWQTY), decimal.Parse(F_PAEZ_MINQTY)), int.Parse(FNumber.ToString()));
                }
                catch (Exception ex)
                {
                    worksheet.Cells[i, 8] = ex.Message;
                    strError += i.ToString() + ex.Message;
                    continue;
                }

                worksheet.Cells[i, 8] = "导入成功";
            }
            if (strError != "")
            {
                MessageBox.Show("有些信息导入出错，请查看最后一列的错误提示！");
            }
            else
            {
                MessageBox.Show("全部数据已经成功导入！");
            }

            myApp.Visible = true;
        }

        /// <summary>
        /// 整形验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress_Int(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                return;//退格键

            if (((TextBox)sender).Text.Length - ((TextBox)sender).SelectedText.Length >= 8)//大于N位数
            {
                e.Handled = true;
                return;
            }

            reg = new Regex(@"^[1-9]\d*|0$");//^[1-9]\d*|0$   //^(?:[1-9]+\d*?|0)(\.\d+)?$--^[1-9]\d*$--^[1-9]\d*|0$

            if (!reg.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 浮点数验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress_Float(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                return;//退格键

            if (e.KeyChar == 46)//小数点
            {
                if (((TextBox)sender).Text.Length == 0 || ((TextBox)sender).Text.IndexOf(".") != -1) e.Handled = true;
                return;
            }

            if (((TextBox)sender).Text.Length - ((TextBox)sender).SelectedText.Length >= 8)//大于N位数
            {
                e.Handled = true;
                return;
            }

            reg = new Regex(@"^[1-9]\d*|0$");//1~9数字

            if (!reg.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 百分比验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress_Percent(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                return;//退格键

            if (e.KeyChar == 46)//小数点
            {
                if (((TextBox)sender).Text.Length == 0 || ((TextBox)sender).Text.IndexOf(".") != -1) e.Handled = true;
                return;
            }

            if (((TextBox)sender).Text.Length - ((TextBox)sender).SelectedText.Length >= 8)//大于N位数
            {
                e.Handled = true;
                return;
            }

            reg = new Regex(@"^[1-9]\d*|0$");//1~9数字

            if (!reg.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                return;
            }
            //
            if (((TextBox)sender).Text.Trim() == "")
                return;

            if (double.Parse(((TextBox)sender).Text) >= 10 && Math.Pow(10, ((TextBox)sender).Text.Length) <= 100)//比例不允许超过100
            {
                e.Handled = true;
                return;
            }

            if (((TextBox)sender).Text.IndexOf(".") == 2 && ((TextBox)sender).SelectionStart <= 2)//当光标在小数点前插入字符时（控制百分比不超过100）
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// rbtNumber_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtNumber.Checked)
            {
                plNumber.Enabled = true;
                plNumber.BorderStyle = BorderStyle.FixedSingle;
                plPercent.Enabled = false;
                plPercent.BorderStyle = BorderStyle.None;
                txtNumber.Focus();
            }
            else
            {
                plNumber.Enabled = false;
                plNumber.BorderStyle = BorderStyle.None;
                plPercent.Enabled = true;
                plPercent.BorderStyle = BorderStyle.FixedSingle;
                txtPercent.Focus();
            }
        }

        /// <summary>
        /// dtpStar_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStar_ValueChanged(object sender, EventArgs e)
        {
            txtSumDays.Text = (Math.Abs(dtpStar.Value.Subtract(dtpEnd.Value).Days) + 1).ToString();
        }

        /// <summary>
        /// dtpEnd_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            txtSumDays.Text = (Math.Abs(dtpStar.Value.Subtract(dtpEnd.Value).Days) + 1).ToString();
        }
    }
}
