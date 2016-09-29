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
    public class TilbudKampagnesController : ApiController
    {
        private XpTilbud2 db = new XpTilbud2();

        // GET: api/TilbudKampagnes
        public IQueryable<TilbudKampagne> GetTilbudKampagne()
        {
            return db.TilbudKampagne;
        }

        // GET: api/TilbudKampagnes/5
        [ResponseType(typeof(TilbudKampagne))]
        public IHttpActionResult GetTilbudKampagne(int id)
        {
            TilbudKampagne tilbudKampagne = db.TilbudKampagne.Find(id);
            if (tilbudKampagne == null)
            {
                return NotFound();
            }

            return Ok(tilbudKampagne);
        }

        // PUT: api/TilbudKampagnes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTilbudKampagne(int id, TilbudKampagne tilbudKampagne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tilbudKampagne.TK_ID)
            {
                return BadRequest();
            }

            db.Entry(tilbudKampagne).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TilbudKampagneExists(id))
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

        // POST: api/TilbudKampagnes
        [ResponseType(typeof(TilbudKampagne))]
        public IHttpActionResult PostTilbudKampagne(TilbudKampagne tilbudKampagne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TilbudKampagne.Add(tilbudKampagne);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tilbudKampagne.TK_ID }, tilbudKampagne);
        }

        // DELETE: api/TilbudKampagnes/5
        [ResponseType(typeof(TilbudKampagne))]
        public IHttpActionResult DeleteTilbudKampagne(int id)
        {
            TilbudKampagne tilbudKampagne = db.TilbudKampagne.Find(id);
            if (tilbudKampagne == null)
            {
                return NotFound();
            }

            db.TilbudKampagne.Remove(tilbudKampagne);
            db.SaveChanges();

            return Ok(tilbudKampagne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TilbudKampagneExists(int id)
        {
            return db.TilbudKampagne.Count(e => e.TK_ID == id) > 0;
        }
    }
}