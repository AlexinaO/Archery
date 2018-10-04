using Archery.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Title"] = "Accueil";

            return View(db.Tournaments.Include("Bows")
                .Include("Pictures")
                .Where(x => x.StartDate >= DateTime.Now)
                .OrderBy(x => x.StartDate)
                .ToList());
        }

        //[Route ("a-propos")]
        public ActionResult About()
        {
            var modelInfo = new Info
            {
                DevName = "Alexina",
                ContactMail = "alexina@alexina.com",
                CreatedDate = DateTime.Now
            };
            return View(modelInfo);
        }
    }
}