using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
//using SimpleInventory.Helpers;
//
namespace SimpleInventory.Models
{
    public class bbItemType
    {
        [Key]
        public long ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public System.DateTime CreatedDate { get; set; }
        [MaxLength(100)]
        public string Manufacture { get; set; }   // Dell, HP, Epson, Logictech, Microsoft
        [MaxLength(100)]
        public string Model { get; set; }
        
        [ForeignKey("Category")]
        public long? Category_ID { get; set; }
        public bblistCategory Category { get; set; }// Monitor, Dock, Laptop, Desktop, switch, firewall
        
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
        public bbItemType()
        {
            ID = 0;
            Name = "";
            Description = "";
            Manufacture = "DELL";
        }
    }
}
