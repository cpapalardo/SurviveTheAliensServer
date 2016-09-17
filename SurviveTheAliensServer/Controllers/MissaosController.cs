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
    public class MissaosController : ApiController
    {
        private SurviveAliensContext db = new SurviveAliensContext();

        // GET: api/Missaos
        public IQueryable<Missao> GetMissaos()
        {
            return db.Missaos;
        }

        // GET: api/Missaos/5
        [ResponseType(typeof(Missao))]
        public async Task<IHttpActionResult> GetMissao(int id)
        {
            Missao missao = await db.Missaos.FindAsync(id);
            if (missao == null)
            {
                return NotFound();
            }

            return Ok(missao);
        }

        // PUT: api/Missaos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMissao(int id, Missao missao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != missao.Id)
            {
                return BadRequest();
            }

            db.Entry(missao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissaoExists(id))
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

        // POST: api/Missaos
        [ResponseType(typeof(Missao))]
        public async Task<IHttpActionResult> PostMissao(Missao missao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Missaos.Add(missao);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = missao.Id }, missao);
        }

        // DELETE: api/Missaos/5
        [ResponseType(typeof(Missao))]
        public async Task<IHttpActionResult> DeleteMissao(int id)
        {
            Missao missao = await db.Missaos.FindAsync(id);
            if (missao == null)
            {
                return NotFound();
            }

            db.Missaos.Remove(missao);
            await db.SaveChangesAsync();

            return Ok(missao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MissaoExists(int id)
        {
            return db.Missaos.Count(e => e.Id == id) > 0;
        }
    }
}