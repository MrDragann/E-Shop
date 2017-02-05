namespace ProductModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class products : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parrent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Parrent_Id)
                .Index(t => t.Parrent_Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        selectedCategory = c.String(),
                        Description = c.String(),
                        Characteristics = c.String(),
                        Price = c.Int(nullable: false),
                        Tags = c.String(),
                        DateAdd = c.String(),
                        Image = c.String(),
                        ManufacturerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .Index(t => t.ManufacturerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Categories", "Parrent_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Categories", new[] { "Parrent_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
        }
    }
}
