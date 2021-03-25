namespace MemesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCommentsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommendId = c.Int(nullable: false, identity: true),
                        Body = c.String(storeType: "ntext"),
                        UserId = c.String(),
                        MemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommendId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
