using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SurviveTheAliensServer.Models.Mapping
{
    public class MissaoJogadorMap : EntityTypeConfiguration<MissaoJogador>
    {
        public MissaoJogadorMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MissaoJogador");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_missao).HasColumnName("id_missao");
            this.Property(t => t.id_jogador).HasColumnName("id_jogador");
        }
    }
}
