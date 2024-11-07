using AL.Core.Domain;
using AL.Core.Exceptions;
using AL.Core.Shared.Messages;
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
                    .OrderBy(f => f.DataInicio)
                    .Include(f => f.Produtos)
                        .ThenInclude(p => p.Categoria) // Carrega a Categoria de cada Produto
                    .ToListAsync();
    }

    public async Task<Feira> InsertNovaFeiraAsync(Feira novaFeira)
    {
        await _context.Feiras.AddAsync(novaFeira);
        await _context.SaveChangesAsync();

        return novaFeira;
    }

    public async Task<Feira> GetFeiraByIdAsync(int feiraID)
    {
        var feira = await _context.Feiras.FindAsync(feiraID) 
            ?? throw new NotFoundException("Nenhum resultado encontrado para ID da feira fornecida.");

        await _context.SaveChangesAsync();

        return feira;
    }

     public async Task<Feira> UpdateFeiraAsync(Feira novaFeira)
    {
        var feiraExistente = await _context.Feiras.FindAsync(novaFeira.FeiraID)
            ?? throw new NotFoundException("Nenhum resultado encontrado para ID da feira fornecida.");

        _context.Entry(feiraExistente).CurrentValues.SetValues(novaFeira); // Essencialmente, este código copia todos os valores das propriedades da entidade cliente para clienteConsultado, que já está sendo rastreado pelo contexto.Após isso, o Entity Framework irá considerar que conta foi modificado, e quando você chamar SaveChanges(), essas alterações serão persistidas no banco de dados.

        await _context.SaveChangesAsync();
        return feiraExistente;
    }

     public async Task DeleteFeiraAsync(int feiraID)
    {
        var feiraExistente = await _context.Feiras.FindAsync(feiraID);

        if (feiraExistente is null)
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        _context.Feiras.Remove(feiraExistente);
        await _context.SaveChangesAsync();
        
}
}


