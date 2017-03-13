using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели заказа
    /// </summary>
    public class ModelOrder
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        /// <value>Идентификатор пользователя</value>
        public int UserId { get; set; }
        /// <summary>
        /// Идентификатор статуса заказа
        /// </summary>
        /// <value>Идентификатор статуса</value>
        public ModelEnumStatusOrder StatusOrderId { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        /// <value>Дата заказа</value>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Общая стоимость заказа
        /// </summary>
        public double TotalPrice { get; set; }
        /// <summary>
        /// Ссылка на список товаров в заказе
        /// </summary>
        /// <value>Список товаров в заказе</value>
        public List<ModelOrderProduct> OrderProduct { get; set; }
        /// <summary>
        /// Ссылка на список пользователей
        /// </summary>
        /// <value>Список пользователей</value>
        public List<ModelUserInfo> User { get; set; }
    }

    /// <summary>
    /// Класс модели товаров заказа
    /// </summary>
    public class ModelOrderProduct
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        /// <value>Идентификатор заказа</value>
        public int OrderId { get; set; }
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        /// <value>Идентификатор товара</value>
        public int ProductId { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        /// <value>Цена</value>
        public int Price { get; set; }
        /// <summary>
        /// Количество товаров
        /// </summary>
        /// <value>Количество</value>
        public int Quantity { get; set; }
        /// <summary>
        /// Ссылка на заказы
        /// </summary>
        /// <value>Заказы</value>
        public ModelOrder Order { get; set; }
        /// <summary>
        /// Ссылка на товары
        /// </summary>
        /// <value>Товары</value>
        public ModelProduct Product { get; set; }
    }
    /// <summary>
    /// Класс модели статуса заказа
    /// </summary>
    public class ModelStatusOrder
    {
        /// <summary>
        /// Идентификатор статуса заказа
        /// </summary>
        /// <value>Идентификатор</value>
        public ModelEnumStatusOrder Id { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
        /// <summary>
        /// Ссылка на список заказов
        /// </summary>
        /// <value>Список заказов</value>
        public List<ModelOrder> Orders { get; set; }
    }

    /// <summary>
    /// Возможные статусы заказа
    /// </summary>
    public enum ModelEnumStatusOrder
    {
        /// <summary>
        /// Корзина
        /// </summary>
        Cart,
        /// <summary>
        /// Обработка
        /// </summary>
        Processing,
        /// <summary>
        /// Заказан
        /// </summary>
        Ordered,
        /// <summary>
        /// Подтвержден
        /// </summary>
        Confirmed,
        /// <summary>
        /// Отказ
        /// </summary>
        Denial
    }
}
