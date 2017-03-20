using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// В корзине
        /// </summary>
        [Description("В корзине")]
        Cart,
        /// <summary>
        /// Подтвержден
        /// </summary>
        [Description("Подтвержден")]
        Confirmed,
        /// <summary>
        /// Отправлен
        /// </summary>
        [Description("Отправлен")]
        ShippedOut,
        /// <summary>
        /// Доставлен
        /// </summary>
        [Description("Доставлен")]
        Delivered,
        /// <summary>
        /// Отказ
        /// </summary>
        [Description("Отказ")]
        Denial
    }
}
