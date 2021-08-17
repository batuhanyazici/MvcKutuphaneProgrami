namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_original_pass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "OriginalPass", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "OriginalPass");
        }
    }
}
