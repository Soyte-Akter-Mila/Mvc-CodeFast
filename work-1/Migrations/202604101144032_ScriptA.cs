namespace work_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomersId = c.Int(nullable: false, identity: true),
                        CustomersName = c.String(nullable: false),
                        PaymentDate = c.DateTime(nullable: false, storeType: "date"),
                        CustomerSize = c.Int(nullable: false),
                        Picture = c.String(),
                        UrgentDelivery = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomersId);
            
            CreateTable(
                "dbo.OrderEntries",
                c => new
                    {
                        OrderEntriesId = c.Int(nullable: false, identity: true),
                        CustomersId = c.Int(nullable: false),
                        ProductsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderEntriesId)
                .ForeignKey("dbo.Customers", t => t.CustomersId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductsId, cascadeDelete: true)
                .Index(t => t.CustomersId)
                .Index(t => t.ProductsId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        ProductsName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderEntries", "ProductsId", "dbo.Products");
            DropForeignKey("dbo.OrderEntries", "CustomersId", "dbo.Customers");
            DropIndex("dbo.OrderEntries", new[] { "ProductsId" });
            DropIndex("dbo.OrderEntries", new[] { "CustomersId" });
            DropTable("dbo.Products");
            DropTable("dbo.OrderEntries");
            DropTable("dbo.Customers");
        }
    }
}
