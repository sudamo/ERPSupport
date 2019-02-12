using System;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserClass
{
    /// <summary>
    /// 
    /// </summary>
    internal class WinMessager : IMessageFilter
    {
        public static int iOperCount = 0;
        public bool PreFilterMessage(ref Message m)
        {
            //如果检测到有鼠标或则键盘的消息，则使计数为0.....
            if (m.Msg == 0x0200 || m.Msg == 0x0201 || m.Msg == 0x0204 || m.Msg == 0x0207)
            {
                iOperCount = 0;
            }

            return false;
        }
    }
}
