using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class Size
    {
        public Size()
        {
            this.DocumentSizes = new List<DocumentSize>();
            this.ItemColorSizes = new List<ItemColorSize>();
            this.ItemPrices = new List<ItemPrice>();
            this.ItemStocks = new List<ItemStock>();
            this.SubInventorySizeRanges = new List<SubInventorySizeRange>();
            this.SubInventories = new List<SubInventory>();
        }

        public int SizeCode { get; set; }
        public string SizeName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<DocumentSize> DocumentSizes { get; set; }
        public virtual ICollection<ItemColorSize> ItemColorSizes { get; set; }
        public virtual ICollection<ItemPrice> ItemPrices { get; set; }
        public virtual ICollection<ItemStock> ItemStocks { get; set; }
        public virtual ICollection<SubInventorySizeRange> SubInventorySizeRanges { get; set; }
        public virtual ICollection<SubInventory> SubInventories { get; set; }
    }
}
