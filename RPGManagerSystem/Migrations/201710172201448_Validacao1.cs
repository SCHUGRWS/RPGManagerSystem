namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validacao1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Nome", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Players", "Apelido", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Apelido", c => c.String());
            AlterColumn("dbo.Players", "Nome", c => c.String(nullable: false));
        }
    }
}
