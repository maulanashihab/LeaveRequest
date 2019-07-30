namespace LeaveRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifieddatatype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Num_Of_Children", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Gender", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Employees", "MaritalStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Employees", "Children");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Children", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "MaritalStatus", c => c.String());
            AlterColumn("dbo.Employees", "Gender", c => c.String());
            DropColumn("dbo.Employees", "Num_Of_Children");
        }
    }
}
