using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class MissaoJogador
    {
        public int id { get; set; }
        public int id_missao { get; set; }
        public int id_jogador { get; set; }
    }
}
