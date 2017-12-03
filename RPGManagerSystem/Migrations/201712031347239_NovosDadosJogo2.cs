namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovosDadosJogo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sheets", "Game_Id", "dbo.Games");
            AddColumn("dbo.Games", "SheetId", c => c.Long(nullable: false));
            AddColumn("dbo.Sheets", "Game_Id1", c => c.Long());
            CreateIndex("dbo.Games", "SheetId");
            CreateIndex("dbo.Sheets", "Game_Id1");
            AddForeignKey("dbo.Games", "SheetId", "dbo.Sheets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sheets", "Game_Id1", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sheets", "Game_Id1", "dbo.Games");
            DropForeignKey("dbo.Games", "SheetId", "dbo.Sheets");
            DropIndex("dbo.Sheets", new[] { "Game_Id1" });
            DropIndex("dbo.Games", new[] { "SheetId" });
            DropColumn("dbo.Sheets", "Game_Id1");
            DropColumn("dbo.Games", "SheetId");
            AddForeignKey("dbo.Sheets", "Game_Id", "dbo.Games", "Id");
        }
    }
}
