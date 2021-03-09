using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bb_Asset_Category : bbBaseList
    {
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
    }
}
