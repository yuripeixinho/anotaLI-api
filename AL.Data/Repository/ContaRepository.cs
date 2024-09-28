using AL.Core.Domain;
using AL.Data.Context;
using AL.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Repository;

public class ContaRepository : IContaRepository
{
    private readonly ALContext _context;

    public ContaRepository(ALContext context)
    {
        _context = context; 
    }

    public async Task<IEnumerable<Conta>> GetContasAsync()
    {
        return await _context.Contas.AsNoTracking().ToListAsync();
    }

    public async Task<Conta> GetContaByIdAsync(int id)
    {
        return await _context.Contas
             .SingleOrDefaultAsync(p => p.ContaID == id);
    }
}
