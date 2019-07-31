namespace LeaveRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmoduleavailableleave : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableLeaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThisYear = c.Int(nullable: false),
                        LastYear = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AvailableLeaves");
        }
    }
}
