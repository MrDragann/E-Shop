namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alo2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "alo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "alo", c => c.Int());
        }
    }
}
