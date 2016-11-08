using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class MissaoJogador
    {
        public int Id { get; set; }
        public int Id_Missao { get; set; }
        public int Id_Jogador { get; set; }
        public bool Liberada { get; set; }
        public virtual Jogador Jogador { get; set; }
        public virtual Missao Missao { get; set; }
    }
}
