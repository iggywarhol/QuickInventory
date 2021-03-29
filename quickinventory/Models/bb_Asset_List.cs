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
    public class bb_Asset_List : bbBaseList
    {
        public ListTypeEnum Type { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bb_accesscontrol_Tenant Tenant { get; set; }
    }
}
