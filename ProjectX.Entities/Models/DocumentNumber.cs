using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class DocumentNumber
    {
        public DocumentNumber()
        {
            this.DocumentDatas = new List<DocumentData>();
        }

        public System.Guid DocUnqRef { get; set; }
        public string DocNumber { get; set; }
        public string DocPrefix { get; set; }
        public Nullable<int> DocSerial { get; set; }
        public string DocID { get; set; }
        public Nullable<System.DateTime> DocDate { get; set; }
        public string SubInvCode { get; set; }
        public string SessionUnqRef { get; set; }
        public string BranchCode { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<DocumentData> DocumentDatas { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual Session Session { get; set; }
        public virtual SubInventory SubInventory { get; set; }
    }
}
