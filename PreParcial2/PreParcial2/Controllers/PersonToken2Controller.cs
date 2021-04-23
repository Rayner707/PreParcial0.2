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
using PreParcial2.Models;

namespace PreParcial2.Controllers
{
    public class PersonToken2Controller : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PersonToken2
        [Authorize]
        public IQueryable<PersonToken2> GetPersonToken2()
        {
            return db.PersonToken2;
        }

        // GET: api/PersonToken2/5
        [Authorize]
        [ResponseType(typeof(PersonToken2))]
        public IHttpActionResult GetPersonToken2(int id)
        {
            PersonToken2 personToken2 = db.PersonToken2.Find(id);
            if (personToken2 == null)
            {
                return NotFound();
            }

            return Ok(personToken2);
        }

        // PUT: api/PersonToken2/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonToken2(int id, PersonToken2 personToken2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personToken2.PersonId)
            {
                return BadRequest();
            }

            db.Entry(personToken2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonToken2Exists(id))
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

        // POST: api/PersonToken2
        [Authorize]
        [ResponseType(typeof(PersonToken2))]
        public IHttpActionResult PostPersonToken2(PersonToken2 personToken2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonToken2.Add(personToken2);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personToken2.PersonId }, personToken2);
        }

        // DELETE: api/PersonToken2/5
        [Authorize]
        [ResponseType(typeof(PersonToken2))]
        public IHttpActionResult DeletePersonToken2(int id)
        {
            PersonToken2 personToken2 = db.PersonToken2.Find(id);
            if (personToken2 == null)
            {
                return NotFound();
            }

            db.PersonToken2.Remove(personToken2);
            db.SaveChanges();

            return Ok(personToken2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonToken2Exists(int id)
        {
            return db.PersonToken2.Count(e => e.PersonId == id) > 0;
        }
    }
}