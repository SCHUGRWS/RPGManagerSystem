namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testesDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Nome", c => c.String());
        }
    }
}
