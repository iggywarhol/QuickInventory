using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
   public class bblistVendor
    {
        [Key]
        public long ID { get; set; }
        [MaxLength(100)]
        public string Company { get; set; }
        [Required]
        public System.DateTime CreatedDate { get; set; }
        [ForeignKey("User")]
        public long? CreatedUser_ID { get; set; }
        public User User { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
    }
}
