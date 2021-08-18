namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrow_request_Add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        BringDate = c.DateTime(nullable: false),
                        Borrow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Borrows", t => t.Borrow_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.UserId)
                .Index(t => t.Borrow_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.BorrowRequests", "Borrow_Id", "dbo.Borrows");
            DropForeignKey("dbo.BorrowRequests", "BookId", "dbo.Books");
            DropIndex("dbo.BorrowRequests", new[] { "Borrow_Id" });
            DropIndex("dbo.BorrowRequests", new[] { "UserId" });
            DropIndex("dbo.BorrowRequests", new[] { "BookId" });
            DropTable("dbo.BorrowRequests");
        }
    }
}
