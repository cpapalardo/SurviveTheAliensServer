using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SurviveTheAliensServer.Models.Mapping
{
    public class HistoriaMap : EntityTypeConfiguration<Historia>
    {
        public HistoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("Historia");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.id_capitulo).HasColumnName("id_capitulo");

            // Relationships
            this.HasOptional(t => t.Capitulo)
                .WithMany(t => t.Historias)
                .HasForeignKey(d => d.id_capitulo);

        }
    }
}
