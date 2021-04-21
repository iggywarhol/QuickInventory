using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//
namespace SimpleInventory.Models
{
    public class bb_Asset_Model : bbBaseList
    {
        [ForeignKey("Make")]
        public long? Make_ID { get; set; }
        public bb_Asset_Make Make { get; set; }
        [ForeignKey("Category")]
        public long? Category_ID { get; set; }
        public bb_Asset_Category Category { get; set; }// Monitor, Dock, Laptop, Desktop, switch, firewall
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bb_Asset_Make Tenant { get; set; }
        [Required]
        public double PreferredCost { get; set; }
        [ForeignKey("Vendor")]
        public long PreferredVendor_Id { get; set; }
        public bb_Asset_Vendor Vendor { get; set; }
    }
}
