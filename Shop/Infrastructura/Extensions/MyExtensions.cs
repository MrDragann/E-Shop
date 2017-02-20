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

        public static string[] SplitString(this string str)
        {
            return str.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static List<int> StrToInt32(this string str)
        {
            List<int> list = null;
            var item = str.SplitString();
            for(int i = 0; i < str.Count(); i++)
            {
                list[i] = Convert.ToInt32(item[i]);
            }
            return list;
        }

        public static string GetSalt()
        {
            var random = new RNGCryptoServiceProvider();

            // Максимальная длина соли
            int max_length = 32;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
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