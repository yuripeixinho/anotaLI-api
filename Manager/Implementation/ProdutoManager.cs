using AL.Core.Domain;
using AL.Core.Shared.ModelViews.PerfilConta;
using AL.Core.Shared.ModelViews.Produto;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;

public class ProdutoManager : IProdutoManager
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IContaRepository _contaRepository;

    public ProdutoManager(IProdutoRepository produtoRepository, IContaRepository contaRepository)
    {
        _produtoRepository = produtoRepository; 
        _contaRepository = contaRepository;
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
            Categoria = p?.Categoria?.Nome ?? "", 
            PerfilConta = p?.PerfilConta != null ? new PerfilContaView
            {
                PerfilContaID = p.PerfilConta.PerfilContaID,
                Nome = p.PerfilConta.Nome
            } : null
        }).ToList();

        return produtoView;
    }

    public async Task<List<ProdutoPerfilContaView>> GetProdutosByPerfilContasAsync(string perfilContaID)
    {
        var produto = await _produtoRepository.GetProdutosByPerfilContasAsync(perfilContaID);

        var produtoView = produto.Select(p => new ProdutoPerfilContaView
        {
            ProdutoID = p.ProdutoID,
            Nome = p.Nome,
            Quantidade = p.Quantidade,
            Unidade = p.Unidade,
            Categoria = p?.Categoria?.Nome ?? "",
        }).ToList();

        return produtoView;
    }

    public async Task<List<ProdutoPerfilContaView>> GetProdutosByFeiraAsync(string contaID, int feiraID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);
        if (contaExistente == null)
            throw new UnauthorizedAccessException("Conta não encontrada.");

        var produtos = await _produtoRepository.GetProdutosByFeiraEContaAsync(contaID, feiraID);

        var produtoView = produtos.Select(p => new ProdutoPerfilContaView
        {
            ProdutoID = p.ProdutoID,
            Nome = p.Nome,
            Quantidade = p.Quantidade,
            Unidade = p.Unidade,
            Categoria = p?.Categoria?.Nome ?? "",
        }).ToList();

        return produtoView;
    }

    public async Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIds)
    {
        return await _produtoRepository.FiltrarFeirasPorPeriodosAsync(periodoIds);
    }

}
