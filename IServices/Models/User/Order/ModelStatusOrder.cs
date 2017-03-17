using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
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
        /// Подтвержден
        /// </summary>
        Confirmed,
        /// <summary>
        /// Отправлен
        /// </summary>
        ShippedOut,
        /// <summary>
        /// Доставлен
        /// </summary>
        Delivered,
        /// <summary>
        /// Отказ
        /// </summary>
        Denial
    }
}
