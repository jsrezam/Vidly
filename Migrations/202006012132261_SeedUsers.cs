namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5d392d33-da95-47be-92b4-546619d36a1f', N'admin@vidly.com', 0, N'ANvR0/Vhogk31FS7EImCs3fPE7f6y+ujvzmOTX3EeoGTc2ukitIEpaZeqZIjL+lpTw==', N'5f5fdc5e-f9d4-49a6-bb08-64319fe62636', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'77ac9d88-d6ea-4303-9999-0c72df8743e3', N'guest@vidly.com', 0, N'AEB3216PyDhG6Ko3HXaY3k8oYAq7gHyIAVmxup/ESUiyxNTs3Cm8J+b7Boc+78YQvw==', N'ba313bf2-184a-4da9-9c85-0d87ef8d3caa', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bdbe4bd3-4d63-4122-b670-35f4fa18c9e8', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5d392d33-da95-47be-92b4-546619d36a1f', N'bdbe4bd3-4d63-4122-b670-35f4fa18c9e8')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
