using AL.Core.Domain;
using AL.Core.Exceptions;
using AL.Core.Shared.Messages;
using AL.Data.Context;
using AL.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Repository;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly ALContext _context;

    public CategoriaRepository(ALContext context)
    {
        _context = context; 
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasDefaultAsync()
    {
       return await _context.Categorias
                    .Where(c => c.ContaID == null)
                    .ToListAsync();
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasByContaAsync(string contaID)
    {
        var categoriaConta = await _context.Categorias
                    .Where(c => c.ContaID == contaID)
                    .ToListAsync();
        
        if (categoriaConta is null || !categoriaConta.Any())
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        return categoriaConta;
    }
}
