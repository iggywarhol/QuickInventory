using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
    public class bbBaseList
    {
        [Key]
        public long ID { get; set; }
        [MaxLength(100)]
        public string Display { get; set; }
        [MaxLength(100)]
        public string Value { get; set; }
        [Required]
        public int Sort { get; set; } = 0;
        [Required]
        public bool Enabled { get; set; } = true;
        [Required]
        public bool Default { get; set; } = false;
        [Required]
        public System.DateTime CreatedDate { get; set; }
        [ForeignKey("User")]
        public long? CreatedUser_ID { get; set; }
        public User User { get; set; }
    }
}
