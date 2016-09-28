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
    public class TilbudsController : ApiController
    {
        private XpDataModel db = new XpDataModel();

        // GET: api/Tilbuds
        public IQueryable<Tilbud> GetTilbud()
        {
            return db.Tilbud;
        }

        // GET: api/Tilbuds/5
        [ResponseType(typeof(Tilbud))]
        public IHttpActionResult GetTilbud(int id)
        {
            Tilbud tilbud = db.Tilbud.Find(id);
            if (tilbud == null)
            {
                return NotFound();
            }

            return Ok(tilbud);
        }

        // PUT: api/Tilbuds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTilbud(int id, Tilbud tilbud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tilbud.Tilbud_ID)
            {
                return BadRequest();
            }

            db.Entry(tilbud).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TilbudExists(id))
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

        // POST: api/Tilbuds
        [ResponseType(typeof(Tilbud))]
        public IHttpActionResult PostTilbud(Tilbud tilbud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tilbud.Add(tilbud);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TilbudExists(tilbud.Tilbud_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tilbud.Tilbud_ID }, tilbud);
        }

        // DELETE: api/Tilbuds/5
        [ResponseType(typeof(Tilbud))]
        public IHttpActionResult DeleteTilbud(int id)
        {
            Tilbud tilbud = db.Tilbud.Find(id);
            if (tilbud == null)
            {
                return NotFound();
            }

            db.Tilbud.Remove(tilbud);
            db.SaveChanges();

            return Ok(tilbud);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TilbudExists(int id)
        {
            return db.Tilbud.Count(e => e.Tilbud_ID == id) > 0;
        }
    }
}