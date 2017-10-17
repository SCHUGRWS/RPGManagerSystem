namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "DataNascimento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "DataNascimento", c => c.DateTime());
        }
    }
}
