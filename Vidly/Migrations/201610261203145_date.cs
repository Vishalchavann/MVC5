namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie1", "MovieGenres_ID", "dbo.MovieGenres");
            DropIndex("dbo.Movie1", new[] { "MovieGenres_ID" });
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            DropTable("dbo.Movie1");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
            CreateIndex("dbo.Movie1", "MovieGenres_ID");
            AddForeignKey("dbo.Movie1", "MovieGenres_ID", "dbo.MovieGenres", "ID");
        }
    }
}
