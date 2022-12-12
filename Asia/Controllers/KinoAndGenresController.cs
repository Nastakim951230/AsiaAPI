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
using Asia.Models;

namespace Asia.Controllers
{
    public class KinoAndGenresController : ApiController
    {
        private AsiaDrama_TrifonovaEntities db = new AsiaDrama_TrifonovaEntities();

        // GET: api/KinoAndGenres
        public IQueryable<KinoAndGenre> GetKinoAndGenre()
        {
            return db.KinoAndGenre;
        }

        // GET: api/KinoAndGenres/5
        [ResponseType(typeof(KinoAndGenre))]
        public IHttpActionResult GetKinoAndGenre(int id)
        {
            KinoAndGenre kinoAndGenre = db.KinoAndGenre.Find(id);
            if (kinoAndGenre == null)
            {
                return NotFound();
            }

            return Ok(kinoAndGenre);
        }

        // PUT: api/KinoAndGenres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKinoAndGenre(int id, KinoAndGenre kinoAndGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kinoAndGenre.IdKinoAndGenre)
            {
                return BadRequest();
            }

            db.Entry(kinoAndGenre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KinoAndGenreExists(id))
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

        // POST: api/KinoAndGenres
        [ResponseType(typeof(KinoAndGenre))]
        public IHttpActionResult PostKinoAndGenre(KinoAndGenre kinoAndGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KinoAndGenre.Add(kinoAndGenre);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kinoAndGenre.IdKinoAndGenre }, kinoAndGenre);
        }

        // DELETE: api/KinoAndGenres/5
        [ResponseType(typeof(KinoAndGenre))]
        public IHttpActionResult DeleteKinoAndGenre(int id)
        {
            KinoAndGenre kinoAndGenre = db.KinoAndGenre.Find(id);
            if (kinoAndGenre == null)
            {
                return NotFound();
            }

            db.KinoAndGenre.Remove(kinoAndGenre);
            db.SaveChanges();

            return Ok(kinoAndGenre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KinoAndGenreExists(int id)
        {
            return db.KinoAndGenre.Count(e => e.IdKinoAndGenre == id) > 0;
        }
    }
}