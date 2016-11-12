using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SurviveTheAliensServer.Models;

namespace SurviveTheAliensServer.Controllers
{
	[RoutePrefix("api/Autenticar")]
	public class AutenticacaoController : ApiController
	{
		private SurviveAliensContext db = new SurviveAliensContext();

		[Route("login")]
		[HttpPost]
		[ResponseType(typeof(Jogador))]
		public async Task<IHttpActionResult> Post([FromBody] Newtonsoft.Json.Linq.JObject data)
		{
			string email = data.GetValue("email").ToString();
			string senha = data.GetValue("senha").ToString();

			Jogador jogador = db.Jogadors.First(x => x.Email == email && x.Senha == senha);

			if (jogador == null)
			{
				return NotFound();
			}

			return Ok(jogador);
		}
	}
}
