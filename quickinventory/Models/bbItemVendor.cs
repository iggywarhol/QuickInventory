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
   public class bbItemVendor
    {
        public long ID { get; set; }
        [MaxLength(200)]
        public string Company { get; set; }
        [ForeignKey("Tenant")]
        public long Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
    }
}
