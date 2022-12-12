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
    public class ActorsController : ApiController
    {
        private AsiaDrama_TrifonovaEntities db = new AsiaDrama_TrifonovaEntities();

        // GET: api/Actors
        public IQueryable<Actor> GetActor()
        {
            return db.Actor;
        }

        // GET: api/Actors/5
        [ResponseType(typeof(Actor))]
        public IHttpActionResult GetActor(int id)
        {
            Actor actor = db.Actor.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        // PUT: api/Actors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActor(int id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actor.IdActor)
            {
                return BadRequest();
            }

            db.Entry(actor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
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

        // POST: api/Actors
        [ResponseType(typeof(Actor))]
        public IHttpActionResult PostActor(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Actor.Add(actor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = actor.IdActor }, actor);
        }

        // DELETE: api/Actors/5
        [ResponseType(typeof(Actor))]
        public IHttpActionResult DeleteActor(int id)
        {
            Actor actor = db.Actor.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            db.Actor.Remove(actor);
            db.SaveChanges();

            return Ok(actor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActorExists(int id)
        {
            return db.Actor.Count(e => e.IdActor == id) > 0;
        }
    }
}