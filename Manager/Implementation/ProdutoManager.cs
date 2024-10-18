using AL.Core.Domain;
using AL.Core.Shared.ModelViews.PerfilConta;
using AL.Core.Shared.ModelViews.Produto;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;

public class ProdutoManager : IProdutoManager
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoManager(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<List<ProdutoContaView>> GetProdutosByContaAsync(string contaID)
    {
        var produto = await _produtoRepository.GetProdutosByContaAsync(contaID);

        var produtoView = produto.Select(p => new ProdutoContaView
        {
            ProdutoID = p.ProdutoID,
            Nome = p.Nome,
            Quantidade = p.Quantidade,
            Unidade = p.Unidade,
            Categoria = p.Categoria.Nome, 
            PerfilConta = p.PerfilConta != null ? new PerfilContaView
            {
                PerfilContaID = p.PerfilConta.PerfilContaID,
                Nome = p.PerfilConta.Nome
            } : null
        }).ToList();

        return produtoView;
    }

    public async Task<List<ProdutoPerfilContaView>> GetProdutosByPerfilContasAsync(int perfilContaID)
    {
        var produto = await _produtoRepository.GetProdutosByPerfilContasAsync(perfilContaID);

        var produtoView = produto.Select(p => new ProdutoPerfilContaView
        {
            ProdutoID = p.ProdutoID,
            Nome = p.Nome,
            Quantidade = p.Quantidade,
            Unidade = p.Unidade,
            Categoria = p.Categoria.Nome,
        }).ToList();

        return produtoView;
    }

    public async Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIds)
    {
        return await _produtoRepository.FiltrarFeirasPorPeriodosAsync(periodoIds);
    }
}
