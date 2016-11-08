using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Missao
    {
        public Missao()
        {
            this.MissaoJogadors = new List<MissaoJogador>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public Nullable<int> Id_Capitulo { get; set; }
        public int KmDeMissao { get; set; }
        public virtual Capitulo Capitulo { get; set; }
        public virtual ICollection<MissaoJogador> MissaoJogadors { get; set; }
    }
}
