namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrow_user_and_book : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Borrows", "BookId");
            AddForeignKey("dbo.Borrows", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrows", "BookId", "dbo.Books");
            DropIndex("dbo.Borrows", new[] { "BookId" });
        }
    }
}
