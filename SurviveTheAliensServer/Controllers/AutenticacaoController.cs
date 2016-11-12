using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurviveTheAliensServer.Controllers
{
	class AutenticacaoController
	{
		[RoutePrefix("api/Autenticar")]
		public class AutenticacaoController : ApiController
		{
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
}
