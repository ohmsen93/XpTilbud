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
using XpTilbud;

namespace XpTilbud.Controllers
{
    public class KaedesController : ApiController
    {
        private XpDataModel db = new XpDataModel();

        // GET: api/Kaedes
        public IQueryable<Kaede> GetKaede()
        {
            return db.Kaede;
        }

        // GET: api/Kaedes/5
        [ResponseType(typeof(Kaede))]
        public IHttpActionResult GetKaede(int id)
        {
            Kaede kaede = db.Kaede.Find(id);
            if (kaede == null)
            {
                return NotFound();
            }

            return Ok(kaede);
        }

        // PUT: api/Kaedes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKaede(int id, Kaede kaede)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kaede.Kaede_ID)
            {
                return BadRequest();
            }

            db.Entry(kaede).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KaedeExists(id))
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

        // POST: api/Kaedes
        [ResponseType(typeof(Kaede))]
        public IHttpActionResult PostKaede(Kaede kaede)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kaede.Add(kaede);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KaedeExists(kaede.Kaede_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kaede.Kaede_ID }, kaede);
        }

        // DELETE: api/Kaedes/5
        [ResponseType(typeof(Kaede))]
        public IHttpActionResult DeleteKaede(int id)
        {
            Kaede kaede = db.Kaede.Find(id);
            if (kaede == null)
            {
                return NotFound();
            }

            db.Kaede.Remove(kaede);
            db.SaveChanges();

            return Ok(kaede);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KaedeExists(int id)
        {
            return db.Kaede.Count(e => e.Kaede_ID == id) > 0;
        }
    }
}