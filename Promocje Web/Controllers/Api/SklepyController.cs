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
    public class SklepyController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext() { Configuration = { LazyLoadingEnabled = false } };

        // GET: api/Sklepy
        public IQueryable<Sklep> GetSklepy()
        {
            return db.Sklepy;
        }

        [Route("api/Sklepy/{id}/ulotki")]
        public IQueryable<Ulotka> GetUlotka(string id)
        {
            return db.Ulotki.Where(u => u.SklepId == id);
        }

        // GET: api/Sklepy/5
        [ResponseType(typeof(Sklep))]
        public IHttpActionResult GetSklep(string id)
        {
            Sklep sklep = db.Sklepy.Find(id);
            if (sklep == null)
            {
                return NotFound();
            }

            return Ok(sklep);
        }

        // PUT: api/Sklepy/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSklep(string id, Sklep sklep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sklep.Id)
            {
                return BadRequest();
            }

            db.Entry(sklep).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SklepExists(id))
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

        // POST: api/Sklepy
        [ResponseType(typeof(Sklep))]
        public IHttpActionResult PostSklep(Sklep sklep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sklepy.Add(sklep);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SklepExists(sklep.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sklep.Id }, sklep);
        }

        // DELETE: api/Sklepy/5
        [ResponseType(typeof(Sklep))]
        public IHttpActionResult DeleteSklep(string id)
        {
            Sklep sklep = db.Sklepy.Find(id);
            if (sklep == null)
            {
                return NotFound();
            }

            db.Sklepy.Remove(sklep);
            db.SaveChanges();

            return Ok(sklep);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SklepExists(string id)
        {
            return db.Sklepy.Count(e => e.Id == id) > 0;
        }
    }
}