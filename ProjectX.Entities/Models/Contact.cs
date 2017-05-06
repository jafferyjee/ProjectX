using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class Contact : Entity
    {
        public Contact()
        {
            this.DocumentDatas = new List<DocumentData>();
            this.Items = new List<Item>();
        }

        public string ContactFullCode { get; set; }
        public string ContactTypeCode { get; set; }
        public string ContactCategoryCode { get; set; }
        public string ContactCode { get; set; }
        public string ContactName { get; set; }
        public string LevelContactFullCode { get; set; }
        public Nullable<bool> IsTransaction { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string BranchCode { get; set; }
        public string Salutation { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Relation { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneDirect { get; set; }
        public string PhoneExt { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string CardFormNo { get; set; }
        public Nullable<System.DateTime> CardIssueDate { get; set; }
        public Nullable<System.DateTime> CardExpiryDate { get; set; }
        public Nullable<int> DiscountPer { get; set; }
        public Nullable<decimal> DiscountAmt { get; set; }
        public string CNIC { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public Nullable<System.DateTime> WeddingAnni { get; set; }
        public Nullable<int> CardStatus { get; set; }
        public string Photo { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ContactCategory ContactCategory { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual ICollection<DocumentData> DocumentDatas { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
