using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class Photo : Entity
    {
        public int PhotoID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string FileName { get; set; }
        public string FileActualName { get; set; }
        public Nullable<int> PhotoType { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Company Company { get; set; }
    }
}
