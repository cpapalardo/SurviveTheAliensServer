using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SurviveTheAliensServer.Models
{
    public class TesteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TesteContext() : base("name=TesteContext")
        {
        }

		public System.Data.Entity.DbSet<SurviveTheAliensServer.Models.Capitulo> Capituloes { get; set; }

		public System.Data.Entity.DbSet<SurviveTheAliensServer.Models.Historia> Historias { get; set; }

		public System.Data.Entity.DbSet<SurviveTheAliensServer.Models.Jogador> Jogadors { get; set; }

		public System.Data.Entity.DbSet<SurviveTheAliensServer.Models.Missao> Missaos { get; set; }

		public System.Data.Entity.DbSet<SurviveTheAliensServer.Models.MissaoJogador> MissaoJogadors { get; set; }

		public System.Data.Entity.DbSet<SurviveTheAliensServer.Models.Recurso> Recursoes { get; set; }
	}
}
