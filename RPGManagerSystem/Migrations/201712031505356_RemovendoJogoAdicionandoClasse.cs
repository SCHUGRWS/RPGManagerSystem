namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoJogoAdicionandoClasse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sheets", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Sheets", "Game_Id1", "dbo.Games");
            DropForeignKey("dbo.Games", "SheetId", "dbo.Sheets");
            DropForeignKey("dbo.Games", "StorytellerId", "dbo.Storytellers");
            DropIndex("dbo.Games", new[] { "SheetId" });
            DropIndex("dbo.Games", new[] { "StorytellerId" });
            DropIndex("dbo.Sheets", new[] { "Game_Id" });
            DropIndex("dbo.Sheets", new[] { "Game_Id1" });
            CreateTable(
                "dbo.SheetClasses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        Habilidades = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sheets", "ClasseId", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Sheets", "Classe_Id", c => c.Long());
            CreateIndex("dbo.Sheets", "Classe_Id");
            AddForeignKey("dbo.Sheets", "Classe_Id", "dbo.SheetClasses", "Id");
            DropColumn("dbo.Sheets", "Classe");
            DropColumn("dbo.Sheets", "GameId");
            DropColumn("dbo.Sheets", "Game_Id");
            DropColumn("dbo.Sheets", "Game_Id1");
            DropTable("dbo.Games");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        SheetId = c.Long(nullable: false),
                        StorytellerId = c.Long(nullable: false),
                        Historia = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sheets", "Game_Id1", c => c.Long());
            AddColumn("dbo.Sheets", "Game_Id", c => c.Long());
            AddColumn("dbo.Sheets", "GameId", c => c.String());
            AddColumn("dbo.Sheets", "Classe", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Sheets", "Classe_Id", "dbo.SheetClasses");
            DropIndex("dbo.Sheets", new[] { "Classe_Id" });
            DropColumn("dbo.Sheets", "Classe_Id");
            DropColumn("dbo.Sheets", "ClasseId");
            DropTable("dbo.SheetClasses");
            CreateIndex("dbo.Sheets", "Game_Id1");
            CreateIndex("dbo.Sheets", "Game_Id");
            CreateIndex("dbo.Games", "StorytellerId");
            CreateIndex("dbo.Games", "SheetId");
            AddForeignKey("dbo.Games", "StorytellerId", "dbo.Storytellers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Games", "SheetId", "dbo.Sheets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sheets", "Game_Id1", "dbo.Games", "Id");
            AddForeignKey("dbo.Sheets", "Game_Id", "dbo.Games", "Id");
        }
    }
}
