namespace MemesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikeToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        MemeId = c.Int(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        DislikeCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Likes");
        }
    }
}
