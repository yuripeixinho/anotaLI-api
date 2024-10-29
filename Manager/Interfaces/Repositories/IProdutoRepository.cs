using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;
public interface IProdutoRepository
{
    Task<List<Produto>> GetProdutosByContaAsync(string contaID);
    Task<List<Produto>> GetProdutosByPerfilContasAsync(string perfilContaID);
    Task<List<Produto>> GetProdutosByFeiraEContaAsync(string contaID, int feiraID);
    Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIDs);
    Task DeleteProdutoAsync(string contaID, int produtoID);
}
