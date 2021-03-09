using System.ComponentModel.DataAnnotations.Schema;
using SimpleInventory.Common;
//
namespace SimpleInventory.Models
{
   public class bb_Asset_Vendor : bbBaseList
    {
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
        //public Address  Address { get; set; }
    }
}
