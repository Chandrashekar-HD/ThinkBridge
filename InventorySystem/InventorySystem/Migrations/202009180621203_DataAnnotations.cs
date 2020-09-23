namespace InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Inventories", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "Description", c => c.String());
            AlterColumn("dbo.Inventories", "Name", c => c.String());
        }
    }
}
