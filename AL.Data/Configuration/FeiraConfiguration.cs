using AL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AL.Data.Configuration;

public class FeiraConfiguration : IEntityTypeConfiguration<Feira>
{
    public void Configure(EntityTypeBuilder<Feira> builder)
    {
        builder.HasKey(c => c.FeiraID);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(45);
    }
}
