using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using ProjectX.Web.Utility;

namespace ProjectX.Web.Filters
{
    public class UnHandledExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override async System.Threading.Tasks.Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, System.Threading.CancellationToken cancellationToken)
        {
            await LogException(actionExecutedContext.Exception);
        }

        private System.Threading.Tasks.Task LogException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}