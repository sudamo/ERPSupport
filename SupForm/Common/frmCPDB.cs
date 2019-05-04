using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using ERPSupport.SQL.K3Cloud;
using ERPSupport.Model.K3Cloud;

namespace ERPSupport.SupForm.Common
{
    public partial class frmCPDB : Form
    {
        /// <summary>
        /// 方案名
        /// </summary>
        private string _FilterName;
        /// <summary>
        /// 筛选条件
        /// </summary>
        private List<Filter> _ListFilter;
        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable _DataSource;

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
            DataTable dt;

            dt = CommonFunction.GetDepartment(3, 100508, "辅助生产部门");
            if (dt != null && dt.Rows.Count != 0)
            {
                cbxDep.DataSource = dt;
                cbxDep.DisplayMember = "FNAME";
                cbxDep.ValueMember = "FVALUE";
                if (cbxDep != null && cbxDep.Items.Count > 3)
                {
                    cbxDep.SelectedIndex = 3;
                }
            }
            dt = CommonFunction.GetStock(3, null);
            if (dt != null && dt.Rows.Count != 0)
            {
                cbxStock.DataSource = dt;
                cbxStock.DisplayMember = "FNAME";
                cbxStock.ValueMember = "FVALUE";

                if (cbxStock != null && cbxStock.Items.Count > 143)
                {
                    cbxStock.SelectedIndex = 143;
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_ListFilter.Count == 0)
            {
                MessageBox.Show("请过滤单据");
                return;
            }
            string strFilter = GetFilter();
            if (strFilter.Equals(string.Empty))
                return;

            _DataSource = PrdAllocation.GetTransForP(strFilter);
            if (_DataSource != null)
            {
                dgv1.DataSource = _DataSource;

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

                Controls.Find("chb1", true)[0].Location = new Point(dgv1.Columns[1].Width - 55, 2);
            }
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
            DataTable dtOrg = CommonFunction.GetOrganization(2);
            DataTable dtBillType = CommonFunction.GetBillType("SAL_SALEORDER");
            DataTable dtDWay = CommonFunction.GetAssistantDataEntryByFID("801e1892b8824299936cb07c1fd1694d");

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

        /// <summary>
        /// 成品调拨
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComit_Click(object sender, EventArgs e)
        {
            if (dgv1 == null) return;
            if (cbxDep.SelectedIndex == 0 || cbxStock.SelectedIndex == 0)
            {
                MessageBox.Show("请选择部门和调入仓库");
                return;
            }

            List<string> listParas = new List<string>();
            listParas.Add(cbxDep.SelectedValue.ToString().Substring(cbxDep.SelectedValue.ToString().IndexOf("|") + 1));
            listParas.Add(cbxDep.SelectedValue.ToString().Substring(0, cbxDep.SelectedValue.ToString().IndexOf("|")));
            listParas.Add(cbxDep.Text);
            listParas.Add(cbxStock.SelectedValue.ToString().Substring(cbxStock.SelectedValue.ToString().IndexOf("|") + 1));
            listParas.Add(cbxStock.SelectedValue.ToString().Substring(0, cbxStock.SelectedValue.ToString().IndexOf("|")));
            listParas.Add(cbxStock.Text);

            DataTable dtTemp = _DataSource.Clone();
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value))
                {
                    dtTemp.ImportRow(_DataSource.Rows[i]);
                }
            }

            //成品调拨
            string strBillNos = PrdAllocation.TransferDir(dtTemp, listParas);
            ////更新反写销售订单锁库调拨数量
            //PrdAllocation.UpdateDirFields2(dtTemp);

            MessageBox.Show("直接调拨单：" + strBillNos);

            btnSearch_Click(sender, e);
        }

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
        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            frmFilter frm = new frmFilter(_ListFilter, _FilterName, Model.Enum.FormID.STK_TransferDirect);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                _ListFilter = frm.ListFilter;
                _FilterName = frm.FilterName;

                if (_ListFilter.Count > 0)
                    btnSearch_Click(sender, e);
            }
        }
    }
}