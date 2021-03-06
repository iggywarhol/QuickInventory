using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
namespace SimpleInventory.Models
{
   public class bbRequestGroup : bbBaseGroup
    {
        [Required]
        public System.DateTime RequestByDate { get; set; }
        [ForeignKey("RequestByUser")]
        public long RequestByUser_ID { get; set; }
        public User RequestByUser { get; set; }
        [ForeignKey("Approver1")]
        public long? Approver1_ID { get; set; }
        public User Approver1 { get; set; }
        [ForeignKey("Approver2")]
        public long? Approver2_ID { get; set; }
        public User Approver2 { get; set; }
        public ICollection<bbRequestItems> Requests { get; set; }
    }
}