using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class SeasonalSaleDetail
    {
        public int SaleID { get; set; }
        public int RowSerial { get; set; }
        public string ItemFullCode { get; set; }
        public string SubInvCode { get; set; }
        public string RangeCode { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<decimal> DiscountPrice { get; set; }
        public Nullable<int> DiscountPer { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Item Item { get; set; }
        public virtual Range Range { get; set; }
        public virtual SeasonalSale SeasonalSale { get; set; }
        public virtual SubInventory SubInventory { get; set; }
    }
}
