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
    public class HistoriasController : ApiController
    {
        private SurviveAliensContext db = new SurviveAliensContext();

        // GET: api/Historias
        public IQueryable<Historia> GetHistorias()
        {
            return db.Historias;
        }

        // GET: api/Historias/5
        [ResponseType(typeof(Historia))]
        public async Task<IHttpActionResult> GetHistoria(int id)
        {
            Historia historia = await db.Historias.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }

            return Ok(historia);
        }

        // PUT: api/Historias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHistoria(int id, Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historia.id)
            {
                return BadRequest();
            }

            db.Entry(historia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaExists(id))
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

        // POST: api/Historias
        [ResponseType(typeof(Historia))]
        public async Task<IHttpActionResult> PostHistoria(Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Historias.Add(historia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = historia.id }, historia);
        }

        // DELETE: api/Historias/5
        [ResponseType(typeof(Historia))]
        public async Task<IHttpActionResult> DeleteHistoria(int id)
        {
            Historia historia = await db.Historias.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }

            db.Historias.Remove(historia);
            await db.SaveChangesAsync();

            return Ok(historia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoriaExists(int id)
        {
            return db.Historias.Count(e => e.id == id) > 0;
        }
    }
}