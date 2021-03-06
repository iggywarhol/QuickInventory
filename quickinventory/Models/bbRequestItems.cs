using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bbRequestItems : bbBaseItem
    {
        public string CostCode1 { get; set; }
        public string CostCode2 { get; set; }
    }
}
