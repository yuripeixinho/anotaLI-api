using AL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AL.Data.Configuration;
public class PerfilContaConfiguration : IEntityTypeConfiguration<PerfilConta>
{
    public void Configure(EntityTypeBuilder<PerfilConta> builder)
    {
        builder.HasKey(p => p.PerfilContaID);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(45);

        builder.Property(p => p.Nome)
        .IsRequired()
        .HasMaxLength(25);
    }
}
