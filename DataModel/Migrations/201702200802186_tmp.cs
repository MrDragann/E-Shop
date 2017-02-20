namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tmp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Categories", name: "Category_Id", newName: "ParentId");
            RenameIndex(table: "dbo.Categories", name: "IX_Category_Id", newName: "IX_ParentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Categories", name: "IX_ParentId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Categories", name: "ParentId", newName: "Category_Id");
        }
    }
}
