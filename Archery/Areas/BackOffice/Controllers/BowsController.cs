﻿using Archery.Data;
using Archery.Filters;
using Archery.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    [Authentication]
    public class BowsController : Controller
    {
        private ArcheryDbContext db = new ArcheryDbContext();

        // GET: BackOffice/Bows
        public ActionResult Index()
        {
            return View(db.Bows.ToList());
        }

        // GET: BackOffice/Bows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bow bow = db.Bows.Find(id);
            if (bow == null)
            {
                return HttpNotFound();
            }
            return View(bow);
        }

        // GET: BackOffice/Bows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Bows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Bow bow)
        {
            if (ModelState.IsValid)
            {
                db.Bows.Add(bow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bow);
        }

        // GET: BackOffice/Bows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bow bow = db.Bows.Find(id);
            if (bow == null)
            {
                return HttpNotFound();
            }
            return View(bow);
        }

        // POST: BackOffice/Bows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Bow bow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bow);
        }

        // GET: BackOffice/Bows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bow bow = db.Bows.Find(id);
            if (bow == null)
            {
                return HttpNotFound();
            }
            return View(bow);
        }

        // POST: BackOffice/Bows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bow bow = db.Bows.Find(id);
            db.Bows.Remove(bow);
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
    }
}