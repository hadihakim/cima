namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Usertype], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'44ad3dae-3285-4aec-87a5-2c420237c693', 0, N'cinema3@gmail.com', 0, N'AJX7ca765x1kPLkBkffvHJgWJdM89qVR5QMN1V+I1hixfqrXICJ7tlmLjq3zNWJ4SA==', N'8c02d6a2-5ab6-4240-b1ff-5bfe3a8f71b6', NULL, 0, 0, NULL, 1, 0, N'cinema3@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'679fbd2a-1142-4df1-9dc2-1bf47b18fcc2', N'CinemaAccount')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'44ad3dae-3285-4aec-87a5-2c420237c693', N'679fbd2a-1142-4df1-9dc2-1bf47b18fcc2')
");
        }
        
        public override void Down()
        {
        }
    }
}
