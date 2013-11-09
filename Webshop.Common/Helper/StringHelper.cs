using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Webshop.Common.Helper
{
    public static class StringHelper
    {
        public static string NicifyString(string title)
        {
            if (String.IsNullOrEmpty(title)) return "";

            // remove entities
            title = Regex.Replace(title, @"&\w+;", "");
            // remove anything that is not letters, numbers, dash, or space
            title = Regex.Replace(title, @"[^A-Za-z0-9\-\s]", "");
            // remove any leading or trailing spaces left over
            title = title.Trim();
            // replace spaces with single dash
            title = Regex.Replace(title, @"\s+", "_");
            // if we end up with multiple dashes, collapse to single dash            
            title = Regex.Replace(title, @"_{2,}", "_");
            // make it all lower case
            title = title.ToLower();
            // if it's too long, clip it
            if (title.Length > 80)
                title = title.Substring(0, 79);
            // remove trailing dash, if there is one
            if (title.EndsWith("_"))
                title = title.Substring(0, title.Length - 1);
            return title;
        }

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