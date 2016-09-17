using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Capitulo
    {
        public Capitulo()
        {
            this.Historias = new List<Historia>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public Nullable<int> id_missao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual Missao Missao { get; set; }
        public virtual ICollection<Historia> Historias { get; set; }
    }
}
