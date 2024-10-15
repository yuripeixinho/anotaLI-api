using AL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AL.Data.Configuration;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(c => c.ProdutoID);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(c => c.Quantidade)
            .IsRequired();

        builder.HasOne(p => p.Categoria)
           .WithMany(c => c.Produtos)
           .HasForeignKey(p => p.CategoriaID)
           .OnDelete(DeleteBehavior.Restrict); // ou DeleteBehavior.Restrict para evitar ciclos

        builder.HasOne(p => p.PerfilConta)
           .WithMany(pc => pc.Produtos)
           .HasForeignKey(p => p.PerfilContaID)
           .OnDelete(DeleteBehavior.Restrict); // ou DeleteBehavior.Restrict

    }
}
