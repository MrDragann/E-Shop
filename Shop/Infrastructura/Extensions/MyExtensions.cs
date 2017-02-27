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
        /// <summary>
        /// Разбиение строки по запятым и пробелам
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] SplitString(this string str)
        {
            return str.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
        }
        /// <summary>
        /// Получение рандомной строки
        /// </summary>
        /// <returns></returns>
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