namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatObrigatoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "DataNascimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "DataNascimento");
        }
    }
}
