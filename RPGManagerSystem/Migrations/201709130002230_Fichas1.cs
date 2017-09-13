namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fichas1 : DbMigration
    {
        public override void Up() { 
            DropPrimaryKey("dbo.Players");
            CreateTable(
                "dbo.Sheets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Player_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);


            AlterColumn("dbo.Players", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Players", "Id");
            Sql("INSERT INTO SHEETS (Player_Id) VALUES (1)");
            Sql("INSERT INTO SHEETS (Player_Id) VALUES (1)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sheets", "Player_Id", "dbo.Players");
            DropIndex("dbo.Sheets", new[] { "Player_Id" });
            DropPrimaryKey("dbo.Players");
            AlterColumn("dbo.Players", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Sheets");
            AddPrimaryKey("dbo.Players", "Id");
            AddColumn("dbo.Sheets", "IdPlayer", c => c.Long(nullable: false));
        }
    }
}
