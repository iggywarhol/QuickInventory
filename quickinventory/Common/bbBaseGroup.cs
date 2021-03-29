using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bbBaseGroup
    {
        [Key]
        public long ID { get; set; }
        public System.DateTime CreatedDate { get; set; } = System.DateTime.Now;
        [ForeignKey("User")]
        public long? CreatedUser_ID { get; set; } = 1;
        public bb_accesscontrol_User User { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; } = 1;
        public bb_accesscontrol_Tenant Tenant { get; set; }
        public string Name { get; set; }
    }
}
