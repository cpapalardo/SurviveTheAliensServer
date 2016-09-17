using System;
using System.Collections.Generic;

namespace SurviveTheAliensServer.Models
{
    public partial class Historia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nullable<int> id_capitulo { get; set; }
        public virtual Capitulo Capitulo { get; set; }
    }
}
