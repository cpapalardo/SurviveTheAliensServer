using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Jogador
    {
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
        public int HorasJogadas { get; set; }
        public int KmCaminhados { get; set; }
        public virtual ICollection<MissaoJogador> MissaoJogadors { get; set; }
    }
}
