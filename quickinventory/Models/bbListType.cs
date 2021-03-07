using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bbListType : bbBaseList
    {
        [MaxLength(100)]
        [Required]
        public string Make { get; set; }
        [MaxLength(100)]
        [Required]
        public string Model { get; set; }
        [ForeignKey("Category")]
        public long? Category_ID { get; set; }
        public bbListCategory Category { get; set; }// Monitor, Dock, Laptop, Desktop, switch, firewall
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
        [Required]
        public double EstimatedCost { get; set; } = 0;
        public bbListType()
        {
            ID = 0;
            Value = "";
            Display = "";
            //Manufacture = ListTypeEnum.Manufacture;
        }
    }
}
