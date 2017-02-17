namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountconfirmation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles", newName: "RoleUsers");
            DropForeignKey("dbo.UserProfiles", "UserId", "dbo.Users");
            DropIndex("dbo.UserProfiles", new[] { "UserId" });
            DropPrimaryKey("dbo.RoleUsers");
            CreateTable(
                "dbo.AccountConfirmations",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ConfirmedEmail = c.Boolean(nullable: false),
                        ConfirmationCode = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "RegistrationDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            AddColumn("dbo.Users", "LastLoginDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            AddColumn("dbo.Users", "Status", c => c.String());
            AddPrimaryKey("dbo.RoleUsers", new[] { "Role_Id", "User_Id" });
            DropTable("dbo.UserProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        LastLoginDate = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        ConfirmedEmail = c.Boolean(nullable: false),
                        ConfirmationCode = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropForeignKey("dbo.AccountConfirmations", "UserId", "dbo.Users");
            DropIndex("dbo.AccountConfirmations", new[] { "UserId" });
            DropPrimaryKey("dbo.RoleUsers");
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Users", "LastLoginDate");
            DropColumn("dbo.Users", "RegistrationDate");
            DropTable("dbo.AccountConfirmations");
            AddPrimaryKey("dbo.RoleUsers", new[] { "User_Id", "Role_Id" });
            CreateIndex("dbo.UserProfiles", "UserId");
            AddForeignKey("dbo.UserProfiles", "UserId", "dbo.Users", "Id");
            RenameTable(name: "dbo.RoleUsers", newName: "UserRoles");
        }
    }
}
