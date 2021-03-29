using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//
//
namespace SimpleInventory.Models
{
    public class SimpleInventoryContext : DbContext
    {
        public SimpleInventoryContext() : base("InventorySd")
        {
        }
        public DbSet<bb_item_Inventory> InventoryItems { get; set; }


        public DbSet<bb_Asset_List> Lists { get; set; }
        public DbSet<bb_Asset_Category> ListCategories { get; set; }
        public DbSet<bb_Asset_Vendor> ListVendors { get; set; }
        public DbSet<bb_Asset_Make> ListMakes { get; set; }
        public DbSet<bb_Asset_Model> ListModels { get; set; }


        public DbSet<bb_common_ListCurrency> ListCurrencys { get; set; }
        public DbSet<bb_item_OrderGroup> OrderGroups { get; set; }
        public DbSet<bb_item_OrderSingle> OrderItems { get; set; }
        public DbSet<bb_item_OrderPayment> OrderPayments { get; set; }
        public DbSet<bb_item_RequestGroup> RequestGroups { get; set; }
        public DbSet<bb_item_RequestSingle> RequestItems { get; set; }
        public DbSet<bb_accesscontrol_Tenant> Tenants { get; set; }
        public DbSet<bb_accesscontrol_User> Users { get; set; }
        public DbSet<bb_accesscontrol_Permissions> UserPermissions { get; set; }
        //
        //
        public DbSet<fw_ConfigItem> fwInventory { get; set; }



    }
    public class SchoolDBInitializer : DropCreateDatabaseAlways<SimpleInventoryContext>
    {



    }
}