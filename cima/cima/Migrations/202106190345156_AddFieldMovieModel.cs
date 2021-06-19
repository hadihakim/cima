namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "userName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "userName");
        }
    }
}
