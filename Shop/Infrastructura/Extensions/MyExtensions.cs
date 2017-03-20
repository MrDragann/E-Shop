using IServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Содержит классы расширения
/// </summary>
namespace Shop.Infrastructura.Extensions
{
    /// <summary>
    /// Класс с расширениями
    /// </summary>
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
        /// <summary>
        /// Описание статуса заказа
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public string EnumOrderDescription(this ModelEnumStatusOrder value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(false)
                .First() as DescriptionAttribute;

            return attribute.Description;
        }
        /// <summary>
        /// Описание статуса пользователя
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public string EnumUserDescription(this ModelEnumStatusUser value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(false)
                .First() as DescriptionAttribute;

            return attribute.Description;
        }
    }


    /// <summary>
    /// Параметры для сортировки
    /// </summary>
    public enum TypeSort
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }
}