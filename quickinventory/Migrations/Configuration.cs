using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleInventory.Models;
using Newtonsoft.Json;

namespace SimpleInventory.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimpleInventory.Models.SimpleInventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SimpleInventory.Models.SimpleInventoryContext context)
        {

            IList<bbTenant> tenant = new List<bbTenant>();
            tenant.Add(new bbTenant() { CreatedDate = DateTime.Now, ID = 1, Company = "GLOBAL ADMIN" });
            tenant.Add(new bbTenant() { CreatedDate = DateTime.Now, ID = 1, Company = "BadBeta" });
            tenant.Add(new bbTenant() { CreatedDate = DateTime.Now, ID = 2, Company = "CRI" });
            tenant.Add(new bbTenant() { CreatedDate = DateTime.Now, ID = 3, Company = "Fluor" });
            context.Tenants.AddRange(tenant);
            context.SaveChanges();

            IList<UserPermission> up = new List<UserPermission>();
            up.Add(new UserPermission() { CreatedDate = DateTime.Now, UserID = 1 });
            up.Add(new UserPermission() { CreatedDate = DateTime.Now, UserID = 2 });
            up.Add(new UserPermission() { CreatedDate = DateTime.Now, UserID = 3 });
            up.Add(new UserPermission() { CreatedDate = DateTime.Now, UserID = 4 });
            context.UserPermissions.AddRange(up);
            context.SaveChanges();

            IList<User> usr = new List<User>();
            usr.Add(new User() { ID = 1, UserPermission_Id = 1, CreatedDate = DateTime.Now, Name = "Administrator", Username = "admin", PasswordHash = User.HashPassword("changeme") });
            usr.Add(new User() { ID = 2, UserPermission_Id = 1, CreatedDate = DateTime.Now, Name = "Scott Devitt", Username = "s.devitt", PasswordHash = User.HashPassword("changeme") });
            usr.Add(new User() { ID = 3, UserPermission_Id = 1, CreatedDate = DateTime.Now, Name = "Joanna Devitt", Username = "j.devitt", PasswordHash = User.HashPassword("changeme") });
            usr.Add(new User() { ID = 4, UserPermission_Id = 1, CreatedDate = DateTime.Now, Name = "Temp 1", Username = "temp1", PasswordHash = User.HashPassword("changeme") });
            usr.Add(new User() { ID = 5, UserPermission_Id = 1, CreatedDate = DateTime.Now, Name = "IT Hold", Username = "IT Hold", PasswordHash = User.HashPassword("changeme") });
            context.Users.AddRange(usr);
            context.SaveChanges();

            IList<bblistCurrency> cur = new List<bblistCurrency>();
            cur.Add(new bblistCurrency() { CreatedDate = DateTime.Now, Name = "US Dollar", Abbreviation = "USD", Symbol = "$", ConversionRateToUSD = 1, IsDefaultCurrency = true });
            cur.Add(new bblistCurrency() { CreatedDate = DateTime.Now, Name = "Cambodian Riel", Abbreviation = "KHR", Symbol = "៛", ConversionRateToUSD = 4050, IsDefaultCurrency = false });
            context.Currencys.AddRange(cur);
            context.SaveChanges();


            string cfgstring = "Monitor,Dock,Laptop,Desktop,Switch,Firewall,Mouse,CD-ROM,DVD-Drive,Keyboard,Router,Access Point";
            List<string> cfgstringsplit = cfgstring.Split(',').ToList();
            foreach (string item in cfgstringsplit)
            {
                bblistCategory x = new bblistCategory();
                x.Display = "";
                x.Value = "";
                x.Tenant_ID = 1;               
                x.CreatedDate = DateTime.Now;
                context.Categories.Add(x);
            }
            context.SaveChanges();






            /*
            string cfgstring = "DELL,HP,Epson,Logitech,Microsoft,LG";
            List<string> cfgstringsplit = cfgstring.Split(',').ToList();
            List<ConfigItem> ConfigItems = new List<ConfigItem>();
            foreach (string item in cfgstringsplit)
            {
                ConfigItem x = new ConfigItem(item);
                ConfigItems.Add(x);
            }
            string output = JsonConvert.SerializeObject(ConfigItems);
            */



            IList<Groups> grps = new List<Groups>();
            grps.Add(new Groups() { ID = 1, Key = "Manufacture", Value = CSVconfig("DELL,HP,Epson,Logitech,Microsoft,LG")});
            grps.Add(new Groups() { ID = 2, Key = "Category", Value = CSVconfig("Monitor,Dock,Laptop,Desktop,Switch,Firewall")});
            context.Groups.AddRange(grps);
            context.SaveChanges();

            
            //IList<bbItemType> itemtypes = new List<bbItemType>();
            //itemtypes.Add(new bbItemType() { ID = 1, Name = "QLM0001", Description = "24 Monitor", Manufacture = "DELL", Model = "MD24", Category = "Monitor" });
            //itemtypes.Add(new bbItemType() { ID = 2, Name = "QLM0002", Description = "32 Monitor", Manufacture = "LG", Model = "LG32C", Category = "Monitor" });
            //itemtypes.Add(new bbItemType() { ID = 3, Name = "QLM0003", Description = "Desktop", Manufacture = "DELL", Model = "AREA 51 R2", Category = "Desktop" });
            //itemtypes.Add(new bbItemType() { ID = 4, Name = "QLM0004", Description = "Laptop", Manufacture = "IBM", Model = "THNKPAD 32S", Category = "Laptop" });
            //itemtypes.Add(new bbItemType() { ID = 5, Name = "QLM0005", Description = "Laptop", Manufacture = "DELL", Model = "Latatuide 5401", Category = "Laptop" });
            //context.ItemTypes.AddRange(itemtypes);
            //context.SaveChanges();

            //IList<bbItem> inventroyitems = new List<bbItem>();
            //inventroyitems.Add(new bbItem() { ID = 1, AssetID = "1000", ItemType_ID = 1 });
            //inventroyitems.Add(new bbItem() { ID = 2, AssetID = "1001", ItemType_ID = 3 });
            //inventroyitems.Add(new bbItem() { ID = 3, AssetID = "1001", ItemType_ID = 5 });
            //context.Items.AddRange(inventroyitems);
            //context.SaveChanges();


        }


        public string CSVconfig(string csvstr)
        {
            List<string> cfgstringsplit = csvstr.Split(',').ToList();
            List<ConfigItem> ConfigItems = new List<ConfigItem>();
            foreach (string item in cfgstringsplit)
            {
                ConfigItem x = new ConfigItem(item);
                ConfigItems.Add(x);
            }
            string output = JsonConvert.SerializeObject(ConfigItems);
            return output;

        }


    }


}
