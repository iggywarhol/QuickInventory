using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
using BadBetaSoftware.Quick.Common;
using BadBetaSoftware.Quick.Common.Helpers;
//
namespace SimpleInventory.Models
{
   public class bb_item_RequestGroup : bbBaseGroup
    {
        [Required]
        public System.DateTime RequestByDate { get; set; }
        [ForeignKey("RequestByUser")]
        public long RequestByUser_ID { get; set; }
        public bb_accesscontrol_User RequestByUser { get; set; }
        [ForeignKey("Approver1")]
        public long? Approver1_ID { get; set; }
        public bb_accesscontrol_User Approver1 { get; set; }
        [ForeignKey("Approver2")]
        public long? Approver2_ID { get; set; }
        public bb_accesscontrol_User Approver2 { get; set; }
        public ICollection<bb_item_RequestSingle> Requests { get; set; }
    }
}