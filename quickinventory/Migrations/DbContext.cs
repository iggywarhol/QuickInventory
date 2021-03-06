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
        public DbSet<bbItemType> ItemTypes { get; set; }
        public DbSet<bblistCategory> Categories { get; set; }
        public DbSet<bblistCurrency> Currencys { get; set; }
        public DbSet<bblistVendor> Vendors { get; set; }
        public DbSet<bbOrder> Orders { get; set; }
        public DbSet<bbOrderItems> OrderItems { get; set; }
        public DbSet<bbOrderPayment> OrderPayments { get; set; }
        public DbSet<bbRequestGroup> RequestGroup { get; set; }
        public DbSet<bbRequestItems> RequestItems { get; set; }
        public DbSet<bbTenant> Tenants { get; set; }
        public DbSet<Groups> Groups { get; set; }
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