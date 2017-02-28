namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelcart : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Users", "CartId", c => c.Int());
            CreateIndex("dbo.Users", "CartId");
            AddForeignKey("dbo.Users", "CartId", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropIndex("dbo.Users", new[] { "CartId" });
            DropColumn("dbo.Users", "CartId");
            DropTable("dbo.Carts");
        }
    }
}
