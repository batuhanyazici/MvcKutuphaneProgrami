namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role_Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Authority");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Authority", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Role");
        }
    }
}
