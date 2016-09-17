using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SurviveTheAliensServer.Models;

namespace SurviveTheAliensServer.Controllers
{
    public class RecursoesController : ApiController
    {
        private SurviveAliensContext db = new SurviveAliensContext();

        // GET: api/Recursoes
        public IQueryable<Recurso> GetRecursoes()
        {
            return db.Recursoes;
        }

        // GET: api/Recursoes/5
        [ResponseType(typeof(Recurso))]
        public async Task<IHttpActionResult> GetRecurso(int id)
        {
            Recurso recurso = await db.Recursoes.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }

            return Ok(recurso);
        }

        // PUT: api/Recursoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecurso(int id, Recurso recurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recurso.Id)
            {
                return BadRequest();
            }

            db.Entry(recurso).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(id))
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

        // POST: api/Recursoes
        [ResponseType(typeof(Recurso))]
        public async Task<IHttpActionResult> PostRecurso(Recurso recurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recursoes.Add(recurso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = recurso.Id }, recurso);
        }

        // DELETE: api/Recursoes/5
        [ResponseType(typeof(Recurso))]
        public async Task<IHttpActionResult> DeleteRecurso(int id)
        {
            Recurso recurso = await db.Recursoes.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }

            db.Recursoes.Remove(recurso);
            await db.SaveChangesAsync();

            return Ok(recurso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecursoExists(int id)
        {
            return db.Recursoes.Count(e => e.Id == id) > 0;
        }
    }
}