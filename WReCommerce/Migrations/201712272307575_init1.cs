namespace WReCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseOrders", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.PurchaseOrders", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.PurchaseOrderLines", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.PurchaseOrderLines", "DateModified", c => c.DateTime());
            AlterColumn("dbo.PurchaseOrderShipments", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.PurchaseOrderShipments", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseOrderShipments", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseOrderShipments", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseOrderLines", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseOrderLines", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseOrders", "DateUpdated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseOrders", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
