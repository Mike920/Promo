using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Promocje_Web.Models;

namespace Promocje_Web.Controllers.Api
{
    public class UlotkiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext() { Configuration = {LazyLoadingEnabled = false } };
        // GET: api/Ulotki
        public IQueryable<Ulotka> GetUlotki()
        {
            return db.Ulotki;
        }
       

        // GET: api/Ulotki/5
        [ResponseType(typeof(Ulotka))]
        public IHttpActionResult GetUlotka(int id)
        {
            Ulotka ulotka = db.Ulotki.Find(id);
            if (ulotka == null)
            {
                return NotFound();
            }

            return Ok(ulotka);
        }

        // PUT: api/Ulotki/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUlotka(int id, Ulotka ulotka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ulotka.Id)
            {
                return BadRequest();
            }

            db.Entry(ulotka).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UlotkaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ulotki
        [ResponseType(typeof(Ulotka))]
        public IHttpActionResult PostUlotka(Ulotka ulotka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ulotki.Add(ulotka);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ulotka.Id }, ulotka);
        }

        // DELETE: api/Ulotki/5
        [ResponseType(typeof(Ulotka))]
        public IHttpActionResult DeleteUlotka(int id)
        {
            Ulotka ulotka = db.Ulotki.Find(id);
            if (ulotka == null)
            {
                return NotFound();
            }

            db.Ulotki.Remove(ulotka);
            db.SaveChanges();

            return Ok(ulotka);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UlotkaExists(int id)
        {
            return db.Ulotki.Count(e => e.Id == id) > 0;
        }
    }
}