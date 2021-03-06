using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//

// https://kopisusa.com/creating-permission-based-security-system/

namespace SimpleInventory.Models
{
    public class UserPermission
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public long UserID { get; set; }
        [Required]
        public System.DateTime CreatedDate { get; set; }
        [Required]
        public bool CanAddEditItems { get; set; }
        [Required]
        public bool CanAdjustItemQuantity { get; set; }
        [Required]
        public bool CanViewDetailedItemQuantityAdjustments { get; set; }
        [Required]
        public bool CanScanItems { get; set; }
        [Required]
        public bool CanGenerateBarcodes { get; set; }
        [Required]
        public bool CanViewReports { get; set; }
        [Required]
        public bool CanViewDetailedItemSoldInfo { get; set; }
        [Required]
        public bool CanSaveReportsToPDF { get; set; }
        [Required]
        public bool CanDeleteItemsFromInventory { get; set; }
        [Required]
        public bool CanManageItemCategories { get; set; }
        [Required]
        public bool CanManageUsers { get; set; }
        [Required]
        public bool CanDeleteItemsSold { get; set; }
        [Required]
        public bool CanViewManageInventoryQuantity { get; set; }
        public void UserPermissions()
        {
            ID = -1;
            UserID = -1;

            CanAddEditItems = false;
            CanAdjustItemQuantity = false;
            CanViewDetailedItemQuantityAdjustments = false;
            CanScanItems = false;
            CanGenerateBarcodes = false;
            CanViewReports = false;
            CanViewDetailedItemSoldInfo = false;
            CanSaveReportsToPDF = false;
            CanDeleteItemsFromInventory = false;
            CanManageItemCategories = false;
            CanManageUsers = false;
            CanDeleteItemsSold = false;
            CanViewManageInventoryQuantity = false;
        }
    }
}
