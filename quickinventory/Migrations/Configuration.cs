using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;
//
using SimpleInventory.Models;
//using SimpleInventory.Common;
//
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
            //
            // Tenants
            //
            IList<bb_accesscontrol_Tenant> tenant = new List<bb_accesscontrol_Tenant>();
            tenant.Add(new bb_accesscontrol_Tenant() { CreatedDate = DateTime.Now, ID = 1, Company = "GLOBAL ADMIN" });
            tenant.Add(new bb_accesscontrol_Tenant() { CreatedDate = DateTime.Now, ID = 1, Company = "BadBeta" });
            tenant.Add(new bb_accesscontrol_Tenant() { CreatedDate = DateTime.Now, ID = 2, Company = "CRI" });
            tenant.Add(new bb_accesscontrol_Tenant() { CreatedDate = DateTime.Now, ID = 3, Company = "Fluor" });
            context.Tenants.AddRange(tenant);
            context.SaveChanges();
            //
            // ListCurrencys
            //
            IList<bb_common_ListCurrency> cur = new List<bb_common_ListCurrency>();
            cur.Add(new bb_common_ListCurrency() { Tenant_ID = 1, CreatedDate = DateTime.Now, Name = "US Dollar", Abbreviation = "USD", Symbol = "$", ConversionRateToUSD = 1, IsDefaultCurrency = true }); ;
            cur.Add(new bb_common_ListCurrency() { Tenant_ID = 1, CreatedDate = DateTime.Now, Name = "Cambodian Riel", Abbreviation = "KHR", Symbol = "៛", ConversionRateToUSD = 4050, IsDefaultCurrency = false });
            context.ListCurrencys.AddRange(cur);
            context.SaveChanges();
            //
            // UserPermissions
            //
            IList<bb_accesscontrol_Permissions> up = new List<bb_accesscontrol_Permissions>();
            up.Add(new bb_accesscontrol_Permissions() { CreatedDate = DateTime.Now, UserID = 1 });
            up.Add(new bb_accesscontrol_Permissions() { CreatedDate = DateTime.Now, UserID = 2 });
            up.Add(new bb_accesscontrol_Permissions() { CreatedDate = DateTime.Now, UserID = 3 });
            up.Add(new bb_accesscontrol_Permissions() { CreatedDate = DateTime.Now, UserID = 4 });
            context.UserPermissions.AddRange(up);
            context.SaveChanges();
            //
            // ListCategories
            //
            string cfgstring = "Monitor,Dock,Laptop,Desktop,Switch,Firewall,Mouse,CD-ROM,DVD-Drive,Keyboard,Router,Access Point,Mouse & Keyboard";
            List<string> cfgstringsplit = cfgstring.Split(',').ToList();
            int idx = 1;
            foreach (string item in cfgstringsplit)
            {
                bb_Asset_Category x = new bb_Asset_Category();
                x.ID = idx++;
                x.Display = item;
                x.Value = item;
                x.Tenant_ID = 1;
                x.CreatedDate = DateTime.Now;
                context.ListCategories.Add(x);
            }
            context.SaveChanges();





            IList<bb_accesscontrol_User> usr = new List<bb_accesscontrol_User>();
            //User ux = new User();
            //ux.Address.City;
            //Address ax = new Address();
            //ax.Faker(true);
            //Address = ax


            usr.Add(new bb_accesscontrol_User()
            {
                ID = 1,
                UserPermission_Id = 1,
                CreatedDate = DateTime.Now,
                Name = "Administrator",
                Username = "admin",
                PasswordHash = bb_accesscontrol_User.HashPassword("changeme"),
            });
            usr.Add(new bb_accesscontrol_User() { ID = 2, UserPermission_Id = 1, CreatedDate = DateTime.Now, Name = "Scott Devitt", Username = "s.devitt", PasswordHash = bb_accesscontrol_User.HashPassword("changeme") });
            usr.Add(new bb_accesscontrol_User() { ID = 3, UserPermission_Id = 1, CreatedDate = DateTime.Now, Name = "Joanna Devitt", Username = "j.devitt", PasswordHash = bb_accesscontrol_User.HashPassword("changeme") });
            usr.Add(new bb_accesscontrol_User() { ID = 4, UserPermission_Id = 1, CreatedDate = DateTime.Now, Name = "Temp 1", Username = "temp1", PasswordHash = bb_accesscontrol_User.HashPassword("changeme") });
            usr.Add(new bb_accesscontrol_User() { ID = 5, UserPermission_Id = 1, CreatedDate = DateTime.Now, Name = "IT Hold", Username = "IT Hold", PasswordHash = bb_accesscontrol_User.HashPassword("changeme") });
            context.Users.AddRange(usr);
            context.SaveChanges();
            //
            // List Makes
            //
            cfgstring = "Dell,Amazon,HP,Epson,LogicTech,Microsoft,NETGEAR,SonicWall,Cisco,Ubiquiti,Redragon";
            cfgstringsplit = cfgstring.Split(',').ToList();
            idx = 1;
            foreach (string item in cfgstringsplit)
            {
                bb_Asset_Make x = new bb_Asset_Make();
                x.ID = idx++;
                x.Display = item;
                x.Value = item;
                x.CreatedDate = DateTime.Now;
                x.CreatedUser_ID = 1;
                x.Tenant_ID = 1;
                //Address Address 
                context.ListMakes.Add(x);
            }
            context.SaveChanges();
            //
            // ListVendors
            //
            cfgstring = "Amazon,Best Buy,WalMart,HomeDepot,CDW,Newegg,Dell,Microsoft,Staples,Lowes,Wish,Target,Ebay";
            cfgstringsplit = cfgstring.Split(',').ToList();
            idx = 1;
            foreach (string item in cfgstringsplit)
            {
                bb_Asset_Vendor x = new bb_Asset_Vendor();
                x.ID = idx++;
                x.Display = item;
                x.Value = item;
                x.Tenant_ID = 1;
                x.CreatedDate = DateTime.Now;
                x.CreatedUser_ID = 1;
                context.ListVendors.Add(x);
            }
            context.SaveChanges();
            //
            //
            //
            //Cat, Make, Model, Display, Cost, Perfered Vendor
            cfgstring = "";
            cfgstring = cfgstring + "Monitor,DELL,P2219H,22 Monitor,0.00,Dell:";
            cfgstring = cfgstring + "Monitor,DELL,P2319H,23 Monitor,0.00,Dell:";
            cfgstring = cfgstring + "Monitor,DELL,P2419H,24 Monitor,0.00,Dell:";
            //
            cfgstring = cfgstring + "Dock,DELL,WD19S,USB 3.0,188.9,Newegg:";
            cfgstring = cfgstring + "Dock,DELL,WD19DCS,USB-C,293.40,Amazon:";
            cfgstring = cfgstring + "Dock,DELL,WD19TB,Thunderbolt,389.99,Dell:";
            //
            cfgstring = cfgstring + "Laptop,DELL,Precision 7750,Laptop,0.0,Dell:";
            //
            cfgstring = cfgstring + "Desktop,DELL,Precision 5820,Tower,0.0,Dell:";
            cfgstring = cfgstring + "Desktop,DELL,Precision 3440,Small Form Factor,0.0,Dell:";
            //
            cfgstring = cfgstring + "Switch,DELL,N1108EP,Switch,839.10,Dell:";
            cfgstring = cfgstring + "Switch,NETGEAR,GS110EMX,Switch,24.99,Dell:";
            cfgstring = cfgstring + "Switch,NETGEAR,GS110EMX,Switch,24.99,Dell:";
            //
            cfgstring = cfgstring + "Firewall,DELL,TZ210,Firewall,115.00,Dell:";
            cfgstring = cfgstring + "Firewall,SonicWall,SOHO 250,Firewall,299.00,Dell:";
            cfgstring = cfgstring + "Firewall,Cisco,RV340,VPN Router with 4 Gigabit,Firewall,216.00,Amazon:";
            cfgstring = cfgstring + "Firewall,Ubiquiti,Unifi Security Gateway (USG),Firewall,132.00,Amazon:";
            //
            cfgstring = cfgstring + "Mouse,Amazon,1234567,3-Button USB Wired Computer Mouse,10.63,Amazon:";
            cfgstring = cfgstring + "Mouse,Logitech,M510,Wireless Computer Mouse,25.99,Amazon:";
            //
            cfgstring = cfgstring + "Keyboard,Microsoft,MS101,Wireless Keyboard and Mouse Combo,20.993,Amazon:";
            cfgstring = cfgstring + "Keyboard,Redragon,S101,Wired Gaming Keyboard and Mouse,39.993,Amazon";


            cfgstringsplit = cfgstring.Split(':').ToList();
            idx = 1;
            foreach (string item in cfgstringsplit)
            {
                List<string> models = item.Split(',').ToList();
                int fidx = context.ListMakes.ToList().FindIndex(x => x.Display == models[1]);
                if (fidx < 0)
                {
                }
                else
                {
                    bb_Asset_Model x = new bb_Asset_Model();
                    x.Category_ID = context.ListCategories.ToList().Find(fm => fm.Value == models[0]).ID;
                    x.Make_ID = context.ListMakes.ToList().Find(fm => fm.Value == models[1]).ID;
                    x.ID = idx++;
                    x.Display = models[3];
                    x.Value = models[2];
                    x.CreatedDate = DateTime.Now;
                    x.CreatedUser_ID = 1;
                    x.Tenant_ID = 1;
                    x.PreferredCost = 0.0;       // models[4];
                    x.PreferredVendor_Id = 1;    // models[5];
                    //public Address Address { get; set; }
                    context.ListModels.Add(x);
                }
            }
            context.SaveChanges();

            /*
            */
        }
    }
}
