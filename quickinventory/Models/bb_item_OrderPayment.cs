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
   public class bb_item_OrderPayment
    {
        [Key]
        public int ID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        //
        //
        [ForeignKey("OrderItems")]
        public long OrderItems_ID { get; set; }
        public bb_item_OrderSingle OrderItems { get; set; }
        [ForeignKey("Tenant")]
        public long Tenant_ID { get; set; }
        public bb_accesscontrol_Tenant Tenant { get; set; }
    }
}
