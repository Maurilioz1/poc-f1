using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POCF1.Business.Models;

namespace POCF1.Data.Mappings
{
    public class PilotoMapping : IEntityTypeConfiguration<Piloto>
    {
        public void Configure(EntityTypeBuilder<Piloto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.NivelExperiencia)
                .IsRequired()
                .HasColumnType("int(1)");

            builder.Property(p => p.QuantidadeParadas)
                .IsRequired()
                .HasColumnType("int(1)");

            builder.Property(p => p.PosicaoLargada)
                .IsRequired()
                .HasColumnType("int(2)");

            builder.ToTable("Pilotos");
        }
    }
}
