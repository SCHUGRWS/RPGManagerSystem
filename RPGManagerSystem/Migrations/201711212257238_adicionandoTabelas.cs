namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionandoTabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sheets", "Nome", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Sheets", "Classe", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Sheets", "GameId", c => c.String());
            AddColumn("dbo.Sheets", "Game_Id", c => c.Long());
            CreateIndex("dbo.Sheets", "Game_Id");
            AddForeignKey("dbo.Sheets", "Game_Id", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sheets", "Game_Id", "dbo.Games");
            DropIndex("dbo.Sheets", new[] { "Game_Id" });
            DropColumn("dbo.Sheets", "Game_Id");
            DropColumn("dbo.Sheets", "GameId");
            DropColumn("dbo.Sheets", "Classe");
            DropColumn("dbo.Sheets", "Nome");
            DropTable("dbo.Games");
        }
    }
}
