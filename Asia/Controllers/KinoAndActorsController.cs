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
    public class KinoAndActorsController : ApiController
    {
        private AsiaDrama_TrifonovaEntities db = new AsiaDrama_TrifonovaEntities();

        // GET: api/KinoAndActors
        public IQueryable<KinoAndActor> GetKinoAndActor()
        {
            return db.KinoAndActor;
        }

        // GET: api/KinoAndActors/5
        [ResponseType(typeof(KinoAndActor))]
        public IHttpActionResult GetKinoAndActor(int id)
        {
            KinoAndActor kinoAndActor = db.KinoAndActor.Find(id);
            if (kinoAndActor == null)
            {
                return NotFound();
            }

            return Ok(kinoAndActor);
        }

        // PUT: api/KinoAndActors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKinoAndActor(int id, KinoAndActor kinoAndActor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kinoAndActor.IdKinoAndActor)
            {
                return BadRequest();
            }

            db.Entry(kinoAndActor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KinoAndActorExists(id))
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

        // POST: api/KinoAndActors
        [ResponseType(typeof(KinoAndActor))]
        public IHttpActionResult PostKinoAndActor(KinoAndActor kinoAndActor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KinoAndActor.Add(kinoAndActor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kinoAndActor.IdKinoAndActor }, kinoAndActor);
        }

        // DELETE: api/KinoAndActors/5
        [ResponseType(typeof(KinoAndActor))]
        public IHttpActionResult DeleteKinoAndActor(int id)
        {
            KinoAndActor kinoAndActor = db.KinoAndActor.Find(id);
            if (kinoAndActor == null)
            {
                return NotFound();
            }

            db.KinoAndActor.Remove(kinoAndActor);
            db.SaveChanges();

            return Ok(kinoAndActor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KinoAndActorExists(int id)
        {
            return db.KinoAndActor.Count(e => e.IdKinoAndActor == id) > 0;
        }
    }
}