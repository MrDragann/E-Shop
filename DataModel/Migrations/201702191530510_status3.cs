namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "StatusUser_Id", "dbo.StatusUsers");
            DropIndex("dbo.Users", new[] { "StatusUser_Id" });
            RenameColumn(table: "dbo.Users", name: "StatusUser_Id", newName: "StatusUserId");
            AlterColumn("dbo.Users", "StatusUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "StatusUserId");
            AddForeignKey("dbo.Users", "StatusUserId", "dbo.StatusUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "StatusUserId", "dbo.StatusUsers");
            DropIndex("dbo.Users", new[] { "StatusUserId" });
            AlterColumn("dbo.Users", "StatusUserId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "StatusUserId", newName: "StatusUser_Id");
            CreateIndex("dbo.Users", "StatusUser_Id");
            AddForeignKey("dbo.Users", "StatusUser_Id", "dbo.StatusUsers", "Id");
        }
    }
}
