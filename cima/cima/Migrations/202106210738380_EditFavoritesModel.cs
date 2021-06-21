namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditFavoritesModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Favorites");
            AddPrimaryKey("dbo.Favorites", new[] { "userName", "movieId" });
            DropColumn("dbo.Favorites", "favoriteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Favorites", "favoriteId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Favorites");
            AddPrimaryKey("dbo.Favorites", "favoriteId");
        }
    }
}
