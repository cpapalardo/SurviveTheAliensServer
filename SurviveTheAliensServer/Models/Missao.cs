using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Missao
    {
        public Missao()
        {
            this.Capituloes = new List<Capitulo>();
        }

        public int Id { get; set; }
        public System.TimeSpan TempoDeMissao { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Capitulo> Capituloes { get; set; }
    }
}
