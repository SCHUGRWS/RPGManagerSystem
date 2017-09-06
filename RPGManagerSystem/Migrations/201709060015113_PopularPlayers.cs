namespace RPGManagerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopularPlayers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PLAYERS (Nome) VALUES ('Richard')");
            Sql("INSERT INTO PLAYERS (Nome) VALUES ('Wilhian')");
            Sql("INSERT INTO PLAYERS (Nome) VALUES ('Schug')");
        }

        public override void Down()
        {
        }
    }
}
