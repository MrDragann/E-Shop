using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели обратной связи
    /// </summary>
    public class ModelFeedback
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        /// <value>Имя</value>
        public string Name { get; set; }
        /// <summary>
        /// Эл.адрес пользователя
        /// </summary>
        /// <value>Эл.адрес</value>
        public string Email { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        /// <value>Дата создания</value>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Тема сообщения
        /// </summary>
        /// <value>Тема сообщения</value>
        public string Subject { get; set; }
        /// <summary>
        /// Сообщение от пользователя
        /// </summary>
        /// <value>Сообщение</value>
        public string Message { get; set; }
    }
}
