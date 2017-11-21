namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoTabela2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Storytellers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        Apelido = c.String(maxLength: 255),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "Storyteller_Id", c => c.Long());
            CreateIndex("dbo.Games", "Storyteller_Id");
            AddForeignKey("dbo.Games", "Storyteller_Id", "dbo.Storytellers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Storyteller_Id", "dbo.Storytellers");
            DropIndex("dbo.Games", new[] { "Storyteller_Id" });
            DropColumn("dbo.Games", "Storyteller_Id");
            DropTable("dbo.Storytellers");
        }
    }
}
