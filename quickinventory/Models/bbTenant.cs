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
    public class bbTenant
    {
        [Key]
        public long ID { get; set; }
        [MaxLength(100)]
        public string Company { get; set; }
        [Required]
        public System.DateTime CreatedDate { get; set; }
    }
}
