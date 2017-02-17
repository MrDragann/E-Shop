namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class register : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "RegistrationDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.UserProfiles", "LastLoginDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "LastLoginDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserProfiles", "RegistrationDate", c => c.DateTime(nullable: false));
        }
    }
}
