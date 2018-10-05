using Archery.Areas.BackOffice.Models;
using Archery.Filters;
using Archery.Models;
using Archery.Tools;
using System.Linq;
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Authentication(Type = "ARCHER")]
        public ActionResult SubscribeTournament(int? tournamentId)
        {
            if (tournamentId == null)
                return HttpNotFound();
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModels model)
        {
            var hash = model.Password.HashMD5();
            var archer = db.Archers.SingleOrDefault(x => x.Mail == model.Mail && x.Password == hash);

            if (archer == null)
            {
                Display("Login/Mot de passe incorrect", MessageType.ERROR);
                return View();
            }
            else
            {
                Session["ARCHER"] = archer;
                if (TempData["REDIRECT"] != null)
                    return Redirect(TempData["REDIRECT"].ToString());
                else

                    return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("ARCHER");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}