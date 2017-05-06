using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class SubInventory : Entity
    {
        public SubInventory()
        {
            this.DocumentDatas = new List<DocumentData>();
            this.DocumentNumbers = new List<DocumentNumber>();
            this.ItemMainCategories = new List<ItemMainCategory>();
            this.Items = new List<Item>();
            this.ItemStocks = new List<ItemStock>();
            this.ItemSubCategories = new List<ItemSubCategory>();
            this.SeasonalSaleDetails = new List<SeasonalSaleDetail>();
            this.SubInventorySizeRanges = new List<SubInventorySizeRange>();
            this.Colors = new List<Color>();
            this.Sizes = new List<Size>();
        }

        public string SubInvCode { get; set; }
        public string SubInvName { get; set; }
        public string CodeFormat { get; set; }
        public string ShortName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<DocumentData> DocumentDatas { get; set; }
        public virtual ICollection<DocumentNumber> DocumentNumbers { get; set; }
        public virtual ICollection<ItemMainCategory> ItemMainCategories { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<ItemStock> ItemStocks { get; set; }
        public virtual ICollection<ItemSubCategory> ItemSubCategories { get; set; }
        public virtual ICollection<SeasonalSaleDetail> SeasonalSaleDetails { get; set; }
        public virtual ICollection<SubInventorySizeRange> SubInventorySizeRanges { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
    }
}
