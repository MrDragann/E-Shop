using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Shop.Infrastructura
{
    //public class Security
    //{
    //    public static Security Instance = new Security();

    //    public string GetHashString(string s)
    //    {
    //        //переводим строку в байт-массим  
    //        byte[] bytes = Encoding.Unicode.GetBytes(s);

    //        //создаем объект для получения средст шифрования  
    //        MD5CryptoServiceProvider CSP =
    //            new MD5CryptoServiceProvider();

    //        //вычисляем хеш-представление в байтах  
    //        byte[] byteHash = CSP.ComputeHash(bytes);

    //        string hash = string.Empty;

    //        //формируем одну цельную строку из массива  
    //        foreach (byte b in byteHash)
    //            hash += string.Format("{0:x2}", b);

    //        return hash;
    //    }

    //    public string GetSalt()
    //    {
    //        var random = new RNGCryptoServiceProvider();

    //        // Максимальная длина соли
    //        int max_length = 32;

    //        // Empty salt array
    //        byte[] salt = new byte[max_length];

    //        // Build the random bytes
    //        random.GetNonZeroBytes(salt);

    //        // Return the string encoded salt
    //        return Convert.ToBase64String(salt);
    //    }

    //    public string[] Split(string str)
    //    {
    //        return str.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
    //    }
    //}
}