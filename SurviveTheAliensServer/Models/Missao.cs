using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Missao
    {
        public int Id { get; set; }
        public System.TimeSpan TempoDeMissao { get; set; }
        public string Nome { get; set; }
        public int id_Capitulo { get; set; }
        public virtual Capitulo Capitulo { get; set; }
    }
}
