using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectX.Web.Areas.Definitions.Models
{
    public class ItemModel
    {
        [Required]
        public string ItemFullCode { get; set; }
        public string ItemCode { get; set; }
        [Required]
        public string ItemName { get; set; }
        public string ItemShortCode { get; set; }
        public string SupplierCode { get; set; }
        [Required]
        public string SubInvCode { get; set; }
        [Required]
        public string MainCategoryCode { get; set; }
        [Required]
        public string SubCategoryCode { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public string RefCode { get; set; }
        public Nullable<decimal> TColumn { get; set; }
        public Nullable<bool> TColumnByAmt { get; set; }
        public Nullable<bool> IsGiftItem { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Photo { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        //custom 
        public bool isEditMode { get; set; }
    }
}