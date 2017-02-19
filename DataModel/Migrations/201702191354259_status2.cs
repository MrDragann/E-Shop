namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusUsers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "StatusUser_Id", c => c.Int());
            CreateIndex("dbo.Users", "StatusUser_Id");
            AddForeignKey("dbo.Users", "StatusUser_Id", "dbo.StatusUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "StatusUser_Id", "dbo.StatusUsers");
            DropIndex("dbo.Users", new[] { "StatusUser_Id" });
            DropColumn("dbo.Users", "StatusUser_Id");
            DropTable("dbo.StatusUsers");
        }
    }
}
