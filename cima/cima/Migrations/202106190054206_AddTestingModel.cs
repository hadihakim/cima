namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestingModel : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.testings");
        }
    }
}
