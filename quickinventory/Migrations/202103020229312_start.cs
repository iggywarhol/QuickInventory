namespace SimpleInventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bbItemCategories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Display = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.bbCurrencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        Symbol = c.String(),
                        ConversionRateToUSD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDefaultCurrency = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FW_Inventory",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        agent_id = c.Long(),
                        asset_tag = c.String(),
                        assigned_on = c.DateTime(),
                        ci_type_id = c.Long(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        deleted = c.Boolean(nullable: false),
                        department_id = c.Long(),
                        disabled = c.Boolean(nullable: false),
                        display_id = c.Int(nullable: false),
                        expiry_notified = c.Boolean(nullable: false),
                        impact = c.Int(nullable: false),
                        location_id = c.Long(),
                        name = c.String(),
                        trashed = c.Boolean(nullable: false),
                        updated_at = c.DateTime(),
                        user_id = c.Long(),
                        department_name = c.String(),
                        used_by = c.String(),
                        business_impact = c.String(),
                        agent_name = c.String(),
                        ci_type_name = c.String(),
                        product_name = c.String(),
                        vendor_name = c.String(),
                        location_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.String(maxLength: 25),
                        Value = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.bbItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssetID = c.String(),
                        Purchase_ID = c.Long(nullable: false),
                        Tenant_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbItemPurchases", t => t.Purchase_ID, cascadeDelete: true)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID, cascadeDelete: true)
                .Index(t => t.Purchase_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.bbItemPurchases",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ItemType_ID = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Vendor_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbItemTypes", t => t.ItemType_ID, cascadeDelete: true)
                .ForeignKey("dbo.bbItemVendors", t => t.Vendor_ID, cascadeDelete: true)
                .Index(t => t.ItemType_ID)
                .Index(t => t.Vendor_ID);
            
            CreateTable(
                "dbo.bbItemTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Manufacture = c.String(maxLength: 100),
                        Model = c.String(maxLength: 100),
                        Category_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbItemCategories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.bbItemVendors",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Company = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.bbTenants",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Company = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.bbOrders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Purchase_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbItemPurchases", t => t.Purchase_ID, cascadeDelete: true)
                .Index(t => t.Purchase_ID);
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CanAddEditItems = c.Boolean(nullable: false),
                        CanAdjustItemQuantity = c.Boolean(nullable: false),
                        CanViewDetailedItemQuantityAdjustments = c.Boolean(nullable: false),
                        CanScanItems = c.Boolean(nullable: false),
                        CanGenerateBarcodes = c.Boolean(nullable: false),
                        CanViewReports = c.Boolean(nullable: false),
                        CanViewDetailedItemSoldInfo = c.Boolean(nullable: false),
                        CanSaveReportsToPDF = c.Boolean(nullable: false),
                        CanDeleteItemsFromInventory = c.Boolean(nullable: false),
                        CanManageItemCategories = c.Boolean(nullable: false),
                        CanManageUsers = c.Boolean(nullable: false),
                        CanDeleteItemsSold = c.Boolean(nullable: false),
                        CanViewManageInventoryQuantity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        WasDeleted = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        PermissionsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserPermissions", t => t.PermissionsId, cascadeDelete: true)
                .Index(t => t.PermissionsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PermissionsId", "dbo.UserPermissions");
            DropForeignKey("dbo.bbOrders", "Purchase_ID", "dbo.bbItemPurchases");
            DropForeignKey("dbo.bbItems", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbItems", "Purchase_ID", "dbo.bbItemPurchases");
            DropForeignKey("dbo.bbItemPurchases", "Vendor_ID", "dbo.bbItemVendors");
            DropForeignKey("dbo.bbItemPurchases", "ItemType_ID", "dbo.bbItemTypes");
            DropForeignKey("dbo.bbItemTypes", "Category_ID", "dbo.bbItemCategories");
            DropIndex("dbo.Users", new[] { "PermissionsId" });
            DropIndex("dbo.bbOrders", new[] { "Purchase_ID" });
            DropIndex("dbo.bbItemTypes", new[] { "Category_ID" });
            DropIndex("dbo.bbItemPurchases", new[] { "Vendor_ID" });
            DropIndex("dbo.bbItemPurchases", new[] { "ItemType_ID" });
            DropIndex("dbo.bbItems", new[] { "Tenant_ID" });
            DropIndex("dbo.bbItems", new[] { "Purchase_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.UserPermissions");
            DropTable("dbo.bbOrders");
            DropTable("dbo.bbTenants");
            DropTable("dbo.bbItemVendors");
            DropTable("dbo.bbItemTypes");
            DropTable("dbo.bbItemPurchases");
            DropTable("dbo.bbItems");
            DropTable("dbo.Groups");
            DropTable("dbo.FW_Inventory");
            DropTable("dbo.bbCurrencies");
            DropTable("dbo.bbItemCategories");
        }
    }
}
