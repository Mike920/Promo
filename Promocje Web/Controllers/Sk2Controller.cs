using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Promocje_Web.Models;

namespace Promocje_Web.Controllers
{
    public class Sk2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sk2
        public ActionResult Index()
        {
            return View(db.Sklepy.ToList());
        }

        // GET: Sk2/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep sklep = db.Sklepy.Find(id);
            if (sklep == null)
            {
                return HttpNotFound();
            }
            return View(sklep);
        }

        // GET: Sk2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sk2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LogoUrl,KategoriaId")] Sklep sklep)
        {
            if (ModelState.IsValid)
            {
                db.Sklepy.Add(sklep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sklep);
        }

        // GET: Sk2/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep sklep = db.Sklepy.Find(id);
            if (sklep == null)
            {
                return HttpNotFound();
            }
            return View(sklep);
        }

        // POST: Sk2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LogoUrl,KategoriaId")] Sklep sklep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sklep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sklep);
        }

        // GET: Sk2/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep sklep = db.Sklepy.Find(id);
            if (sklep == null)
            {
                return HttpNotFound();
            }
            return View(sklep);
        }

        // POST: Sk2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sklep sklep = db.Sklepy.Find(id);
            db.Sklepy.Remove(sklep);
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
