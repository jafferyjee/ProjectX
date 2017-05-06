using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class Color
    {
        public Color()
        {
            this.DocumentDatas = new List<DocumentData>();
            this.ItemColorSizes = new List<ItemColorSize>();
            this.ItemStocks = new List<ItemStock>();
            this.SubInventories = new List<SubInventory>();
        }

        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<DocumentData> DocumentDatas { get; set; }
        public virtual ICollection<ItemColorSize> ItemColorSizes { get; set; }
        public virtual ICollection<ItemStock> ItemStocks { get; set; }
        public virtual ICollection<SubInventory> SubInventories { get; set; }
    }
}
