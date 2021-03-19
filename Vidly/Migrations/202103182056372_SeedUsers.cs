namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0e9f539b-2452-439e-8ff0-90a89867dab6', N'admin@vidly.com', 0, N'AKE/BOTdDqHtRqseZ0xvCzbpRwdw+s6l32wPtJGXfeuuMR7B10PWEU5Ci/xpv0C7nw==', N'd34dd91f-a02a-43ba-a2bf-a0aa7950c41a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd4c87755-e2e2-4d3a-a3ed-a45585b0ff2e', N'guest@vidly.com', 0, N'AOoT1waAaUFkvhTncjNBkU9ZZ9H22ctphEgLFtblQraXOd1uPAJ6TjgCADX+6W53Sg==', N'f5c0a28a-3dd9-4035-bd9f-905733f2daf3', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'23d578af-c758-4870-acff-aa1dfefdb66f', N'CanManageMovies')");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0e9f539b-2452-439e-8ff0-90a89867dab6', N'23d578af-c758-4870-acff-aa1dfefdb66f')");
        }
        
        public override void Down()
        {
        }
    }
}
