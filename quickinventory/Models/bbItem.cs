using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
//
using SimpleInventory.Helpers;
//
namespace SimpleInventory.Models
{
    public class bbItem
    {
        public int ID { get; set; }
        public string AssetID { get; set; }
        //
        //
        [ForeignKey("Purchase")]
        public long Purchase_ID { get; set; }
        public bbItemPurchase Purchase { get; set; }
        [ForeignKey("Tenant")]
        public long Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
    }
}
