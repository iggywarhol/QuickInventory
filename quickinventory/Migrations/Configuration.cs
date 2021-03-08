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

            string cfgstring = "Dell,HP,Epson,LogicTech,Microsoft";
            List<string> cfgstringsplit = cfgstring.Split(',').ToList();
            foreach (string item in cfgstringsplit)
            {
                bbList x = new bbList();
                x.Type = ListTypeEnum.Make;
                x.Display = item;
                x.Value = item;
                x.Tenant_ID = 1;
                x.CreatedDate = DateTime.Now;
                x.CreatedUser_ID = 1;
                context.Lists.Add(x);
            }
            context.SaveChanges();
            //
            // ListCategories
            //
            cfgstring = "Monitor,Dock,Laptop,Desktop,Switch,Firewall,Mouse,CD-ROM,DVD-Drive,Keyboard,Router,Access Point,Mouse & Keyboard";
            cfgstringsplit = cfgstring.Split(',').ToList();
            int idx = 1;
            foreach (string item in cfgstringsplit)
            {
                bbListCategory x = new bbListCategory();
                x.ID = idx++;
                x.Display = item;
                x.Value = item;
                x.Tenant_ID = 1;
                x.CreatedDate = DateTime.Now;
                context.ListCategories.Add(x);
            }
            context.SaveChanges();
            //
            // ListCurrencys
            //
            IList<bbListCurrency> cur = new List<bbListCurrency>();
            cur.Add(new bbListCurrency() { Tenant_ID = 1, CreatedDate = DateTime.Now, Name = "US Dollar", Abbreviation = "USD", Symbol = "$", ConversionRateToUSD = 1, IsDefaultCurrency = true }); ;
            cur.Add(new bbListCurrency() { Tenant_ID = 1, CreatedDate = DateTime.Now, Name = "Cambodian Riel", Abbreviation = "KHR", Symbol = "៛", ConversionRateToUSD = 4050, IsDefaultCurrency = false });
            context.ListCurrencys.AddRange(cur);
            context.SaveChanges();
            //
            // Vendor
            //
            cfgstring = "Amazon,Best Buy,WalMart,HomeDepot,CDW,Newegg,Dell,Microsoft,Staples,Lowes,Wish,Target,Ebay";
            cfgstringsplit = cfgstring.Split(',').ToList();
            idx = 1;
            foreach (string item in cfgstringsplit)
            {
                bbListVendor x = new bbListVendor();
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
            //ListType
            // 
            //Cat, Make, Model, Display, Cost, Perfered Vendor
            cfgstring = "";
            cfgstring = cfgstring + "1,DELL,P2219H,22 Monitor,0.00,7:";
            cfgstring = cfgstring + "1,DELL,P2319H,23 Monitor,0.00,7:";
            cfgstring = cfgstring + "1,DELL,P2419H,24 Monitor,0.00,7:";
            //
            cfgstring = cfgstring + "2,DELL,WD19S,USB 3.0,188.9,6:";
            cfgstring = cfgstring + "2,DELL,WD19DCS,USB-C,293.40,1:";
            cfgstring = cfgstring + "2,DELL,WD19TB,Thunderbolt,389.99,7:";
            //
            cfgstring = cfgstring + "3,DELL,Precision 7750,Laptop,0.0,7:";
            //
            cfgstring = cfgstring + "4,DELL,Precision 5820,Tower,0.0,7:";
            cfgstring = cfgstring + "4,DELL,Precision 3440,Small Form Factor,0.0,7:";
            //
            cfgstring = cfgstring + "5,DELL,N1108EP,Switch,839.10,7:";
            cfgstring = cfgstring + "5,NETGEAR,GS110EMX,Switch,24.99,7:";
            cfgstring = cfgstring + "5,NETGEAR,GS110EMX,Switch,24.99,7:";
            //Linksys SE3016 16-Port Gigabit Ethernet Switch 19.99
            //TP-Link TL-SG105 | 5 Port Gigabit 15.99
            //NETGEAR 5-Port Gigabit Ethernet Unmanaged Switch (GS105NA) - Desktop, and ProSAFE Limited 29.99
            //Linksys Business LGS116 16-Port Desktop  64.33
            //
            cfgstring = cfgstring + "6,DELL,TZ210,Firewall,115.00,7:";
            cfgstring = cfgstring + "6,SonicWall,SOHO 250,Firewall,299.00,7:";
            cfgstring = cfgstring + "6,Cisco,RV340,VPN Router with 4 Gigabit,Firewall,216.00,1:";
            cfgstring = cfgstring + "6,Ubiquiti,Unifi Security Gateway (USG),Firewall,132.00,1:";
            //
            cfgstring = cfgstring + "7,Amazon Basics,1234567,3-Button USB Wired Computer Mouse,10.63,1:";
            cfgstring = cfgstring + "7,Logitech,M510,Wireless Computer Mouse,25.99,1:";
            //
            cfgstring = cfgstring + "13,Microsoft,MS101,Wireless Keyboard and Mouse Combo,20.993,1:";
            cfgstring = cfgstring + "13,Redragon,S101,Wired Gaming Keyboard and Mouse,39.993,1";
            //
            //
            cfgstringsplit = cfgstring.Split(':').ToList();
            idx = 1;
            foreach (string item in cfgstringsplit)
            {
                List<string> c1 = item.Split(',').ToList();
                bbListType x = new bbListType();
                x.ID = idx++;
                x.Category_ID = Convert.ToInt32(c1[0]);
                x.Make = c1[1];
                x.Model = c1[2];
                x.Display = c1[3];
                x.Value = c1[2];
                x.Tenant_ID = 1;
                x.CreatedDate = DateTime.Now;
                x.CreatedUser_ID = 1;
                x.EstimatedCost = 0.0;
                context.ListTypes.Add(x);
            }
            context.SaveChanges();



            idx = 1;
            {
                bbRequestGroup x = new bbRequestGroup();
                x.ID = idx++;
                x.Tenant_ID = 1;
                x.CreatedDate = DateTime.Now;
                x.CreatedUser_ID = 1;
                x.RequestByDate = System.DateTime.Now.AddDays(7);
                x.RequestByUser_ID = 1;
                x.Name = "It Supplies 1";
                x.Approver1_ID = 1;
                x.Approver2_ID = 2;
                //context.ListVendors.Add(x);
                //context.SaveChanges();
            }


            idx = 1;
            {
                bbRequestItems x = new bbRequestItems();
                x.ID = idx++;
                x.CreatedDate = System.DateTime.Now;
                x.CreatedUser_ID = 1;
                //x.ItemType_ID =
                //x.Quantity=
                //x.Cost=
                //x.Tax =
                //x.Shipping=
                //x.Vendor_ID =
                //x.CostCode1=
                //x.CostCode2 =
                //x.RequestedUser_ID =
            }



        }
    }
}
