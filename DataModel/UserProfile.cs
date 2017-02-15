using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("UserOf")]
        public int UserId { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public bool ConfirmedEmail { get; set; }

        public string ConfirmationCode { get; set; }

        //ссылка на пользователя
        public User UserOf { get; set; }
    }
}
