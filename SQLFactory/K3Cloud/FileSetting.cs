using System;
using System.IO;
using System.Text;

namespace ERPSupport.SQL.K3Cloud
{
    /// <summary>
    /// 文件操作方法 - 已弃用
    /// </summary>
    public static class FileSetting
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static FileSetting() { }

        /// <summary>
        /// 根据指定的路径和内容生成本地文件
        /// </summary>
        /// <param name="pFilePath">文件路径</param>
        /// <param name="pText">内容</param>
        public static void CreateLocalText(string pFilePath, string pText)
        {
            if (File.Exists(pFilePath))
                File.Delete(pFilePath);

            FileStream fs = new FileStream(pFilePath, FileMode.OpenOrCreate);
            byte[] fdate = Encoding.Default.GetBytes(pText);

            fs.Write(fdate, 0, fdate.Length);
            fs.Flush();
            fs.Close();
        }
    }
}
