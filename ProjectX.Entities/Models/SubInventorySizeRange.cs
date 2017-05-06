using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class SubInventorySizeRange
    {
        public string SubInvCode { get; set; }
        public string RangeCode { get; set; }
        public int SizeCode { get; set; }
        public virtual Range Range { get; set; }
        public virtual Size Size { get; set; }
        public virtual SubInventory SubInventory { get; set; }
    }
}
