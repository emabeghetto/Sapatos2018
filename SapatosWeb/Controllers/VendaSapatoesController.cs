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
using BibliotecaModelos;
using SapatosWeb.Models;
using System.Web.Routing;

namespace SapatosWeb.Controllers
{
    public class VendaSapatoesController : ApiController
    {
        private ContextoBanco db = new ContextoBanco();

        // GET: api/VendaSapatoes
        public IQueryable<VendaSapato> GetVendaSapatoes()
        {
            return db.VendaSapatoes;
        }

        // GET: api/VendaSapatoes/5
        [ResponseType(typeof(VendaSapato))]
        public IHttpActionResult GetVendaSapato(int id)
        {
            VendaSapato vendaSapato = db.VendaSapatoes.Find(id);
            if (vendaSapato == null)
            {
                return NotFound();
            }

            return Ok(vendaSapato);
        }

        // PUT: api/VendaSapatoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendaSapato(int id, VendaSapato vendaSapato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendaSapato.Id)
            {
                return BadRequest();
            }

            db.Entry(vendaSapato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaSapatoExists(id))
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

        // POST: api/VendaSapatoes
        [ResponseType(typeof(VendaSapato))]
        public IHttpActionResult PostVendaSapato(VendaSapato vendaSapato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VendaSapatoes.Add(vendaSapato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vendaSapato.Id }, vendaSapato);
        }

        // DELETE: api/VendaSapatoes/5
        [ResponseType(typeof(VendaSapato))]
        public IHttpActionResult DeleteVendaSapato(int id)
        {
            VendaSapato vendaSapato = db.VendaSapatoes.Find(id);
            if (vendaSapato == null)
            {
                return NotFound();
            }

            db.VendaSapatoes.Remove(vendaSapato);
            db.SaveChanges();

            return Ok(vendaSapato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendaSapatoExists(int id)
        {
            return db.VendaSapatoes.Count(e => e.Id == id) > 0;
        }
    }
}