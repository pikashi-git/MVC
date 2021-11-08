namespace Net.DatabaseLib1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase1202110202315 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", new[] { "Order_OrderId", "Order_CustomerId" }, "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId", "Order_CustomerId" });
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.OrderDetails", "Pic", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Misc", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Customers", "CustomerId", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Customers", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Orders", "OrderId", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "CustomerId", c => c.String(maxLength: 10));
            AlterColumn("dbo.Orders", "Delivery", c => c.String(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderDetailId", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.String(maxLength: 10));
            AlterColumn("dbo.OrderDetails", "Order_OrderId", c => c.String(maxLength: 10));
            AlterColumn("dbo.Products", "ProductId", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.Customers", "CustomerId");
            AddPrimaryKey("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.OrderDetails", "OrderDetailId");
            AddPrimaryKey("dbo.Products", "ProductId");
            CreateIndex("dbo.Orders", "CustomerId");
            CreateIndex("dbo.OrderDetails", "ProductId");
            CreateIndex("dbo.OrderDetails", "Order_OrderId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders", "OrderId");
            DropColumn("dbo.OrderDetails", "OrderId");
            DropColumn("dbo.OrderDetails", "Pics");
            DropColumn("dbo.OrderDetails", "Order_CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Order_CustomerId", c => c.String(maxLength: 128));
            AddColumn("dbo.OrderDetails", "Pics", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "OrderId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.OrderDetails");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetails", "Order_OrderId", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.String());
            AlterColumn("dbo.OrderDetails", "OrderDetailId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Orders", "Delivery", c => c.String());
            AlterColumn("dbo.Orders", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Orders", "OrderId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Customers", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Products", "Misc");
            DropColumn("dbo.OrderDetails", "Pic");
            AddPrimaryKey("dbo.Products", "ProductId");
            AddPrimaryKey("dbo.OrderDetails", new[] { "OrderDetailId", "OrderId" });
            AddPrimaryKey("dbo.Orders", new[] { "OrderId", "CustomerId" });
            AddPrimaryKey("dbo.Customers", "CustomerId");
            CreateIndex("dbo.OrderDetails", new[] { "Order_OrderId", "Order_CustomerId" });
            AddForeignKey("dbo.OrderDetails", new[] { "Order_OrderId", "Order_CustomerId" }, "dbo.Orders", new[] { "OrderId", "CustomerId" });
        }
    }
}
