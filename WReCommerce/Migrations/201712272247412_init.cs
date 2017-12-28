namespace WReCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressBillings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserprofileId = c.Int(nullable: false),
                        Street1 = c.String(nullable: false),
                        Street2 = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Userprofiles", t => t.UserprofileId, cascadeDelete: true)
                .Index(t => t.UserprofileId);
            
            CreateTable(
                "dbo.Userprofiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 64),
                        LastName = c.String(nullable: false, maxLength: 64),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalShipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        RefPurchaseOrderStatus = c.Int(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Userprofiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.PurchaseOrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        PurchaseOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        PurchaseOrderShipment = c.Int(nullable: false),
                        PurchaePurchaseOrderShipment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrderShipments", t => t.PurchaePurchaseOrderShipment_Id)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId, cascadeDelete: true)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaePurchaseOrderShipment_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProductMembershipValue = c.Int(nullable: false),
                        UnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductCategory = c.Int(nullable: false),
                        ProductForm = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseOrderShipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackingNumber = c.String(),
                        ShipmentStatus = c.String(),
                        Items = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        PurchaseOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId, cascadeDelete: true)
                .Index(t => t.PurchaseOrderId);
            
            CreateTable(
                "dbo.AddressShippings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserprofileId = c.Int(nullable: false),
                        Street1 = c.String(nullable: false),
                        Street2 = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Userprofiles", t => t.UserprofileId, cascadeDelete: true)
                .Index(t => t.UserprofileId);
            
            CreateTable(
                "dbo.UserMemberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipInitial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MembershipRemaining = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        MembershipCategory = c.Int(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Userprofiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.RefProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProductForm = c.Int(nullable: false),
                        ProductCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMemberships", "UserProfileId", "dbo.Userprofiles");
            DropForeignKey("dbo.UserMemberships", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AddressShippings", "UserprofileId", "dbo.Userprofiles");
            DropForeignKey("dbo.PurchaseOrders", "UserProfileId", "dbo.Userprofiles");
            DropForeignKey("dbo.PurchaseOrderLines", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrderLines", "PurchaePurchaseOrderShipment_Id", "dbo.PurchaseOrderShipments");
            DropForeignKey("dbo.PurchaseOrderShipments", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrderLines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AddressBillings", "UserprofileId", "dbo.Userprofiles");
            DropIndex("dbo.UserMemberships", new[] { "ProductId" });
            DropIndex("dbo.UserMemberships", new[] { "UserProfileId" });
            DropIndex("dbo.AddressShippings", new[] { "UserprofileId" });
            DropIndex("dbo.PurchaseOrderShipments", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrderLines", new[] { "PurchaePurchaseOrderShipment_Id" });
            DropIndex("dbo.PurchaseOrderLines", new[] { "ProductId" });
            DropIndex("dbo.PurchaseOrderLines", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "UserProfileId" });
            DropIndex("dbo.AddressBillings", new[] { "UserprofileId" });
            DropTable("dbo.RefProductTypes");
            DropTable("dbo.UserMemberships");
            DropTable("dbo.AddressShippings");
            DropTable("dbo.PurchaseOrderShipments");
            DropTable("dbo.Products");
            DropTable("dbo.PurchaseOrderLines");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.Userprofiles");
            DropTable("dbo.AddressBillings");
        }
    }
}
