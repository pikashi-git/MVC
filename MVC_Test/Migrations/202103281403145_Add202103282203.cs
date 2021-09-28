namespace MVC網站.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add202103282203 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Departments", new[] { "Location_LocationSerial" });
            DropColumn("dbo.Departments", "DepartmentID");
            RenameColumn(table: "dbo.Departments", name: "Location_LocationSerial", newName: "DepartmentID");
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Departments", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "DepartmentID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Departments", "DepartmentID");
            CreateIndex("dbo.Departments", "DepartmentID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Departments", new[] { "DepartmentID" });
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Departments", "DepartmentID", c => c.Int());
            AlterColumn("dbo.Departments", "DepartmentID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Departments", "DepartmentID");
            RenameColumn(table: "dbo.Departments", name: "DepartmentID", newName: "Location_LocationSerial");
            AddColumn("dbo.Departments", "DepartmentID", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Departments", "Location_LocationSerial");
        }
    }
}
