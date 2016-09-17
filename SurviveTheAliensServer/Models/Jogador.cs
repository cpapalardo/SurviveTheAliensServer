using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public int HorasJogadas { get; set; }
        public Nullable<int> kmCaminhados { get; set; }
    }
}
