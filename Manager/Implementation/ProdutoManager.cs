using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Categoria;
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
            CategoriaID = p.CategoriaID,
            PerfilContaID = p.PerfilContaID,
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
            Categoria = new CategoriaView { CategoriaID = p.Categoria.CategoriaID ,Nome = p.Categoria?.Nome }
        }).ToList();

        return produtoView;
    }

    public async Task<List<ProdutoPerfilContaView>> GetProdutosByFeiraEContaAsync(string contaID, int feiraID)
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
            Categoria = new CategoriaView { CategoriaID = p.Categoria.CategoriaID, Nome = p.Categoria?.Nome }
        }).ToList();

        return produtoView;
    }

    public async Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIds)
    {
        return await _produtoRepository.FiltrarFeirasPorPeriodosAsync(periodoIds);
    }

    public async Task<NovoProduto> InsertProdutoAsync(NovoProduto produto, string contaID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);
        if (contaExistente == null)
            throw new UnauthorizedAccessException("Conta não encontrada.");

        Produto novoProduto = new()
        {
            Nome = produto.Nome,
            Quantidade = produto.Quantidade,
            Unidade = produto.Unidade,
            ContaID = contaID,
            CategoriaID = produto.CategoriaID,
            PerfilContaID = produto.PerfilContaID,
            FeiraID = produto.FeiraID,
        };

        var produtoCriado = _produtoRepository.InsertProdutoAsync(novoProduto);

        NovoProduto produtoContaView = new()
        {
            Nome = produtoCriado.Result.Nome,
            Quantidade = produtoCriado.Result.Quantidade,
            Unidade = produtoCriado.Result.Unidade,
            CategoriaID = produtoCriado.Result.CategoriaID,
            PerfilContaID = produtoCriado.Result.PerfilContaID,
            FeiraID = produtoCriado.Result.FeiraID,
        };

        return produtoContaView;    
    }

    //public int ProdutoID { get; set; }
    //public required string Nome { get; set; }
    //public required int Quantidade { get; set; }
    //public string? Unidade { get; set; }

    //public required string ContaID { get; set; }
    //public required int CategoriaID { get; set; }
    //public required string PerfilContaID { get; set; }
    //public required int FeiraID { get; set; }


    //Feira addNovaFeira = new()
    //{
    //    ContaID = contaID,
    //    Nome = novaFeira.Nome,
    //    DataInicio = novaFeira.DataInicio.GetValueOrDefault(),
    //    DataFim = novaFeira.DataFim.GetValueOrDefault()
    //};

    //var novaFeiraCriada = await _feiraRepository.InsertNovaFeiraAsync(addNovaFeira);

    //NovaFeira perfilContaView = new()
    //{
    //    Nome = novaFeiraCriada.Nome,
    //    DataInicio = novaFeiraCriada.DataInicio.GetValueOrDefault(),
    //    DataFim = novaFeiraCriada.DataFim.GetValueOrDefault()
    //};

    //    return perfilContaView;

    public async Task DeleteProdutoAsync(string contaID, int feiraID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);

        if (contaExistente == null)
            throw new UnauthorizedAccessException("Conta não encontrada.");


        throw new NotImplementedException();
    }
}
