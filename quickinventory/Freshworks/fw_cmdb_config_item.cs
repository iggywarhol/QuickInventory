using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventory.Models
{
    public class fw_cmdb_config_item
    {
        public string name { get; set; }
        public string impact { get; set; }
        public string asset_tag { get; set; }
        public string location_id { get; set; }
    }
}
