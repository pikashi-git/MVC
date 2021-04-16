﻿namespace MVC網站.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add202103282159 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Location_LocationSerial", c => c.Int());
            CreateIndex("dbo.Departments", "Location_LocationSerial");
            AddForeignKey("dbo.Departments", "Location_LocationSerial", "dbo.Location", "LocationSerial");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "Location_LocationSerial", "dbo.Location");
            DropIndex("dbo.Departments", new[] { "Location_LocationSerial" });
            DropColumn("dbo.Departments", "Location_LocationSerial");
        }
    }
}
