namespace MemesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMinusSection : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MemeModels", "Minus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemeModels", "Minus", c => c.Int(nullable: false));
        }
    }
}
