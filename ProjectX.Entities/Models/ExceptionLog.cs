using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class ExceptionLog : Entity
    {
        public int ExceptionLogID { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    }
}
