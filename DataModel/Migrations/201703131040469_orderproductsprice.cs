namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderproductsprice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderUsers", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderUsers", "User_Id", "dbo.Users");
            DropIndex("dbo.OrderUsers", new[] { "Order_Id" });
            DropIndex("dbo.OrderUsers", new[] { "User_Id" });
            AddColumn("dbo.Orders", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderProducts", "Price", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "OrderDate");
            DropTable("dbo.OrderUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderUsers",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.User_Id });
            
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropColumn("dbo.OrderProducts", "Price");
            DropColumn("dbo.Orders", "CreateDate");
            CreateIndex("dbo.OrderUsers", "User_Id");
            CreateIndex("dbo.OrderUsers", "Order_Id");
            AddForeignKey("dbo.OrderUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderUsers", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
