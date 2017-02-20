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

        public static Expression<Func<Category, ModelCategory>> ShowCategory()
        {
            return category => new ModelCategory()
            {
                Id = category.Id,
                Name = category.Name,
                Parent = category.Parent,
                Products = category.Products,
                Сhild = category.Сhild,
                ParentId = category.ParentId
            };
        }

        public void AddCategory()
        {
            using (var db = new DataContext())
            {
                db.Categories.Add(new Category() {Name = "" });
                db.Categories.Add(new Category() { Name = "", ParentId = 1 });
                db.SaveChanges();
            }
        }

        public List<ModelCategory> GetCategory()
        {
            using (var db = new DataContext())
            {
                var categories = db.Categories.Select(ShowCategory()).Where(_ => !_.ParentId.HasValue).Include(_ => _.Сhild).Include(_ => _.Сhild.Select(c => c.Сhild)).ToList();
                return categories;
            }
        }

        public void UpdateCategory(int id)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.Include(_ => _.Сhild).FirstOrDefault(_ => _.Id == id);
                category.Сhild.Add(new Category() { Name = "sd1" });
                category.Сhild.Add(new Category() { Name = "sd2" });
                db.SaveChanges();

            }
        }

        public void UpdateCategoryParent(int parentId, string name)
        {
            using (var db = new DataContext())
            {
                db.Categories.Add(new Category() { Name = name, ParentId = parentId });
                db.SaveChanges();

            }
        }

        public void Update(int id, string name)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(_ => _.Id == id);
                category.Name = name;
                db.SaveChanges();
            }

        }

         public void Update2(int id, string name)
        {
            using (var db = new DataContext())
            {
                var category = new Category() { Id = id };
                db.Categories.Attach(category);
                category.Name = name;
                db.Entry(category).Property(_ => _.Name).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}
