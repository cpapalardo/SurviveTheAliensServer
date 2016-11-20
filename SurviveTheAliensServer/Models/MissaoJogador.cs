using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class MissaoJogador
    {
		public MissaoJogador()
		{

		}

		public MissaoJogador(int Id, int Id_Missao, int Id_Jogador, bool Liberada)
		{
			this.Id = Id;
			this.Id_Missao = Id_Missao;
			this.Id_Jogador = Id_Jogador;
			this.Liberada = Liberada;
		}

        public int Id { get; set; }
        public int Id_Missao { get; set; }
        public int Id_Jogador { get; set; }
        public bool Liberada { get; set; }
        public virtual Jogador Jogador { get; set; }
        public virtual Missao Missao { get; set; }
    }
}
