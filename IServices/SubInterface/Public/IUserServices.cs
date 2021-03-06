﻿using DataModel.Models;
using IServices.Models;
using System.Collections.Generic;

namespace IServices.SubInterface
{
    /// <summary>
    /// Определяет методы связанные с пользователями
    /// </summary>
    public interface IUserServices
    {
        #region Авторизация/Регистрация
        /// <summary>
        /// Проверка существования пользователя в БД
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns><c>true</c> если пользователь имеется в базе данных, <c>false</c> иначе.</returns>
        bool Login(string userName, string password);
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="email">Эл. адрес</param>
        /// <param name="password">Пароль</param>
        /// <param name="salt">Соль</param>
        /// <returns><c>true</c> если регистрация прошла успешно, <c>false</c> иначе.</returns>
        bool Register(string userName, string email, string password, string salt);

        /// <summary>
        /// Вывод имеющихся ролей пользователей
        /// </summary>
        /// <returns>List&lt;ModelRole&gt;.</returns>
        List<ModelRole> GetRoles();

        /// <summary>
        /// Вывод имеющихся статусов пользователей
        /// </summary>
        /// <returns>List&lt;ModelStatusUser&gt;.</returns>
        List<ModelStatusUser> GetStatuses();
        #endregion
        #region Корзина/Список жедаемого
        /// <summary>
        /// Вывод содержимого корзины
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns>ModelCarts.</returns>
        ModelCarts GetCart(string userName);
        /// <summary>
        /// Получение данных о корзине из куки
        /// </summary>
        /// <returns>ModelCarts.</returns>
        ModelCarts CookieCart();
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <param name="quantity">Количество</param>
        /// <param name="userName">Имя пользователя</param>
        void AddToCart(int productId, int quantity, string userName);
        /// <summary>
        /// Изменение количества товара
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <param name="quantity">Количество</param>
        /// <param name="userName">Имя пользователя</param>
        void EditQuantity(int productId, int quantity, string userName);
        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <param name="userName">Имя пользователя</param>
        void DeleteItem(int productId, string userName);
        //void Clear(string userName);
        List<ModelOrderProduct> GetCartQuantity(string userName);
        #endregion
        #region Заказы
        List<ModelOrder> Orders(string userName);

        ModelOrder GoToCheckout(string userName);


        void ConfirmOrder(string userName);

        /// <summary>
        /// Подтверждение получения заказа
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="OrderId">Идентификатор заказа</param>
        void ConfirmReceipt(string userName, int OrderId);
        /// <summary>
        /// Отмена заказа
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="OrderId">Идентификатор заказа</param>
        void CancelOrder(string userName, int OrderId);
        #endregion
        #region Действия над аккаунтом
        /// <summary>
        /// Подтверждение аккаунта
        /// </summary>
        /// <param name="salt">Соль</param>
        /// <param name="userName">Имя пользователя</param>
        /// <returns><c>true</c> если данные в базе данных совпадают, <c>false</c> иначе.</returns>
        bool ConfrimedEmail(string salt, string userName);
        /// <summary>
        /// Проверка роли пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="role">Роль пользователя</param>
        /// <returns><c>true</c> если роль совпадает, <c>false</c> иначе.</returns>
        bool CheckRole(string userName, string role);
        /// <summary>
        /// Замена старого пароля на новый
        /// </summary>
        /// <param name="email">Эл.адрес</param>
        /// <param name="password">Новый пароль</param>
        /// <param name="salt">Новая соль</param>
        void ResetPassword(string email, string password, string salt);
        void EditUserProfile(ModelUserProfile model, string userName);
        ModelUserInfo GetUserInfo(string userName);
        #endregion
        #region Обратная связь
        void NewFeedbackMessage(ModelFeedback model);
        #endregion
    }
}
