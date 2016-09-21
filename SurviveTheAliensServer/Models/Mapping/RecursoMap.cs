using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SurviveTheAliensServer.Models.Mapping
{
    public class RecursoMap : EntityTypeConfiguration<Recurso>
    {
        public RecursoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Imagem)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Recurso");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Imagem).HasColumnName("Imagem");
        }
    }
}
