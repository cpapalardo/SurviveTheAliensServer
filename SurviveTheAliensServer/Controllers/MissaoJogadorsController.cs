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
    public class MissaoJogadorsController : ApiController
    {
        private SurviveAliensContext db = new SurviveAliensContext();

        // GET: api/MissaoJogadors
        public IQueryable<MissaoJogador> GetMissaoJogadors()
        {
            return db.MissaoJogadors;
        }

        // GET: api/MissaoJogadors/5
        [ResponseType(typeof(MissaoJogador))]
        public async Task<IHttpActionResult> GetMissaoJogador(int id)
        {
            MissaoJogador missaoJogador = await db.MissaoJogadors.FindAsync(id);
            if (missaoJogador == null)
            {
                return NotFound();
            }

            return Ok(missaoJogador);
        }

        // PUT: api/MissaoJogadors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMissaoJogador(int id, MissaoJogador missaoJogador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != missaoJogador.id)
            {
                return BadRequest();
            }

            db.Entry(missaoJogador).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissaoJogadorExists(id))
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

        // POST: api/MissaoJogadors
        [ResponseType(typeof(MissaoJogador))]
        public async Task<IHttpActionResult> PostMissaoJogador(MissaoJogador missaoJogador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MissaoJogadors.Add(missaoJogador);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = missaoJogador.id }, missaoJogador);
        }

        // DELETE: api/MissaoJogadors/5
        [ResponseType(typeof(MissaoJogador))]
        public async Task<IHttpActionResult> DeleteMissaoJogador(int id)
        {
            MissaoJogador missaoJogador = await db.MissaoJogadors.FindAsync(id);
            if (missaoJogador == null)
            {
                return NotFound();
            }

            db.MissaoJogadors.Remove(missaoJogador);
            await db.SaveChangesAsync();

            return Ok(missaoJogador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MissaoJogadorExists(int id)
        {
            return db.MissaoJogadors.Count(e => e.id == id) > 0;
        }
    }
}