using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    public class ModelUserProfile
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string StreetAddress { get; set; }

        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        /// <value>Пользователь</value>
        public ModelUserInfo User { get; set; }
    }
}
