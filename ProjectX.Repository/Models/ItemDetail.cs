using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Repository.Models
{
    public class ItemDetail
    {
        public string ItemFullCode { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemShortCode { get; set; }
        public string LevelItemFullCode { get; set; }
        public string SupplierCode { get; set; }
        public string SubInvCode { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public string RefCode { get; set; }
        public Nullable<decimal> TColumn { get; set; }
        public Nullable<bool> TColumnByAmt { get; set; }
        public Nullable<bool> IsGiftItem { get; set; }
        public Nullable<bool> IsTransaction { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public string MasterCategoryFullCode { get; set; }
        public string MasterCategoryName { get; set; }
        public string CategoryFullCode { get; set; }
        public string CategoryName { get; set; }
        public string SubInvName { get; set; }
        public string SupplierName { get; set; }
    }
}
