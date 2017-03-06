using DataModel;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IServices.Models;
using System.Linq.Expressions;
using IServices.Models.User;
using System.Security.Cryptography;
using Services;

namespace IServices
{
    public class UserServices : IUserServices
    {
        #region Авторизация/Регистрация
        /// <summary>
        /// Проверка существования пользователя в БД
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(_ => _.UserName == userName);
                var HeshPass = (user.Salt + password).GetHashString();

                var authorized = db.Users.Any(_ => _.UserName == userName && _.Password == HeshPass && _.StatusUserId != EnumStatusUser.Locked);
                if (authorized)
                {
                    user.LastLoginDate = DateTime.Now;
                    db.SaveChanges();
                }
                return authorized;
            }
        }

        public ModelUser Login(int userId)
        {
            using (var db = new DataContext())
            {
                return db.Users.Select(SelectDetailUser()).FirstOrDefault(x => x.Id == userId);
            }
        }
        /// <summary>
        /// Регистрация пользователя 
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public bool Register(string userName, string email, string password, string salt)
        {
            try
            {
                using (var db = new DataContext())
                {
                    User user = new User()
                    {
                        UserName = userName,
                        Email = email,
                        Password = (salt + password).GetHashString(),
                        Salt = salt,
                        RegistrationDate = DateTime.Now,
                        LastLoginDate = DateTime.MinValue,
                        StatusUserId = EnumStatusUser.NConfirmed,
                        AccountConfirmation = new AccountConfirmation
                        {
                            ConfirmedEmail = false,
                            ConfirmationCode = salt
                        },
                        Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList()
                    };

                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static Expression<Func<User, ModelUser>> SelectDetailUser()
        {
            return user => new ModelUser()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = user.Roles.Select(role => new ModelRole { Id = (ModelEnumTypeRoles)role.Id, Name = role.Name }).ToList()
            };
        }
        #endregion

        #region Действия над аккаунтом
        public bool ConfrimedEmail(string salt, string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(_ => _.UserName == userName);
                var confirm = db.AccountConfirmations.FirstOrDefault(x => x.UserId == user.Id);
                if (db.AccountConfirmations.Any(x => x.ConfirmationCode == salt))
                {
                    user.StatusUserId = EnumStatusUser.Confirmed;
                    confirm.ConfirmedEmail = true;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
        /// <summary>
        /// Проверка роли пользователя
        /// </summary>
        /// <param name="role">Роль пользователя</param>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        public bool CheckRole(string userName, string role)
        {
            using (var db = new DataContext())
            {
                var users = db.Users.Where(x => x.Roles.Any(y => y.Name == role));
                bool included = users.Any(x => x.UserName == userName);
                return included;
            }
        }
        /// <summary>
        /// Замена старого пароля на новый
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Новый пароль</param>
        /// <param name="salt">Новая соль</param>
        public void ResetPassword(string email, string password, string salt)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Email == email);
                user.Salt = salt;
                user.Password = (salt + password).GetHashString();
                db.SaveChanges();
            }
        }

        public static Expression<Func<Role, ModelRole>> SelectDetailRole()
        {
            return role => new ModelRole { Id = (ModelEnumTypeRoles)role.Id, Name = role.Name };
        }

        public static Expression<Func<StatusUser, ModelStatus>> SelectDetailStatus()
        {
            return status => new ModelStatus { Id = (ModelEnumStatusUser)status.Id, Name = status.Name };
        }

        #endregion

        #region Корзина/Список жедаемого
        public List<ModelProduct> GetCart(string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                var order = db.Orders.Include(x => x.OrderProduct).Where(p => p.UserId == user.Id && p.StatusOrderId == EnumStatusOrder.Cart).FirstOrDefault();
                var products = GetOrderProducts(order);

                return (products);
            }
        }
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="productId">Id товара</param>
        /// <param name="quantity">Количество</param>
        /// <param name="userName">Имя пользователя</param>
        public void AddToCart(int productId, int quantity, string userName)
        {
            if (userName != null)
            {
                using (var db = new DataContext())
                {
                    var user = db.Users.Include(x=>x.Order).FirstOrDefault(x => x.UserName == userName);
                    var cart = db.Orders.Include(x=>x.OrderProduct).Where(p => p.UserId == user.Id && p.StatusOrderId == EnumStatusOrder.Cart).FirstOrDefault();
                    //Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList()

                    ////Может пригодиться
                    //using (var db = new DataContext())
                    //{
                    //    var user = db.Users.Include(_ => _.Roles).FirstOrDefault(_ => _.Id == 19);
                    //    user.Roles = db.Roles.Where(_ => new[] { TypeRoles.Admin }.Contains(_.Id)).ToList();
                    //    db.SaveChanges();
                    //}
                    if (cart == null)
                    {
                        var order = db.Orders.Add(new Order
                        {
                            OrderDate = DateTime.Now,
                            UserId = user.Id,
                            User = new List<User> { user },
                            StatusOrderId = EnumStatusOrder.Cart
                        });
                        db.OrderProducts.Add(new OrderProduct
                        {
                            OrderId = order.Id,
                            ProductId = productId,
                            Quantity = quantity
                        });
                    }
                    //if (cart.OrderProduct.Any(x => x.ProductId != productId))
                    //{
                    //    db.OrderProducts.Add(new OrderProduct
                    //    {
                    //        OrderId = order.Id,
                    //        ProductId = productId,
                    //        Quantity = quantity
                    //    });
                    //}
                    if (cart != null)
                    {
                        if (cart.OrderProduct.Any(x => x.ProductId == productId))
                        {
                            var order = db.OrderProducts.FirstOrDefault(x => x.OrderId == cart.Id);
                            order.Quantity++;
                            //db.OrderProducts//
                            //cart.OrderProduct = db.OrderProducts.Where(_ => new[] { productId, quantity }.Contains(_.OrderId)).ToList();
                        }
                        if (cart.OrderProduct.Where(x=>x.ProductId!=productId)==null)
                        {
                            db.OrderProducts.Add(new OrderProduct
                            {
                                OrderId = user.Order.FirstOrDefault(x=>x.StatusOrderId==EnumStatusOrder.Cart).Id,
                                ProductId = productId,
                                Quantity = quantity
                            });
                        }
                    }
                    
                    db.SaveChanges();
                }
            }
        }
        ///// <summary>
        ///// Удаление товара из корзины
        ///// </summary>
        ///// <param name="productId"></param>
        //public void RemoveLine(int productId, string userName)
        //{

        //    if (userName != null)
        //    {
        //        using (var db = new DataContext())
        //        {
        //            var user = db.Users.FirstOrDefault(x => x.UserName == userName);
        //            var cart = db.Carts.FirstOrDefault(p => p.UserId == user.Id && p.ProductId==productId);

        //            db.Carts.Remove(cart);

        //            db.SaveChanges();
        //        }
        //    }
        //}

        ///// <summary>
        ///// Очистка корзины
        ///// </summary>
        //public void Clear(string userName)
        //{
        //    if (userName != null)
        //    {
        //        using (var db = new DataContext())
        //        {
        //            var user = db.Users.FirstOrDefault(x => x.UserName == userName);
        //            var cart = db.Carts.Where(p => p.UserId == user.Id);

        //            db.Carts.RemoveRange(cart);

        //            db.SaveChanges();
        //        }
        //    }
        //}

        public static Expression<Func<OrderProduct, CartLine>> Cart()
        {
            return product => new CartLine()
            {
                OrderId = product.OrderId,
                ProductId = product.ProductId,
                Quantity = product.Quantity
            };
        }
        public List<ModelProduct> GetOrderProducts(Order model)
        {
            using (var db = new DataContext())
            {
                List<ModelProduct> products = new List<ModelProduct>();
                foreach (var Product in model.OrderProduct)
                {
                    var product = db.Products.Select(ProductServices.Details()).Where(x => x.Id == Product.ProductId).FirstOrDefault();
                    product.Quantity = Product.Quantity;
                    products.Add(product);
                }

                return products;
            }
        }
        #endregion
    }
    #region Хеширование
    public static class Extens
    {
        public static string GetHashString(this string s)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(s), 0, Encoding.UTF8.GetByteCount(s));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }

    #endregion
}
