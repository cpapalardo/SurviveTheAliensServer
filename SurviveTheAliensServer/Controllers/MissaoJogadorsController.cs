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
using System.Data.SqlClient;

namespace SurviveTheAliensServer.Controllers
{
    public class MissaoJogadorsController : ApiController
    {
        private SurviveAliensContext db = new SurviveAliensContext();

        // GET: api/MissaoJogadors
        public IEnumerable<MissaoJogador> GetMissaoJogadors()
        {
			using (SqlConnection conn = Sql.Open())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT Id, Id_Missao, Id_Jogador, Liberada FROM MissaoJogador", conn))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{

						List<MissaoJogador> missaoJogadorList = new List<MissaoJogador>();
						//Obtém os registros, um por vez
						while (reader.Read() == true)
						{
							int id = reader.GetInt32(0);
							int id_missao = reader.GetInt32(1);
							int id_jogador = reader.GetInt32(2);
							bool liberada = reader.GetBoolean(3);

							missaoJogadorList.Add(new MissaoJogador(id, id_missao, id_jogador, liberada));
						}
						return missaoJogadorList;
					}
				}
			}
		}

        // GET: api/MissaoJogadors/5
        [ResponseType(typeof(MissaoJogador))]
        public IEnumerable<MissaoJogador> GetMissaoJogador(int id)
        {
			using (SqlConnection conn = Sql.Open())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT Id, Id_Missao, Id_Jogador, Liberada FROM MissaoJogador WHERE Id_Jogador = @Id_jogador", conn))
				{
					cmd.Parameters.AddWithValue("@Id_Jogador", id);
					using (SqlDataReader reader = cmd.ExecuteReader())
					{

						List<MissaoJogador> missaoJogadorList = new List<MissaoJogador>();
						//Obtém os registros, um por vez
						while (reader.Read() == true)
						{
							int idMissaoJogador = reader.GetInt32(0);
							int id_missao = reader.GetInt32(1);
							int id_jogador = reader.GetInt32(2);
							bool liberada = reader.GetBoolean(3);

							missaoJogadorList.Add(new MissaoJogador(idMissaoJogador, id_missao, id_jogador, liberada));
						}
						return missaoJogadorList;
					}
				}
			}
			//return db.MissaoJogadors.Where(x => x.Id_Jogador == id);
        }

		// PUT: api/MissaoJogadors/5
		[ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMissaoJogador(int id, MissaoJogador missaoJogador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != missaoJogador.Id)
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

            return CreatedAtRoute("DefaultApi", new { id = missaoJogador.Id }, missaoJogador);
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
            return db.MissaoJogadors.Count(e => e.Id == id) > 0;
        }
    }
}