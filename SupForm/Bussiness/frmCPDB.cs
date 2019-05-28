using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using ERPSupport.Model.K3Cloud;

namespace ERPSupport.SupForm.Bussiness
{
    public partial class frmCPDB : Form
    {
        /// <summary>
        /// 从数据源的第iStart行开始取数据
        /// </summary>
        private int _Start;
        /// <summary>
        /// 取数据截至行
        /// </summary>
        private int _End;
        /// <summary>
        /// 当前页号（页码）
        /// </summary>
        private int _CurrentPage;
        /// <summary>
        /// 每页显示行数（页长）
        /// </summary>
        private int _PageSize;
        /// <summary>
        /// 页数＝总记录数/每页显示行数（向上取整）
        /// </summary>
        private int _PageCount;
        /// <summary>
        /// 总记录数
        /// </summary>
        private int _RecordCount;
        /// <summary>
        /// Regex
        /// </summary>
        private Regex _reg;
        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable _DataSource;
        /// <summary>
        /// 用于显示的数据
        /// </summary>
        private DataTable _DataTemp;
        /// <summary>
        /// 方案名
        /// </summary>
        private string _FilterName;
        /// <summary>
        /// 筛选条件
        /// </summary>
        private List<Filter> _ListFilter;

        /// <summary>
        /// 
        /// </summary>
        public frmCPDB()
        {
            InitializeComponent();
            _FilterName = string.Empty;
            _ListFilter = new List<Filter>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCPDB_Load(object sender, EventArgs e)
        {
            FromSetting();
            FillComboBox();
            _PageSize = int.Parse(bn_cbxPageSize.ComboBox.SelectedValue.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        private void FromSetting()
        {
            //-----
            DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
            newColumn.HeaderText = "";
            newColumn.Width = 20;
            dgv1.Columns.Add(newColumn);

            CheckBox ckBox = new CheckBox();
            ckBox.Name = "chb1";
            ckBox.Size = new Size(16, 16);
            ckBox.Location = new Point(42, 2);
            ckBox.Checked = false;
            ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
            dgv1.Controls.Add(ckBox);
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            DataTable dtComboBox;
            DataRow dr;

            dtComboBox = CommFunction.GetDepartment(3, 100508, "辅助生产部门");
            if (dtComboBox != null && dtComboBox.Rows.Count != 0)
            {
                bnTop_cbxDep.ComboBox.DataSource = dtComboBox;
                bnTop_cbxDep.ComboBox.DisplayMember = "FNAME";
                bnTop_cbxDep.ComboBox.ValueMember = "FVALUE";
                if (bnTop_cbxDep != null && bnTop_cbxDep.ComboBox.Items.Count > 3)
                {
                    bnTop_cbxDep.ComboBox.SelectedIndex = 3;
                }
            }
            dtComboBox = CommFunction.GetStock(3);
            if (dtComboBox != null && dtComboBox.Rows.Count != 0)
            {
                bnTop_cbxInStock.ComboBox.DataSource = dtComboBox;
                bnTop_cbxInStock.ComboBox.DisplayMember = "FNAME";
                bnTop_cbxInStock.ComboBox.ValueMember = "FVALUE";

                if (bnTop_cbxInStock != null && bnTop_cbxInStock.Items.Count > 149)
                {
                    bnTop_cbxInStock.SelectedIndex = 149;
                }
            }

            dtComboBox = new DataTable();
            dtComboBox.Columns.Add("FName");
            dtComboBox.Columns.Add("FValue");

            dr = dtComboBox.NewRow();
            dr["FName"] = "25";
            dr["FValue"] = "25";
            dtComboBox.Rows.Add(dr);

            dr = dtComboBox.NewRow();
            dr["FName"] = "50";
            dr["FValue"] = "50";
            dtComboBox.Rows.Add(dr);

            dr = dtComboBox.NewRow();
            dr["FName"] = "100";
            dr["FValue"] = "100";
            dtComboBox.Rows.Add(dr);

            dr = dtComboBox.NewRow();
            dr["FName"] = "500";
            dr["FValue"] = "500";
            dtComboBox.Rows.Add(dr);

            dr = dtComboBox.NewRow();
            dr["FName"] = "1000";
            dr["FValue"] = "1000";
            dtComboBox.Rows.Add(dr);

            bn_cbxPageSize.ComboBox.DataSource = dtComboBox;
            bn_cbxPageSize.ComboBox.DisplayMember = "FName";
            bn_cbxPageSize.ComboBox.ValueMember = "FValue";
            bn_cbxPageSize.ComboBox.SelectedIndex = 2;
        }

        /// <summary>
        /// 筛选
        /// </summary>
        private void Filter()
        {
            frmFilter frm = new frmFilter(_ListFilter, _FilterName, Model.Enum.FormID.STK_TransferDirect);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                _ListFilter = frm.ListFilter;
                _FilterName = frm.FilterName;

                if (_ListFilter.Count > 0)
                    Search();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void Search()
        {
            DataSourceBinding(1);
            if (dgv1 != null && dgv1.Rows.Count > 0)
            {
                dgv1.Columns[3].Visible = false;
                dgv1.Columns[4].Visible = false;
                dgv1.Columns[6].Visible = false;
                dgv1.Columns[7].Visible = false;
                dgv1.Columns[8].Visible = false;

                dgv1.Columns[10].Visible = false;
                dgv1.Columns[13].Visible = false;
                dgv1.Columns[14].Visible = false;
                dgv1.Columns[19].Visible = false;
                dgv1.Columns[20].Visible = false;

                dgv1.Columns[21].Visible = false;
                dgv1.Columns[22].Visible = false;
                dgv1.Columns[24].Visible = false;
                dgv1.Columns[26].Visible = false;
                dgv1.Columns[27].Visible = false;

                dgv1.Columns[28].Visible = false;

                dgv1.Columns[36].Visible = false;
                dgv1.Columns[37].Visible = false;

                Controls.Find("chb1", true)[0].Location = new Point(dgv1.Columns[1].Width - 35, 2);
            }
        }

        /// <summary>
        /// 成品调拨
        /// </summary>
        private void Commit()
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;
            if (bnTop_cbxDep.SelectedIndex == 0 || bnTop_cbxInStock.SelectedIndex == 0)
            {
                MessageBox.Show("请选择部门和调入仓库");
                return;
            }

            List<string> listParas = new List<string>();
            listParas.Add(bnTop_cbxDep.ComboBox.SelectedValue.ToString().Substring(bnTop_cbxDep.ComboBox.SelectedValue.ToString().IndexOf("|") + 1));
            listParas.Add(bnTop_cbxDep.ComboBox.SelectedValue.ToString().Substring(0, bnTop_cbxDep.ComboBox.SelectedValue.ToString().IndexOf("|")));
            listParas.Add(bnTop_cbxDep.ComboBox.Text);
            listParas.Add(bnTop_cbxInStock.ComboBox.SelectedValue.ToString().Substring(bnTop_cbxInStock.ComboBox.SelectedValue.ToString().IndexOf("|") + 1));
            listParas.Add(bnTop_cbxInStock.ComboBox.SelectedValue.ToString().Substring(0, bnTop_cbxInStock.ComboBox.SelectedValue.ToString().IndexOf("|")));
            listParas.Add(bnTop_cbxInStock.Text);

            DataTable dtTemp = _DataTemp.Clone();
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value))
                {
                    dtTemp.ImportRow(_DataTemp.Rows[i]);
                }
            }

            //成品调拨
            string strBillNos = PrdAllocation.TransferDir(dtTemp, listParas);
            ////更新反写销售订单锁库调拨数量
            //PrdAllocation.UpdateDirFields2(dtTemp);

            MessageBox.Show("直接调拨单：" + strBillNos);

            Search();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="pType">Search,ChangePageSize OR Navi</param>
        private void DataSourceBinding(int pType)
        {
            if (_ListFilter.Count == 0)
            {
                MessageBox.Show("请过滤单据");
                return;
            }
            string strFilter = GetFilter();
            if (strFilter.Equals(string.Empty))
                return;

            if (pType == 1)//重新加载数据源
            {
                _DataSource = PrdAllocation.GetTransForP(strFilter);

                if (_DataSource == null || _DataSource.Rows.Count == 0)
                {
                    dgv1.DataSource = null;
                    return;
                }

                _CurrentPage = 1;//当前页数从1开始
            }
            else if (pType == 2)//改变_PageSize，重新计算 _CurrentPage
            {
                if (dgv1.DataSource == null || dgv1.Rows.Count == 0)
                    return;

                _CurrentPage = _Start / _PageSize + 1;
            }

            _RecordCount = _DataSource.Rows.Count;
            _PageCount = (_RecordCount / _PageSize);
            if ((_RecordCount % _PageSize) > 0)
                _PageCount++;

            _Start = _PageSize * (_CurrentPage - 1);
            if (_CurrentPage == _PageCount)
                _End = _RecordCount;
            else
                _End = _PageSize * _CurrentPage;

            _DataTemp = _DataSource.Clone();
            for (int i = _Start; i < _End; i++)
                _DataTemp.ImportRow(_DataSource.Rows[i]);

            bn_txtCurrentPage.Text = _CurrentPage.ToString();
            bn_lblPageCount.Text = string.Format("{0}页", _PageCount.ToString());
            bn_lblRecordCount.Text = string.Format("{0}行", _RecordCount.ToString());
            bn_lblLockQty.Text = string.Format("锁库数汇总：{0}", SumQty("锁库数量"));

            bs1.DataSource = _DataTemp;
            bn1.BindingSource = bs1;
            dgv1.DataSource = bs1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pColumnName"></param>
        /// <returns></returns>
        private string SumQty(string pColumnName)
        {
            if (_DataTemp == null || _DataTemp.Rows.Count == 0)
                return "0";

            float fSum = 0;

            for (int i = 0; i < _DataTemp.Rows.Count; i++)
            {
                fSum += float.Parse(_DataTemp.Rows[i][pColumnName].ToString());
            }
            return fSum.ToString();
        }

        #region 构造过滤条件
        /// <summary>
        /// 获取过滤条件
        /// </summary>
        /// <returns></returns>
        private string GetFilter()
        {
            string retrunValue = string.Empty;
            string sLeft, sField, sCompare, sValue, sRight, sLogic;
            DataTable dtOrg = CommFunction.GetOrganization(2);
            DataTable dtBillType = CommFunction.GetBillType("SAL_SALEORDER");
            DataTable dtDWay = CommFunction.GetAssistantDataEntryByFID("801e1892b8824299936cb07c1fd1694d");

            for (int i = 0; i < _ListFilter.Count; i++)
            {
                sLeft = sField = sCompare = sValue = sRight = sLogic = string.Empty;

                if (_ListFilter[i].Validation)
                {
                    //左括号
                    switch (_ListFilter[i].ParenthesesLeft)
                    {
                        case 1:
                            sLeft = "(";
                            break;
                        case 2:
                            sLeft = "((";
                            break;
                        case 3:
                            sLeft = "(((";
                            break;
                    }
                    //字段、比较、值
                    switch (_ListFilter[i].Field)
                    {
                        case 1:
                            sField = "TO_CHAR(O.FDATE,'yyyy-mm-dd')";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], new DataTable());
                            break;
                        case 2:
                            sField = "TO_CHAR(O.FAPPROVEDATE,'yyyy-mm-dd')";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], new DataTable());
                            break;
                        case 3:
                            sField = "O.FBILLNO";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], new DataTable());
                            break;
                        case 4:
                            sField = "O.FSALEORGID";
                            sCompare = GetCompare(_ListFilter[i], true);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 5:
                            sField = "O.FBILLTYPEID";
                            sCompare = GetCompare(_ListFilter[i], true);
                            sValue = GetValue(_ListFilter[i], dtBillType);
                            break;

                        case 6:
                            sField = "O.FHEADDELIVERYWAY";
                            sCompare = GetCompare(_ListFilter[i], true);
                            sValue = GetValue(_ListFilter[i], dtDWay);
                            break;
                        case 7:
                            sField = "MTL.FNUMBER";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], new DataTable());
                            break;
                        case 8:
                            sField = "MTLL.FNAME";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], new DataTable());
                            break;
                        case 9:
                            sField = "O.FFULLLOCK";
                            sCompare = " = ";
                            sValue = GetValue(_ListFilter[i], new DataTable());
                            break;
                        case 10:
                            sField = "";
                            sCompare = "";
                            sValue = GetValue(_ListFilter[i], new DataTable());
                            break;
                    }
                    //右括号
                    switch (_ListFilter[i].ParenthesesRight)
                    {
                        case 1:
                            sRight = ")";
                            break;
                        case 2:
                            sRight = "))";
                            break;
                        case 3:
                            sRight = ")))";
                            break;
                    }
                    //逻辑
                    switch (_ListFilter[i].Logic)
                    {
                        case 1:
                            sLogic = "AND";
                            break;
                        case 2:
                            sLogic = "OR";
                            break;
                        default:
                            sLogic = "AND";
                            break;
                    }
                }
                if (i == _ListFilter.Count - 1)
                    retrunValue += " " + sLeft + " " + sField + " " + sCompare + " " + sValue + " " + sRight + " ";
                else
                    retrunValue += " " + sLeft + " " + sField + " " + sCompare + " " + sValue + " " + sRight + " " + sLogic + " ";
            }

            if (retrunValue.Trim().Equals(string.Empty))
                retrunValue = "1 = 1";

            return retrunValue;
        }

        /// <summary>
        /// 获取比较
        /// </summary>
        /// <param name="pFilter"></param>
        /// <returns></returns>
        private string GetCompare(Filter pFilter, bool pIsComboBox)
        {
            string retrunValue = string.Empty;

            if (pIsComboBox)
            {
                if (pFilter.Compare == 2)
                    retrunValue = " <> ";
                else
                    retrunValue = " = ";
            }
            else
                switch (pFilter.Compare)
                {
                    case 1:
                        retrunValue = " = ";
                        break;
                    case 2:
                        retrunValue = " <> ";
                        break;
                    case 3:
                        retrunValue = " > ";
                        break;
                    case 4:
                        retrunValue = " >= ";
                        break;
                    case 5:
                        retrunValue = " < ";
                        break;

                    case 6:
                        retrunValue = " <= ";
                        break;
                    case 7:
                    case 8:
                    case 9:
                        retrunValue = " LIKE ";
                        break;
                    case 10:
                        retrunValue = " NOT LIKE ";
                        break;
                    default:
                        retrunValue = " = ";
                        break;
                }

            return retrunValue;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="pFilter"></param>
        /// <param name="pDT"></param>
        /// <returns></returns>
        private string GetValue(Filter pFilter, DataTable pDT)
        {
            string retrunValue = string.Empty;

            switch (pFilter.Field)
            {
                case 1:
                case 2:
                    retrunValue = "'" + pFilter.FilterValue.FilterDateTime.ToString("yyyy-MM-dd") + "'";
                    break;
                case 3:
                case 7:
                case 8:
                    switch (pFilter.Compare)
                    {
                        case 7:
                        case 10:
                            retrunValue = "'%" + pFilter.FilterValue.FilterText + "%'";
                            break;
                        case 8:
                            retrunValue = "'" + pFilter.FilterValue.FilterText + "%'";
                            break;
                        case 9:
                            retrunValue = "'%" + pFilter.FilterValue.FilterText + "'";
                            break;
                        default:
                            retrunValue = "'" + pFilter.FilterValue.FilterText + "'";
                            break;
                    }
                    break;
                case 4:
                    retrunValue = pDT.Rows[pFilter.FilterValue.FilterIndex]["FValue"].ToString();
                    break;
                case 5:
                case 6:
                    retrunValue = "'" + pDT.Rows[pFilter.FilterValue.FilterIndex]["FValue"].ToString() + "'";
                    break;
                case 9:
                    retrunValue = pFilter.FilterValue.FilterCheck ? "'1'" : "'0'";
                    break;
                case 10:
                    retrunValue = pFilter.FilterValue.FilterCheck ? "OER.FBASEDELIQTY > OE.F_PAEZ_LOCKALLOTQTY" : "OER.FBASEDELIQTY <= OE.F_PAEZ_LOCKALLOTQTY";
                    break;
            }

            return retrunValue;
        }
        #endregion

        #region 勾选
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            foreach (DataGridViewRow dr in dgv1.Rows)
            {
                dr.Cells[0].Value = ((CheckBox)sender).Checked;
            }
            dgv1.EndEdit();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    Filter();
                    break;
                case "2":
                    Commit();
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (_DataSource == null || _DataSource.Rows.Count == 0 || e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    if (_CurrentPage <= 1)
                    {
                        return;
                    }
                    else
                    {
                        _CurrentPage = 1;
                    }
                    break;
                case "2":
                    if (_CurrentPage <= 1)
                    {
                        //MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                        return;
                    }
                    else
                    {
                        _CurrentPage--;
                    }
                    break;
                case "3":
                    _reg = new Regex(@"^[0-9]*[1-9][0-9]*$");

                    if (!_reg.IsMatch(bn_txtCurrentPage.Text))
                    {
                        MessageBox.Show("输入的页码格式不正确！");
                        bn_txtCurrentPage.Focus();
                        bn_txtCurrentPage.Text = _PageCount.ToString();
                        bn_txtCurrentPage.Select(0, bn_txtCurrentPage.Text.Length);
                        return;
                    }
                    if (int.Parse(bn_txtCurrentPage.Text) > _PageCount)
                    {
                        MessageBox.Show("跳转页超过了总页数！");
                        return;
                    }
                    _CurrentPage = int.Parse(bn_txtCurrentPage.Text);
                    break;
                case "4":
                    if (_CurrentPage >= _PageCount)
                    {
                        //MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                        return;
                    }
                    else
                    {
                        _CurrentPage++;
                    }
                    break;
                case "5":
                    if (_CurrentPage >= _PageCount)
                    {
                        return;
                    }
                    else
                    {
                        _CurrentPage = _PageCount;
                    }
                    break;
                default:
                    return;
            }

            //if (e.ClickedItem.Text == "FIRST")
            //{
            //    if (_CurrentPage <= 1)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        _CurrentPage = 1;
            //    }
            //}
            //else if (e.ClickedItem.Text == "PREVIOUS")
            //{
            //    if (_CurrentPage <= 1)
            //    {
            //        //MessageBox.Show("已经是第一页，请点击“下一页”查看！");
            //        return;
            //    }
            //    else
            //    {
            //        _CurrentPage--;
            //    }
            //}
            //else if (e.ClickedItem.Text == "GOTO")
            //{
            //    _reg = new Regex(@"^[0-9]*[1-9][0-9]*$");

            //    if (!_reg.IsMatch(bn_txtCurrentPage.Text))
            //    {
            //        MessageBox.Show("输入的页码格式不正确！");
            //        bn_txtCurrentPage.Focus();
            //        bn_txtCurrentPage.Text = _PageCount.ToString();
            //        bn_txtCurrentPage.Select(0, bn_txtCurrentPage.Text.Length);
            //        return;
            //    }
            //    if (int.Parse(bn_txtCurrentPage.Text) > _PageCount)
            //    {
            //        MessageBox.Show("跳转页超过了总页数！");
            //        return;
            //    }
            //    _CurrentPage = int.Parse(bn_txtCurrentPage.Text);
            //}
            //else if (e.ClickedItem.Text == "NEXT")
            //{
            //    if (_CurrentPage >= _PageCount)
            //    {
            //        //MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
            //        return;
            //    }
            //    else
            //    {
            //        _CurrentPage++;
            //    }
            //}
            //else if (e.ClickedItem.Text == "LAST")
            //{
            //    if (_CurrentPage >= _PageCount)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        _CurrentPage = _PageCount;
            //    }
            //}
            //else
            //    return;

            //控制按钮颜色
            if (_PageCount == 1)
            {
                bn_btnStart.Image = Properties.Resources.control_start;
                bn_btnPrevious.Image = Properties.Resources.control_play2;
                bn_btnNext.Image = Properties.Resources.control_play;
                bn_btnLast.Image = Properties.Resources.control_end;

                bn_btnGoto.Image = Properties.Resources.control_repeat;
            }
            else
            {
                if (_CurrentPage == 1)
                {
                    bn_btnStart.Image = Properties.Resources.control_start;
                    bn_btnPrevious.Image = Properties.Resources.control_play2;
                    bn_btnNext.Image = Properties.Resources.control_play_blue;
                    bn_btnLast.Image = Properties.Resources.control_end_blue;
                }
                else if (_CurrentPage != _PageCount)
                {
                    bn_btnStart.Image = Properties.Resources.control_start_blue;
                    bn_btnPrevious.Image = Properties.Resources.control_play2_blue;
                    bn_btnNext.Image = Properties.Resources.control_play_blue;
                    bn_btnLast.Image = Properties.Resources.control_end_blue;
                }
                else
                {
                    bn_btnStart.Image = Properties.Resources.control_start_blue;
                    bn_btnPrevious.Image = Properties.Resources.control_play2_blue;
                    bn_btnNext.Image = Properties.Resources.control_play;
                    bn_btnLast.Image = Properties.Resources.control_end;
                }

                bn_btnGoto.Image = Properties.Resources.control_repeat_blue;
            }

            DataSourceBinding(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn_cbxPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            try
            {
                _PageSize = int.Parse(bn_cbxPageSize.ComboBox.SelectedValue.ToString());
                DataSourceBinding(2);
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}