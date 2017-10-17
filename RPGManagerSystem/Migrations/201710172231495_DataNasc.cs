namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataNasc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "DataNascimento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "DataNascimento");
        }
    }
}
