namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviegeneresID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieGenresID", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieGenresID");
        }
    }
}
