using IServices;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices : IProductServices
    {
        public List<Product> GetProducts()
        {
            using(var db = new DataContext())
            {
                var products = db.Products.ToList();
                return products;
            }
        }
    }
}
