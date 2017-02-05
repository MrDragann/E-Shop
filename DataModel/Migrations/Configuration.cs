namespace DataModel.Migrations
{
    using System;
    using ProductModel.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModel.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataModel.DataContext context)
        {
            var admin = new User { UserName = "Andrew", Password = Security.Instance.GetHashString("123456"), Salt = Security.Instance.GetSalt() };
            var moderator = new User { UserName = "Stive", Password = Security.Instance.GetHashString("123456"), Salt = Security.Instance.GetSalt() };
            var user = new User { UserName = "Frank", Password = Security.Instance.GetHashString("123456"), Salt = Security.Instance.GetSalt() };
            context.Users.AddOrUpdate(
              p => p.Id,
              admin,
              moderator,
              user,
              new User { UserName = "Harry", Password = Security.Instance.GetHashString("123456"), Salt = Security.Instance.GetSalt() }
            );

            context.Roles.AddOrUpdate(p => p.Id,
                new Role { Id = TypeRoles.Admin, Name = "Admin", Users = new List<User> { admin } },
                new Role { Id = TypeRoles.Moderator, Name = "Moderator", Users = new List<User> { moderator } },
                new Role { Id = TypeRoles.User, Name = "User", Users = new List<User> { user } }
                );
        }
    }
}
