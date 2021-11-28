namespace Net.DatabaseLib1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase1202110202349 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId" });
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "Customer_CustomerId");
            RenameColumn(table: "dbo.OrderDetails", name: "ProductId", newName: "Product_ProductId");
            RenameColumn(table: "dbo.OrderDetails", name: "Order_OrderId", newName: "OrderId");
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerId", newName: "IX_Customer_CustomerId");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_ProductId", newName: "IX_Product_ProductId");
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.String(maxLength: 10));
            RenameIndex(table: "dbo.OrderDetails", name: "IX_Product_ProductId", newName: "IX_ProductId");
            RenameIndex(table: "dbo.Orders", name: "IX_Customer_CustomerId", newName: "IX_CustomerId");
            RenameColumn(table: "dbo.OrderDetails", name: "OrderId", newName: "Order_OrderId");
            RenameColumn(table: "dbo.OrderDetails", name: "Product_ProductId", newName: "ProductId");
            RenameColumn(table: "dbo.Orders", name: "Customer_CustomerId", newName: "CustomerId");
            CreateIndex("dbo.OrderDetails", "Order_OrderId");
            AddForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
