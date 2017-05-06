using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class Item : Entity
    {
        public Item()
        {
            this.DocumentDatas = new List<DocumentData>();
            this.ItemColorSizes = new List<ItemColorSize>();
            this.ItemPrices = new List<ItemPrice>();
            this.ItemStocks = new List<ItemStock>();
            this.SeasonalSaleDetails = new List<SeasonalSaleDetail>();
        }

        public string ItemFullCode { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemShortCode { get; set; }
        public string SupplierCode { get; set; }
        public string SubInvCode { get; set; }
        public string MainCategoryCode { get; set; }
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
        public virtual Contact Contact { get; set; }
        public virtual ICollection<DocumentData> DocumentDatas { get; set; }
        public virtual ICollection<ItemColorSize> ItemColorSizes { get; set; }
        public virtual ItemMainCategory ItemMainCategory { get; set; }
        public virtual ICollection<ItemPrice> ItemPrices { get; set; }
        public virtual ItemSubCategory ItemSubCategory { get; set; }
        public virtual SubInventory SubInventory { get; set; }
        public virtual ICollection<ItemStock> ItemStocks { get; set; }
        public virtual ICollection<SeasonalSaleDetail> SeasonalSaleDetails { get; set; }
    }
}
