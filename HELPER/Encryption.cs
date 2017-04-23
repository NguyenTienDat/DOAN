using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
namespace HELPER
{
    public class Encryption
    {
        public static string Md5(string strChange)
        {
            byte[] pass = Encoding.UTF8.GetBytes(strChange);
            MD5 md5 = new MD5CryptoServiceProvider();
            string strPassword = Encoding.UTF8.GetString(md5.ComputeHash(pass));
            return strPassword;
        } 
    }
}
