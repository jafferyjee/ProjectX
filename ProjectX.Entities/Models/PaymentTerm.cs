using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class PaymentTerm
    {
        public PaymentTerm()
        {
            this.DocumentDatas = new List<DocumentData>();
        }

        public int PaymentTermID { get; set; }
        public string PaymentTermName { get; set; }
        public virtual ICollection<DocumentData> DocumentDatas { get; set; }
    }
}
