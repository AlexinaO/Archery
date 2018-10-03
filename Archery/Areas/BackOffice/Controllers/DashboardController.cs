using Archery.Filters;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    [Authentication]
    public class DashboardController : Controller
    {
        // GET: BackOffice/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}