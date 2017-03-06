using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Infrastructura.Constants
{
    public static class MyConstats
    {
        public const string PathToProducts = "/Content/Images/home/Products/";
        /// <summary>
        /// Данные для постраничного вывода
        /// </summary>
        public static int PageSize = 2;
        public static int PageNum { get; set; }
        public static int ItemsCount { get; set; }
    }
}