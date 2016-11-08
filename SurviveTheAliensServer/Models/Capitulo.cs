using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Capitulo
    {
        public Capitulo()
        {
            this.Missaos = new List<Missao>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Missao> Missaos { get; set; }
    }
}
