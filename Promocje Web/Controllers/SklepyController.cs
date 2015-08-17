﻿using System;
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
    public class SklepyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sklepy
        public ActionResult Index()
        {
            return View(db.Skleps.ToList());
        }

        // GET: Sklepy/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep sklep = db.Skleps.Find(id);
            if (sklep == null)
            {
                return HttpNotFound();
            }
            return View(sklep);
        }

        // GET: Sklepy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sklepy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LogoUrl")] Sklep sklep)
        {
            if (ModelState.IsValid)
            {
                db.Skleps.Add(sklep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sklep);
        }

        // GET: Sklepy/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep sklep = db.Skleps.Find(id);
            if (sklep == null)
            {
                return HttpNotFound();
            }
            return View(sklep);
        }

        // POST: Sklepy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LogoUrl")] Sklep sklep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sklep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sklep);
        }

        // GET: Sklepy/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sklep sklep = db.Skleps.Find(id);
            if (sklep == null)
            {
                return HttpNotFound();
            }
            return View(sklep);
        }

        // POST: Sklepy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sklep sklep = db.Skleps.Find(id);
            db.Skleps.Remove(sklep);
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
