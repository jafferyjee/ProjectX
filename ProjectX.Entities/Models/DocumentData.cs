using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class DocumentData
    {
        public DocumentData()
        {
            this.DocumentSizes = new List<DocumentSize>();
        }

        public string RowUnqRef { get; set; }
        public Nullable<System.Guid> DocUnqRef { get; set; }
        public Nullable<int> RowSerial { get; set; }
        public string DocNumber { get; set; }
        public string DocPrefix { get; set; }
        public Nullable<int> DocSerial { get; set; }
        public string DocDisplayNumber { get; set; }
        public string DocID { get; set; }
        public Nullable<System.DateTime> DocDate { get; set; }
        public string Description { get; set; }
        public string ItemFullCode { get; set; }
        public string ItemCode { get; set; }
        public string ItemShortCode { get; set; }
        public Nullable<int> DocQuantity { get; set; }
        public Nullable<double> DocRate { get; set; }
        public Nullable<double> DocAmount { get; set; }
        public string SubInvCode { get; set; }
        public string SessionUnqRef { get; set; }
        public string BranchCode { get; set; }
        public string ContactFullCode { get; set; }
        public string ColorCode { get; set; }
        public Nullable<int> DiscountPer { get; set; }
        public Nullable<double> DiscountAmt { get; set; }
        public Nullable<double> TaxAmt { get; set; }
        public Nullable<int> TaxPer { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string ManualRef { get; set; }
        public string BranchRef { get; set; }
        public Nullable<System.Guid> RefDocUnqRef { get; set; }
        public string RefDocNumber { get; set; }
        public Nullable<int> PaymentTermID { get; set; }
        public Nullable<decimal> CostPrice { get; set; }
        public Nullable<bool> IsSeasonalItem { get; set; }
        public Nullable<bool> IsPosted { get; set; }
        public Nullable<int> Xref01 { get; set; }
        public Nullable<int> Xref02 { get; set; }
        public Nullable<int> Xref03 { get; set; }
        public Nullable<int> Xref04 { get; set; }
        public Nullable<int> Xref05 { get; set; }
        public string Xref06 { get; set; }
        public string Xref07 { get; set; }
        public string Xref08 { get; set; }
        public string Xref09 { get; set; }
        public string Xref10 { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Color Color { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual DocumentNumber DocumentNumber { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual Item Item { get; set; }
        public virtual PaymentTerm PaymentTerm { get; set; }
        public virtual Session Session { get; set; }
        public virtual SubInventory SubInventory { get; set; }
        public virtual ICollection<DocumentSize> DocumentSizes { get; set; }
    }
}
