using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SurviveTheAliensServer.Models.Mapping;

namespace SurviveTheAliensServer.Models
{
    public partial class SurviveAliensContext : DbContext
    {
        static SurviveAliensContext()
        {
            Database.SetInitializer<SurviveAliensContext>(null);
        }

        public SurviveAliensContext()
            : base("Name=SurviveAliensContext")
        {
        }

        public DbSet<Capitulo> Capituloes { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Jogador> Jogadors { get; set; }
        public DbSet<Missao> Missaos { get; set; }
        public DbSet<MissaoJogador> MissaoJogadors { get; set; }
        public DbSet<Recurso> Recursoes { get; set; }
       // public DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CapituloMap());
            modelBuilder.Configurations.Add(new HistoriaMap());
            modelBuilder.Configurations.Add(new JogadorMap());
            modelBuilder.Configurations.Add(new MissaoMap());
            modelBuilder.Configurations.Add(new MissaoJogadorMap());
            modelBuilder.Configurations.Add(new RecursoMap());
            //modelBuilder.Configurations.Add(new database_firewall_rulesMap());

			base.OnModelCreating(modelBuilder);
        }
    }
}
