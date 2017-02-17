using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string RoleName { get; set; }


    }
}
