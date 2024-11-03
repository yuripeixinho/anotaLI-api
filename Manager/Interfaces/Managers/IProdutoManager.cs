using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Produto;

namespace AL.Manager.Interfaces.Managers;

public interface IProdutoManager
{
    Task<List<ProdutoContaView>> GetProdutosByContaAsync(string contaID);
    Task<ProdutoContaView> GetProdutosByIdAsync(int produtoID);
    Task<ProdutoContaView> GetProdutosByContaByIdAsync(string contaID, int produtoID);
    Task<List<ProdutoPerfilContaView>> GetProdutosByPerfilContasAsync(string perfilContaID);
    Task<List<ProdutoPerfilContaView>> GetProdutosByFeiraEContaAsync(string contaID, int feiraID);
    Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIDs);
    Task<ProdutoContaView> InsertProdutoAsync(NovoProduto produto, string contaID);
    Task<ProdutoContaView> UpdateProdutoAsync(AlteraProduto alteraProduto, string contaID, int produtoID);
    Task DeleteProdutoAsync(string contaID, int produtoID);
}
