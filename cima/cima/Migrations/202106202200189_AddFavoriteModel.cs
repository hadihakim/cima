namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavoriteModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        favoriteId = c.Int(nullable: false, identity: true),
                        userName = c.String(maxLength: 255),
                        movieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.favoriteId)
                .ForeignKey("dbo.Movies", t => t.movieId, cascadeDelete: true)
                .Index(t => t.movieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "movieId", "dbo.Movies");
            DropIndex("dbo.Favorites", new[] { "movieId" });
            DropTable("dbo.Favorites");
        }
    }
}
