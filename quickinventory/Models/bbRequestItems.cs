using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bbRequestItems : bbBaseItem
    {
        public string CostCode1 { get; set; }
        public string CostCode2 { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
        [ForeignKey("RequestedUser")]
        public long RequestedUser_ID { get; set; }
        public User RequestedUser { get; set; }
    }
}
