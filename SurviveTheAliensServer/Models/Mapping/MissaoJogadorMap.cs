using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SurviveTheAliensServer.Models.Mapping
{
    public class MissaoJogadorMap : EntityTypeConfiguration<MissaoJogador>
    {
        public MissaoJogadorMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MissaoJogador");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Id_Missao).HasColumnName("Id_Missao");
            this.Property(t => t.Id_Jogador).HasColumnName("Id_Jogador");
            this.Property(t => t.Liberada).HasColumnName("Liberada");

            // Relationships
            this.HasRequired(t => t.Jogador)
                .WithMany(t => t.MissaoJogadors)
                .HasForeignKey(d => d.Id_Jogador);
            this.HasRequired(t => t.Missao)
                .WithMany(t => t.MissaoJogadors)
                .HasForeignKey(d => d.Id_Missao);

        }
    }
}
