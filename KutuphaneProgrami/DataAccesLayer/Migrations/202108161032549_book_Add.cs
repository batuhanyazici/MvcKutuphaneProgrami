namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book_Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Borrows", "Book_Id", c => c.Int());
            CreateIndex("dbo.Borrows", "BookId");
            CreateIndex("dbo.Borrows", "Book_Id");
            AddForeignKey("dbo.Borrows", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Borrows", "Book_Id", "dbo.Books", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrows", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Borrows", "BookId", "dbo.Books");
            DropIndex("dbo.Borrows", new[] { "Book_Id" });
            DropIndex("dbo.Borrows", new[] { "BookId" });
            DropColumn("dbo.Borrows", "Book_Id");
        }
    }
}
