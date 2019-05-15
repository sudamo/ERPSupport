using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using ERPSupport.SQL.K3Cloud;
using ERPSupport.Model.Enum;
using ERPSupport.Model.K3Cloud;

namespace ERPSupport.SupForm.Bussiness
{
    /// <summary>
    /// 筛选条件方案
    /// </summary>
    public partial class frmFilter : Form
    {
        /// <summary>
        /// 检验是否成功
        /// </summary>
        private bool _Check;

        private string _FilterName;
        /// <summary>
        /// 方案名称
        /// </summary>
        public string FilterName
        {
            get
            {
                return _FilterName;
            }

            set
            {
                _FilterName = value;
            }
        }

        private List<Filter> _ListFilter;
        /// <summary>
        /// 过滤条件
        /// </summary>
        public List<Filter> ListFilter
        {
            get
            {
                return _ListFilter;
            }

            set
            {
                _ListFilter = value;
            }
        }

        /// <summary>
        /// 业务标识
        /// </summary>
        private FormID _FormID;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pListFilter">筛选条件</param>
        /// <param name="pFilterName">方案名称</param>
        public frmFilter(List<Filter> pListFilter, string pFilterName, FormID pFormID)
        {
            InitializeComponent();
            _FilterName = pFilterName;
            _ListFilter = pListFilter;
            _FormID = pFormID;

            _Check = true;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFilter_Load(object sender, EventArgs e)
        {
            FillComboBox();
            SetComboBoxStatus();
            SetDataSource();
            SeletRow();
        }

        /// <summary>
        /// 设置方案数据源
        /// </summary>
        private void SetDataSource()
        {
            dgv1.DataSource = CommFunction.GetSolution(_FormID);
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            DataTable dtLeft, dtRight, dtField, dtCompare, dtValue, dtLogic;
            DataRow dr;
            foreach (Control ctl in sc1.Panel2.Controls)
            {
                if (ctl.Name.Contains("cbxLeft"))
                {
                    dtLeft = new DataTable();
                    dtLeft.Columns.Add("FName");
                    dtLeft.Columns.Add("FValue");

                    dr = dtLeft.NewRow();
                    dr["FName"] = "";
                    dr["FValue"] = "-1";
                    dtLeft.Rows.Add(dr);

                    dr = dtLeft.NewRow();
                    dr["FName"] = "  (";
                    dr["FValue"] = "1";
                    dtLeft.Rows.Add(dr);
                    dr = dtLeft.NewRow();
                    dr["FName"] = " ((";
                    dr["FValue"] = "2";
                    dtLeft.Rows.Add(dr);
                    dr = dtLeft.NewRow();
                    dr["FName"] = "(((";
                    dr["FValue"] = "3";
                    dtLeft.Rows.Add(dr);

                    ((ComboBox)ctl).DataSource = dtLeft;
                    ((ComboBox)ctl).DisplayMember = "FName";
                    ((ComboBox)ctl).ValueMember = "FValue";
                }
                else if (ctl.Name.Contains("cbxRight"))
                {
                    dtRight = new DataTable();
                    dtRight.Columns.Add("FName");
                    dtRight.Columns.Add("FValue");

                    dr = dtRight.NewRow();
                    dr["FName"] = "";
                    dr["FValue"] = "-1";
                    dtRight.Rows.Add(dr);

                    dr = dtRight.NewRow();
                    dr["FName"] = ")";
                    dr["FValue"] = "1";
                    dtRight.Rows.Add(dr);
                    dr = dtRight.NewRow();
                    dr["FName"] = "))";
                    dr["FValue"] = "2";
                    dtRight.Rows.Add(dr);
                    dr = dtRight.NewRow();
                    dr["FName"] = ")))";
                    dr["FValue"] = "3";
                    dtRight.Rows.Add(dr);

                    ((ComboBox)ctl).DataSource = dtRight;
                    ((ComboBox)ctl).DisplayMember = "FName";
                    ((ComboBox)ctl).ValueMember = "FValue";
                }
                else if (ctl.Name.Contains("cbxField"))
                {
                    switch(_FormID)
                    {
                        case FormID.SAL_SaleOrder:
                        case FormID.SAL_SaleOrderRun://销售订单
                            {
                                dtField = new DataTable();
                                dtField.Columns.Add("FName");
                                dtField.Columns.Add("FValue");

                                dr = dtField.NewRow();
                                dr["FName"] = "";
                                dr["FValue"] = "-1";
                                dtField.Rows.Add(dr);

                                dr = dtField.NewRow();
                                dr["FName"] = "日期";
                                dr["FValue"] = "A.FDATE";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "审核日期";
                                dr["FValue"] = "A.FAPPROVEDATE";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "计划开工日期";
                                dr["FValue"] = "AE.FPLANSTARTDATE";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "单据编号";
                                dr["FValue"] = "A.FBILLNO";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "物料编码";
                                dr["FValue"] = "MTL.FNumber";
                                dtField.Rows.Add(dr);//5

                                dr = dtField.NewRow();
                                dr["FName"] = "物料名称";
                                dr["FValue"] = "MTLL.FNAME";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "关联采购/生产数量";
                                dr["FValue"] = "AR.FPURJOINQTY";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "销售组织";
                                dr["FValue"] = "A.FSALEORGID";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "生产组织";
                                dr["FValue"] = "A.F_PAEZ_FACTORGID";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "库存组织";
                                dr["FValue"] = "AE.FSTOCKORGID";
                                dtField.Rows.Add(dr);//10

                                dr = dtField.NewRow();
                                dr["FName"] = "完全锁库";
                                dr["FValue"] = "A.FFULLLOCK";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "业务终止";
                                dr["FValue"] = "AE.FMRPTERMINATESTATUS";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "批量锁库标识";
                                dr["FValue"] = "AE.FBATCHFLAG";
                                dtField.Rows.Add(dr);

                                ((ComboBox)ctl).DataSource = dtField;
                                ((ComboBox)ctl).DisplayMember = "FName";
                                ((ComboBox)ctl).ValueMember = "FValue";
                            }
                            break;
                        case FormID.STK_TransferDirect://调拨单
                            {
                                dtField = new DataTable();
                                dtField.Columns.Add("FName");
                                dtField.Columns.Add("FValue");

                                dr = dtField.NewRow();
                                dr["FName"] = "";
                                dr["FValue"] = "-1";
                                dtField.Rows.Add(dr);

                                dr = dtField.NewRow();
                                dr["FName"] = "日期";
                                dr["FValue"] = "O.FDATE";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "审核日期";
                                dr["FValue"] = "O.FAPPROVEDATE";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "单据编号";
                                dr["FValue"] = "O.FBILLNO";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "销售组织";
                                dr["FValue"] = "O.FSALEORGID";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "单据类型";
                                dr["FValue"] = "O.FBILLTYPEID";
                                dtField.Rows.Add(dr);

                                dr = dtField.NewRow();
                                dr["FName"] = "发货类别";
                                dr["FValue"] = "O.FHEADDELIVERYWAY";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "物料代码";
                                dr["FValue"] = "MTL.FNUMBER";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "物料名称";
                                dr["FValue"] = "MTLL.FNAME";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "完全锁库";
                                dr["FValue"] = "O.FFULLLOCK";
                                dtField.Rows.Add(dr);
                                dr = dtField.NewRow();
                                dr["FName"] = "通知单数>锁库调拨数";
                                dr["FValue"] = "OER.FBASEDELIQTY>OE.F_PAEZ_LOCKALLOTQTY";
                                dtField.Rows.Add(dr);

                                ((ComboBox)ctl).DataSource = dtField;
                                ((ComboBox)ctl).DisplayMember = "FName";
                                ((ComboBox)ctl).ValueMember = "FValue";
                            }
                            break;
                        default:
                            {
                                //默认
                            }
                            break;
                    }
                }
                else if (ctl.Name.Contains("cbxCompare"))
                {
                    dtCompare = new DataTable();
                    dtCompare.Columns.Add("FName");
                    dtCompare.Columns.Add("FValue");

                    dr = dtCompare.NewRow();
                    dr["FName"] = "";
                    dr["FValue"] = "-1";
                    dtCompare.Rows.Add(dr);

                    dr = dtCompare.NewRow();
                    dr["FName"] = "等于";
                    dr["FValue"] = "=";
                    dtCompare.Rows.Add(dr);
                    dr = dtCompare.NewRow();
                    dr["FName"] = "不等于";
                    dr["FValue"] = "<>";
                    dtCompare.Rows.Add(dr);
                    dr = dtCompare.NewRow();
                    dr["FName"] = "大于";
                    dr["FValue"] = ">";
                    dtCompare.Rows.Add(dr);
                    dr = dtCompare.NewRow();
                    dr["FName"] = "大于等于";
                    dr["FValue"] = ">=";
                    dtCompare.Rows.Add(dr);
                    dr = dtCompare.NewRow();
                    dr["FName"] = "小于";
                    dr["FValue"] = "<";
                    dtCompare.Rows.Add(dr);//5
                    dr = dtCompare.NewRow();
                    dr["FName"] = "小于等于";
                    dr["FValue"] = "<=";
                    dtCompare.Rows.Add(dr);

                    dr = dtCompare.NewRow();
                    dr["FName"] = "包含";
                    dr["FValue"] = "LIKE";
                    dtCompare.Rows.Add(dr);
                    dr = dtCompare.NewRow();
                    dr["FName"] = "左包含";
                    dr["FValue"] = "LIKE";
                    dtCompare.Rows.Add(dr);
                    dr = dtCompare.NewRow();
                    dr["FName"] = "右包含";
                    dr["FValue"] = "LIKE";
                    dtCompare.Rows.Add(dr);
                    dr = dtCompare.NewRow();
                    dr["FName"] = "不包含";
                    dr["FValue"] = "NOT LIKE";
                    dtCompare.Rows.Add(dr);//10

                    ((ComboBox)ctl).DataSource = dtCompare;
                    ((ComboBox)ctl).DisplayMember = "FName";
                    ((ComboBox)ctl).ValueMember = "FValue";
                }
                else if (ctl.Name.Contains("cbxValue"))
                {
                    dtValue = CommFunction.GetOrganization(2);

                    ((ComboBox)ctl).DataSource = dtValue;
                    ((ComboBox)ctl).DisplayMember = "FName";
                    ((ComboBox)ctl).ValueMember = "FValue";
                }
                else if (ctl.Name.Contains("cbxLogic"))
                {
                    dtLogic = new DataTable();
                    dtLogic.Columns.Add("FName");
                    dtLogic.Columns.Add("FValue");

                    dr = dtLogic.NewRow();
                    dr["FName"] = "";
                    dr["FValue"] = "-1";
                    dtLogic.Rows.Add(dr);

                    dr = dtLogic.NewRow();
                    dr["FName"] = "并且";
                    dr["FValue"] = "AND";
                    dtLogic.Rows.Add(dr);
                    dr = dtLogic.NewRow();
                    dr["FName"] = "或者";
                    dr["FValue"] = "OR";
                    dtLogic.Rows.Add(dr);

                    ((ComboBox)ctl).DataSource = dtLogic;
                    ((ComboBox)ctl).DisplayMember = "FName";
                    ((ComboBox)ctl).ValueMember = "FValue";
                }
            }
        }

        /// <summary>
        /// 设置筛选状态
        /// </summary>
        private void SetComboBoxStatus()
        {
            if (ListFilter == null || ListFilter.Count == 0)
                return;
            int iTemp = 0;
            for (int i = 0; i < ListFilter.Count; i++)
            {
                if (!ListFilter[i].Validation) continue;//无效逻辑
                iTemp++;
                //左括号
                if (ListFilter[i].ParenthesesLeft > 0)
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxLeft" + iTemp, false)[0]).SelectedIndex = ListFilter[i].ParenthesesLeft;
                //右括号
                if (ListFilter[i].ParenthesesRight > 0)
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxRight" + iTemp, false)[0]).SelectedIndex = ListFilter[i].ParenthesesRight;
                //字段
                if (ListFilter[i].Field > 0)
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxField" + iTemp, false)[0]).SelectedIndex = ListFilter[i].Field;
                //比较
                if (ListFilter[i].Compare > 0)
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iTemp, false)[0]).SelectedIndex = ListFilter[i].Compare;
                //逻辑
                if (ListFilter[i].Logic > 0)
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxLogic" + iTemp, false)[0]).SelectedIndex = ListFilter[i].Logic;

                //值
                if (ListFilter[i].Field > 0)
                {
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iTemp, false)[0]).SelectedIndex = ListFilter[i].FilterValue.FilterIndex;
                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iTemp, false)[0]).Text = ListFilter[i].FilterValue.FilterText;
                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iTemp, false)[0]).Value = ListFilter[i].FilterValue.FilterDateTime;
                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iTemp, false)[0]).Checked = ListFilter[i].FilterValue.FilterCheck;
                }
            }
        }

        /// <summary>
        /// 定位方案名
        /// </summary>
        private void SeletRow()
        {
            if (_FilterName.Equals(string.Empty)) return;
            if (dgv1 == null || dgv1.Rows.Count == 0) return;

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1.Rows[i].Cells[0].Value.ToString().Contains(_FilterName))
                {
                    dgv1.ClearSelection();
                    dgv1.Rows[i].Selected = true;
                    dgv1.CurrentCell = dgv1.Rows[i].Cells[2];
                    break;
                }
            }

            Text = "过滤条件 - " + _FilterName;
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            ListFilter = CheckLogic(true);
            if (!_Check)
                return;
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 过滤条件逻辑检验
        /// </summary>
        /// <param name="pShowMessageBox">是否提示</param>
        /// <returns></returns>
        private List<Filter> CheckLogic(bool pShowMessageBox)
        {
            List<Filter> ListFilterNew = new List<Filter>();
            Filter entry;
            int iLeft = 0, iRight = 0;

            for (int i = 0; i < 15; i++)
            {
                entry = new Filter();

                entry.ParenthesesLeft = ((ComboBox)sc1.Panel2.Controls.Find("cbxLeft" + (i + 1).ToString(), false)[0]).SelectedIndex;
                entry.ParenthesesRight = ((ComboBox)sc1.Panel2.Controls.Find("cbxRight" + (i + 1).ToString(), false)[0]).SelectedIndex;
                entry.Field = ((ComboBox)sc1.Panel2.Controls.Find("cbxField" + (i + 1).ToString(), false)[0]).SelectedIndex;
                entry.Compare = ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + (i + 1).ToString(), false)[0]).SelectedIndex;
                entry.Logic = ((ComboBox)sc1.Panel2.Controls.Find("cbxLogic" + (i + 1).ToString(), false)[0]).SelectedIndex;

                entry.FilterValue = new FilterValue(((TextBox)sc1.Panel2.Controls.Find("txtValue" + (i + 1).ToString(), false)[0]).Text.Trim(), ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + (i + 1).ToString(), false)[0]).Value, ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + (i + 1).ToString(), false)[0]).SelectedIndex, ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + (i + 1).ToString(), false)[0]).Checked);

                if ((entry.Field > 0 && entry.Compare > 0) || (entry.Field == 9 || entry.Field == 10))//复选框可以没有比较逻辑
                {
                    iLeft += entry.ParenthesesLeft;
                    iRight += entry.ParenthesesRight;
                    entry.Validation = true;
                    ListFilterNew.Add(entry);
                }
            }
            //判断逻辑是否合法
            if (iLeft != iRight)
            {
                if (pShowMessageBox)
                    MessageBox.Show("逻辑检验失败：左右括号数量不一致。");
                _Check = false;
                return ListFilter;
            }
            _Check = true;
            return ListFilterNew;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// btnSave_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Text != "过滤条件")
                _FilterName = Text.Substring(7);
            if (_FilterName.Equals(string.Empty))
            {
                SaveAs();
            }
            else
            {
                Save();
            }
        }

        /// <summary>
        /// btnSaveAs_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        /// <summary>
        /// 保存方案
        /// </summary>
        private void Save()
        {
            ListFilter = CheckLogic(false);
            string sContent = string.Empty;
            int iRows = 0;
            for (int i = 0; i < ListFilter.Count; i++)
            {
                if (ListFilter[i].Validation)
                {
                    sContent += "[" + ListFilter[i].ParenthesesLeft.ToString() + "|" + ListFilter[i].Field.ToString() + "|" + ListFilter[i].Compare.ToString() + "|" + ListFilter[i].FilterValue.FilterDateTime.ToString() + "|" + ListFilter[i].FilterValue.FilterText.ToString() + "|" + ListFilter[i].FilterValue.FilterIndex.ToString() + "|" + (ListFilter[i].FilterValue.FilterCheck ? "1" : "0") + "|" + ListFilter[i].ParenthesesRight.ToString() + "|" + ListFilter[i].Logic.ToString() + "]";
                    iRows++;
                }
            }
            if (sContent.Equals(string.Empty)) sContent = " ";

            CommFunction.UpdateSolution(_FilterName, sContent, iRows);
            MessageBox.Show("[" + _FilterName + "]修改成功！");
        }

        /// <summary>
        /// 另存方案
        /// </summary>
        private void SaveAs()
        {
            ListFilter = CheckLogic(false);
            if (ListFilter == null || ListFilter.Count == 0)
            {
                MessageBox.Show("过滤条件为空或逻辑有误");
                return;
            }

            frmAddFilter frm = new frmAddFilter(ListFilter, _FormID);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                _FilterName = frm.FilterName;
                MessageBox.Show("保存成功");
                SetDataSource();
                SeletRow();
            }
        }

        /// <summary>
        /// 删除方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv1.DataSource == null || dgv1.Rows.Count == 0) return;
            _FilterName = dgv1.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("是否删除方案：" + _FilterName, "删除方案", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //添加限制，不能删除他人的方案。
                string strCreator = CommFunction.GetSolution(_FilterName).Rows[0]["Creator"].ToString();
                if (Model.Globa.GlobalParameter.K3Inf.UserName != "Administrator" && Model.Globa.GlobalParameter.K3Inf.UserName != strCreator)
                {
                    MessageBox.Show("只能删除自己创建的方案。");
                    return;
                }

                CommFunction.DelSolution(_FilterName);
                SetDataSource();
                _FilterName = string.Empty;
                Text = "过滤条件";
            }
        }

        /// <summary>
        /// 下拉框响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSeq = int.Parse((((ComboBox)sender).Name.Substring(8)));
            switch (_FormID)
            {
                case FormID.SAL_SaleOrder:
                case FormID.SAL_SaleOrderRun://销售订单
                    {
                        switch (((ComboBox)sender).SelectedIndex)
                        {
                            case 1:
                            case 2:
                            case 3:
                                {
                                    //日期
                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = true;

                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = false;
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                                {
                                    //文本
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                            case 8:
                            case 9:
                            case 10:
                                {
                                    //组织下拉框
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).DataSource = CommFunction.GetOrganization(2);
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                            case 11:
                            case 12:
                            case 13:
                                {
                                    //复选框
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = false;
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = false;
                                }
                                break;
                            case 14:
                                {
                                    //单据类型下拉框
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).DataSource = CommFunction.GetBillType("SAL_SALEORDER");
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                            default:
                                {
                                    //文本
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                        }
                    }
                    break;
                case FormID.STK_TransferDirect://调拨单
                    {
                        switch (((ComboBox)sender).SelectedIndex)
                        {
                            case 1:
                            case 2:
                                {
                                    //日期
                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = true;

                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = false;
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                            case 3:
                            case 7:
                            case 8:
                                {
                                    //文本
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                            case 4:
                                {
                                    //组织下拉框
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).DataSource = CommFunction.GetOrganization(2);
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                            case 5:
                                {
                                    //单据类型下拉框
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).DataSource = CommFunction.GetBillType("SAL_SALEORDER");
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                            case 6:
                                {
                                    //发货类别下拉框
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).DataSource = CommFunction.GetAssistantDataEntryByFID("801e1892b8824299936cb07c1fd1694d");
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                            case 9:
                            case 10:
                                {
                                    //复选框
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = false;
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = false;
                                }
                                break;
                            default:
                                {
                                    //文本
                                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Visible = true;

                                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Visible = false;
                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).Visible = false;
                                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Visible = false;

                                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).Visible = true;
                                }
                                break;
                        }
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
        }

        #region 清除过滤条件
        /// <summary>
        /// 清除所有条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in sc1.Panel2.Controls)
            {
                if (ctl.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)ctl).SelectedIndex = 0;
                }
                else if (ctl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctl).Text = string.Empty;
                }
                else if (ctl.GetType() == typeof(DateTimePicker))
                {
                    ((DateTimePicker)ctl).Value = DateTime.Now;
                }
                else if (ctl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)ctl).Checked = false;
                }
            }

            _FilterName = string.Empty;
        }

        /// <summary>
        /// 清除当前行的条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Row(object sender, EventArgs e)
        {
            int iSeq = int.Parse((((Button)sender).Name.Substring(8)));

            //左括号
            ((ComboBox)sc1.Panel2.Controls.Find("cbxLeft" + iSeq, false)[0]).SelectedIndex = 0;
            //右括号
            ((ComboBox)sc1.Panel2.Controls.Find("cbxRight" + iSeq, false)[0]).SelectedIndex = 0;
            //字段
            ((ComboBox)sc1.Panel2.Controls.Find("cbxField" + iSeq, false)[0]).SelectedIndex = 0;
            //比较
            ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + iSeq, false)[0]).SelectedIndex = 0;
            //逻辑
            ((ComboBox)sc1.Panel2.Controls.Find("cbxLogic" + iSeq, false)[0]).SelectedIndex = 0;

            //值
            ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + iSeq, false)[0]).SelectedIndex = 0;
            ((TextBox)sc1.Panel2.Controls.Find("txtValue" + iSeq, false)[0]).Text = string.Empty;
            ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + iSeq, false)[0]).Value = DateTime.Now;
            ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + iSeq, false)[0]).Checked = false;

            _FilterName = string.Empty;
        }
        #endregion

        /// <summary>
        /// 双击方案填充过滤条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            //DataTable dtContent = new DataTable();
            //_FilterName = dgv1.CurrentRow.Cells[0].Value.ToString();//获取方案名

            //dtContent = CommonFunction.GetSolution(_FilterName);
            //int iRows = int.Parse(dtContent.Rows[0]["SROWS"].ToString());
            //string sContent = dtContent.Rows[0]["SCONTENT"].ToString(), tmp;

            //if (iRows == 0) return;//没有过滤条件

            //for (int i = 0; i < 15; i++)
            //{
            //    if (i < iRows)//根据方案填充过滤条件
            //    {
            //        tmp = sContent.Substring(1, sContent.IndexOf("]") - 1);

            //        //左括号
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxLeft" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, 1));
            //        tmp = tmp.Substring(2);
            //        //字段
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxField" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, tmp.IndexOf("|")));
            //        tmp = tmp.Substring(tmp.IndexOf("|") + 1);
            //        //比较
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, tmp.IndexOf("|")));
            //        tmp = tmp.Substring(tmp.IndexOf("|") + 1);
            //        //值
            //        ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + (i + 1), false)[0]).Value = DateTime.Parse(tmp.Substring(0, tmp.IndexOf("|")));
            //        tmp = tmp.Substring(tmp.IndexOf("|") + 1);
            //        ((TextBox)sc1.Panel2.Controls.Find("txtValue" + (i + 1), false)[0]).Text = tmp.Substring(0, tmp.IndexOf("|"));
            //        tmp = tmp.Substring(tmp.IndexOf("|") + 1);
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, tmp.IndexOf("|")));
            //        tmp = tmp.Substring(tmp.IndexOf("|") + 1);
            //        ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + (i + 1), false)[0]).Checked = tmp.Substring(0, tmp.IndexOf("|")) == "1" ? true : false;
            //        tmp = tmp.Substring(tmp.IndexOf("|") + 1);
            //        //右括号
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxRight" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, 1));
            //        tmp = tmp.Substring(2);
            //        //逻辑
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxLogic" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp);

            //        sContent = sContent.Substring(sContent.IndexOf("]") + 1);
            //    }
            //    else//删除多余的过滤条件
            //    {
            //        //左括号
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxLeft" + (i + 1), false)[0]).SelectedIndex = 0;
            //        //字段
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxField" + (i + 1), false)[0]).SelectedIndex = 0;
            //        //比较
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + (i + 1), false)[0]).SelectedIndex = 0;
            //        //值
            //        ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + (i + 1), false)[0]).Value = DateTime.Now;
            //        ((TextBox)sc1.Panel2.Controls.Find("txtValue" + (i + 1), false)[0]).Text = string.Empty;
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + (i + 1), false)[0]).SelectedIndex = 0;
            //        ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + (i + 1), false)[0]).Checked = false;
            //        //右括号
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxRight" + (i + 1), false)[0]).SelectedIndex = 0;
            //        //逻辑
            //        ((ComboBox)sc1.Panel2.Controls.Find("cbxLogic" + (i + 1), false)[0]).SelectedIndex = 0;
            //    }
            //}

            //Text = "过滤条件 - " + _FilterName;
        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            DataTable dtContent = new DataTable();
            _FilterName = dgv1.CurrentRow.Cells[0].Value.ToString();//获取方案名

            dtContent = CommFunction.GetSolution(_FilterName);
            int iRows = int.Parse(dtContent.Rows[0]["SROWS"].ToString());
            string sContent = dtContent.Rows[0]["SCONTENT"].ToString(), tmp;

            if (iRows == 0) return;//没有过滤条件

            for (int i = 0; i < 15; i++)
            {
                if (i < iRows)//根据方案填充过滤条件
                {
                    tmp = sContent.Substring(1, sContent.IndexOf("]") - 1);

                    //左括号
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxLeft" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, 1));
                    tmp = tmp.Substring(2);
                    //字段
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxField" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, tmp.IndexOf("|")));
                    tmp = tmp.Substring(tmp.IndexOf("|") + 1);
                    //比较
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, tmp.IndexOf("|")));
                    tmp = tmp.Substring(tmp.IndexOf("|") + 1);
                    //值
                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + (i + 1), false)[0]).Value = DateTime.Parse(tmp.Substring(0, tmp.IndexOf("|")));
                    tmp = tmp.Substring(tmp.IndexOf("|") + 1);
                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + (i + 1), false)[0]).Text = tmp.Substring(0, tmp.IndexOf("|"));
                    tmp = tmp.Substring(tmp.IndexOf("|") + 1);
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, tmp.IndexOf("|")));
                    tmp = tmp.Substring(tmp.IndexOf("|") + 1);
                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + (i + 1), false)[0]).Checked = tmp.Substring(0, tmp.IndexOf("|")) == "1" ? true : false;
                    tmp = tmp.Substring(tmp.IndexOf("|") + 1);
                    //右括号
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxRight" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp.Substring(0, 1));
                    tmp = tmp.Substring(2);
                    //逻辑
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxLogic" + (i + 1), false)[0]).SelectedIndex = int.Parse(tmp);

                    sContent = sContent.Substring(sContent.IndexOf("]") + 1);
                }
                else//删除多余的过滤条件
                {
                    //左括号
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxLeft" + (i + 1), false)[0]).SelectedIndex = 0;
                    //字段
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxField" + (i + 1), false)[0]).SelectedIndex = 0;
                    //比较
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxCompare" + (i + 1), false)[0]).SelectedIndex = 0;
                    //值
                    ((DateTimePicker)sc1.Panel2.Controls.Find("dtpValue" + (i + 1), false)[0]).Value = DateTime.Now;
                    ((TextBox)sc1.Panel2.Controls.Find("txtValue" + (i + 1), false)[0]).Text = string.Empty;
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxValue" + (i + 1), false)[0]).SelectedIndex = 0;
                    ((CheckBox)sc1.Panel2.Controls.Find("chbValue" + (i + 1), false)[0]).Checked = false;
                    //右括号
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxRight" + (i + 1), false)[0]).SelectedIndex = 0;
                    //逻辑
                    ((ComboBox)sc1.Panel2.Controls.Find("cbxLogic" + (i + 1), false)[0]).SelectedIndex = 0;
                }
            }

            Text = "过滤条件 - " + _FilterName;
        }
    }
}
