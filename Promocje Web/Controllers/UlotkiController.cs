using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Promocje_Web.Models;
using Microsoft.AspNet.Identity;
using Promocje_Web.Services;
using System.IO;

namespace Promocje_Web.Controllers
{
    [Authorize]
    public class UlotkiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ulotki
        public ActionResult Index()
        {
            var ulotki = db.Ulotki.Include(u => u.ApplicationUser).Include(u => u.Sklep);
            return View(ulotki.ToList());
        }

        // GET: Ulotki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ulotka ulotka = db.Ulotki.Find(id);
            if (ulotka == null)
            {
                return HttpNotFound();
            }
            return View(ulotka);
        }

        // GET: Ulotki/Create
        public ActionResult Create()
        {
            ViewBag.SklepId = new SelectList(db.Sklepy, "Id", "Id");
            return View();
        }

        // POST: Ulotki/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,FileSetType,urls,Description,StartDate,EndDate,SklepId")] Ulotka ulotka)
        {
            ulotka.ApplicationUserId = User.Identity.GetUserId();
            ulotka.PublishDate = DateTime.Now;
            //ulotka.FileSetType
            ModelState.Clear();
            var urls = ulotka.urls.Split(new char[]{';'},StringSplitOptions.RemoveEmptyEntries);

            if (TryValidateModel(ulotka) && ServerTools.TempFolderContains(urls))
            {
                string destinationUrlList = string.Empty;
                foreach (var item in urls)
                {
                    //todo better naming /sklep/ulotka123
                    string sourcePath = Path.Combine(ServerTools.TempFolderPath, item);
                    string folder = ulotka.FileSetType == FileSetType.Pdf ? "Data/Pdf" : "Data/Images";
                    string destinationPath = Path.Combine(ServerTools.MediaFolderPath(folder), item);
                    System.IO.File.Move(sourcePath, destinationPath);
                    destinationUrlList += ServerTools.RelativePath(destinationPath) +";";
                }
                ulotka.urls = destinationUrlList;

                db.Ulotki.Add(ulotka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.SklepId = new SelectList(db.Sklepy, "Id", "Id", ulotka.SklepId);
            return View(ulotka);
        }

        // GET: Ulotki/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ulotka ulotka = db.Ulotki.Find(id);
            if (ulotka == null)
            {
                return HttpNotFound();
            }
            ViewBag.SklepId = new SelectList(db.Sklepy, "Id", "Id", ulotka.SklepId);
            return View(ulotka);
        }

        // POST: Ulotki/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplicationUserId,Title,Description,FileSetType,StartDate,EndDate,PublishDate,SklepId")] Ulotka ulotka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ulotka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SklepId = new SelectList(db.Sklepy, "Id", "Id", ulotka.SklepId);
            return View(ulotka);
        }

        // GET: Ulotki/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ulotka ulotka = db.Ulotki.Find(id);
            if (ulotka == null)
            {
                return HttpNotFound();
            }
            return View(ulotka);
        }

        // POST: Ulotki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ulotka ulotka = db.Ulotki.Find(id);
            db.Ulotki.Remove(ulotka);
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
