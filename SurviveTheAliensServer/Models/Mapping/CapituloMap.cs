using System.ComponentModel.DataAnnotations.Schema;
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
                .HasMaxLength(20);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Capitulo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
