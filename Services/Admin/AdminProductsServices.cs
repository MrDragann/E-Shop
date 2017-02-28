using DataModel;
using IServices.Models;
using IServices.SubInterfac.Admin;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Admin
{
    public class AdminProductsServices : IAdminProductServices 
    {
        #region Товары
        /// <summary>
        /// Добавление нового товара
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(ModelProduct model)
        {
            using (var db = new DataContext()) 
            {
                var product = new Product
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    ManufacturerId = model.ManufacturerId,
                    Price = model.Price,
                    Description = model.Description,
                    Characteristics = model.Characteristics,
                    Tags = model.Tags,
                    Image = model.FileName,
                    DateAdd = model.DateAdd
                };
                db.Products.Add(product);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Удаление выбранных товаров
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProducts(List<int> id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    foreach (int item in id)
                    {
                        var product = db.Products.FirstOrDefault(_ => _.Id == item);
                        db.Products.Remove(product);
                    }
                    db.SaveChanges();
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// Редактирование выбранного товара
        /// </summary>
        /// <param name="model"></param>
        public void EditProduct(ModelProduct model)
        {
            using (var db = new DataContext())
            {
                var product = db.Products.FirstOrDefault(x => x.Id == model.Id);
                product.Name = model.Name;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;
                product.ManufacturerId = model.ManufacturerId;
                product.Description = model.Description;
                product.Characteristics = model.Characteristics;
                product.Tags = model.Tags;
                product.Image = model.FileName;
                product.DateAdd = model.DateAdd;
                db.SaveChanges();
            }
        }
        #endregion

        #region Категории
        /// <summary>
        /// Добавление главной категории
        /// </summary>
        /// <param name="name">Название категории</param>
        public void AddMainCategory(string name)
        {
            using (var db = new DataContext())
            {
                db.Categories.Add(new Category { Name = name });
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Добавление дочерней категории
        /// </summary>
        /// <param name="name">Название категории</param>
        public void AddChildCategory(int mainId, string child)
        {
            using (var db = new DataContext())
            {
                db.Categories.Add(new Category { Name = child, ParentId = mainId });
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Изменение названия главной категории
        /// </summary>
        /// <param name="mainId">ID категории</param>
        /// <param name="newName">Новое название</param>
        public void EditMainCategory(int mainId, string newName)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == mainId);
                category.Name = newName;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Изменение названия дочерней категории
        /// </summary>
        /// <param name="childId">ID категории</param>
        /// <param name="newName">Новое название</param>
        public void EditChildCategory(int childId, string newName)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == childId);
                category.Name = newName;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Удаление родительской категории
        /// </summary>
        /// <param name="mainId">Id родительской категории</param>
        /// <returns></returns>
        public void DeleteMainCategory(int mainId)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.Include(x => x.Сhild).FirstOrDefault(x => x.Id == mainId);
                db.Categories.RemoveRange(category.Сhild);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Удаление дочерней категории
        /// </summary>
        /// <param name="childId">Id дочерней категории</param>
        /// <returns></returns>
        public void DeleteChildCategory(int childId)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == childId);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }
        #endregion
    }
}
