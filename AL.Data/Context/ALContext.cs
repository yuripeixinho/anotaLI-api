using AL.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Context;

public class ALContext : DbContext
{
    public ALContext(DbContextOptions<ALContext> options) : base(options)
    {
    }

    public DbSet<Conta> Contas { get; set; }



}
