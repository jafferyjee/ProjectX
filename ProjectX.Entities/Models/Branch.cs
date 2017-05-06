using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class Branch
    {
        public Branch()
        {
            this.DocumentDatas = new List<DocumentData>();
            this.DocumentNumbers = new List<DocumentNumber>();
            this.ItemStocks = new List<ItemStock>();
        }

        public string BranchCode { get; set; }
        public int CompanyID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string Phone { get; set; }
        public Nullable<bool> IsHeadOffice { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<DocumentData> DocumentDatas { get; set; }
        public virtual ICollection<DocumentNumber> DocumentNumbers { get; set; }
        public virtual ICollection<ItemStock> ItemStocks { get; set; }
    }
}
