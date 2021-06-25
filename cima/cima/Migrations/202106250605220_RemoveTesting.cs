namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTesting : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.testings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.testings",
                c => new
                    {
                        testId = c.Int(nullable: false, identity: true),
                        testname = c.String(),
                    })
                .PrimaryKey(t => t.testId);
            
        }
    }
}
