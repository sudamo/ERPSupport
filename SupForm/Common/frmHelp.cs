using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ERPSupport.SupForm.Common
{
    /// <summary>
    /// 程序信息
    /// </summary>
    public partial class frmHelp : Form
    {
        /// <summary>
        /// 类型
        /// </summary>
        private int strType;
        /// <summary>
        /// 文本内容
        /// </summary>
        string strContext;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pType"></param>
        public frmHelp(int pType)
        {
            InitializeComponent();
            strType = pType;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHelp_Load(object sender, EventArgs e)
        {
            switch (strType)
            {
                case 1:
                    strContext = "开放使用中，无需注册。";
                    break;
                case 2:
                    strContext = "\n\r如需帮助请联系信息部。\n电话：020-62870908-";
                    break;
                case 3:
                    {
                        string strTitle, strDescription, strProduct, strCompany, strCopyRight, strConfiguration, strTradeMark, strFileVersion, strVersion;
                        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                        strTitle = ((AssemblyTitleAttribute)attributes[0]).Title.ToString();
                        attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                        strDescription = ((AssemblyDescriptionAttribute)attributes[0]).Description.ToString();
                        attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                        strProduct = ((AssemblyProductAttribute)attributes[0]).Product.ToString();
                        attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                        strCompany = ((AssemblyCompanyAttribute)attributes[0]).Company.ToString();
                        attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                        strCopyRight = ((AssemblyCopyrightAttribute)attributes[0]).Copyright.ToString();
                        attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false);
                        strConfiguration = ((AssemblyConfigurationAttribute)attributes[0]).Configuration.ToString();
                        attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false);
                        strTradeMark = ((AssemblyTrademarkAttribute)attributes[0]).Trademark.ToString();
                        attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
                        strFileVersion = ((AssemblyFileVersionAttribute)attributes[0]).Version.ToString();
                        strVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                        strContext = "\n\r          程序集信息\r 标题：" + strTitle + "\n 备注：" + strDescription + "\n 产品名称：" + strProduct + "\n 公司：" + strCompany + "\n 版权：" + strCopyRight + "\n 配置：" + strConfiguration + "\n 商标声明：" + strTradeMark + "\n 版本：" + strVersion + "\n 修订版本：" + strFileVersion;
                    }
                    break;
                case 4:
                    strContext = "\n\r          留言簿\n\r 试问江南应不好 却道 此心安处是吾乡 - 大漠\n\r 老猴聊发少年狂，左手抱，右手抗，香槟宝马，一任潇洒郎。\r 猴抓手，崂山酒，满厂春色任我搂。\r 东风恶，欢情薄，一怀愁绪，几年离索。\r 错，错，错。 - 小候\n\r 本系统由广州车邦汽车用品制造有限公司开发，版权归本公司所有。";
                    break;
                default:
                    strContext = "";
                    break;
            }
            rtbContext.Text = strContext;
            rtbContext.Font = new Font(rtbContext.Font.FontFamily, 10, rtbContext.Font.Style);
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}