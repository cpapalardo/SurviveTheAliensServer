using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SurviveTheAliensServer.Models.Mapping
{
    public class JogadorMap : EntityTypeConfiguration<Jogador>
    {
        public JogadorMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Apelido)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Genero)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(16);

            // Table & Column Mappings
            this.ToTable("Jogador");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Apelido).HasColumnName("Apelido");
            this.Property(t => t.Genero).HasColumnName("Genero");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.HorasJogadas).HasColumnName("HorasJogadas");
            this.Property(t => t.KmCaminhados).HasColumnName("KmCaminhados");
        }
    }
}
