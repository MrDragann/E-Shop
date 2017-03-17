using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Web;
using DataModel.Models;
using IServices.Models;
using IServices.SubInterface;

namespace Services.Public
{
    public class UserServices : IUserServices
    {
        #region Авторизация/Регистрация
        /// <summary>
        /// Проверка существования пользователя в БД
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns><c>true</c> если пользователь имеется в базе данных, <c>false</c> иначе.</returns>
        public bool Login(string userName, string password)
        {
            try
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
            catch { return false; }
        }
        /// <summary>
        /// Получение модели полезователя по его ID
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>ModelUser.</returns>
        public ModelUser Login(int userId)
        {
            using (var db = new DataContext())
            {
                return db.Users.Select(DetailUser()).FirstOrDefault(x => x.Id == userId);
            }
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="email">Эл. адрес</param>
        /// <param name="password">Пароль</param>
        /// <param name="salt">Соль</param>
        /// <returns><c>true</c> если регистрация прошла успешно, <c>false</c> иначе.</returns>
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
                        Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList(),
                        UserProfile = new UserProfile()
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

        /// <summary>
        /// Конвертирование модели пользователя
        /// </summary>
        /// <returns>Expression&lt;Func&lt;User, ModelUser&gt;&gt;.</returns>
        public static Expression<Func<User, ModelUser>> DetailUser()
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
        /// <summary>
        /// Подтверждение аккаунта пользователя
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
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
        /// <param name="email">Эл.адрес</param>
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
        /// <summary>
        /// Вывод имеющихся ролей пользователей
        /// </summary>
        /// <returns>List&lt;ModelRole&gt;.</returns>
        public List<ModelRole> GetRoles()
        {
            using (var db = new DataContext())
            {
                var roles = db.Roles.Select(DetailRole()).ToList();
                return roles;
            }
        }
        /// <summary>
        /// Вывод имеющихся статусов пользователей
        /// </summary>
        /// <returns>List&lt;ModelStatusUser&gt;.</returns>
        public List<ModelStatusUser> GetStatuses()
        {
            using (var db = new DataContext())
            {
                var statuses = db.StatusUsers.Select(DetailStatus()).ToList();
                return statuses;
            }
        }
        /// <summary>
        /// Конвертирование модели ролей пользователей
        /// </summary>
        /// <returns>Expression&lt;Func&lt;Role, ModelRole&gt;&gt;.</returns>
        public static Expression<Func<Role, ModelRole>> DetailRole()
        {
            return role => new ModelRole { Id = (ModelEnumTypeRoles)role.Id, Name = role.Name };
        }

        /// <summary>
        /// Конвертирование модели статусов пользователей
        /// </summary>
        /// <returns>Expression&lt;Func&lt;StatusUser, ModelStatusUser&gt;&gt;.</returns>
        public static Expression<Func<StatusUser, ModelStatusUser>> DetailStatus()
        {
            return status => new ModelStatusUser { Id = (ModelEnumStatusUser)status.Id, Name = status.Name };
        }

        public void EditUserProfile(ModelUserProfile model, string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.Include(x=>x.UserProfile).FirstOrDefault(x => x.UserName == userName);
                user.UserProfile.FirstName = model.FirstName;
                user.UserProfile.LastName = model.LastName;
                user.UserProfile.Phone = model.Phone;
                user.UserProfile.Country = model.Country;
                user.UserProfile.City = model.City;
                user.UserProfile.StreetAddress = model.StreetAddress;
                //{
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    Phone = model.Phone,
                //    Country = model.Country,
                //    City = model.City,
                //    StreetAddress = model.StreetAddress
                //};
                db.SaveChanges();
            }
        }

        #endregion

        #region Корзина
        /// <summary>
        /// Вывод содержимого корзины
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns>ModelCarts.</returns>
        public ModelCarts GetCart(string userName)
        {
            if (userName != null)
            {
                using (var db = new DataContext())
                {
                    var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                    var order = db.Orders.Include(x => x.OrderProduct).Where(p => p.UserId == user.Id && p.StatusOrderId == EnumStatusOrder.Cart).FirstOrDefault();
                    if (order == null || order.OrderProduct.Count < 1) 
                    {
                        return new ModelCarts();
                    }
                    else
                    {
                        var products = GetOrderProducts(order.OrderProduct);
                        return new ModelCarts { ProductCart = products };
                    }
                    
                }
            }
            else
            {
                return CookieCart();
            }
        }
        /// <summary>
        /// Получение данных о корзине из куки
        /// </summary>
        /// <returns>ModelCarts.</returns>
        public ModelCarts CookieCart()
        {
            HttpCookie CookieReq = HttpContext.Current.Request.Cookies["UserCart"];
            if (CookieReq==null || string.IsNullOrWhiteSpace(CookieReq.Values["productId"]))
            {
                return new ModelCarts();
            }
            else
            {
                var CookieProducts = CookieReq.Values["productId"].Split(',').Select(int.Parse).ToList();
                var CookieQuantity = CookieReq.Values["quantity"].Split(',').Select(int.Parse).ToList();

                List<OrderProduct> CookieCart = new List<OrderProduct>();
                for (int i = 0; i < CookieProducts.Count(); i++)
                {
                    CookieCart.Add(new OrderProduct { ProductId = CookieProducts[i], Quantity = CookieQuantity[i] });
                }
                var products = GetOrderProducts(CookieCart);
                return new ModelCarts { ProductCart = products };
            }
        }
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
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
                    
                    if (cart == null)
                    {
                        var order = db.Orders.Add(new Order
                        {
                            CreateDate = DateTime.Now,
                            UserId = user.Id,
                            User = user,
                            StatusOrderId = EnumStatusOrder.Cart
                        });
                        db.OrderProducts.Add(new OrderProduct
                        {
                            OrderId = order.Id,
                            ProductId = productId,
                            Quantity = quantity
                        });
                    }
                    if (cart != null)
                    {
                        if (cart.OrderProduct.Any(x => x.ProductId == productId))
                        {
                            var order = db.OrderProducts.FirstOrDefault(x => x.OrderId == cart.Id && x.ProductId == productId);
                            order.Quantity++;
                            db.SaveChanges();
                            return;
                        }
                        if (cart.OrderProduct.Where(x=>x.ProductId==productId)!=null)
                        {
                            var newItem = new OrderProduct
                            {
                                OrderId = user.Order.FirstOrDefault(x => x.StatusOrderId == EnumStatusOrder.Cart).Id,
                                ProductId = productId,
                                Quantity = quantity
                            };
                            db.OrderProducts.Add(newItem);
                        }
                    }
                    
                    db.SaveChanges();
                }
            }
            else
            {
                HttpCookie CookieReq = HttpContext.Current.Request.Cookies["UserCart"];
                if (CookieReq == null || string.IsNullOrWhiteSpace(CookieReq.Values["productId"]))
                {
                    HttpCookie aCookie = new HttpCookie("UserCart");

                    aCookie.Values["productId"] = productId.ToString();
                    aCookie.Values["quantity"] = quantity.ToString();

                    aCookie.Expires = DateTime.Now.AddDays(7);
                    HttpContext.Current.Response.Cookies.Add(aCookie);
                }
                else
                {
                    var CookieProducts = CookieReq.Values["productId"].Split(',').Select(int.Parse).ToList();
                    var CookieQuantity = CookieReq.Values["quantity"].Split(',').Select(int.Parse).ToList();
                    if (CookieProducts.Contains(productId))
                    {
                        var ProductIndex = CookieProducts.FindIndex(x => x == productId);
                        CookieQuantity[ProductIndex] += 1;
                        CookieReq.Values["quantity"] = string.Join(",", CookieQuantity.ToArray());
                        //aCookie.Expires = DateTime.Now.AddDays(7);
                        HttpContext.Current.Response.Cookies.Add(CookieReq);
                    }
                    else
                    {
                        CookieReq.Values["productId"] += "," + productId;
                        CookieReq.Values["quantity"] += "," + quantity;
                        HttpContext.Current.Response.Cookies.Add(CookieReq);
                    }
                }
            }
        }

        /// <summary>
        /// Изменение количества товара
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <param name="quantity">Количество</param>
        /// <param name="userName">Имя пользователя</param>
        public void EditQuantity(int productId, int quantity, string userName)
        {
            if (userName != null)
            {
                using (var db = new DataContext())
                {
                    var user = db.Users.Include(x => x.Order).FirstOrDefault(x => x.UserName == userName);
                    var cart = db.Orders.Include(x => x.OrderProduct).Where(p => p.UserId == user.Id && p.StatusOrderId == EnumStatusOrder.Cart).FirstOrDefault();
                    
                    if (cart != null)
                    {
                        if (cart.OrderProduct.Any(x => x.ProductId == productId))
                        {
                            var order = db.OrderProducts.FirstOrDefault(x => x.OrderId == cart.Id && x.ProductId == productId);
                            order.Quantity=quantity;
                            db.SaveChanges();
                            return;
                        }
                    }
                }
            }
            else
            {
                HttpCookie CookieReq = HttpContext.Current.Request.Cookies["UserCart"];
                if (CookieReq != null)
                {
                    var CookieProducts = CookieReq.Values["productId"].Split(',').Select(int.Parse).ToList();
                    var CookieQuantity = CookieReq.Values["quantity"].Split(',').Select(int.Parse).ToList();
                    var ProductIndex = CookieProducts.FindIndex(x => x == productId);
                    CookieQuantity[ProductIndex] = quantity;
                    CookieReq.Values["quantity"] = string.Join(",", CookieQuantity.ToArray());
                    //aCookie.Expires = DateTime.Now.AddDays(7);
                    HttpContext.Current.Response.Cookies.Add(CookieReq);
                }
            }
        }

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <param name="userName">Имя пользователя</param>
        public void DeleteItem(int productId, string userName)
        {

            if (userName != null)
            {
                using (var db = new DataContext())
                {
                    var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                    var cart = db.Orders.Include(x => x.OrderProduct).Where(p => p.UserId == user.Id && p.StatusOrderId == EnumStatusOrder.Cart).FirstOrDefault();
                    var order = db.OrderProducts.FirstOrDefault(x => x.OrderId == cart.Id && x.ProductId == productId);

                    //db.Orders.Remove(cart);
                    db.OrderProducts.Remove(order);
                    db.SaveChanges();
                }
            }
            else
            {
                HttpCookie CookieReq = HttpContext.Current.Request.Cookies["UserCart"];
                if (CookieReq != null)
                {
                    var CookieProducts = CookieReq.Values["productId"].Split(',').Select(int.Parse).ToList();
                    var CookieQuantity = CookieReq.Values["quantity"].Split(',').Select(int.Parse).ToList();
                    var ProductIndex = CookieProducts.FindIndex(x => x == productId);
                    CookieProducts.Remove(productId);
                    CookieQuantity.RemoveAt(ProductIndex);
                    CookieReq.Values["productId"] = string.Join(",", CookieProducts.ToArray());
                    CookieReq.Values["quantity"] = string.Join(",", CookieQuantity.ToArray());
                    //aCookie.Expires = DateTime.Now.AddDays(7);
                    HttpContext.Current.Response.Cookies.Add(CookieReq);
                }
            }
        }

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

        /// <summary>
        /// Получение списка содержимого корзины
        /// </summary>
        /// <param name="model">Список товаров заказа</param>
        /// <returns>List&lt;ModelCart&gt;.</returns>
        public List<ModelCart> GetOrderProducts(List<OrderProduct> model)
        {
            using (var db = new DataContext())
            {
                List<ModelCart> ProductCart = new List<ModelCart>();
                foreach (var Product in model)
                {
                    var product = db.Products.Select(ProductServices.Details()).Where(x => x.Id == Product.ProductId).FirstOrDefault();
                    ProductCart.Add(new ModelCart { ProductId = product.Id, Product = product, Quantity = Product.Quantity });
                }

                return ProductCart;
            }
        }

        /// <summary>
        /// Конвертирование модели корзины
        /// </summary>
        /// <returns>Expression&lt;Func&lt;OrderProduct, ModelCart&gt;&gt;.</returns>
        public static Expression<Func<OrderProduct, ModelCart>> Cart()
        {
            return product => new ModelCart()
            {
                ProductId = product.ProductId,
                Quantity = product.Quantity
            };
        }
        /// <summary>
        /// Вывод информации о статусе корзины пользователя
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>List&lt;ModelOrderProduct&gt;.</returns>
        public List<ModelOrderProduct> GetCartQuantity(string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                var order = db.Orders.Include(x => x.OrderProduct).Where(o => o.UserId == user.Id && o.StatusOrderId == EnumStatusOrder.Cart).FirstOrDefault();
                if (order == null)
                {
                    return new List<ModelOrderProduct>();
                }
                else
                {
                    return order.OrderProduct.Select(o => ConverModelOrderProduct(o)).ToList(); ;
                }
                
            }
        }
        #endregion

        #region Заказы
        
        /// <summary>
        /// Перейти к оформлению заказа
        /// </summary>
        /// <returns>List&lt;ModelOrder&gt;.</returns>
        public ModelOrder GoToCheckout(string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                var order = db.Orders.Include(x => x.OrderProduct).Where(p => p.UserId == user.Id && p.StatusOrderId == EnumStatusOrder.Cart).FirstOrDefault();
                var ModelOrder = db.Orders.Select(ShowOrders()).Where(p => p.UserId == user.Id && p.StatusOrderId == ModelEnumStatusOrder.Cart).FirstOrDefault();
                ModelOrder.OrderProduct = order.OrderProduct.Select(o => ConverModelOrderProduct(o)).ToList();
                double TotalPrice = 0;
                foreach (var product in ModelOrder.OrderProduct)
                {
                    product.Product = db.Products.Select(ProductServices.Details()).FirstOrDefault(x => x.Id == product.ProductId);
                    TotalPrice += product.Product.Price * product.Quantity;
                }
                order.TotalPrice = TotalPrice;
                db.SaveChanges();
                ModelOrder.TotalPrice = TotalPrice;
                return ModelOrder;
            }
        }
        public void ConfirmOrder(string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                var order = db.Orders.Include(x => x.OrderProduct).Where(p => p.UserId == user.Id && p.StatusOrderId == EnumStatusOrder.Cart).FirstOrDefault();
                
                order.StatusOrderId = EnumStatusOrder.Confirmed;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Вывод всех заказов
        /// </summary>
        /// <returns>List&lt;ModelOrder&gt;.</returns>
        public List<ModelOrder> Orders(string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                var order = db.Orders.Include(x => x.OrderProduct).Where(o => o.UserId == user.Id && o.StatusOrderId != EnumStatusOrder.Cart).ToList();
                var orders = db.Orders.Select(ShowOrders()).Where(o=> o.UserId == user.Id && o.StatusOrderId!= ModelEnumStatusOrder.Cart).ToList();
                for(var i = 0; i < order.Count; i++)
                {
                    orders[i].OrderProduct = order[i].OrderProduct.Select(o => ConverModelOrderProduct(o)).ToList();
                    foreach(var product in orders[i].OrderProduct)
                    {
                        product.Product= db.Products.Select(ProductServices.Details()).FirstOrDefault(x => x.Id == product.ProductId);
                    }
                }
                    return orders;
            }
        }

        public static Expression<Func<Order, ModelOrder>> ShowOrders()
        {
            return orders => new ModelOrder()
            {
                Id = orders.Id,
                UserId = orders.UserId,
                CreateDate = orders.CreateDate,
                StatusOrderId = (ModelEnumStatusOrder)orders.StatusOrderId,
                TotalPrice = orders.TotalPrice

            };
        }
        private static ModelOrderProduct ConverModelOrderProduct(OrderProduct model)
        {

            return new ModelOrderProduct
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Price = model.Price,
                Quantity = model.Quantity

            };
        }
        public static Expression<Func<OrderProduct, ModelOrderProduct>> ShowOrderProducts()
        {
            return orders => new ModelOrderProduct()
            {
                OrderId = orders.OrderId,
                ProductId = orders.ProductId,
                Price = orders.Price,
                Quantity = orders.Quantity

            };
        }

        public ModelUserInfo GetUserInfo(string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.Select(DetailUserInfo()).FirstOrDefault(x => x.UserName == userName);
                user.UserProfile = db.UserProfiles.Select(ShowUserProfile()).FirstOrDefault(x => x.UserId == user.Id);
                return user;
            }
        }

        public static Expression<Func<UserProfile, ModelUserProfile>> ShowUserProfile()
        {
            return profile => new ModelUserProfile()
            {
                UserId = profile.UserId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Phone = profile.Phone,
                Country = profile.Country,
                City = profile.City,
                StreetAddress = profile.StreetAddress

            };
        }

        /// <summary>
        /// Конвертирование модели пользователя
        /// </summary>
        /// <returns>Expression&lt;Func&lt;User, ModelUser&gt;&gt;.</returns>
        public static Expression<Func<User, ModelUserInfo>> DetailUserInfo()
        {
            return user => new ModelUserInfo()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Photo =user.Photo
            };
        }
        #endregion
    }
    #region Хеширование
    /// <summary>
    /// Класс с расширениями строк
    /// </summary>
    public static class ExtensionString
    {
        /// <summary>
        /// Метод расширения, хеширующий строку по стандарту SHA256
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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
