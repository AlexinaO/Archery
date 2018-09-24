using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var modelinfo = new Info
            {
                DevName = "Alexina",
                ContactMail = "alexina@alexina.com",
                CreateDate = DateTime.Now
            };
            return View(modelinfo);
        }
    }
}