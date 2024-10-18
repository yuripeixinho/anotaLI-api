using AL.Core.Domain;
using AL.Core.Exceptions;
using AL.Core.Shared.Messages;
using AL.Data.Context;
using AL.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Repository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ALContext _context;

    public ProdutoRepository(ALContext context)
    {
        _context = context; 
    }

    public async Task<List<Produto>> GetProdutosByContaAsync(string contaID)
    {
        var produtos = await _context.Produtos
                .AsNoTracking()
                .Include(p => p.PerfilConta)
                .Include(p => p.Categoria)
                .Where(p => p.PerfilConta.ContaID == contaID) 
                .ToListAsync();

        return produtos;    
    }

    public async Task<List<Produto>> GetProdutosByPerfilContasAsync(int perfilContaID)
    {
        var produtos = await _context.Produtos
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Where(p => p.PerfilContaID == perfilContaID)
                .ToListAsync();

        return produtos;
    }


    public async Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIDs)
    {
        if(periodoIDs == null || !periodoIDs.Any())
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        return await _context.Produtos
           .Include(p => p.DimPeriodoFeira)
           .Where(p => periodoIDs.Contains(p.DimPeriodoFeiraID)) // Filtra pelos IDs dos períodos selecionados
           .ToListAsync();
    }

}
