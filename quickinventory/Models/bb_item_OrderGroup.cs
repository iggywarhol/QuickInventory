using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bb_item_OrderGroup : bbBaseGroup
    {
        public string OrderName { get; set; }
        public ICollection<bb_item_OrderSingle> Orders { get; set; }
    }
}
