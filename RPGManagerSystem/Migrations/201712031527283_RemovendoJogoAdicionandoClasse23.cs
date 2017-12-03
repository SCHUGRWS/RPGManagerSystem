namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoJogoAdicionandoClasse23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sheets", "SheetClass_Id", "dbo.SheetClasses");
            DropIndex("dbo.Sheets", new[] { "SheetClass_Id" });
            DropColumn("dbo.Sheets", "SheetClassId");
            RenameColumn(table: "dbo.Sheets", name: "SheetClass_Id", newName: "SheetClassId");
            AlterColumn("dbo.Sheets", "SheetClassId", c => c.Long(nullable: false));
            AlterColumn("dbo.Sheets", "SheetClassId", c => c.Long(nullable: false));
            CreateIndex("dbo.Sheets", "SheetClassId");
            AddForeignKey("dbo.Sheets", "SheetClassId", "dbo.SheetClasses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sheets", "SheetClassId", "dbo.SheetClasses");
            DropIndex("dbo.Sheets", new[] { "SheetClassId" });
            AlterColumn("dbo.Sheets", "SheetClassId", c => c.Long());
            AlterColumn("dbo.Sheets", "SheetClassId", c => c.String(nullable: false, maxLength: 255));
            RenameColumn(table: "dbo.Sheets", name: "SheetClassId", newName: "SheetClass_Id");
            AddColumn("dbo.Sheets", "SheetClassId", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Sheets", "SheetClass_Id");
            AddForeignKey("dbo.Sheets", "SheetClass_Id", "dbo.SheetClasses", "Id");
        }
    }
}
