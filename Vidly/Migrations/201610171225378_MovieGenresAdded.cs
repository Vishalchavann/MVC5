namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieGenresAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        ReleseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        
                        MovieGenres_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MovieGenres", t => t.MovieGenres_ID)
                .Index(t => t.MovieGenres_ID);
            
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenres_ID", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenres_ID" });
            DropTable("dbo.MovieGenres");
            DropTable("dbo.Movies");
        }
    }
}
