using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    public class ModelUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        /// <summary>
        /// Авторизован пользователь или нет
        /// </summary>
        public bool IsAuth { get; set; }
    }
}
