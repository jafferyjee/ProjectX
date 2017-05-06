using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class SeasonalSale
    {
        public SeasonalSale()
        {
            this.SeasonalSaleDetails = new List<SeasonalSaleDetail>();
        }

        public int SaleID { get; set; }
        public string SaleDescription { get; set; }
        public Nullable<System.DateTime> SaleStartDate { get; set; }
        public Nullable<System.DateTime> SaleEndDate { get; set; }
        public string SaleBranchCodes { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<SeasonalSaleDetail> SeasonalSaleDetails { get; set; }
    }
}
