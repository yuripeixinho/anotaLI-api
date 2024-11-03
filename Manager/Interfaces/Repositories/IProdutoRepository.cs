using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Produto;

namespace AL.Manager.Interfaces.Repositories;
public interface IProdutoRepository
{
    Task<List<Produto>> GetProdutosByContaAsync(string contaID);
    Task<Produto> GetProdutosByIdAsync(int produtoID);
    Task<Produto> GetProdutosByContaByIdAsync(string contaID, int produtoID);
    Task<List<Produto>> GetProdutosByPerfilContasAsync(string perfilContaID);
    Task<List<Produto>> GetProdutosByFeiraEContaAsync(string contaID, int feiraID);
    Task<Produto> InsertProdutoAsync(Produto produto);
    Task<Produto> UpdateProdutoAsync(Produto produto);
    Task<List<Produto>> InsertProdutoListAsync(List<Produto> produtos);
    Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIDs);
    Task DeleteProdutoAsync(int produtoID);
}
