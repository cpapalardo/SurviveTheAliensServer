using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Historia
    {
        public Historia()
        {
            this.Capituloes = new List<Capitulo>();
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public virtual ICollection<Capitulo> Capituloes { get; set; }
    }
}
