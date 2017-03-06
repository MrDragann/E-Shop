using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Shop.Helpers
{
    public static class Paging
    {
        /// <summary>
        /// Метод организации постраничного вывода
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="PageNum"></param>
        /// <param name="ItemsCount"></param>
        /// <param name="PageSize"></param>
        /// <returns>Элементы списка с ссылками на страницы</returns>
        public static MvcHtmlString PagingNav(this HtmlHelper helper, int PageNum, int ItemsCount, int PageSize, string Sort)
        {
            /// Получение количества страниц
            int PagesCount = (int)Math.Ceiling((double)ItemsCount / PageSize);
            StringBuilder sb = new StringBuilder();
            if (PageNum > 0)
            {
                sb.Append("<li>" + helper.ActionLink("«", "upProducts", new { pageNum = PageNum - 1, sort = Sort }) + "</li>");
            }
            else
            {
                sb.Append("<li class='disabled'><a>«</a></li>");
            }

            for(int i = 0; i < PagesCount; i++)
            {
                sb.Append("<li>" + helper.ActionLink((i+1).ToString(), "upProducts", new { pageNum = i, sort = Sort }) + "</li>");
            }

            if (PageNum < PagesCount - 1) 
            {
                sb.Append("<li>" + helper.ActionLink("»", "upProducts", new { pageNum = PageNum + 1, sort = Sort }) + "</li>");
            }
            else
            {
                sb.Append("<li class='disabled'><a>»</a></li>");
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        /// <summary>
        /// Метод организации постраничного вывода
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="PageNum"></param>
        /// <param name="ItemsCount"></param>
        /// <param name="PageSize"></param>
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