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

        public int id { get; set; }
        public int numero { get; set; }
        public Nullable<int> id_historia { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public virtual Historia Historia { get; set; }
        public virtual ICollection<Missao> Missaos { get; set; }
    }
}
