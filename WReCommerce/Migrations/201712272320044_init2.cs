namespace WReCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserMemberships", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.UserMemberships", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMemberships", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserMemberships", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
