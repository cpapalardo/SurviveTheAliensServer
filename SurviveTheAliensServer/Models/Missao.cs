using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int? Id_Capitulo { get; set; }
        public int KmDeMissao { get; set; }
		public int Numero { get; set; }
		public virtual Capitulo Capitulo { get; set; }
        public virtual ICollection<MissaoJogador> MissaoJogadors { get; set; }
    }
}
