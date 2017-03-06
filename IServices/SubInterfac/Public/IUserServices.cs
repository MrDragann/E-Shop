using IServices.Models;
using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IUserServices
    {
        #region Авторизация/Регистрация
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string userName, string password);
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="email">Эл. адрес</param>
        /// <param name="password">Пароль</param>
        /// <param name="salt">Соль</param>
        /// <returns></returns>
        bool Register(string userName, string email, string password, string salt);
        #endregion
        #region Корзина/Список жедаемого
        List<CartLine> GetCart(string userName);
        void AddToCart(int productId, int quantity, string userName);
        //void RemoveLine(int productId, string userName);
        //void Clear(string userName);
        #endregion
        #region Действия над аккаунтом
        /// <summary>
        /// Подтверждение аккаунта
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool ConfrimedEmail(string salt, string userName);
        /// <summary>
        /// Проверка роли пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        bool CheckRole(string userName, string role);
        /// <summary>
        /// Сброс пароля пользователя
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        void ResetPassword(string email, string password, string salt);
        #endregion
    }
}
