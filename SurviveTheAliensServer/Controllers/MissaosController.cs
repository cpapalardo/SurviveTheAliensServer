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
    public class MissaosController : ApiController
    {
        private SurviveAliensContext db = new SurviveAliensContext();

        // GET: api/Missaos
        public IEnumerable<Missao> GetMissaos()
        {
			using (SqlConnection conn = Sql.Open())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Id_Capitulo, KmDeMissao, Numero, KmIntro, KmApice, KmFim FROM Missao", conn))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						List<Missao> missaoList = new List<Missao>();
						//Obtém os registros, um por vez
						while (reader.Read() == true)
						{
							int id = reader.GetInt32(0);
							string nome = reader.GetString(1);
							int idCapitulo = reader.GetInt32(2);
							float kmDeMissao = reader.GetFloat(3);
							int numero = reader.GetInt32(4);
							float KmIntro = reader.GetFloat(5);
							float KmApice = reader.GetFloat(6);
							float KmFim = reader.GetFloat(7);


							missaoList.Add(new Missao(id, nome, idCapitulo, kmDeMissao, numero, KmIntro, KmApice, KmFim));
						}
						return missaoList;
					}
				}
			}
		}

        // GET: api/Missaos/5
        [ResponseType(typeof(Missao))]
        public async Task<IHttpActionResult> GetMissao(int id)
        {
			using (SqlConnection conn = Sql.Open())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Id_Capitulo, KmDeMissao, Numero, KmIntro, KmApice, KmFim FROM Missao WHERE Id = @Id", conn))
				{
					cmd.Parameters.AddWithValue("@id", id);
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						Missao missao = new Missao();
						//Obtém os registros, um por vez
						while (reader.Read() == true)
						{
							int idMissao = reader.GetInt32(0);
							string nome = reader.GetString(1);
							int idCapitulo = reader.GetInt32(2);
							float kmDeMissao = reader.GetFloat(3);
							int numero = reader.GetInt32(4);
							float KmIntro = reader.GetFloat(5);
							float KmApice = reader.GetFloat(6);
							float KmFim = reader.GetFloat(7);

							missao = new Missao(id, nome, idCapitulo, kmDeMissao, numero, KmIntro, KmApice, KmFim);
						}
						if(missao.Id <= 0)
							return NotFound();
						return Ok(missao);
					}
				}
			}
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