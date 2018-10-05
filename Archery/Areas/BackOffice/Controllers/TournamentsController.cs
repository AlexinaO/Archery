using Archery.Data;
using Archery.Filters;
using Archery.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    [Authentication]
    public class TournamentsController : Controller
    {
        private ArcheryDbContext db = new ArcheryDbContext();

        // GET: BackOffice/Tournaments
        public ActionResult Index()
        {
            return View(db.Tournaments.ToList());
        }

        // GET: BackOffice/Tournaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Include("Bows").SingleOrDefault(x => x.ID == id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Create
        public ActionResult Create()
        {
            MultiSelectList bowsValues = new MultiSelectList(db.Bows, "ID", "Name");
            ViewBag.Bows = bowsValues;
            return View();
        }

        // POST: BackOffice/Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Location,StartDate,EndDate,ArcherCount,Price, Description")] Tournament tournament, int[] BowsID)
        {
            if (ModelState.IsValid)
            {
                //tournament.Bows = new List<Bow>();
                //foreach (var item in BowsID)
                //{
                //    tournament.Bows.Add(db.Bows.Find(item));
                //}

                if (BowsID.Count() > 0)
                    tournament.Bows = db.Bows.Where(x => BowsID.Contains(x.ID)).ToList();
                db.Tournaments.Add(tournament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            MultiSelectList bowsValues = new MultiSelectList(db.Bows, "ID", "Name");
            ViewBag.Bows = bowsValues;
            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Include("Bows").Include("Pictures").SingleOrDefault(x => x.ID == id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            //tournament.Bows = db.Bows.Where(x => BowsID.Contains(x.ID)).ToList();
            MultiSelectList bowsValues = new MultiSelectList(db.Bows, "ID", "Name", tournament.Bows.Select(x => x.ID));
            ViewBag.Bows = bowsValues;
            return View(tournament);
        }

        // POST: BackOffice/Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location,StartDate,EndDate,ArcherCount,Price, Description")] Tournament tournament, int[] BowsID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;

                db.Tournaments.Include("Bows").Include("Pictures").SingleOrDefault(x => x.ID == tournament.ID); //charge dans le cache
                if (BowsID != null)
                {
                    tournament.Bows = db.Bows.Where(x => BowsID.Contains(x.ID)).ToList();
                }
                else
                    tournament.Bows.Clear();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            MultiSelectList bowsValues = new MultiSelectList(db.Bows, "ID", "Name", tournament.Bows.Select(x => x.ID));
            ViewBag.Bows = bowsValues;
            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: BackOffice/Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament tournament = db.Tournaments.Include("Bows").SingleOrDefault(x => x.ID == id);
            tournament.Bows.Clear();

            var shooters = db.Shooters.Where(x => x.TournamentID == id);
            foreach (var item in shooters)
            {
                db.Entry(item).State = EntityState.Deleted;
                //db.Shooters.Remove(item);
            }
            //db.Entry(tournament).State = Entity.Deleted;
            db.Tournaments.Remove(tournament);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new TournamentPicture();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.TournamentID = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.TournamentPictures.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "tournaments", new { id = id });
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult DeletePicture(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var picture = db.TournamentPictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            db.TournamentPictures.Remove(picture);
            db.SaveChanges();
            return Json(picture);
        }
    }
}