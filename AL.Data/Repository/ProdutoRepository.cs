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

    public async Task<List<Produto>> GetProdutosByPerfilContasAsync(string perfilContaID)
    {
        var produtos = await _context.Produtos
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Where(p => p.PerfilContaID == perfilContaID)
                .ToListAsync();

        return produtos;
    }

    public async Task<List<Produto>> GetProdutosByFeiraEContaAsync(string contaID, int feiraID)
    {
        bool feiraExiste = await _context.Feiras
        .AnyAsync(f => f.ContaID == contaID && f.FeiraID == feiraID);

        if (!feiraExiste)
            throw new InvalidOperationException("A feira não existe para a conta especificada.");

        var produtos = await _context.Produtos
            .AsNoTracking()
            .Include(p => p.Categoria)
            .Where(p => p.PerfilConta.ContaID == contaID && p.FeiraID == feiraID)
            .ToListAsync();

        return produtos;
    }

    public async Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIDs)
    {
        if(periodoIDs == null || !periodoIDs.Any())
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        return await _context.Produtos
           .Include(p => p.Feira)
           .Where(p => periodoIDs.Contains(p.FeiraID)) 
           .ToListAsync();
    }

    public async Task DeleteProdutoAsync(string contaID, int produtoID)
    {
        //bool feiraExiste = await _context.Produtos
        //.AnyAsync(f => f.ContaID == contaID && f.FeiraID == feiraID);

        //var produtoExistente = await _context.Contas.FindAsync(produtoID);

        //if (feiraExiste is null)
        //    throw new NotFoundException(ExceptionMessages.NotFoundID);

        //_context.Contas.Remove(feiraExiste);
        //await _context.SaveChangesAsync();
    }

}
