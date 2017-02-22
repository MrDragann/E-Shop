namespace DataModel.Migrations
{
    using System;
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
            //var user = new User { UserName = "User", Email = "User", LastLoginDate = DateTime.Now, RegistrationDate = DateTime.Now, Salt = "User", Password = "user", StatusUserId= EnumStatusUser.Locked };
            //var user1 = new User { UserName = "User", Email = "User", LastLoginDate = DateTime.Now, RegistrationDate = DateTime.Now, Salt = "User", Password = "user", StatusUserId= EnumStatusUser.Confirmed };
            //var user2 = new User { UserName = "User", Email = "User", LastLoginDate = DateTime.Now, RegistrationDate = DateTime.Now, Salt = "User", Password = "user",StatusUserId= EnumStatusUser.NConfirmed };
            //context.Users.AddOrUpdate(p => p.Id,
            //    user,
            //    user1,
            //    user2
            //    );

            //context.StatusUsers.AddOrUpdate(p => p.Id,
            //    new StatusUser { Id = EnumStatusUser.Locked, Name = "������������" },
            //    new StatusUser { Id = EnumStatusUser.Confirmed, Name = "�����������" },
            //    new StatusUser { Id = EnumStatusUser.NConfirmed, Name = "�� ������������" }
            //    );
            //context.Roles.AddOrUpdate(p => p.Id,
            //    new Role { Id = TypeRoles.Admin, Name = "�������������" },
            //    new Role { Id = TypeRoles.Moderator, Name = "��������" },
            //   // new Role { Id = EnumStatusUser.NConfirmed, Name = "�� ������������" }
            //    );
        }
    }
}
