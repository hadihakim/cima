namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeedBackModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        feedBackId = c.Int(nullable: false, identity: true),
                        movieId = c.Int(nullable: false),
                        comment = c.String(nullable: false, maxLength: 500),
                        userName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.feedBackId)
                .ForeignKey("dbo.Movies", t => t.movieId, cascadeDelete: true)
                .Index(t => t.movieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedBacks", "movieId", "dbo.Movies");
            DropIndex("dbo.FeedBacks", new[] { "movieId" });
            DropTable("dbo.FeedBacks");
        }
    }
}
