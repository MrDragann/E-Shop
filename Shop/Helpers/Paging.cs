using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

/// <summary>
/// Содержит классы-хелперы
/// </summary>
namespace Shop.Helpers
{
    /// <summary>
    /// Class Paging.
    /// </summary>
    public static class Paging
    {
        /// <summary>
        /// Метод организации постраничного вывода заказов в админке
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="PageNum"></param>
        /// <param name="ItemsCount"></param>
        /// <param name="PageSize"></param>
        /// <returns>Элементы списка с ссылками на страницы</returns>
        public static MvcHtmlString OrdersPaging(this HtmlHelper helper, int PageNum, int ItemsCount, int PageSize = 5)
        {
            /// Получение количества страниц
            int PagesCount = (int)Math.Ceiling((double)ItemsCount / PageSize);
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='row'><div class='col-md-5 col-sm-5'>");
            sb.Append("</div><div class='col-md-7 col-sm-7'><div class='dataTables_paginate paging_bootstrap_full_number' id='sample_1_paginate'><ul class='pagination' style='visibility: visible;'>");
            if (PageNum > 0)
            {
                sb.Append("<li class='prev pageNav'> " + "<a value=" + "/Admin/Users/AjaxOrders/?pageNum=" + (PageNum - 1) + " >" + "<i class='fa fa-angle-left'></i>" + "</a>" + "</li>");
            }
            else
            {
                sb.Append("<li class='prev disabled'><a><i class='fa fa-angle-left'></i></a></li>");
            }

            for(int i = 0; i < PagesCount; i++)
            {
                sb.Append("<li class='pageNav'>" + "<a value="+"/Admin/Users/AjaxOrders/?pageNum="+i +" >"+(i+1)+"</a>" + "</li>");
            }

            if (PageNum < PagesCount - 1) 
            {
                sb.Append("<li class='next pageNav'>" + "<a value=" + "/Admin/Users/AjaxOrders/?pageNum=" + (PageNum + 1) + " >" + "<i class='fa fa-angle-right'></i>" + "</a>" + "</li>");
            }
            else
            {
                sb.Append("<li class='next disabled'><a><i class='fa fa-angle-right'></i></a></li>");
            }
            sb.Append("</ul></div></div></div>");
            return MvcHtmlString.Create(sb.ToString());
        }

        /// <summary>
        /// Метод организации постраничного вывода товаров в разделе категорий
        /// </summary>
        /// <param name="helper">Хелпер</param>
        /// <param name="PageNum">Номер страницы</param>
        /// <param name="ItemsCount">Размер коллекции товаров</param>
        /// <param name="PageSize">Количество на одной странице</param>
        /// <param name="Category">Выбранная категория</param>
        /// <param name="Sort">Параметр сортировки</param>
        /// <returns>Элементы списка с ссылками на страницы</returns>
        public static MvcHtmlString CategoryPaging(this HtmlHelper helper, int PageNum, int ItemsCount, int PageSize, string Category, string Sort)
        {
            int category = Convert.ToInt32(Category); 
            /// Получение количества страниц
            int PagesCount = (int)Math.Ceiling((double)ItemsCount / PageSize);
            StringBuilder sb = new StringBuilder();
            if (PageNum > 0)
            {
                sb.Append("<li>" + helper.ActionLink("«", "category", new { Category = category, pageNum = PageNum - 1, sort = Sort }) + "</li>");
            }
            else
            {
                sb.Append("<li ><a>«</a></li>");
            }

            for (int i = 0; i < PagesCount; i++)
            {
                sb.Append("<li>" + helper.ActionLink((i + 1).ToString(), "category", new { Category = category, pageNum = i, sort = Sort }) + "</li>");
            }

            if (PageNum < PagesCount - 1)
            {
                sb.Append("<li>" + helper.ActionLink("»", "category", new { Category = category, pageNum = PageNum + 1, sort = Sort }) + "</li>");
            }
            else
            {
                sb.Append("<li ><a>»</a></li>");
            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}