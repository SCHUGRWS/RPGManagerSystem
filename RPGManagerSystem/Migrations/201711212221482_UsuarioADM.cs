namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioADM : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6d55fa7e-33c8-4c17-b779-a329da089b6e', N'administrador@rpgmanagersystem.com.br', 0, N'ACBZJPeKb4LLudvFNrciKsKeHiuM7tYRAN5rsWef1FicK63iUKDBLeQ3TMLG304Y0A==', N'39c7dd6a-45da-4317-9354-1d1731405df5', NULL, 0, 0, NULL, 1, 0, N'administrador@rpgmanagersystem.com.br')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5ba8726e-1fd7-4fc0-a354-861bdfe038d6', N'Administrador')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d55fa7e-33c8-4c17-b779-a329da089b6e', N'5ba8726e-1fd7-4fc0-a354-861bdfe038d6')
");
        }
        
        public override void Down()
        {
        }
    }
}
