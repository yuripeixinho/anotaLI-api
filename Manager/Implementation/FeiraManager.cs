using AL.Core.Domain;
using AL.Core.Exceptions;
using AL.Core.Shared.ModelViews.Categoria;
using AL.Core.Shared.ModelViews.Feira;
using AL.Core.Shared.ModelViews.PerfilConta;
using AL.Core.Shared.ModelViews.Produto;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;
public class FeiraManager : IFeiraManager
{
    private readonly IFeiraRepository _feiraRepository;
    private readonly IProdutoRepository _produtoRepository;

    public FeiraManager(IFeiraRepository feiraRepository, IProdutoRepository produtoRepository)
    {
        _feiraRepository = feiraRepository; 
        _produtoRepository = produtoRepository;
    }

    public async Task<IEnumerable<FeiraView>> GetFeirasAsync(string contaID)
    {
        var feiras = await _feiraRepository.GetFeirasAsync(contaID);

        var feiraView = feiras.Select(feira => new FeiraView
        {
            FeiraID = feira.FeiraID,
            Nome = feira.Nome,
            DataFim = feira.DataFim.GetValueOrDefault(),
            DataInicio = feira.DataInicio.GetValueOrDefault(),
            Produtos = feira.Produtos?.Select(produto
            => new ProdutoContaView
            {
                Quantidade = produto.Quantidade,
                PerfilContaID = produto.PerfilContaID,
                Nome = produto.Nome,
                Categoria = new CategoriaView { Nome = produto.Categoria?.Nome ?? "", CategoriaID = produto.CategoriaID }
            })
        })
        .ToList();

        return feiraView;
    }

    public async Task<FeiraView> GetFeiraByIdAsync(int feiraID)
    {
        var feiraEncontrada = await _feiraRepository.GetFeiraByIdAsync(feiraID);

        FeiraView feiraEncontradaView = new()
        {
            FeiraID = feiraID,
            Nome = feiraEncontrada.Nome,
            DataInicio = feiraEncontrada.DataInicio.GetValueOrDefault(),
            DataFim = feiraEncontrada.DataFim.GetValueOrDefault()
        };

        return feiraEncontradaView;
    }
    
    public async Task<NovaFeira> InsertNovaFeiraAsync(NovaFeira novaFeira, string contaID)
    {
        // Criando a nova feira
        Feira addNovaFeira = new()
        {
            ContaID = contaID,
            Nome = novaFeira.Nome,
            DataInicio = novaFeira.DataInicio.GetValueOrDefault(),
            DataFim = novaFeira.DataFim.GetValueOrDefault()
        };

        // Insira a nova feira e obtenha o ID
        var novaFeiraCriada = await _feiraRepository.InsertNovaFeiraAsync(addNovaFeira);

        // Agora que a feira foi criada, você pode mapear os produtos
        List<Produto> produtos = novaFeira.Produto != null && novaFeira.Produto.Any() 
            ? novaFeira.Produto.Select(p => new Produto
            {
                ContaID = contaID, // Preencha com o contaID correto
                Nome = p.Nome,
                Quantidade = p.Quantidade,
                Unidade = p.Unidade,
                CategoriaID = p.CategoriaID,
                PerfilContaID = p.PerfilContaID,
                FeiraID = novaFeiraCriada.FeiraID // Use o ID da nova feira criada
            }).ToList() 
            : []; // Cria uma lista vazia se Produto for nulo ou vazio

        // Adicione os produtos após a feira ter sido criada
        if (produtos.Any())
        {
            await _produtoRepository.InsertProdutoListAsync(produtos); // Você precisa de um método para inserir os produtos
        }

        NovaFeira perfilContaView = new()
        {
            Nome = novaFeiraCriada.Nome,
            DataInicio = novaFeiraCriada.DataInicio.GetValueOrDefault(),
            DataFim = novaFeiraCriada.DataFim.GetValueOrDefault(),
            Produto = novaFeira.Produto.Select(p => new NovoProduto
            {
                Nome = p.Nome,
                Quantidade = p.Quantidade,
                Unidade = p.Unidade,
                CategoriaID = p.CategoriaID,
                PerfilContaID = p.PerfilContaID,
                FeiraID = novaFeiraCriada.FeiraID // Use o ID da nova feira criada
            }).ToList()
        };

        return perfilContaView;
    }

    public async Task<NovaFeira> UpdateFeiraAsync(NovaFeira novaFeira, int feiraID, string contaID)
    {
        var feiraExistente = await _feiraRepository.GetFeiraByIdAsync(feiraID); 

        if (feiraExistente.ContaID != contaID)
            throw new UnauthorizedAccessException("O perfil não pertence à conta fornecida.");

        // Cria a instância de Feira e preenche as propriedades necessárias
        Feira feiraParaAlterar = new()
        {
            ContaID = contaID,
            Nome = novaFeira.Nome,
            FeiraID = feiraID,
            DataInicio = novaFeira.DataInicio, // Atribui a data de início
            DataFim = novaFeira.DataFim        // Atribui a data de fim
        };

        // Atualiza a feira no repositório
        var feiraAlterada = await _feiraRepository.UpdateFeiraAsync(feiraParaAlterar);

        // Cria a nova instância de NovaFeira com os dados atualizados
        NovaFeira perfilContaView = new()
        {
            Nome = feiraAlterada.Nome,
            DataInicio = feiraAlterada.DataInicio,
            DataFim = feiraAlterada.DataFim
        };

        return perfilContaView;
    }

      public async Task DeleteFeiraAsync(string contaID, int feiraID)
    {
        var feiraExistente = await _feiraRepository.GetFeiraByIdAsync(feiraID);
        if (feiraExistente == null)
            throw new NotFoundException("Produto não encontrado.");

        if (feiraExistente.ContaID != contaID)
            throw new NotFoundException("O produto não pertence à conta fornecida.");

        await _feiraRepository.DeleteFeiraAsync(feiraID);
    }
}
