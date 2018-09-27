using Archery.Data;
using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class ArchersController : Controller
    {
        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }


        private ArcheryDbContext db = new ArcheryDbContext();

        [HttpPost]
        public ActionResult Subscribe(Archer archer )
        {
            if (ModelState.IsValid)
            {
                db.Archers.Add(archer);
                db.SaveChanges();
                TempData["Success"] = "Vous êtes bien inscrits";
                //return View();
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                this.db.Dispose();
        }

    }
}