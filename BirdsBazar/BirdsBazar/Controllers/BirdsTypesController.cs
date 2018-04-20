using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BirdsBazar.Models;

namespace BirdsBazar.Controllers
{
    public class BirdsTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BirdsTypes
        public ActionResult Index()
        {
            return View(db.BirdsTypes.ToList());
        }

        // GET: BirdsTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirdsType birdsType = db.BirdsTypes.Find(id);
            if (birdsType == null)
            {
                return HttpNotFound();
            }
            return View(birdsType);
        }

        // GET: BirdsTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BirdsTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BirdsName")] BirdsType birdsType)
        {
            if (ModelState.IsValid)
            {
                db.BirdsTypes.Add(birdsType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(birdsType);
        }

        // GET: BirdsTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirdsType birdsType = db.BirdsTypes.Find(id);
            if (birdsType == null)
            {
                return HttpNotFound();
            }
            return View(birdsType);
        }

        // POST: BirdsTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BirdsName")] BirdsType birdsType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birdsType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(birdsType);
        }

        // GET: BirdsTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirdsType birdsType = db.BirdsTypes.Find(id);
            if (birdsType == null)
            {
                return HttpNotFound();
            }
            return View(birdsType);
        }

        // POST: BirdsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BirdsType birdsType = db.BirdsTypes.Find(id);
            db.BirdsTypes.Remove(birdsType);
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
