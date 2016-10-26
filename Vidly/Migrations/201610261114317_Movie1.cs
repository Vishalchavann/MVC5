namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movie1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ReleseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(),
                        NumberInStock = c.Int(nullable: false),
                        MovieGenres_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MovieGenres", t => t.MovieGenres_ID)
                .Index(t => t.MovieGenres_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie1", "MovieGenres_ID", "dbo.MovieGenres");
            DropIndex("dbo.Movie1", new[] { "MovieGenres_ID" });
            DropTable("dbo.Movie1");
        }
    }
}
