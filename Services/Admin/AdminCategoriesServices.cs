using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices.SubInterfac.Admin;
using DataModel;

namespace Services.Admin
{
    public class AdminCategoriesServices : IAdminCategoriesServices
    {
        /// <summary>
        /// Добавление главной категории
        /// </summary>
        /// <param name="name">Название категории</param>
        public void AddMainCategory(string name)
        {
            using(var db = new DataContext())
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
    }
}
