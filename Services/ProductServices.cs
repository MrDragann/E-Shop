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
        public List<ModelProductPreview> ProductsPreview()
        {
            using(var db = new DataContext())
            {
                var products = db.Products.Select(Preview()).ToList();
                return products;
            }
        }

        public List<ModelProduct> ProductsDetails()
        {
            using(var db = new DataContext())
            {
                var products = db.Products.Select(Details()).ToList();
                return products;
            }
        }

        public static Expression<Func<Product, ModelProductPreview>> Preview()
        {
            return product => new ModelProductPreview()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                CategoryName = product.CategoryName,
                DateAdd = product.DateAdd
            };
        }

        public static Expression<Func<Product, ModelProduct>> Details()
        {
            return product => new ModelProduct()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryName = product.CategoryName,
                Description = product.Description,
                Characteristics = product.Characteristics,
                Tags = product.Tags,
                Image = product.Image,
                DateAdd = product.DateAdd
            };
        }
    }
}
