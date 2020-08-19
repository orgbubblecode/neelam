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
using AllMyBio;
using OBSync.Models.OBDataSources;

namespace OBSync.Controllers
{
    public class TestdomainsController : ApiController
    {
        private AllMyBioDbEntities db = new AllMyBioDbEntities();

        // GET: api/Testdomains
        public IQueryable<link> Getlinks()
        {
            return db.links;
        }

        // GET: api/Testdomains/5
        [ResponseType(typeof(link))]
        public IHttpActionResult Getlink(int id)
        {
            link link = db.links.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            return Ok(link);
        }

        // PUT: api/Testdomains/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlink(int id, link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != link.link_id)
            {
                return BadRequest();
            }

            db.Entry(link).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!linkExists(id))
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

        // POST: api/Testdomains
        [ResponseType(typeof(link))]
        public IHttpActionResult Postlink(link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.links.Add(link);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = link.link_id }, link);
        }

        // DELETE: api/Testdomains/5
        [ResponseType(typeof(link))]
        public IHttpActionResult Deletelink(int id)
        {
            link link = db.links.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            db.links.Remove(link);
            db.SaveChanges();

            return Ok(link);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool linkExists(int id)
        {
            return db.links.Count(e => e.link_id == id) > 0;
        }
    }
}