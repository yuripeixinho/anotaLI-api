using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Feira;
using AL.Data.Context;
using AL.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Repository;
public class FeiraRepository : IFeiraRepository
{
    private readonly ALContext _context;

    public FeiraRepository(ALContext context)
    {
        _context = context; 
    }

    
    public async Task<IEnumerable<Feira>> GetFeirasAsync(string contaID)
    {
        return await _context.Feiras
                     .Where(c => c.ContaID == contaID)
                     .ToListAsync();
    }


}
