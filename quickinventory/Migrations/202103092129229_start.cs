namespace SimpleInventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
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
                "dbo.bbInventoryItems",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AssetID = c.String(maxLength: 100),
                        Tenant_ID = c.Long(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                        Quantity = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        Shipping = c.Double(nullable: false),
                        Vendor_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .ForeignKey("dbo.bb_Asset_Vendor", t => t.Vendor_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.CreatedUser_ID)
                .Index(t => t.Vendor_ID);
            
            CreateTable(
                "dbo.bbTenants",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Company = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 100),
                        WasDeleted = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 100),
                        UserPermission_Id = c.Long(nullable: false),
                        Tenant_ID = c.Long(),
                        CreatedDate = c.DateTime(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Prefix = c.String(maxLength: 8),
                        Credentials = c.String(maxLength: 12),
                        Title = c.String(maxLength: 128),
                        CompanyName = c.String(maxLength: 128),
                        EmailAddress = c.String(maxLength: 128),
                        EmailCC = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.UserPermissions", t => t.UserPermission_Id, cascadeDelete: true)
                .Index(t => t.UserPermission_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
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
                "dbo.bb_Asset_Vendor",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Tenant_ID = c.Long(),
                        Display = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        Sort = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Default = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.CreatedUser_ID);
            
            CreateTable(
                "dbo.bb_Asset_Category",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Tenant_ID = c.Long(),
                        Display = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        Sort = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Default = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.CreatedUser_ID);
            
            CreateTable(
                "dbo.bbListCurrencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Abbreviation = c.String(maxLength: 25),
                        Symbol = c.String(maxLength: 2),
                        ConversionRateToUSD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDefaultCurrency = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Tenant_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID, cascadeDelete: true)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.bb_Asset_Make",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Tenant_ID = c.Long(),
                        Display = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        Sort = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Default = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.CreatedUser_ID);
            
            CreateTable(
                "dbo.bb_Asset_Model",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Make_ID = c.Long(),
                        Category_ID = c.Long(),
                        Tenant_ID = c.Long(),
                        PreferredCost = c.Double(nullable: false),
                        PreferredVendor_Id = c.Long(nullable: false),
                        Display = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        Sort = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Default = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bb_Asset_Category", t => t.Category_ID)
                .ForeignKey("dbo.bb_Asset_Make", t => t.Make_ID)
                .ForeignKey("dbo.bb_Asset_Make", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .ForeignKey("dbo.bb_Asset_Vendor", t => t.PreferredVendor_Id, cascadeDelete: true)
                .Index(t => t.Make_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.PreferredVendor_Id)
                .Index(t => t.CreatedUser_ID);
            
            CreateTable(
                "dbo.bbLists",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Tenant_ID = c.Long(),
                        Display = c.String(maxLength: 100),
                        Value = c.String(maxLength: 100),
                        Sort = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Default = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.CreatedUser_ID);
            
            CreateTable(
                "dbo.bbOrderGroups",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        OrderName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                        Tenant_ID = c.Long(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .Index(t => t.CreatedUser_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.bbOrderItems",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Tenant_ID = c.Long(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                        Quantity = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        Shipping = c.Double(nullable: false),
                        Vendor_ID = c.Long(),
                        bbOrderGroup_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .ForeignKey("dbo.bb_Asset_Vendor", t => t.Vendor_ID)
                .ForeignKey("dbo.bbOrderGroups", t => t.bbOrderGroup_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.CreatedUser_ID)
                .Index(t => t.Vendor_ID)
                .Index(t => t.bbOrderGroup_ID);
            
            CreateTable(
                "dbo.bbOrderPayments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        OrderItems_ID = c.Long(nullable: false),
                        Tenant_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.bbOrderItems", t => t.OrderItems_ID, cascadeDelete: true)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID, cascadeDelete: true)
                .Index(t => t.OrderItems_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.bbRequestGroups",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        RequestByDate = c.DateTime(nullable: false),
                        RequestByUser_ID = c.Long(nullable: false),
                        Approver1_ID = c.Long(),
                        Approver2_ID = c.Long(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                        Tenant_ID = c.Long(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.Approver1_ID)
                .ForeignKey("dbo.Users", t => t.Approver2_ID)
                .ForeignKey("dbo.Users", t => t.RequestByUser_ID, cascadeDelete: true)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .Index(t => t.RequestByUser_ID)
                .Index(t => t.Approver1_ID)
                .Index(t => t.Approver2_ID)
                .Index(t => t.CreatedUser_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.bbRequestItems",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CostCode1 = c.String(),
                        CostCode2 = c.String(),
                        Tenant_ID = c.Long(),
                        RequestedUser_ID = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedUser_ID = c.Long(),
                        Quantity = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        Shipping = c.Double(nullable: false),
                        Vendor_ID = c.Long(),
                        bbRequestGroup_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.RequestedUser_ID, cascadeDelete: true)
                .ForeignKey("dbo.bbTenants", t => t.Tenant_ID)
                .ForeignKey("dbo.Users", t => t.CreatedUser_ID)
                .ForeignKey("dbo.bb_Asset_Vendor", t => t.Vendor_ID)
                .ForeignKey("dbo.bbRequestGroups", t => t.bbRequestGroup_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.RequestedUser_ID)
                .Index(t => t.CreatedUser_ID)
                .Index(t => t.Vendor_ID)
                .Index(t => t.bbRequestGroup_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.bbRequestGroups", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bbRequestGroups", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbRequestItems", "bbRequestGroup_ID", "dbo.bbRequestGroups");
            DropForeignKey("dbo.bbRequestItems", "Vendor_ID", "dbo.bb_Asset_Vendor");
            DropForeignKey("dbo.bbRequestItems", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bbRequestItems", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbRequestItems", "RequestedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bbRequestGroups", "RequestByUser_ID", "dbo.Users");
            DropForeignKey("dbo.bbRequestGroups", "Approver2_ID", "dbo.Users");
            DropForeignKey("dbo.bbRequestGroups", "Approver1_ID", "dbo.Users");
            DropForeignKey("dbo.bbOrderPayments", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbOrderPayments", "OrderItems_ID", "dbo.bbOrderItems");
            DropForeignKey("dbo.bbOrderGroups", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bbOrderGroups", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbOrderItems", "bbOrderGroup_ID", "dbo.bbOrderGroups");
            DropForeignKey("dbo.bbOrderItems", "Vendor_ID", "dbo.bb_Asset_Vendor");
            DropForeignKey("dbo.bbOrderItems", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bbOrderItems", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbLists", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bbLists", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bb_Asset_Model", "PreferredVendor_Id", "dbo.bb_Asset_Vendor");
            DropForeignKey("dbo.bb_Asset_Model", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bb_Asset_Model", "Tenant_ID", "dbo.bb_Asset_Make");
            DropForeignKey("dbo.bb_Asset_Model", "Make_ID", "dbo.bb_Asset_Make");
            DropForeignKey("dbo.bb_Asset_Model", "Category_ID", "dbo.bb_Asset_Category");
            DropForeignKey("dbo.bb_Asset_Make", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bb_Asset_Make", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbListCurrencies", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bb_Asset_Category", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bb_Asset_Category", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbInventoryItems", "Vendor_ID", "dbo.bb_Asset_Vendor");
            DropForeignKey("dbo.bb_Asset_Vendor", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.bb_Asset_Vendor", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbInventoryItems", "CreatedUser_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "UserPermission_Id", "dbo.UserPermissions");
            DropForeignKey("dbo.Users", "Tenant_ID", "dbo.bbTenants");
            DropForeignKey("dbo.bbInventoryItems", "Tenant_ID", "dbo.bbTenants");
            DropIndex("dbo.bbRequestItems", new[] { "bbRequestGroup_ID" });
            DropIndex("dbo.bbRequestItems", new[] { "Vendor_ID" });
            DropIndex("dbo.bbRequestItems", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bbRequestItems", new[] { "RequestedUser_ID" });
            DropIndex("dbo.bbRequestItems", new[] { "Tenant_ID" });
            DropIndex("dbo.bbRequestGroups", new[] { "Tenant_ID" });
            DropIndex("dbo.bbRequestGroups", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bbRequestGroups", new[] { "Approver2_ID" });
            DropIndex("dbo.bbRequestGroups", new[] { "Approver1_ID" });
            DropIndex("dbo.bbRequestGroups", new[] { "RequestByUser_ID" });
            DropIndex("dbo.bbOrderPayments", new[] { "Tenant_ID" });
            DropIndex("dbo.bbOrderPayments", new[] { "OrderItems_ID" });
            DropIndex("dbo.bbOrderItems", new[] { "bbOrderGroup_ID" });
            DropIndex("dbo.bbOrderItems", new[] { "Vendor_ID" });
            DropIndex("dbo.bbOrderItems", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bbOrderItems", new[] { "Tenant_ID" });
            DropIndex("dbo.bbOrderGroups", new[] { "Tenant_ID" });
            DropIndex("dbo.bbOrderGroups", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bbLists", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bbLists", new[] { "Tenant_ID" });
            DropIndex("dbo.bb_Asset_Model", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bb_Asset_Model", new[] { "PreferredVendor_Id" });
            DropIndex("dbo.bb_Asset_Model", new[] { "Tenant_ID" });
            DropIndex("dbo.bb_Asset_Model", new[] { "Category_ID" });
            DropIndex("dbo.bb_Asset_Model", new[] { "Make_ID" });
            DropIndex("dbo.bb_Asset_Make", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bb_Asset_Make", new[] { "Tenant_ID" });
            DropIndex("dbo.bbListCurrencies", new[] { "Tenant_ID" });
            DropIndex("dbo.bb_Asset_Category", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bb_Asset_Category", new[] { "Tenant_ID" });
            DropIndex("dbo.bb_Asset_Vendor", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bb_Asset_Vendor", new[] { "Tenant_ID" });
            DropIndex("dbo.Users", new[] { "Tenant_ID" });
            DropIndex("dbo.Users", new[] { "UserPermission_Id" });
            DropIndex("dbo.bbInventoryItems", new[] { "Vendor_ID" });
            DropIndex("dbo.bbInventoryItems", new[] { "CreatedUser_ID" });
            DropIndex("dbo.bbInventoryItems", new[] { "Tenant_ID" });
            DropTable("dbo.bbRequestItems");
            DropTable("dbo.bbRequestGroups");
            DropTable("dbo.bbOrderPayments");
            DropTable("dbo.bbOrderItems");
            DropTable("dbo.bbOrderGroups");
            DropTable("dbo.bbLists");
            DropTable("dbo.bb_Asset_Model");
            DropTable("dbo.bb_Asset_Make");
            DropTable("dbo.bbListCurrencies");
            DropTable("dbo.bb_Asset_Category");
            DropTable("dbo.bb_Asset_Vendor");
            DropTable("dbo.UserPermissions");
            DropTable("dbo.Users");
            DropTable("dbo.bbTenants");
            DropTable("dbo.bbInventoryItems");
            DropTable("dbo.FW_Inventory");
        }
    }
}
