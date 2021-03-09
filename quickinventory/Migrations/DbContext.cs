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
        public DbSet<bbInventoryItems> InventoryItems { get; set; }


        public DbSet<bbList> Lists { get; set; }
        public DbSet<bb_Asset_Category> ListCategories { get; set; }
        public DbSet<bb_Asset_Vendor> ListVendors { get; set; }
        public DbSet<bb_Asset_Make> ListMakes { get; set; }
        public DbSet<bb_Asset_Model> ListModels { get; set; }


        public DbSet<bbListCurrency> ListCurrencys { get; set; }
        public DbSet<bbOrderGroup> OrderGroups { get; set; }
        public DbSet<bbOrderItems> OrderItems { get; set; }
        public DbSet<bbOrderPayment> OrderPayments { get; set; }
        public DbSet<bbRequestGroup> RequestGroups { get; set; }
        public DbSet<bbRequestItems> RequestItems { get; set; }
        public DbSet<bbTenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        //
        //
        public DbSet<fw_ConfigItem> fwInventory { get; set; }



    }
    public class SchoolDBInitializer : DropCreateDatabaseAlways<SimpleInventoryContext>
    {



    }
}