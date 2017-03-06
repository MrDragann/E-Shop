namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderstatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "StatusOrder_Id", "dbo.StatusOrders");
            DropIndex("dbo.Orders", new[] { "StatusOrder_Id" });
            RenameColumn(table: "dbo.Orders", name: "StatusOrder_Id", newName: "StatusOrderId");
            AddColumn("dbo.Users", "Photo", c => c.String());
            AlterColumn("dbo.Orders", "StatusOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "StatusOrderId");
            AddForeignKey("dbo.Orders", "StatusOrderId", "dbo.StatusOrders", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "OrderStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderStatus", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "StatusOrderId", "dbo.StatusOrders");
            DropIndex("dbo.Orders", new[] { "StatusOrderId" });
            AlterColumn("dbo.Orders", "StatusOrderId", c => c.Int());
            DropColumn("dbo.Users", "Photo");
            RenameColumn(table: "dbo.Orders", name: "StatusOrderId", newName: "StatusOrder_Id");
            CreateIndex("dbo.Orders", "StatusOrder_Id");
            AddForeignKey("dbo.Orders", "StatusOrder_Id", "dbo.StatusOrders", "Id");
        }
    }
}
