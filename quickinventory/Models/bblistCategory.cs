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
    public class bblistCategory
    {
        [Key]
        public long ID { get; set; }
        [MaxLength(100)]
        public string Display { get; set; }
        [MaxLength(100)]
        public string Value { get; set; }
        [Required]
        public System.DateTime CreatedDate { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }

    }
}
