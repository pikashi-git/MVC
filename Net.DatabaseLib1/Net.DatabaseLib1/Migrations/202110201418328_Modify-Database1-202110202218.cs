namespace Net.DatabaseLib1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase1202110202218 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        Delivery = c.String(),
                    })
                .PrimaryKey(t => new { t.OrderId, t.CustomerId });
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.String(nullable: false, maxLength: 128),
                        OrderId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.String(),
                        Pics = c.Int(nullable: false),
                        Order_OrderId = c.String(maxLength: 128),
                        Order_CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.OrderDetailId, t.OrderId })
                .ForeignKey("dbo.Orders", t => new { t.Order_OrderId, t.Order_CustomerId })
                .Index(t => new { t.Order_OrderId, t.Order_CustomerId });
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", new[] { "Order_OrderId", "Order_CustomerId" }, "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId", "Order_CustomerId" });
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
