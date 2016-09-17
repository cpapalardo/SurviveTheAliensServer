using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SurviveTheAliensServer.Models.Mapping
{
    public class CapituloMap : EntityTypeConfiguration<Capitulo>
    {
        public CapituloMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("Capitulo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.id_missao).HasColumnName("id_missao");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Descricao).HasColumnName("Descricao");

            // Relationships
            this.HasOptional(t => t.Missao)
                .WithMany(t => t.Capituloes)
                .HasForeignKey(d => d.id_missao);

        }
    }
}
