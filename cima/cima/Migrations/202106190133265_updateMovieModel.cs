namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "UserId", c => c.String());
            DropColumn("dbo.Movies", "releaseDate");
        }
    }
}
