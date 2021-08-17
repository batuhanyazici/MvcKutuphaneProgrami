namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category_id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "CategoryId");
        }
    }
}
