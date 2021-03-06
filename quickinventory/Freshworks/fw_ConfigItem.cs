using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//
namespace SimpleInventory.Models
{
    [Table("FW_Inventory")]
    public class fw_ConfigItem
    {
        public long? agent_id { get; set; }
        public string asset_tag { get; set; }
        public DateTime? assigned_on { get; set; }
        public long ci_type_id { get; set; }
        public DateTime created_at { get; set; }
        public bool deleted { get; set; }
        public long? department_id { get; set; }
        public object depreciation_id { get; set; }
        public object description { get; set; }
        public bool disabled { get; set; }
        public int display_id { get; set; }
        public bool expiry_notified { get; set; }
        [Key] 
        public long id { get; set; }
        public int impact { get; set; }
        public long? location_id { get; set; }
        public string name { get; set; }
        public object salvage { get; set; }
        public bool trashed { get; set; }
        public DateTime? updated_at { get; set; }
        public long? user_id { get; set; }
        public string department_name { get; set; }
        public string used_by { get; set; }
        public string business_impact { get; set; }
        public string agent_name { get; set; }
        //public fw_LevelfieldValues levelfield_values { get; set; }
        public string ci_type_name { get; set; }
        public string product_name { get; set; }
        public string vendor_name { get; set; }
        public object state_name { get; set; }
        public string location_name { get; set; }
    }
}