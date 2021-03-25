namespace MemesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToMemeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemeModels", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.MemeModels", "CategoryId");
            AddForeignKey("dbo.MemeModels", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemeModels", "CategoryId", "dbo.Categories");
            DropIndex("dbo.MemeModels", new[] { "CategoryId" });
            DropColumn("dbo.MemeModels", "CategoryId");
        }
    }
}
