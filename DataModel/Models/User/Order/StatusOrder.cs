﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models
{
    /// <summary>
    /// Класс модели статуса заказа
    /// </summary>
    public class StatusOrder
    {
        /// <summary>
        /// Идентификатор статуса заказа
        /// </summary>
        /// <value>Идентификатор</value>
        public EnumStatusOrder Id { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
        /// <summary>
        /// Ссылка на список заказов
        /// </summary>
        /// <value>Список заказов</value>
        public List<Order> Orders { get; set; }
    }

    /// <summary>
    /// Возможные статусы заказа
    /// </summary>
    public enum EnumStatusOrder
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
