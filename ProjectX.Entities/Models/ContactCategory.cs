using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class ContactCategory : Entity
    {
        public ContactCategory()
        {
            this.Contacts = new List<Contact>();
        }

        public string ContactCategoryCode { get; set; }
        public string ContactCategoryName { get; set; }
        public string ContactTypeCode { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
