namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category_id1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.CategoryBooks", "Book_Id", "dbo.Books");
            DropIndex("dbo.CategoryBooks", new[] { "Category_Id" });
            DropIndex("dbo.CategoryBooks", new[] { "Book_Id" });
            CreateIndex("dbo.Books", "CategoryId");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropTable("dbo.CategoryBooks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Book_Id });
            
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            CreateIndex("dbo.CategoryBooks", "Book_Id");
            CreateIndex("dbo.CategoryBooks", "Category_Id");
            AddForeignKey("dbo.CategoryBooks", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
