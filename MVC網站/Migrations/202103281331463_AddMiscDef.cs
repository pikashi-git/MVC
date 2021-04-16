namespace MVC網站.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMiscDef : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "Department_DepartmentID", c => c.Int());
            CreateIndex("dbo.Location", "Department_DepartmentID");
            AddForeignKey("dbo.Location", "Department_DepartmentID", "dbo.Departments", "DepartmentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "Department_DepartmentID", "dbo.Departments");
            DropIndex("dbo.Location", new[] { "Department_DepartmentID" });
            DropColumn("dbo.Location", "Department_DepartmentID");
        }
    }
}
