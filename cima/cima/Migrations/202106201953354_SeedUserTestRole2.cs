namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserTestRole2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Usertype], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b3d1b345-f1ef-4f7b-8f53-38b5f21bce92', 0, N'testrole2@gmail.com', 0, N'AAMqnCUpToiD7md/1kvwLHHgXhwskKYXkUORwnZVq96R0xrZQzHbp/EYkeMQns8Eow==', N'dde9c72e-5573-4361-93fc-3a84c5414af2', NULL, 0, 0, NULL, 1, 0, N'testrole2@gmail.com')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b3d1b345-f1ef-4f7b-8f53-38b5f21bce92', N'679fbd2a-1142-4df1-9dc2-1bf47b18fcc2')
");
        }
        
        public override void Down()
        {
        }
    }
}
