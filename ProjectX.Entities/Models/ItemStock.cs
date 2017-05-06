using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models 
{
    public partial class ItemStock : Entity
    {
        public string RowUnqRef { get; set; }
        public string ItemFullCode { get; set; }
        public string ColorCode { get; set; }
        public int SizeCode { get; set; }
        public string BranchCode { get; set; }
        public string SubInvCode { get; set; }
        public Nullable<int> QtyOnHand { get; set; }
        public string ItemCode { get; set; }
        public string ItemShortCode { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Color Color { get; set; }
        public virtual Item Item { get; set; }
        public virtual Size Size { get; set; }
        public virtual SubInventory SubInventory { get; set; }
    }
}
