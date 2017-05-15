using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpeedReading_5x5.Models;

namespace SpeedReading_5x5.Controllers
{
    public class ResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Results
        public ActionResult Index()
        {
            var results = db.Results.Include(r => r.ApplicationUser).Include(r => r.Books);
            return View(results.ToList());
        }

        // GET: Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.Results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Role");
            ViewBag.BooksId = new SelectList(db.Books, "Id", "Title");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WordNumber,ApplicationUserId,BooksId")] Results results)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Role", results.ApplicationUserId);
            ViewBag.BooksId = new SelectList(db.Books, "Id", "Title", results.BooksId);
            return View(results);
        }

        // GET: Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.Results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Role", results.ApplicationUserId);
            ViewBag.BooksId = new SelectList(db.Books, "Id", "Title", results.BooksId);
            return View(results);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WordNumber,ApplicationUserId,BooksId")] Results results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Role", results.ApplicationUserId);
            ViewBag.BooksId = new SelectList(db.Books, "Id", "Title", results.BooksId);
            return View(results);
        }

        // GET: Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.Results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Results results = db.Results.Find(id);
            db.Results.Remove(results);
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
