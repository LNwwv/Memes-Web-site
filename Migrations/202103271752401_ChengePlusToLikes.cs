namespace MemesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChengePlusToLikes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemeModels", "Likes", c => c.Int(nullable: false));
            DropColumn("dbo.MemeModels", "Plus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemeModels", "Plus", c => c.Int(nullable: false));
            DropColumn("dbo.MemeModels", "Likes");
        }
    }
}
