namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrow_request_given_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BorrowRequests", "Given", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BorrowRequests", "Given");
        }
    }
}
