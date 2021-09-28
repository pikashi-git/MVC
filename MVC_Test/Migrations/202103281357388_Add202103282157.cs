namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add202103282157 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "Department_DepartmentID", "dbo.Departments");
            DropIndex("dbo.Location", new[] { "Department_DepartmentID" });
            DropColumn("dbo.Location", "Department_DepartmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "Department_DepartmentID", c => c.Int());
            CreateIndex("dbo.Location", "Department_DepartmentID");
            AddForeignKey("dbo.Location", "Department_DepartmentID", "dbo.Departments", "DepartmentID");
        }
    }
}
