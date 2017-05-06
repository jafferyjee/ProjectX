using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class ItemColorSize : Entity
    {
        public string ItemFullCode { get; set; }
        public string ColorCode { get; set; }
        public int SizeCode { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Color Color { get; set; }
        public virtual Item Item { get; set; }
        public virtual Size Size { get; set; }
    }
}
