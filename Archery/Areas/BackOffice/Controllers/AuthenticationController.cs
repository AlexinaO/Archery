using Archery.Areas.BackOffice.Models;
using Archery.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    public class AuthenticationController : BaseController
    {
        // GET: BackOffice/Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthenticationLoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                //var hash = model.Password.HashMD5();
                //var admin = db.Administrators.SingleOrDefault(x => x.Mail == model.Mail && x.Password == hash);
                var admin = db.Administrators.SingleOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);

                if (admin == null)
                {
                    ModelState.AddModelError("Mail", "Login / mot de passe invalide");
                    return View();
                }
                else
                {
                    Session["ADMINISTRATOR"] = admin;
                    //Session["AdminName"] = admin.FirstName;

                    return RedirectToAction("Index", "Dashboard", new { area = "BackOffice" }); //area inutile ici puisque nous sommes déjà dedans mais cela n'affecte rien de la mettre quand même
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("ADMINISTRATOR");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}