using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;
public interface IProdutoRepository
{
    Task<List<Produto>> GetProdutosByContaAsync(string contaID);
    Task<List<Produto>> GetProdutosByPerfilContasAsync(string perfilContaID);
    Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIDs);
    Task DeleteProdutoAsync(string contaID, int produtoID);
}
