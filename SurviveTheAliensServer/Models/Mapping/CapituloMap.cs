using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SurviveTheAliensServer.Models.Mapping
{
    public class CapituloMap : EntityTypeConfiguration<Capitulo>
    {
        public CapituloMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nome)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("Capitulo");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.numero).HasColumnName("numero");
            this.Property(t => t.id_historia).HasColumnName("id_historia");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.descricao).HasColumnName("descricao");

            // Relationships
            this.HasOptional(t => t.Historia)
                .WithMany(t => t.Capituloes)
                .HasForeignKey(d => d.id_historia);

        }
    }
}
