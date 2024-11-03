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

    public async Task<Produto> GetProdutosByIdAsync(int produtoID)
    {
        var produtos = await _context.Produtos
            .Include(p => p.PerfilConta)
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.ProdutoID == produtoID); // Filtra pelo ID do produto

        return produtos;
    }

    public async Task<Produto> GetProdutosByContaByIdAsync(string contaID, int produtoID)
    {
        var produtos = await _context.Produtos
              .Include(p => p.PerfilConta)
              .Include(p => p.Categoria)
              .SingleOrDefaultAsync(p => p.ContaID == contaID && p.ProdutoID == produtoID);

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

    public async Task<Produto> InsertProdutoAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();

        return produto;
    }

   public async Task<List<Produto>> InsertProdutoListAsync(List<Produto> produtos)
    {
        await _context.Produtos.AddRangeAsync(produtos);
        
        await _context.SaveChangesAsync();

        return produtos;
    }

    public async Task<Produto> UpdateProdutoAsync(Produto produto)
    {
        var produtoExistente = await _context.Produtos.FindAsync(produto.ProdutoID);

        if (produtoExistente is null)
            throw new NotFoundException("Nenhum resultado encontrado para ID do produto fornecido.");

        _context.Entry(produtoExistente).CurrentValues.SetValues(produto); 

        await _context.SaveChangesAsync();
        return produtoExistente;
    }

    public async Task DeleteProdutoAsync(int produtoID)
    {
        var produtoExistente = await _context.Produtos.FindAsync(produtoID);

        if (produtoExistente is null)
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        _context.Produtos.Remove(produtoExistente);
        await _context.SaveChangesAsync();
    }

}
