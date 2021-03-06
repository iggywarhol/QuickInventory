using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
//
namespace SimpleInventory.Models
{
    public class bbItemPurchase
    {
        public long ID { get; set; }
        [ForeignKey("Type")]
        public long ItemType_ID { get; set; }
        public bbItemType Type { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Vendor")]
        public long Vendor_ID { get; set; }
        public bbItemVendor Vendor { get; set; }
    }
}
