using IServices;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IServices.Models;
using System.Linq.Expressions;

namespace Services
{
    public class ProductServices : IProductServices
    {
        public List<Product> GetProducts()
        {
            using(var db = new DataContext())
            {
                var products = db.Products.Select(selector()).ToList();
                return products;
            }
        }

        public static Expression<Func<Product, ModelProductPreview>> selector()
        {
            return product => new ModelProductPreview()
            {
                Id = product.Id
            };
        }
    }
}
