
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    class ToolStripDateTimePicker : ToolStripControlHost
    {
        public ToolStripDateTimePicker() : base(new DateTimePicker())
        {
        }
    }
}
