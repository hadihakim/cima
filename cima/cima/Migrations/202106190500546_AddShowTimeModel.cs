namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowTimeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Showtimes",
                c => new
                    {
                        showtimeId = c.Int(nullable: false, identity: true),
                        movieId = c.Int(nullable: false),
                        day = c.Int(nullable: false),
                        time1 = c.DateTime(nullable: false),
                        time2 = c.DateTime(nullable: false),
                        time3 = c.DateTime(nullable: false),
                        time4 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.showtimeId)
                .ForeignKey("dbo.Movies", t => t.movieId, cascadeDelete: true)
                .Index(t => t.movieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Showtimes", "movieId", "dbo.Movies");
            DropIndex("dbo.Showtimes", new[] { "movieId" });
            DropTable("dbo.Showtimes");
        }
    }
}
