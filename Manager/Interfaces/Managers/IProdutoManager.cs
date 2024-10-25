using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Produto;

namespace AL.Manager.Interfaces.Managers;

public interface IProdutoManager
{
    Task<List<ProdutoContaView>> GetProdutosByContaAsync(string contaID);
    Task<List<ProdutoPerfilContaView>> GetProdutosByPerfilContasAsync(string perfilContaID);
    Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIDs);

}
