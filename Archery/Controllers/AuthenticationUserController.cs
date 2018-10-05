using Archery.Models;
using Archery.Tools;
using System.Linq;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class AuthenticationUserController : BaseController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(AuthenticationUserViewModels model)
        {
            if (ModelState.IsValid)
            {
                var hash = model.Password.HashMD5();
                var archer = db.Archers.SingleOrDefault(x => x.Mail == model.Mail && x.Password == hash);

                if (archer == null)
                {
                    ModelState.AddModelError("Mail", "Login / mot de passe invalide");
                    return View();
                }
                else
                {
                    Session["ARCHER"] = archer;

                    return RedirectToAction("Index", "home", new { area = "" });
                }
            }
            return View();
        }

        public ActionResult LogoutUser()
        {
            Session.Remove("USER");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}