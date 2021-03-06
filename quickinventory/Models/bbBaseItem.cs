﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bbBaseItem
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public System.DateTime CreatedDate { get; set; }
        [ForeignKey("User")]
        public long? CreatedUser_ID { get; set; }
        public User User { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
        //
        //
        [ForeignKey("Type")]
        public long ItemType_ID { get; set; }
        public bbItemType Type { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public double Tax { get; set; } = 0;
        public double Shipping { get; set; } = 0;
        [ForeignKey("Vendor")]
        public long? Vendor_ID { get; set; }
        public bblistVendor Vendor { get; set; }
        
        //[ForeignKey("RequestedUser")]
        //public long RequestedUser_ID { get; set; }
        //public User RequestedUser { get; set; }

    }
}
