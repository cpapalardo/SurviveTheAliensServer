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
    public class CapituloesController : ApiController
    {
        private SurviveAliensContext db = new SurviveAliensContext();

        // GET: api/Capituloes
        public IQueryable<Capitulo> GetCapituloes()
        {
            return db.Capituloes;
        }

        // GET: api/Capituloes/5
        [ResponseType(typeof(Capitulo))]
        public async Task<IHttpActionResult> GetCapitulo(int id)
        {
            Capitulo capitulo = await db.Capituloes.FindAsync(id);
            if (capitulo == null)
            {
                return NotFound();
            }

            return Ok(capitulo);
        }

        // PUT: api/Capituloes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCapitulo(int id, Capitulo capitulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != capitulo.Id)
            {
                return BadRequest();
            }

            db.Entry(capitulo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapituloExists(id))
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

        // POST: api/Capituloes
        [ResponseType(typeof(Capitulo))]
        public async Task<IHttpActionResult> PostCapitulo(Capitulo capitulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Capituloes.Add(capitulo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = capitulo.Id }, capitulo);
        }

        // DELETE: api/Capituloes/5
        [ResponseType(typeof(Capitulo))]
        public async Task<IHttpActionResult> DeleteCapitulo(int id)
        {
            Capitulo capitulo = await db.Capituloes.FindAsync(id);
            if (capitulo == null)
            {
                return NotFound();
            }

            db.Capituloes.Remove(capitulo);
            await db.SaveChangesAsync();

            return Ok(capitulo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CapituloExists(int id)
        {
            return db.Capituloes.Count(e => e.Id == id) > 0;
        }
    }
}