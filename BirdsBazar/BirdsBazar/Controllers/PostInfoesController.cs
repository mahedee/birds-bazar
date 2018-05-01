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
    public class PostInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PostInfoes
        public ActionResult Index()
        {
            return View(db.PostInfoes.ToList());
        }

        // GET: PostInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostInfo postInfo = db.PostInfoes.Find(id);
            if (postInfo == null)
            {
                return HttpNotFound();
            }
            return View(postInfo);
        }

        // GET: PostInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Details")] PostInfo postInfo)
        {
            if (ModelState.IsValid)
            {
                db.PostInfoes.Add(postInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postInfo);
        }

        // GET: PostInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostInfo postInfo = db.PostInfoes.Find(id);
            if (postInfo == null)
            {
                return HttpNotFound();
            }
            return View(postInfo);
        }

        // POST: PostInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Details")] PostInfo postInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postInfo);
        }

        // GET: PostInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostInfo postInfo = db.PostInfoes.Find(id);
            if (postInfo == null)
            {
                return HttpNotFound();
            }
            return View(postInfo);
        }

        // POST: PostInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostInfo postInfo = db.PostInfoes.Find(id);
            db.PostInfoes.Remove(postInfo);
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
