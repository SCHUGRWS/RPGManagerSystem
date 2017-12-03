namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoJogoAdicionandoClasse2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sheets", name: "Classe_Id", newName: "SheetClass_Id");
            RenameIndex(table: "dbo.Sheets", name: "IX_Classe_Id", newName: "IX_SheetClass_Id");
            AddColumn("dbo.Sheets", "SheetClassId", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Sheets", "ClasseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sheets", "ClasseId", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Sheets", "SheetClassId");
            RenameIndex(table: "dbo.Sheets", name: "IX_SheetClass_Id", newName: "IX_Classe_Id");
            RenameColumn(table: "dbo.Sheets", name: "SheetClass_Id", newName: "Classe_Id");
        }
    }
}
