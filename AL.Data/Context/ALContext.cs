using AL.Core.Domain;
using AL.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Context;

public class ALContext : DbContext
{
    public ALContext(DbContextOptions<ALContext> options) : base(options)
    {
    }

    public DbSet<Conta> Contas { get; set; }
    public DbSet<PerfilConta> PerfilContas { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ContaConfiguration());
        modelBuilder.ApplyConfiguration(new PerfilContaConfiguration());
    }
}
