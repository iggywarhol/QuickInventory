using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleInventory.Models
{



    public class ConfigItem
    {
        public string Display { get; set; }
        public string Value { get; set; }
        public int Sort { get; set; } = 0;
        public bool Enabled { get; set; } = true;
        public bool Default { get; set; } = false;
        public ConfigItem(string display, string value, int sort, bool enabled, bool dflt)
        {
            Display = display;
            Value = value;
            Sort = sort;
            Enabled = enabled;
            Default = dflt;
        }

        public ConfigItem()
        {

        }
        public ConfigItem(string value)
        {
            Display = value;
            Value = value;
            Sort = 0;
            Enabled = true;
            Default = false;
        }

    }




    // public class Groups
    // {
    //     public int ID { get; set; }
    //     [MaxLength(50)]
    //     public string Section { get; set; }
    //     [MaxLength(50)] 
    //     public string Key { get; set; }
    //     public string Value { get; set; }
    // }
    public class Groups
    {
        public int ID { get; set; }
        [MaxLength(25)]
        public string Key { get; set; }
        [MaxLength(2000)]
        public string Value { get; set; }
    }
}
