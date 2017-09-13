namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPlayerToSheet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sheets", "Player_Id", "dbo.Players");
            DropIndex("dbo.Sheets", new[] { "Player_Id" });
            RenameColumn(table: "dbo.Sheets", name: "Player_Id", newName: "PlayerId");
            AlterColumn("dbo.Sheets", "PlayerId", c => c.Long(nullable: false));
            CreateIndex("dbo.Sheets", "PlayerId");
            AddForeignKey("dbo.Sheets", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sheets", "PlayerId", "dbo.Players");
            DropIndex("dbo.Sheets", new[] { "PlayerId" });
            AlterColumn("dbo.Sheets", "PlayerId", c => c.Long());
            RenameColumn(table: "dbo.Sheets", name: "PlayerId", newName: "Player_Id");
            CreateIndex("dbo.Sheets", "Player_Id");
            AddForeignKey("dbo.Sheets", "Player_Id", "dbo.Players", "Id");
        }
    }
}
