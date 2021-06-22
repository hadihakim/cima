namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNormalUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Usertype], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bbf27c1f-1afc-4615-9ed3-43dd7759f810', 1, N'normal1@gmail.com', 0, N'ANnrQKlFeufQGZBa4hICwdk97wLrTz8NPaWPqo65TSK1L1jf8zECocqH6gCmkq+03g==', N'8cad39f5-80c9-48c7-84bc-07caa92e93d8', NULL, 0, 0, NULL, 1, 0, N'normal1@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9ed46312-0d12-41c6-aefb-3711f85bce78', N'NormalAccount')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bbf27c1f-1afc-4615-9ed3-43dd7759f810', N'9ed46312-0d12-41c6-aefb-3711f85bce78')


");
           
        }
        
        public override void Down()
        {
        }
    }
}
