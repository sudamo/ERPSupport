using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace ERPSupport.SupForm.Utility
{
    public class PasswordUtility
    {
        /// <summary>
        /// 密码长度小于八位、纯数字、全小写英文、全大写英文等非常弱组合的密码不会通过。
        /// </summary>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public static bool PasswordLength(string pPassword)
        {
            if (pPassword.Length < 8)
                return false;

            if (0 - Convert.ToInt32(Regex.IsMatch(pPassword, "[a-z]")) - Convert.ToInt32(Regex.IsMatch(pPassword, "[A-Z]"))
                - Convert.ToInt32(Regex.IsMatch(pPassword, "\\d")) - Convert.ToInt32(Regex.IsMatch(pPassword, ".{10,}")) <= -2)
                return true;
            else
                return false;
        }

        #region 对称算法 AES(Rjindael)--DES,3DES,RC2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPlainText"></param>
        /// <param name="pKey"></param>
        /// <param name="pIV"></param>
        /// <returns></returns>
        public static string AESEncryptor(string pPlainText, byte[] pKey, byte[] pIV)
        {
            byte[] data = Encoding.ASCII.GetBytes(pPlainText);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            string encryptedString = Convert.ToBase64String(aes.CreateEncryptor(pKey, pIV).TransformFinalBlock(data, 0, data.Length));
            return encryptedString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEncryptedString"></param>
        /// <param name="pKey"></param>
        /// <param name="pIV"></param>
        /// <returns></returns>
        public static string AESDecryptor(string pEncryptedString, byte[] pKey, byte[] pIV)
        {
            byte[] data = Convert.FromBase64String(pEncryptedString);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            string decryptedString = Encoding.ASCII.GetString(aes.CreateDecryptor(pKey, pIV).TransformFinalBlock(data, 0, data.Length));
            return decryptedString;
        }
        #endregion

        #region 非对称算法 RSA
        #endregion

        #region 哈希算法 MD5,SHA256,SHA512--SHA1,SHA384(建议使用Guid+PlaniText一起加密)
        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="pString"></param>
        /// <returns></returns>
        public static string MD5Encryptor(string pString)
        {
            string strPWD = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.Default.GetBytes(pString));

            //Method 1
            for (int i = 0; i < s.Length; i++)
                strPWD += s[i].ToString("x2");

            ////Method 2
            //strPWD = BitConverter.ToString(s).Replace("-", "");

            return strPWD;
        }
        /// <summary>
        /// SHA256
        /// </summary>
        /// <param name="pPlainText"></param>
        /// <returns></returns>
        public static string SHA256Encryptor(string pPlainText)
        {
            byte[] data = Encoding.ASCII.GetBytes(pPlainText);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] result = sha256.ComputeHash(data);
            return Convert.ToBase64String(result);
        }
        /// <summary>
        /// SHA512
        /// </summary>
        /// <param name="pPlainText"></param>
        /// <returns></returns>
        public static string SHA512Encryptor(string pPlainText)
        {
            byte[] data = Encoding.ASCII.GetBytes(pPlainText);
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            byte[] result = sha512.ComputeHash(data);
            return Convert.ToBase64String(result);
        }
        #endregion
    }
}
