using System.ComponentModel.DataAnnotations.Schema;
//
using BadBetaSoftware.Quick.Common;
//
namespace SimpleInventory.Models
{
    public class bb_item_OrderSingle : bbBaseItem
    {
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bb_accesscontrol_Tenant Tenant { get; set; }
    }
}
