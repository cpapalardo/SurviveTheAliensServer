using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SurviveTheAliensServer.Models;
using System.Data.SqlClient;

namespace SurviveTheAliensServer.Controllers
{
	public class JogadorsController : ApiController
	{
		private SurviveAliensContext db = new SurviveAliensContext();

		// GET: api/Jogadors
		//public IQueryable<Jogador> GetJogadors()
		public IEnumerable<Jogador> GetJogadors()
		{
			//return db.Jogadors;
			using (SqlConnection conn = Sql.Open())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Apelido, Genero, Email, Senha, HorasJogadas, KmCaminhados FROM Jogador", conn))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{

						List<Jogador> jogadorList = new List<Jogador>();
						//Obtém os registros, um por vez
						while (reader.Read() == true)
						{
							int id = reader.GetInt32(0);
							string nome = reader.GetString(1);
							string apelido = reader.GetString(2);
							string genero = reader.GetString(3);
							string email = reader.GetString(4);
							string senha = reader.GetString(5);
							float horasJogadas = reader.GetFloat(6);
							float kmCaminhados = reader.GetFloat(7);

							jogadorList.Add(new Jogador(id, nome, apelido, genero, email, senha, horasJogadas, kmCaminhados));

						}
						return jogadorList;
					}
				}
			}
		}

		// GET: api/Jogadors/5
		[ResponseType(typeof(Jogador))]
		public async Task<IHttpActionResult> GetJogador(int id)
		{
			using (SqlConnection conn = Sql.Open())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Apelido, Genero, Email, Senha, HorasJogadas, KmCaminhados FROM Jogador WHERE Id = @Id", conn))
				{
					cmd.Parameters.AddWithValue("@id", id);
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						Jogador jogador = new Jogador();
						//Obtém os registros, um por vez
						while (reader.Read() == true)
						{
							int idJogador = reader.GetInt32(0);
							string nome = reader.GetString(1);
							string apelido = reader.GetString(2);
							string genero = reader.GetString(3);
							string email = reader.GetString(4);
							string senha = reader.GetString(5);
							float horasJogadas = reader.GetFloat(6);
							float kmCaminhados = reader.GetFloat(7);

							jogador = new Jogador(id, nome, apelido, genero, email, senha, horasJogadas, kmCaminhados);

						}
						if (jogador.Id <= 0)
							return NotFound();
						return Ok(jogador);
					}
				}
			}
		}

		// PUT: api/Jogadors/5
		[HttpPut]
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
			int id;
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (db.Jogadors.Count(x => x.Email == jogador.Email) > 0)
			//if(jog.Id != null)
			{
				return BadRequest("E-mail já cadastrado.");
			}
			//db.Jogadors.Add(jogador);
			//await db.SaveChangesAsync();

			using (SqlConnection conn = Sql.Open())
			{
				using (SqlCommand cmd = new SqlCommand("INSERT INTO JOGADOR (Nome, Apelido, Genero, Email, Senha, HorasJogadas, KmCaminhados) OUTPUT INSERTED.Id VALUES (@Nome, @Apelido, @Genero, @Email, @Senha, @HorasJogadas, @KmCaminhados)", conn))
				{
					cmd.Parameters.AddWithValue("@Nome", jogador.Nome);
					cmd.Parameters.AddWithValue("@Apelido", jogador.Apelido);
					cmd.Parameters.AddWithValue("@Genero", jogador.Genero);
					cmd.Parameters.AddWithValue("@Email", jogador.Email);
					cmd.Parameters.AddWithValue("@Senha", jogador.Senha);
					cmd.Parameters.AddWithValue("@HorasJogadas", jogador.HorasJogadas);
					cmd.Parameters.AddWithValue("@KmCaminhados", jogador.KmCaminhados);

					id = (int)cmd.ExecuteScalar();
				}

				var missoes = db.Missaos.ToList();
				List<MissaoJogador> missaoJogadorList = new List<MissaoJogador>();
				foreach (Missao mi in missoes)
				{
					using (SqlCommand cmd = new SqlCommand("INSERT INTO MISSAOJOGADOR (Id_Missao, Id_Jogador, Liberada) VALUES (@Id_Missao, @Id_Jogador, @Liberada)", conn))
					{
						cmd.Parameters.AddWithValue("@Id_Missao", mi.Id);
						cmd.Parameters.AddWithValue("@Id_Jogador", id);
						if (mi.Numero == 1 && mi.Capitulo.Numero == 1)
							cmd.Parameters.AddWithValue("@Liberada", true);
						else
							cmd.Parameters.AddWithValue("@Liberada", false);

						cmd.ExecuteNonQuery();
					}

				}
			}

			jogador.Id = id;
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

		[Route("api/Autenticar/creds")]
		[ResponseType(typeof(Jogador))]
		public async Task<IHttpActionResult> AutenticarJogador(Credenciais credenciais)
		{
			//string separators = "----";
			//string[] tokens = Regex.Split(emailsenha, separators);
			//return context.Jogadors.First(x => x.Email == tokens[0] && x.Senha == tokens[1]);
			//Jogador jogador = db.Jogadors.First(x => x.Email == credenciais.Email && x.Senha == credenciais.Senha);
			//if (jogador == null)
			//	return NotFound();
			//return Ok(jogador);

			using (SqlConnection conn = Sql.Open())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Apelido, Genero, Email, Senha, HorasJogadas, KmCaminhados FROM Jogador WHERE Email = @Email AND Senha = @Senha", conn))
				{
					cmd.Parameters.AddWithValue("@Email", credenciais.Email);
					cmd.Parameters.AddWithValue("@Senha", credenciais.Senha);
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						Jogador jogador = new Jogador();
						//Obtém os registros, um por vez
						while (reader.Read() == true)
						{
							int idJogador = reader.GetInt32(0);
							string nome = reader.GetString(1);
							string apelido = reader.GetString(2);
							string genero = reader.GetString(3);
							string email = reader.GetString(4);
							string senha = reader.GetString(5);
							float horasJogadas = reader.GetFloat(6);
							float kmCaminhados = reader.GetFloat(7);

							jogador = new Jogador(idJogador, nome, apelido, genero, email, senha, horasJogadas, kmCaminhados);
						}
						if (jogador.Id <= 0)
							return NotFound();
						return Ok(jogador);
					}
				}
			}
		}
	}
}