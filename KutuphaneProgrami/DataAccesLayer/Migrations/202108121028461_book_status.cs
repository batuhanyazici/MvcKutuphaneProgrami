namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Status");
        }
    }
}
