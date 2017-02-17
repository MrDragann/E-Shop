using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Авторизован пользователь или нет
        /// </summary>
        public bool IsAuth { get; set; }

        public List<ModelRole> Roles { get; set; }
    }
}
