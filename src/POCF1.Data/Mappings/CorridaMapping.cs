using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POCF1.Business.Models;

namespace POCF1.Data.Mappings
{
    public class CorridaMapping : IEntityTypeConfiguration<Corrida>
    {
        public void Configure(EntityTypeBuilder<Corrida> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NomeCircuito)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(e => e.TrajetoTotalCircuito)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.DataCorrida)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.Piloto1)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Tempo1)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.Piloto2)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Tempo2)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.Piloto3)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Tempo3)
                .IsRequired()
                .HasColumnType("datetime");

            builder.ToTable("Corridas");
        }
    }
}
