using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjectX.Web.Utility
{
    public static class Util
    {
        public static string CurrentUser {
            get { return HttpContext.Current.User.Identity.Name; }
        }

        public static string UploadPath 
        {
            get { return ConfigurationManager.AppSettings["UploadPath"]; }
        }
    }
}