﻿using System;
using System.Xml;
using System.Configuration;

namespace ERPSupport.SupForm.UserClass
{
    /// <summary>
    /// App.config文件操作
    /// </summary>
    public static class AppConfig
    {
        static AppConfig() { }

        /// <summary>
        /// 根据key读取value
        /// </summary>
        /// <param name="pKey">key</param>
        /// <param name="pType">AppSettings/connectionStrings</param>
        /// <returns></returns>
        public static string ReadValue(string pKey, string pType)
        {
            if (pType == "AppSettings")
            {
                if(pKey.Contains("_PWD"))
                {
                    string strValue = ConfigurationManager.AppSettings[pKey];
                    return DMData.Code.DataEncoder.DecryptData(strValue);
                }
                return ConfigurationManager.AppSettings[pKey];
            }
            return ConfigurationManager.ConnectionStrings[pKey].ToString();
        }

        /// <summary>
        /// 根据字段写入值-App.config
        /// </summary>
        /// <param name="pKey">key</param>
        /// <param name="pValue">value</param>
        public static void WriteValue(string pKey, string pValue)
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径
            string strFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            // string  strFileName= AppDomain.CurrentDomain.BaseDirectory + "\\exe.config";
            doc.Load(strFileName);
            //找出名称为“add”的所有元素
            XmlNodeList nodes = doc.GetElementsByTagName("add");
            for (int i = 0; i < nodes.Count; i++)
            {
                //获得将当前元素的key属性
                XmlAttribute att = nodes[i].Attributes["key"];
                //根据元素的第一个属性来判断当前的元素是不是目标元素
                if (att.Value == pKey)
                {
                    //对目标元素中的第二个属性赋值
                    att = nodes[i].Attributes["value"];

                    if (pKey.Contains("_PWD"))//加密
                    {
                        att.Value = DMData.Code.DataEncoder.EncryptData(pValue);
                    }
                    else
                    {
                        att.Value = pValue;
                    }
                    break;
                }
            }
            //保存上面的修改
            doc.Save(strFileName);
            ConfigurationManager.RefreshSection("appSettings");
        }

        ///// <summary>
        ///// 根据节点和字段写入值-Web.config
        ///// </summary>
        ///// <param name="item">节点</param>
        ///// <param name="key">字段</param>
        ///// <param name="value">值</param>
        //private static void WriteConfig(string item, string key, string value)
        //{
        //    if (item == "") item = "appSettings";

        //    Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(System.Web.HttpContext.Current.Request.ApplicationPath);
        //    AppSettingsSection appSection = (AppSettingsSection)config.GetSection(item);
        //    if (appSection.Settings[key] == null)
        //    {
        //        appSection.Settings.Add(key, value);
        //        config.Save();
        //    }
        //    else
        //    {
        //        appSection.Settings.Remove(key);
        //        appSection.Settings.Add(key, value);
        //        config.Save();
        //    }
        //}
    }
}
