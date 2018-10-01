using Archery.Models;
using Archery.Tools;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe([Bind(Exclude = "ID")]Archer archer)
        {
            if (ModelState.IsValid)
            {
                //archer.Password = Extension.MD5Hash(archer.Password);
                //archer.Password = Extension.HashMD5(archer.Password);
                archer.Password = archer.Password.HashMD5(); //raccourci d'écriture avec méthode d'extension statique dans une classe statique
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Archers.Add(archer);
                db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                //TempData["Success"] = "Inscription effectuée";
                //return View();
                Display("Archer enregistré"); //Le type par défaut est success voir BaseControler.cs
                return RedirectToAction("index", "Home");
            }
            Display("Veuillez corriger les erreurs", Tools.MessageType.ERROR);
            return View();
        }
    }
}