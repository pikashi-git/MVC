namespace MVC網站.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentForeignLocation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "Department_DepartmentID", "dbo.Departments");
            DropIndex("dbo.Location", new[] { "Department_DepartmentID" });
            DropColumn("dbo.Departments", "DepartmentID");
            RenameColumn(table: "dbo.Departments", name: "Department_DepartmentID", newName: "DepartmentID");
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Departments", "DepartmentID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Departments", "DepartmentID");
            CreateIndex("dbo.Departments", "DepartmentID");
            DropColumn("dbo.Location", "Department_DepartmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "Department_DepartmentID", c => c.Int());
            DropIndex("dbo.Departments", new[] { "DepartmentID" });
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Departments", "DepartmentID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Departments", "DepartmentID");
            RenameColumn(table: "dbo.Departments", name: "DepartmentID", newName: "Department_DepartmentID");
            AddColumn("dbo.Departments", "DepartmentID", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Location", "Department_DepartmentID");
            AddForeignKey("dbo.Location", "Department_DepartmentID", "dbo.Departments", "DepartmentID");
        }
    }
}
