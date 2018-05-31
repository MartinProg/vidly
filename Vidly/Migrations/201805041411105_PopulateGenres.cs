namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Id,Name) values (1,'Comedy') ");
            Sql("insert into Genres (Id,Name) values (2,'Family') ");
            Sql("insert into Genres (Id,Name) values (3,'Romance') ");
            Sql("insert into Genres (Id,Name) values (4,'Action') ");
            Sql("insert into Genres (Id,Name) values (5,'Drama') ");
            Sql("insert into Genres (Id,Name) values (6,'War') ");
            Sql("insert into Genres (Id,Name) values (7,'History') ");
            Sql("insert into Genres (Id,Name) values (8,'Fantasy') ");
        }
        
        public override void Down()
        {
        }
    }
}
