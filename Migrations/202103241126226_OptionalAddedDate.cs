namespace MemesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalAddedDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MemeModels", "AddedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MemeModels", "AddedDate", c => c.DateTime(nullable: false));
        }
    }
}
