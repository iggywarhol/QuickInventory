using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bbInventoryItems : bbBaseItem
    {
        [MaxLength(100)]
        public string AssetID { get; set; }
    }
}
