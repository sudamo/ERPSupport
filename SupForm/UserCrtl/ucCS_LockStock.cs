using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ERPSupport.SupForm.UserCrtl
{
    using DALFactory.K3Cloud;

    /// <summary>
    /// 锁库仓库
    /// </summary>
    public partial class ucCS_LockStock : UserControl
    {
        /// <summary>
        /// 内码
        /// </summary>
        private int _FID;
        /// <summary>
        /// 类型
        /// </summary>
        private string _Type;
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex _reg;
        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable _dtSource;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pType">类型</param>
        public ucCS_LockStock(string pType)
        {
            InitializeComponent();
            _Type = pType;

            _FID = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCS_LockStock_Load(object sender, EventArgs e)
        {
            FillComboBox();
            SetDataSource();
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            bnTop_cbxOrg.ComboBox.DataSource = DALCreator.CommFunction.GetOrganization("LOCKSTOCK");
            bnTop_cbxOrg.ComboBox.DisplayMember = "FName";
            bnTop_cbxOrg.ComboBox.ValueMember = "FValue";

            FillStock();
        }

        /// <summary>
        /// 填充仓库下拉框
        /// </summary>
        private void FillStock()
        {
            if (bnTop_cbxOrg.SelectedIndex == 0)
                bnTop_cbxStock.ComboBox.DataSource = DALCreator.CommFunction.GetStock(1);
            else
                bnTop_cbxStock.ComboBox.DataSource = DALCreator.CommFunction.GetStock(2, int.Parse(bnTop_cbxOrg.ComboBox.SelectedValue.ToString()));

            bnTop_cbxStock.ComboBox.DisplayMember = "FName";
            bnTop_cbxStock.ComboBox.ValueMember = "FValue";
        }

        /// <summary>
        /// 数据源
        /// </summary>
        private void SetDataSource()
        {
            _dtSource = DALCreator.CommFunction.CalculateStock(_Type, bnTop_cbxOrg.SelectedIndex, bnTop_cbxOrg.SelectedIndex == 0 ? 0 : int.Parse(bnTop_cbxOrg.ComboBox.SelectedValue.ToString()));
            dgv1.DataSource = _dtSource;
            dgv1.Columns[3].Visible = false;
        }

        ///// <summary>
        ///// 新增
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (bnTop_cbxOrg.SelectedIndex == 0)
        //    {
        //        MessageBox.Show("请选择使用组织");
        //        return;
        //    }
        //    if (bnTop_txtSeq.Text == string.Empty)
        //    {
        //        MessageBox.Show("请输入序号");
        //        //bnTop_txtSeq.Focus();
        //        return;
        //    }
        //    string strStockName = ((DataRowView)bnTop_cbxStock.SelectedItem).Row.ItemArray[1].ToString();//仓库名称
        //    if (MessageBox.Show("要添加[" + strStockName + "]仓库吗？", "添加仓库", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

        //    int iSEQ = int.Parse(bnTop_txtSeq.Text);
        //    string strStockNo = bnTop_cbxStock.ComboBox.SelectedValue.ToString();
        //    int iStockId = int.Parse(strStockNo.Substring(strStockNo.IndexOf("|") + 1));//获取仓库ID
        //    strStockNo = strStockNo.Substring(0, strStockNo.IndexOf("|"));//获取仓库名称

        //    //唯一性检查
        //    if (CommFunction.CalculateNumberExists(_Type, iSEQ, strStockNo))
        //    {
        //        MessageBox.Show("序号或仓库是唯一，不能重复录入。");
        //        return;
        //    }

        //    //新增记录
        //    CommFunction.AddCalculateStock(_Type, iSEQ, iStockId, strStockNo, strStockName);

        //    //操作日志
        //    string OName;
        //    if (_Type == "LOCKSTOCK")
        //        OName = "锁库仓库";
        //    else
        //        OName = "运算仓库";
        //    CommFunction.DM_Log_Local("新增" + OName, "配置\\设置" + OName, bnTop_txtSeq.Text + "|" + bnTop_cbxOrg.Text + "|" + bnTop_cbxStock.Text, "1");

        //    //重新获取数据
        //    SetDataSource();
        //}
        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (dgv1.Rows.Count == 0) return;
        //    _FID = int.Parse(dgv1.CurrentRow.Cells[3].Value.ToString());

        //    //根据序号删除数据
        //    CommFunction.UpdateCalculateStock(_FID);
        //    //操作日志
        //    string OName;
        //    if (_Type == "LOCKSTOCK")
        //        OName = "锁库仓库";
        //    else
        //        OName = "运算仓库";
        //    CommFunction.DM_Log_Local("删除" + OName, "配置\\设置" + OName, bnTop_txtSeq.Text + "|" + bnTop_cbxOrg.Text + "|" + bnTop_cbxStock.Text, "1");
        //    //重新获取数据
        //    SetDataSource();
        //}

        private void bnTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    AddStock();
                    break;
                case "2":
                    MoveUp();
                    break;
                case "3":
                    MoveDown();
                    break;
                case "4":
                    Save();
                    break;
                case "5":
                    Delete();
                    break;
                case "6":
                    RefreshDate();
                    break;
            }
        }

        private void AddStock()
        {
            if (bnTop_cbxOrg.SelectedIndex == 0)
            {
                MessageBox.Show("请选择使用组织");
                return;
            }
            if (bnTop_txtSeq.Text == string.Empty)
            {
                MessageBox.Show("请输入序号");
                //bnTop_txtSeq.Focus();
                return;
            }
            //string strStockName = ((DataRowView)bnTop_cbxStock.SelectedItem).Row.ItemArray[1].ToString();//仓库名称
            string strStockName = bnTop_cbxStock.Text;//仓库名称
            if (MessageBox.Show("要添加[" + strStockName + "]仓库吗？", "添加仓库", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            int iSEQ = int.Parse(bnTop_txtSeq.Text);
            string strStockNo = bnTop_cbxStock.ComboBox.SelectedValue.ToString();
            int iStockId = int.Parse(strStockNo.Substring(strStockNo.IndexOf("|") + 1));//获取仓库ID
            strStockNo = strStockNo.Substring(0, strStockNo.IndexOf("|"));//获取仓库名称

            //唯一性检查
            if (DALCreator.CommFunction.CalculateNumberExists(_Type, iSEQ, strStockNo))
            {
                MessageBox.Show("序号或仓库是唯一，不能重复录入。");
                return;
            }

            //新增记录
            DALCreator.CommFunction.AddCalculateStock(_Type, iSEQ, iStockId, strStockNo, strStockName);

            //操作日志
            string OName;
            if (_Type == "LOCKSTOCK")
                OName = "锁库仓库";
            else
                OName = "运算仓库";
            DALCreator.CommFunction.DM_Log_Local("新增" + OName, "配置\\设置" + OName, bnTop_txtSeq.Text + "|" + bnTop_cbxOrg.Text + "|" + bnTop_cbxStock.Text);

            //重新获取数据
            SetDataSource();
        }
        private void MoveUp()
        {
            if (_dtSource == null || _dtSource.Rows.Count == 0 || dgv1.SelectedRows[0].Index <= 0)
                return;

            int iCurrent = dgv1.SelectedRows[0].Index;
            DataTable dtTemp = _dtSource.Clone();
            DataRow dr;

            for (int i = 0; i < _dtSource.Rows.Count; i++)
            {
                if (i == iCurrent - 1)
                {
                    dr = dtTemp.NewRow();
                    dr["序号"] = _dtSource.Rows[i]["序号"];
                    dr["仓库编码"] = _dtSource.Rows[i + 1]["仓库编码"];
                    dr["仓库名称"] = _dtSource.Rows[i + 1]["仓库名称"];
                    dr["内码"] = _dtSource.Rows[i + 1]["内码"];
                    dtTemp.Rows.Add(dr);
                }
                else if (i == iCurrent)
                {
                    dr = dtTemp.NewRow();
                    dr["序号"] = _dtSource.Rows[i]["序号"];
                    dr["仓库编码"] = _dtSource.Rows[i - 1]["仓库编码"];
                    dr["仓库名称"] = _dtSource.Rows[i - 1]["仓库名称"];
                    dr["内码"] = _dtSource.Rows[i - 1]["内码"];
                    dtTemp.Rows.Add(dr);
                }
                else
                {
                    dtTemp.ImportRow(_dtSource.Rows[i]);
                }
            }
            _dtSource = dtTemp;

            dgv1.DataSource = _dtSource;

            dgv1.Rows[iCurrent - 1].Selected = true;
        }
        private void MoveDown()
        {
            if (_dtSource == null || _dtSource.Rows.Count == 0 || dgv1.SelectedRows[0].Index >= dgv1.Rows.Count - 1)
                return;

            int iCurrent = dgv1.SelectedRows[0].Index;
            DataTable dtTemp = _dtSource.Clone();
            DataRow dr;

            for (int i = 0; i < _dtSource.Rows.Count; i++)
            {
                if (i == iCurrent)
                {
                    dr = dtTemp.NewRow();
                    dr["序号"] = _dtSource.Rows[i]["序号"];
                    dr["仓库编码"] = _dtSource.Rows[i + 1]["仓库编码"];
                    dr["仓库名称"] = _dtSource.Rows[i + 1]["仓库名称"];
                    dr["内码"] = _dtSource.Rows[i + 1]["内码"];
                    dtTemp.Rows.Add(dr);
                }
                else if (i == iCurrent + 1)
                {
                    dr = dtTemp.NewRow();
                    dr["序号"] = _dtSource.Rows[i]["序号"];
                    dr["仓库编码"] = _dtSource.Rows[i - 1]["仓库编码"];
                    dr["仓库名称"] = _dtSource.Rows[i - 1]["仓库名称"];
                    dr["内码"] = _dtSource.Rows[i - 1]["内码"];
                    dtTemp.Rows.Add(dr);
                }
                else
                {
                    dtTemp.ImportRow(_dtSource.Rows[i]);
                }
            }
            _dtSource = dtTemp;

            dgv1.DataSource = _dtSource;

            dgv1.Rows[iCurrent + 1].Selected = true;
        }
        private void Save()
        {
            if (MessageBox.Show("你确定要保存修改吗？", "保存信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DALCreator.CommFunction.SaveCalculateStock(_dtSource);

                //日志
                string OName;
                if (_Type == "LOCKSTOCK")
                    OName = "锁库仓库";
                else
                    OName = "运算仓库";
                DALCreator.CommFunction.DM_Log_Local("调整" + OName + "序号", "配置\\设置" + OName, "");

                MessageBox.Show("信息已经保存。");
            }
        }
        private void Delete()
        {
            if (MessageBox.Show("你确定要删除所需记录吗？", "删除信息", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            if (dgv1.Rows.Count == 0) return;
            _FID = int.Parse(dgv1.CurrentRow.Cells[3].Value.ToString());

            //根据序号删除数据
            DALCreator.CommFunction.UpdateCalculateStock(_FID);
            //操作日志
            string OName;
            if (_Type == "LOCKSTOCK")
                OName = "锁库仓库";
            else
                OName = "运算仓库";
            DALCreator.CommFunction.DM_Log_Local("删除" + OName, "配置\\设置" + OName, bnTop_txtSeq.Text + "|" + bnTop_cbxOrg.Text + "|" + bnTop_cbxStock.Text);
            //重新获取数据
            SetDataSource();
        }
        private void RefreshDate()
        {
            SetDataSource();
        }


        /// <summary>
        /// txtSEQ_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSEQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            _reg = new Regex(@"^[1-9]\d*|0$");//匹配整数的正则表达式
            if (e.KeyChar != '\b')
            {
                if (!_reg.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// cbxUseOrg_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStock();
            SetDataSource();
        }
    }
}

