namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ReceivingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Address");
            DropColumn("dbo.Orders", "ReceivingDate");
        }
    }
}
