using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class Range
    {
        public Range()
        {
            this.ItemPrices = new List<ItemPrice>();
            this.SeasonalSaleDetails = new List<SeasonalSaleDetail>();
            this.SubInventorySizeRanges = new List<SubInventorySizeRange>();
        }

        public string RangeCode { get; set; }
        public string RangeName { get; set; }
        public virtual ICollection<ItemPrice> ItemPrices { get; set; }
        public virtual ICollection<SeasonalSaleDetail> SeasonalSaleDetails { get; set; }
        public virtual ICollection<SubInventorySizeRange> SubInventorySizeRanges { get; set; }
    }
}
