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
    public class KampagnesController : ApiController
    {
        private XpTilbud2 db = new XpTilbud2();

        // GET: api/Kampagnes
        public IQueryable<Kampagne> GetKampagne()
        {
            return db.Kampagne;
        }

        // GET: api/Kampagnes/5
        [ResponseType(typeof(Kampagne))]
        public IHttpActionResult GetKampagne(int id)
        {
            Kampagne kampagne = db.Kampagne.Find(id);
            if (kampagne == null)
            {
                return NotFound();
            }

            return Ok(kampagne);
        }

        // PUT: api/Kampagnes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKampagne(int id, Kampagne kampagne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kampagne.Kampagne_ID)
            {
                return BadRequest();
            }

            db.Entry(kampagne).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KampagneExists(id))
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

        // POST: api/Kampagnes
        [ResponseType(typeof(Kampagne))]
        public IHttpActionResult PostKampagne(Kampagne kampagne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kampagne.Add(kampagne);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kampagne.Kampagne_ID }, kampagne);
        }

        // DELETE: api/Kampagnes/5
        [ResponseType(typeof(Kampagne))]
        public IHttpActionResult DeleteKampagne(int id)
        {
            Kampagne kampagne = db.Kampagne.Find(id);
            if (kampagne == null)
            {
                return NotFound();
            }

            db.Kampagne.Remove(kampagne);
            db.SaveChanges();

            return Ok(kampagne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KampagneExists(int id)
        {
            return db.Kampagne.Count(e => e.Kampagne_ID == id) > 0;
        }
    }
}