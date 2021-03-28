namespace MemesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemeModelToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Plus = c.Int(nullable: false),
                        Minus = c.Int(nullable: false),
                        ImgSource = c.String(),
                        CreatedBy = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemeModels");
        }
    }
}
