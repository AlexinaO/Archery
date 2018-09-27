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

        [HttpPost]
        public ActionResult Subscribe(Archer archer )
        {
            /* si on met ici alors cela va être uniquement dans ce contrôleur et il faudra le copier dans chaque contrôleur où on veut l'utiliser!*/
            //if (DateTime.Now.AddYears(-9) <= archer.BirthDate) /*à utiliser pour 1ère et 2ème façon*/
            //{
            //    /*ViewBag.Erreur = "Vous êtes trop jeune !";
            //    return View(); 1ère façon de faire*/
            //    ModelState.AddModelError("BirthDate", "Date de naissance invalide");/*2ème façon de faire*/

            //}


            if (ModelState.IsValid)
            {
               
            }
            return View();
        }

       //public static ErrorMessage (string errorMessage)
       // {

       // }
    }
}