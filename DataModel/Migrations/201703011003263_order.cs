namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Users", "CartId", "dbo.Carts");
            DropIndex("dbo.Users", new[] { "CartId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        StatusOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StatusOrders", t => t.StatusOrder_Id)
                .Index(t => t.StatusOrder_Id);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.StatusOrders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderUsers",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.User_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.Users", "CartId");
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "CartId", c => c.Int());
            DropForeignKey("dbo.Orders", "StatusOrder_Id", "dbo.StatusOrders");
            DropForeignKey("dbo.OrderUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.OrderUsers", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderUsers", new[] { "User_Id" });
            DropIndex("dbo.OrderUsers", new[] { "Order_Id" });
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "StatusOrder_Id" });
            DropTable("dbo.OrderUsers");
            DropTable("dbo.StatusOrders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Orders");
            CreateIndex("dbo.Carts", "ProductId");
            CreateIndex("dbo.Users", "CartId");
            AddForeignKey("dbo.Users", "CartId", "dbo.Carts", "Id");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
