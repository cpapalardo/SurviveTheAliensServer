using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
	[JsonObject(IsReference = true)]
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
		[JsonIgnore]
		public virtual ICollection<Missao> Missaos { get; set; }
    }
}
