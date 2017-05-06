using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class ContactType : Entity
    {
        public ContactType()
        {
            this.ContactCategories = new List<ContactCategory>();
            this.Contacts = new List<Contact>();
        }

        public string ContactTypeCode { get; set; }
        public string ContactTypeName { get; set; }
        public string CodeFormat { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<ContactCategory> ContactCategories { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
