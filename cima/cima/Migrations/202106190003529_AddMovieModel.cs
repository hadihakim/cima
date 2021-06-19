namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        movieid = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        movieName = c.String(nullable: false, maxLength: 255),
                        movieYear = c.Int(nullable: false),
                        movieSeason = c.Int(nullable: false),
                        starring = c.String(maxLength: 255),
                        creator = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.movieid)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "UserId" });
            DropTable("dbo.Movies");
        }
    }
}
