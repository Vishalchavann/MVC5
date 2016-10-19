namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMovieGenre : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Genre");
            DropColumn("dbo.Movies", "MovieGenresID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MovieGenresID", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
        }
    }
}
