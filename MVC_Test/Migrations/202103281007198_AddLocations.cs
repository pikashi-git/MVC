namespace MVC_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationSerial = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false),
                        AreaCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationSerial);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Location");
        }
    }
}
