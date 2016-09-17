using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SurviveTheAliensServer.Models.Mapping
{
    public class MissaoMap : EntityTypeConfiguration<Missao>
    {
        public MissaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Missao");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TempoDeMissao).HasColumnName("TempoDeMissao");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
