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
   public class bbOrderPayment
    {
        [Key]
        public int ID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        //
        //
        [ForeignKey("OrderItems")]
        public long OrderItems_ID { get; set; }
        public bbOrderItems OrderItems { get; set; }
        [ForeignKey("Tenant")]
        public long Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
    }
}
