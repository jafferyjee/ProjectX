using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class Company
    {
        public Company()
        {
            this.Branches = new List<Branch>();
            this.Photos = new List<Photo>();
        }

        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string TagLine { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string TaxID { get; set; }
        public string Logo { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
