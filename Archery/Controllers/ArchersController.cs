using Archery.Data;
using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class ArchersController : BaseController
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
                //TempData["Success"] = "Inscription effectuée";
                //return View();
                Display("Archer enregistré"); //Le type par défaut est success voir BaseControler.cs
                return RedirectToAction("index", "Home");
            }
            ViewBag.Message = "Veuillez corriger les erreurs";
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