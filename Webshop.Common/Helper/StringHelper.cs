using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Webshop.Common.Helper
{
    public static class StringHelper
    {
        public static string MD5(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = x.ComputeHash(data);
            String md5Hash = System.Text.Encoding.ASCII.GetString(data);

            return md5Hash;
        }
    }
}