using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POCF1.Business.Models;

namespace POCF1.Data.Mappings
{
    public class EquipeMapping : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(e => e.PotenciaCarro)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.AerodinamicaCarro)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("Equipes");
        }
    }
}
