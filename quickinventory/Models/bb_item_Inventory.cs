using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bb_item_Inventory : bbBaseItem
    {
        [MaxLength(100)]
        public string AssetID { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bb_accesscontrol_Tenant Tenant { get; set; }
    }
}
