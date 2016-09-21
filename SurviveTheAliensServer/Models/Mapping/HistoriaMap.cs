using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SurviveTheAliensServer.Models.Mapping
{
    public class HistoriaMap : EntityTypeConfiguration<Historia>
    {
        public HistoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nome)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.descricao)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Historia");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.descricao).HasColumnName("descricao");
        }
    }
}
