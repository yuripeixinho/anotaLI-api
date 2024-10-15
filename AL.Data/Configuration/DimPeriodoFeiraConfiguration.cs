using AL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AL.Data.Configuration;

public class DimPeriodoFeiraConfiguration : IEntityTypeConfiguration<DimPeriodoFeira>
{
    public void Configure(EntityTypeBuilder<DimPeriodoFeira> builder)
    {
        builder.HasKey(c => c.DimPeriodoFeiraID);

        builder.Property(c => c.Periodo)
            .IsRequired()
            .HasMaxLength(45);
    }
}
