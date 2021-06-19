namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieGenre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieGenre");
        }
    }
}
