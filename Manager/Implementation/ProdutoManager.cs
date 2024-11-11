using AL.Core.Domain;
using AL.Core.Exceptions;
using AL.Core.Shared.Messages;
using AL.Core.Shared.ModelViews.Categoria;
using AL.Core.Shared.ModelViews.Feira;
using AL.Core.Shared.ModelViews.Imagens;
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
            Descricao = p.Descricao,
            Quantidade = p.Quantidade,
            Unidade = p.Unidade,
            Categoria = new CategoriaView { CategoriaID = p.Categoria.CategoriaID, Nome = p.Categoria?.Nome },
            PerfilContaID = p.PerfilContaID,
            QuantidadeUnidade = $"{p.Quantidade} {p.Unidade}",
            PerfilConta = p?.PerfilConta != null ? new PerfilContaView
            {
                PerfilContaID = p.PerfilConta.PerfilContaID,
                Nome = p.PerfilConta.Nome
            } : null
        }).ToList();

        return produtoView;
    }

    public async Task<ProdutoContaView> GetProdutosByIdAsync(int produtoID)
    {
        var produto = await _produtoRepository.GetProdutosByIdAsync(produtoID);
        if (produto == null)
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        var produtoView = new ProdutoContaView
        {
            ProdutoID = produto.ProdutoID,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Quantidade = produto.Quantidade,
            Unidade = produto.Unidade,
            PerfilContaID = produto.PerfilContaID,
            QuantidadeUnidade = $"{produto?.Quantidade} {produto?.Unidade}",
            PerfilConta = produto?.PerfilConta != null ? new PerfilContaView
            {
                PerfilContaID = produto.PerfilConta.PerfilContaID,
                Nome = produto.PerfilConta.Nome
            } : null
        };

        return produtoView;
    }

    public async Task<ProdutoContaView> GetProdutosByContaByIdAsync(string contaID, int produtoID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);
        if (contaExistente == null)
            throw new NotFoundException("Conta não encontrada.");

        var produto = await _produtoRepository.GetProdutosByContaByIdAsync(contaID, produtoID);
        if (produto == null)
            throw new NotFoundException(ExceptionMessages.NotFoundID);

        var produtoView = new ProdutoContaView
        {
            ProdutoID = produto.ProdutoID,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Quantidade = produto.Quantidade,
            Unidade = produto.Unidade,
            PerfilContaID = produto.PerfilContaID,
            QuantidadeUnidade = $"{produto?.Quantidade} {produto?.Unidade}",
            PerfilConta = produto?.PerfilConta != null ? new PerfilContaView
            {
                PerfilContaID = produto.PerfilConta.PerfilContaID,
                Nome = produto.PerfilConta.Nome
            } : null
        };

        return produtoView;
    }

    public async Task<List<ProdutoPerfilContaView>> GetProdutosByPerfilContasAsync(string perfilContaID)
    {
        var produto = await _produtoRepository.GetProdutosByPerfilContasAsync(perfilContaID);

        var produtoView = produto.Select(p => new ProdutoPerfilContaView
        {
            ProdutoID = p.ProdutoID,
            FeiraID = p.FeiraID,
            Nome = p.Nome,
            Descricao = p.Descricao,
            Quantidade = p.Quantidade,
            QuantidadeUnidade = $"{p.Quantidade} {p.Unidade}",
            Unidade = p.Unidade,
            PerfilConta = p?.PerfilConta != null ? new PerfilContaView
            {
                PerfilContaID = p.PerfilConta.PerfilContaID,
                Nome = p.PerfilConta.Nome
            } : null,            
            Categoria = new CategoriaView { CategoriaID = p.Categoria.CategoriaID, Nome = p.Categoria?.Nome },
            Feira = new FeiraView { FeiraID = p.Feira.FeiraID ,Nome = p.Feira.Nome }

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
            Descricao = p.Descricao,    
            Quantidade = p.Quantidade,
            Unidade = p.Unidade,
            QuantidadeUnidade = $"{p.Quantidade} {p.Unidade}",
            Categoria = new CategoriaView { CategoriaID = p.Categoria.CategoriaID, Nome = p.Categoria?.Nome },
            PerfilConta = new PerfilContaView {Nome = p.PerfilConta.Nome, PerfilContaID = p.PerfilConta.PerfilContaID, 
              ImagemPerfil = p.PerfilConta.ImagemPerfil != null 
                ? new ImagemView 
                {
                    CaminhoImagem = p.PerfilConta.ImagemPerfil.CaminhoImagem, 
                    Id = p.PerfilConta.ImagemPerfil.Id
                } 
                : null}
        }).ToList();

        return produtoView;
    }

    public async Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIds)
    {
        return await _produtoRepository.FiltrarFeirasPorPeriodosAsync(periodoIds);
    }

    public async Task<ProdutoContaView> InsertProdutoAsync(NovoProduto produto, string contaID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);
        if (contaExistente == null)
            throw new UnauthorizedAccessException("Conta não encontrada.");

        Produto novoProduto = new()
        {
            Nome = produto.Nome,
            Descricao= produto.Descricao,    
            Quantidade = produto.Quantidade,
            Unidade = produto.Unidade,
            ContaID = contaID,
            CategoriaID = produto.CategoriaID,
            PerfilContaID = produto.PerfilContaID,
            FeiraID = produto.FeiraID,
        };

        var produtoCriado = _produtoRepository.InsertProdutoAsync(novoProduto);

        ProdutoContaView produtoContaView = new()
        {
            ProdutoID = produtoCriado.Result.ProdutoID,
            Nome = produtoCriado.Result.Nome,
            Descricao = produtoCriado.Result.Descricao,
            Quantidade = produtoCriado.Result.Quantidade,
            Unidade = produtoCriado.Result.Unidade,
            PerfilContaID = produtoCriado.Result.PerfilContaID,
        };

        return produtoContaView;    
    }

    public async Task<ProdutoContaView> UpdateProdutoAsync(AlteraProduto alteraProduto, string contaID, int produtoID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);
        if (contaExistente == null)
            throw new NotFoundException("Conta não encontrada.");

        var produtoExistente = await _produtoRepository.GetProdutosByIdAsync(produtoID);
        if (produtoExistente == null)
            throw new NotFoundException("Produto não encontrado.");

        if(produtoExistente.ContaID != contaID)
            throw new NotFoundException("O produto não pertence à conta fornecida.");

        Produto produtoParaAlterar = new()
        {
            ProdutoID = produtoID,
            ContaID = contaID,

            // Usar os valores existentes a menos que novos valores sejam fornecidos
            Nome = alteraProduto.Nome ?? produtoExistente.Nome,
            Descricao = alteraProduto.Descricao ?? produtoExistente.Descricao,
            Quantidade = alteraProduto.Quantidade ?? produtoExistente.Quantidade,
            Unidade = alteraProduto.Unidade ?? produtoExistente.Unidade,
            CategoriaID = alteraProduto.CategoriaID ?? produtoExistente.CategoriaID,
            PerfilContaID = alteraProduto.PerfilContaID ?? produtoExistente.PerfilContaID,
            FeiraID = alteraProduto.FeiraID ?? produtoExistente.FeiraID,
        };

        await _produtoRepository.UpdateProdutoAsync(produtoParaAlterar);

        ProdutoContaView produtoContaView = new()
        {
            ProdutoID = produtoParaAlterar.ProdutoID,
            Nome = produtoParaAlterar.Nome,
            Descricao = produtoParaAlterar.Descricao,
            Quantidade = produtoParaAlterar.Quantidade,
            Unidade = produtoParaAlterar.Unidade,
            CategoriaID = produtoParaAlterar.CategoriaID,
            PerfilContaID = produtoParaAlterar.PerfilContaID
        };

        return produtoContaView;
    }

    public async Task DeleteProdutoAsync(string contaID, int produtoID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);
        if (contaExistente == null)
            throw new NotFoundException("Conta não encontrada.");

        var produtoExistente = await _produtoRepository.GetProdutosByIdAsync(produtoID);
        if (produtoExistente == null)
            throw new NotFoundException("Produto não encontrado.");

        if (produtoExistente.ContaID != contaID)
            throw new NotFoundException("O produto não pertence à conta fornecida.");

        await _produtoRepository.DeleteProdutoAsync(produtoID);
    }

}
