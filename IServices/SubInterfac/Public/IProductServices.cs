using DataModel;
using IServices.Models;
using IServices.Models.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IProductServices
    {
        /// <summary>
        /// Вывод частичной информации о товарах
        /// </summary>
        /// <returns></returns>
        List<ModelProductPreview> ProductsPreview();
        /// <summary>
        /// Вывод полной информации о товарах
        /// </summary>
        /// <returns></returns>
        List<ModelProduct> ProductsDetails();
        //List<ModelProduct> GetOrderProducts(OrderProduct model);
        string GetCategoryName(int id);
        ModelCategories GetCategory();
        /// <summary>
        /// Вывод списка производителей
        /// </summary>
        /// <returns></returns>
        List<ModelManufacturer> GetManufacturers();

        ModelProduct GetProduct(int id);
    }
}
