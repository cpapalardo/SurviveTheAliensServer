using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Jogador
    {
		public Jogador(int Id, string Nome, string Apelido, string Genero,
			string Email, string Senha, float HorasJogadas, float KmCaminhados)
		{
			this.Id = Id;
			this.Nome = Nome;
			this.Apelido = Apelido;
			this.Genero = Genero;
			this.Email = Email;
			this.Senha = Senha;
			this.HorasJogadas = HorasJogadas;
			this.KmCaminhados = KmCaminhados;
		}

        public Jogador()
        {
            this.MissaoJogadors = new List<MissaoJogador>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public float HorasJogadas { get; set; }
        public float KmCaminhados { get; set; }
        public virtual ICollection<MissaoJogador> MissaoJogadors { get; set; }
    }
}
