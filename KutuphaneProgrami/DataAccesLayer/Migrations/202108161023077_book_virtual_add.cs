namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book_virtual_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "User_Id", c => c.Int());
            CreateIndex("dbo.Books", "User_Id");
            AddForeignKey("dbo.Books", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "User_Id", "dbo.Users");
            DropIndex("dbo.Books", new[] { "User_Id" });
            DropColumn("dbo.Books", "User_Id");
        }
    }
}
