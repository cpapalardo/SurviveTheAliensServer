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
using System.Text.RegularExpressions;

namespace SurviveTheAliensServer.Controllers
{
    public class JogadorsController : ApiController
    {
        private SurviveAliensContext db = new SurviveAliensContext();

        // GET: api/Jogadors
        public IQueryable<Jogador> GetJogadors()
        {
            return db.Jogadors;
        }

        // GET: api/Jogadors/5
        [ResponseType(typeof(Jogador))]
        public async Task<IHttpActionResult> GetJogador(int id)
        {
            Jogador jogador = await db.Jogadors.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);
        }

        // PUT: api/Jogadors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJogador(int id, Jogador jogador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jogador.Id)
            {
                return BadRequest();
            }

            db.Entry(jogador).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return StatusCode(HttpStatusCode.NoContent);
            return Ok(jogador);
        }

        // POST: api/Jogadors
        [ResponseType(typeof(Jogador))]
        public async Task<IHttpActionResult> PostJogador(Jogador jogador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jogadors.Add(jogador);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = jogador.Id }, jogador);
        }

        // DELETE: api/Jogadors/5
        [ResponseType(typeof(Jogador))]
        public async Task<IHttpActionResult> DeleteJogador(int id)
        {
            Jogador jogador = await db.Jogadors.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }

            db.Jogadors.Remove(jogador);
            await db.SaveChangesAsync();

            return Ok(jogador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JogadorExists(int id)
        {
            return db.Jogadors.Count(e => e.Id == id) > 0;
        }

        [Route("api/Jogadors/{email}/{senha}")]
        [ResponseType(typeof(Jogador))]
        private Jogador AutenticarJogador(string email, string senha)
        {
            //string separators = "----";
            //string[] tokens = Regex.Split(emailsenha, separators);
            //return context.Jogadors.First(x => x.Email == tokens[0] && x.Senha == tokens[1]);
            return db.Jogadors.First(x => x.Email == email && x.Senha == senha);
        }

		[ResponseType(typeof(Jogador))]
		public async Task<IHttpActionResult> Autenticar(string login, string senha)
		{
			Jogador jogador = null; // código de consulta por login e senha

			if (jogador == null)
			{
				return NotFound();
			}

			return Ok(jogador);
		}

		[ResponseType(typeof(Jogador))]
		public async Task<IHttpActionResult> GetJogador(int id)
		{
			Jogador jogador = await db.Jogadors.FindAsync(id);
			if (jogador == null)
			{
				return NotFound();
			}

			return Ok(jogador);
		}
	}
}