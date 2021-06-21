namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFavoriteModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Favorites", "userName", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Favorites", "userName", c => c.String(maxLength: 255));
        }
    }
}
