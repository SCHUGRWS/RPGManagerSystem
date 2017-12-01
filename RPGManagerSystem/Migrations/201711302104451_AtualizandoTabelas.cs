namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizandoTabelas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Storyteller_Id", "dbo.Storytellers");
            DropIndex("dbo.Games", new[] { "Storyteller_Id" });
            RenameColumn(table: "dbo.Games", name: "Storyteller_Id", newName: "StorytellerId");
            AddColumn("dbo.Games", "Historia", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "StorytellerId", c => c.Long(nullable: false));
            CreateIndex("dbo.Games", "StorytellerId");
            AddForeignKey("dbo.Games", "StorytellerId", "dbo.Storytellers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "StorytellerId", "dbo.Storytellers");
            DropIndex("dbo.Games", new[] { "StorytellerId" });
            AlterColumn("dbo.Games", "StorytellerId", c => c.Long());
            DropColumn("dbo.Games", "Historia");
            RenameColumn(table: "dbo.Games", name: "StorytellerId", newName: "Storyteller_Id");
            CreateIndex("dbo.Games", "Storyteller_Id");
            AddForeignKey("dbo.Games", "Storyteller_Id", "dbo.Storytellers", "Id");
        }
    }
}
