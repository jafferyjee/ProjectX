using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class ItemSubCategory : Entity
    {
        public ItemSubCategory()
        {
            this.Items = new List<Item>();
        }

        public string SubCategoryCode { get; set; }
        public string MainCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public string SubInvCode { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ItemMainCategory ItemMainCategory { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual SubInventory SubInventory { get; set; }
    }
}
