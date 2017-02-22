using IServices;
using DataModel;
using System;
using IServices.Models.Product;
using System.Collections.Generic;
using System.Linq;
using IServices.Models;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Services
{
    public class ProductServices : IProductServices
    {
        /// <summary>
        /// Вывод частичной информации о товарах
        /// </summary>
        /// <returns></returns>
        public List<ModelProductPreview> ProductsPreview()
        {
            using(var db = new DataContext())
            {
                var products = db.Products.Select(Preview()).ToList();
                return products;
            }
        }
        /// <summary>
        /// Вывод полной информации о товарах
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Вывод всех категорий
        /// </summary>
        /// <returns>Коллекция всех категорий</returns>
        public ModelCategories GetCategory()
        {
            using (var db = new DataContext())
            {
                var categories = db.Categories.ToList();
                return new ModelCategories { Categories = categories.Select(c => ConverModelCategory(c)).ToList() };
            }
        }

        private static ModelCategory ConverModelCategory(Category category)
        {

            return new ModelCategory
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,

            };
        }
        //public static List<Category> GetCategories()
        //{
        //    using (var db = new DataContext())
        //    {
        //        var categories = db.Categories.Where(_ => !_.ParentId.HasValue).Include(_ => _.Сhild).ToList();
        //        return categories;
        //    }
        //}
        #region Может пригодиться
        //public void AddCategory()
        //{
        //    using (var db = new DataContext())
        //    {
        //        db.Categories.Add(new Category() {Name = "" });
        //        db.Categories.Add(new Category() { Name = "", ParentId = 1 });
        //        db.SaveChanges();
        //    }
        //}


        //public void UpdateCategory(int id)
        //{
        //    using (var db = new DataContext())
        //    {
        //        var category = db.Categories.Include(_ => _.Сhild).FirstOrDefault(_ => _.Id == id);
        //        category.Сhild.Add(new Category() { Name = "sd1" });
        //        category.Сhild.Add(new Category() { Name = "sd2" });
        //        db.SaveChanges();

        //    }
        //}

        //public void UpdateCategoryParent(int parentId, string name)
        //{
        //    using (var db = new DataContext())
        //    {
        //        db.Categories.Add(new Category() { Name = name, ParentId = parentId });
        //        db.SaveChanges();

        //    }
        //}

        //public void Update(int id, string name)
        //{
        //    using (var db = new DataContext())
        //    {
        //        var category = db.Categories.FirstOrDefault(_ => _.Id == id);
        //        category.Name = name;
        //        db.SaveChanges();
        //    }

        //}

        // public void Update2(int id, string name)
        //{
        //    using (var db = new DataContext())
        //    {
        //        var category = new Category() { Id = id };
        //        db.Categories.Attach(category);
        //        category.Name = name;
        //        db.Entry(category).Property(_ => _.Name).IsModified = true;
        //        db.SaveChanges();
        //    }
        //}
        public static List<Category> GetCategories()
        {
            using (var db = new DataContext())
            {
                var categories = db.Categories.Where(_ => !_.ParentId.HasValue).Include(_ => _.Сhild).ToList();
                return categories;
            }
        }
        #endregion
    }
}
