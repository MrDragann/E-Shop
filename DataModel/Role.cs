using System.Collections.Generic;

namespace DataModel
{
    public class Role
    {
        public TypeRoles Id { get; set; }

        public string Name { get; set; }

        public List<User> Users { get; set; }
    }

    public enum TypeRoles
    {
        Admin,
        User
    }
}