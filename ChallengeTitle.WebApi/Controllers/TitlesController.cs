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
using ChallengeTitle.WebApi.Models;
using System.Web.Http.Cors;

namespace ChallengeTitle.WebApi.Controllers
{
    [EnableCors("http://localhost:51334", "*", "*")]
    public class TitlesController : ApiController
    {
        private TitleContext db = new TitleContext();

        // GET: api/Titles
        public IQueryable<Title> GetTitles()
        {
            return db.Titles;
        }

        public IQueryable<Title> GetTitles(string search)
        {
            return db.Titles.Where(s => s.TitleName.Contains(search));
        }

        // GET: api/Titles/5
        [ResponseType(typeof(Title))]
        public IHttpActionResult GetTitle(int id)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        // PUT: api/Titles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTitle(int id, Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != title.TitleId)
            {
                return BadRequest();
            }

            db.Entry(title).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
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

        // POST: api/Titles
        [ResponseType(typeof(Title))]
        public IHttpActionResult PostTitle(Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Titles.Add(title);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TitleExists(title.TitleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = title.TitleId }, title);
        }

        // DELETE: api/Titles/5
        [ResponseType(typeof(Title))]
        public IHttpActionResult DeleteTitle(int id)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return NotFound();
            }

            db.Titles.Remove(title);
            db.SaveChanges();

            return Ok(title);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TitleExists(int id)
        {
            return db.Titles.Count(e => e.TitleId == id) > 0;
        }
    }
}