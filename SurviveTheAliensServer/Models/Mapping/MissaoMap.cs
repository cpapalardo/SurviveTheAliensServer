using System.ComponentModel.DataAnnotations.Schema;
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
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Missao");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Id_Capitulo).HasColumnName("Id_Capitulo");
            this.Property(t => t.KmDeMissao).HasColumnName("KmDeMissao");
			Property(t => t.Numero).HasColumnName("Numero");

			// Relationships
			this.HasOptional(t => t.Capitulo)
				.WithMany(t => t.Missaos)
				.HasForeignKey(d => d.Id_Capitulo);

		}
    }
}
