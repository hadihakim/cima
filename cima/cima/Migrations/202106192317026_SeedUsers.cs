namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Usertype], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'20a48d93-e2fc-4b38-ad7e-207176c90827', 1, N'mhmd123@gmail.com', 0, N'AJFJF+Md/Rh+ybPT5SjI/yaaa22hv8Wfwi2HA/gkIBe04iYArUeWF43rpjjKC6ahmA==', N'fc1d2bbb-b994-45c0-98dc-4206809b6e8c', NULL, 0, 0, NULL, 1, 0, N'mhmd123@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Usertype], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'433cfe3f-8f8f-4e71-90fb-4740c8478c85', 1, N'hadi@gmail.com', 0, N'AHI/G+7u9UEwNSPvdNDOXTrusziwIHDTjk8eX4tGIXV1Rd5zxPZtHUUK8CxAVip+CQ==', N'3492b6d5-a5d3-4b62-8a34-726e3b70d7b8', NULL, 0, 0, NULL, 1, 0, N'hadi@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Usertype], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7521f835-e675-4022-9034-94c0c140b8a3', 0, N'hadihakim123@gmail.com', 0, N'AAXTg42KLGML+whEvZ5025ABw3KnW+PA9I4sCXGKa/o0n04Q0xXjfMCUaqBm2uTCPw==', N'f42a6945-caea-473e-ae9b-7cfabad58e8f', NULL, 0, 0, NULL, 1, 0, N'hadihakim123@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Usertype], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8502a0f8-6713-4c92-a1d0-34637f782a73', 0, N'admin@gmail.com', 0, N'ADPfFu5N86uD6t9hgp1rQgvv59OW58Hjttbp+l0ZasnqzD7jcJK3jx8h0DDEBVDr0A==', N'e8d0670e-554c-4a73-b2a7-dbf54884d95a', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bb9ef075-dd83-4ca4-b727-64ac730ad10f', N'applicationAdmin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8502a0f8-6713-4c92-a1d0-34637f782a73', N'bb9ef075-dd83-4ca4-b727-64ac730ad10f')

");
        }
        
        public override void Down()
        {
        }
    }
}
