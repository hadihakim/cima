namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveApplicationUserFromMovieModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "UserId" });
            AlterColumn("dbo.Movies", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Movies", "UserId");
            AddForeignKey("dbo.Movies", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
