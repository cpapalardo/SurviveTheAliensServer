using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurviveTheAliensServer.Models
{
    public partial class Missao
    {
		public Missao(int Id, string Nome, int? Id_Capitulo, float KmDeMissao, int Numero, float KmIntro, float KmApice, float KmFim)
		{
			this.Id = Id;
			this.Nome = Nome;
			this.Id_Capitulo = Id_Capitulo;
			this.KmDeMissao = KmDeMissao;
			this.Numero = Numero;
			this.KmIntro = KmIntro;
			this.KmApice = KmApice;
			this.KmFim = KmFim;
		}

        public Missao()
        {
            this.MissaoJogadors = new List<MissaoJogador>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Id_Capitulo { get; set; }
        public float KmDeMissao { get; set; }
		public int Numero { get; set; }
		public float KmIntro { get; set; }
		public float KmApice { get; set; }
		public float KmFim { get; set; }
		public virtual Capitulo Capitulo { get; set; }
        public virtual ICollection<MissaoJogador> MissaoJogadors { get; set; }
    }
}
