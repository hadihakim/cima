namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEnumFromMovieModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "MovieGenre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MovieGenre", c => c.Int(nullable: false));
        }
    }
}
