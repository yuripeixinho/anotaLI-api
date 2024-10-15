using AL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AL.Data.Configuration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.CategoriaID);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasOne(c => c.Conta)
            .WithMany(c => c.Categorias)
            .HasForeignKey(c => c.ContaID)
            .OnDelete(DeleteBehavior.Restrict); // ou DeleteBehavior.SetNull
    }
}
