using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.User
{
    public class ModelRole
    {
        public ModelEnumTypeRoles Id { get; set; }

        public string Name { get; set; }
    }

    public enum ModelEnumTypeRoles
    {
        Admin,
        Moderator,
        User
    }
}
