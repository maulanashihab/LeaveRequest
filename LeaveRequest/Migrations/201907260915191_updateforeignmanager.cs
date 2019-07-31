namespace LeaveRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateforeignmanager : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Manager_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Manager_Id");
            AddForeignKey("dbo.Employees", "Manager_Id", "dbo.Employees", "Id");
            DropColumn("dbo.Employees", "ManagerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ManagerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "Manager_Id", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Manager_Id" });
            DropColumn("dbo.Employees", "Manager_Id");
        }
    }
}
