using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bbBaseGroup
    {
        [Key]
        public long ID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        [ForeignKey("User")]
        public long? CreatedUser_ID { get; set; }
        public User User { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
    }
}
