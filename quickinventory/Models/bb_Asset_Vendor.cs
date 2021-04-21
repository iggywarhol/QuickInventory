﻿using System.ComponentModel.DataAnnotations.Schema;
//
using BadBetaSoftware.Quick.Common;
using BadBetaSoftware.Quick.Common.Helpers;
//
//
namespace SimpleInventory.Models
{
   public class bb_Asset_Vendor : bbBaseList
    {
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bb_accesscontrol_Tenant Tenant { get; set; }
        //public Address  Address { get; set; }
    }
}
