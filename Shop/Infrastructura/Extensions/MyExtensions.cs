using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Shop.Infrastructura.Extensions
{
    public static class MyExtensions
    {

        public static string GetHashString(this string s)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(s), 0, Encoding.UTF8.GetByteCount(s));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }


        public static string[] Split(this string str)
        {
            return str.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
        }
    }


    public enum TypeSort
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }
}