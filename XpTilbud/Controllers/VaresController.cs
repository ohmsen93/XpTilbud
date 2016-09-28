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
    public class VaresController : ApiController
    {
        private XpDataModel db = new XpDataModel();

        // GET: api/Vares
        public IQueryable<Vare> GetVare()
        {
            return db.Vare;
        }

        // GET: api/Vares/5
        [ResponseType(typeof(Vare))]
        public IHttpActionResult GetVare(int id)
        {
            Vare vare = db.Vare.Find(id);
            if (vare == null)
            {
                return NotFound();
            }

            return Ok(vare);
        }

        // PUT: api/Vares/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVare(int id, Vare vare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vare.Vare_ID)
            {
                return BadRequest();
            }

            db.Entry(vare).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VareExists(id))
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

        // POST: api/Vares
        [ResponseType(typeof(Vare))]
        public IHttpActionResult PostVare(Vare vare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vare.Add(vare);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VareExists(vare.Vare_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vare.Vare_ID }, vare);
        }

        // DELETE: api/Vares/5
        [ResponseType(typeof(Vare))]
        public IHttpActionResult DeleteVare(int id)
        {
            Vare vare = db.Vare.Find(id);
            if (vare == null)
            {
                return NotFound();
            }

            db.Vare.Remove(vare);
            db.SaveChanges();

            return Ok(vare);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VareExists(int id)
        {
            return db.Vare.Count(e => e.Vare_ID == id) > 0;
        }
    }
}