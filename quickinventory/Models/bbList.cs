using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public enum ListTypeEnum
    {
        Make = 1,
        Model = 1
    }
    public class bbList : bbBaseList
    {
        public ListTypeEnum Type { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
    }
}
