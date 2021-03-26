namespace MemesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategoriesValuetoDb : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Categories] ON");
            Sql("INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Animals')");
            Sql("INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Meme')");
            Sql("INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Politics')");
            Sql("INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Curiosity')");
            Sql("INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Funny')");
        }
        
        public override void Down()
        {
        }
    }
}
