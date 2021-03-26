namespace MemesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnterMemesToDb : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[MemeModels] ON");
            Sql("INSERT INTO[dbo].[MemeModels] ([Id], [Title], [Plus], [ImgSource], [CreatedBy], [AddedDate], [CategoryId]) VALUES(81, N'Corgdashian', 4, N'https://i.pinimg.com/originals/6b/f7/01/6bf70103441c1892020f7a48750854af.jpg', N'User', N'2021-03-26 09:29:32', 1)");
            Sql("INSERT INTO [dbo].[MemeModels] ([Id], [Title], [Plus], [ImgSource], [CreatedBy], [AddedDate], [CategoryId]) VALUES (82, N'Typical fail', 2, N'https://i.pinimg.com/originals/01/86/d2/0186d29b82b424d6b2189c8ae999d0ce.jpg', N'User', N'2021-03-26 09:33:32', 2)");
            Sql("INSERT INTO [dbo].[MemeModels] ([Id], [Title], [Plus], [ImgSource], [CreatedBy], [AddedDate], [CategoryId]) VALUES (86, N'Mars', 0, N'https://i.insider.com/502292d36bb3f76241000009?width=1100&format=jpeg&auto=webp', N'Admin', N'2021-03-26 09:42:51', 4)");
            Sql("INSERT INTO [dbo].[MemeModels] ([Id], [Title], [Plus], [ImgSource], [CreatedBy], [AddedDate], [CategoryId]) VALUES (88, N'Cat', 0, N'https://instoremag.com/wp-content/uploads/2020/01/doing-a-bit-of-everything-photo-u1.jpg', N'Admin', N'2021-03-26 09:45:35', 5)");
            Sql("INSERT INTO [dbo].[MemeModels] ([Id], [Title], [Plus], [ImgSource], [CreatedBy], [AddedDate], [CategoryId]) VALUES (89, N'Funny meme', 0, N'https://oaza-memow.pl/img/uploads/meme_6AcdEYJ9EMe2owITRHU2hlKXr.jpeg', N'Admin', N'2021-03-26 09:46:17', 5)");
            Sql("SET IDENTITY_INSERT [dbo].[MemeModels] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
