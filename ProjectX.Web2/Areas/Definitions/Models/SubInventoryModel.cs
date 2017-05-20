using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectX.Web.Areas.Definitions.Models
{
    public class SubInventoryModel
    {
        [Display(Name="Code")]
        [Required]
        public string SubInvCode { get; set; }

        [Display(Name="Name")]
        [Required]
        public string SubInvName { get; set; }
        
        [ScaffoldColumn(false)]
        public string CodeFormat { get; set; }

        [Display(Name = "Short Name")]
        [Required]
        public string ShortName { get; set; }

        [ReadOnly(true)]
        public string CreatedBy { get; set; }
        [ReadOnly(true)]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [ReadOnly(true)]
        public string ModifiedBy { get; set; }
        [ReadOnly(true)]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}