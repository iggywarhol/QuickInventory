﻿using System.ComponentModel.DataAnnotations.Schema;
//BadBetaSoftware.Quick.
//
namespace SimpleInventory.Models
{
    public class bb_Asset_Make : bbBaseList
    {
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bb_accesscontrol_Tenant Tenant { get; set; }
       // public Address Address { get; set; }
    }
}
