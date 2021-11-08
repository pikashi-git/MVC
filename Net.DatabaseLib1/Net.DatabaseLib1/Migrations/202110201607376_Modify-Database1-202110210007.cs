namespace Net.DatabaseLib1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase1202110210007 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductId" });
            RenameColumn(table: "dbo.Orders", name: "Customer_CustomerId", newName: "CustomerId");
            RenameColumn(table: "dbo.OrderDetails", name: "Product_ProductId", newName: "ProductId");
            RenameIndex(table: "dbo.Orders", name: "IX_Customer_CustomerId", newName: "IX_CustomerId");
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.OrderDetails", "ProductId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.String(maxLength: 10));
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerId", newName: "IX_Customer_CustomerId");
            RenameColumn(table: "dbo.OrderDetails", name: "ProductId", newName: "Product_ProductId");
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "Customer_CustomerId");
            CreateIndex("dbo.OrderDetails", "Product_ProductId");
            AddForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products", "ProductId");
        }
    }
}
