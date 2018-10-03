using System.Web.Mvc;

namespace Archery.Filters
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["ADMINISTRATOR"] == null)
            {
                filterContext.Result = new RedirectResult(@"\BackOffice\authentication\login");
                base.OnActionExecuting(filterContext);
            }
        }
    }
}