
namespace ERPSupport.SupForm.UserClass
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;

    /// <summary>
    /// 定义触发单击事件的委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void datagridviewcheckboxHeaderEventHander(object sender, datagridviewCheckboxHeaderEventArgs e);

    /// <summary>
    /// 定义包含列头checkbox选择状态的参数类
    /// </summary>
    public class datagridviewCheckboxHeaderEventArgs : EventArgs
    {
        private bool _checkedState = false;

        public bool CheckedState
        {
            get { return _checkedState; }
            set { _checkedState = value; }
        }
    }

    /// <summary>
    /// 定义继承于DataGridViewColumnHeaderCell的类，用于绘制checkbox，定义checkbox鼠标单击事件
    /// </summary>
    public class datagridviewCheckboxHeaderCell : DataGridViewColumnHeaderCell
    {
        private Point checkBoxLocation;
        private Size checkBoxSize;
        private bool _checked = false;
        private Point _cellLocation = new Point();
        private CheckBoxState _cbState = CheckBoxState.UncheckedNormal;
        public event datagridviewcheckboxHeaderEventHander OnCheckBoxClicked;

        //绘制列头checkbox
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics, CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X + (cellBounds.Width / 2) - (s.Width / 2) - 1;//列头checkbox的X坐标
            p.Y = cellBounds.Location.Y + (cellBounds.Height / 2) - (s.Height / 2);//列头checkbox的Y坐标
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = CheckBoxState.CheckedNormal;
            else
                _cbState = CheckBoxState.UncheckedNormal;

            CheckBoxRenderer.DrawCheckBox(graphics, checkBoxLocation, _cbState);
        }

        /// <summary>
        /// 点击列头checkbox单击事件
        /// </summary>
        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <= checkBoxLocation.X + checkBoxSize.Width && p.Y >= checkBoxLocation.Y && p.Y <= checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                //获取列头checkbox的选择状态
                datagridviewCheckboxHeaderEventArgs ex = new datagridviewCheckboxHeaderEventArgs();
                ex.CheckedState = _checked;

                object sender = new object();//此处不代表选择的列头checkbox，只是作为参数传递。应该列头checkbox是绘制出来的，无法获得它的实例

                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(sender, ex);//触发单击事件
                    DataGridView.InvalidateCell(this);
                }
            }
            base.OnMouseClick(e);
        }
    }
}