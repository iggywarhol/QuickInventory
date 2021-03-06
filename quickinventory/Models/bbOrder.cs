using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bbOrder : bbBaseGroup
    {
        public string OrderName { get; set; }
        public ICollection<bbOrderItems> Orders { get; set; }
    }
}
