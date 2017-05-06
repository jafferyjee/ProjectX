using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class DocumentSize
    {
        public string RowUnqRef { get; set; }
        public int SizeCode { get; set; }
        public Nullable<int> SizeQty { get; set; }
        public virtual DocumentData DocumentData { get; set; }
        public virtual Size Size { get; set; }
    }
}
