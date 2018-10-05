using System;
using System.Web.Mvc;

namespace Archery.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public string Type { get; set; } = "BO";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Type == "BO")
            {
                if (filterContext.HttpContext.Session["ADMINISTRATOR"] == null)
                {
                    filterContext.Result = new RedirectResult(@"\BackOffice\authentication\login");
                }
            }

            if (Type == "ARCHER")
            {
                if (filterContext.HttpContext.Session["ARCHER"] == null)
                {
                    filterContext.Result = new RedirectResult(@"\archers\login");
                }
            }
        }
    }
}