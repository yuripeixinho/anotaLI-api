using AL.Core.Domain;
using AL.Data.Context;
using AL.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Repository;

public class PerfilContaRepository : IPerfilContaRepository
{
    private readonly ALContext _context;

    public PerfilContaRepository(ALContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PerfilConta>> GetPerfisContaAsync(string contaID)
    {
        return await _context.PerfilContas
            .Include(p => p.Conta)
            .Include(p => p.Produtos)    
            .AsNoTracking()
            .Where(p => p.ContaID == contaID)
            .ToListAsync();
    }
}
