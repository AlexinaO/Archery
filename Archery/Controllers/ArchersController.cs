using Archery.Data;
using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Archery.Tools;

namespace Archery.Controllers
{
    public class ArchersController : BaseController
    {
        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe([Bind(Exclude="ID")]Archer archer )
        {
            if (ModelState.IsValid)
            {
                archer.Password = Encryptor.MD5Hash(archer.Password);
                db.Archers.Add(archer);
                db.SaveChanges();
                //TempData["Success"] = "Inscription effectuée";
                //return View();
                Display("Archer enregistré"); //Le type par défaut est success voir BaseControler.cs
                return RedirectToAction("index", "Home");
            }
            Display("Veuillez corriger les erreurs",Tools.MessageType.ERROR);
            return View();
        }

        

    }
}