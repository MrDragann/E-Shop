namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productdatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateAdd", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DateAdd", c => c.String());
        }
    }
}
