namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (ID,NAME) VALUES ('1','Comedy')");
            Sql("INSERT INTO Genres (ID,NAME) VALUES ('2','Action')");
            Sql("INSERT INTO Genres (ID,NAME) VALUES ('3','Family')");
            Sql("INSERT INTO Genres (ID,NAME) VALUES ('4','Romance')");            
        }
        
        public override void Down()
        {
        }
    }
}
