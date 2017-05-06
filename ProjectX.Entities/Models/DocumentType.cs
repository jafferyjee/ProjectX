using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            this.DocumentDatas = new List<DocumentData>();
            this.DocumentNumbers = new List<DocumentNumber>();
        }

        public string DocID { get; set; }
        public string DocName { get; set; }
        public string StockEffect { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> IsSessionBased { get; set; }
        public virtual ICollection<DocumentData> DocumentDatas { get; set; }
        public virtual ICollection<DocumentNumber> DocumentNumbers { get; set; }
    }
}
