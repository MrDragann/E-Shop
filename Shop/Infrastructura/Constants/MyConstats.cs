using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Infrastructura.Constants
{
    /// <summary>
    /// Класс содержащий константы
    /// </summary>
    public static class MyConstats
    {
        /// <summary>
        /// Путь к папке с изображениями товаров
        /// </summary>
        public const string PathToProducts = "/Content/Images/home/Products/";
        /// <summary>
        /// Количество на одной странице
        /// </summary>
        public static int PageSize = 2;
        /// <summary>
        /// Номер страницы
        /// </summary>
        /// <value>Номер страницы</value>
        public static int PageNum { get; set; }
        /// <summary>
        /// Размер коллекции товаров
        /// </summary>
        /// <value>Размер коллекции</value>
        public static int ItemsCount { get; set; }
    }
}