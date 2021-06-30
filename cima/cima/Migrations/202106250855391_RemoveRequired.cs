namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FeedBacks", "comment", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedBacks", "comment", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
