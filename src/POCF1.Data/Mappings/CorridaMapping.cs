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

            builder.ToTable("Corridas");
        }
    }
}
