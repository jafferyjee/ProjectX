using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Web.Areas.Definitions.Models
{
    public class SubCategoryModel
    {
        public string SubCategoryCode { get; set; }
        public string MainCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public string SubInvCode { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}