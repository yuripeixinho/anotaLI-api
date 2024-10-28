using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Feira;
using AL.Core.Shared.ModelViews.PerfilConta;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;
public class FeiraManager : IFeiraManager
{
    private readonly IFeiraRepository _feiraRepository;

    public FeiraManager(IFeiraRepository feiraRepository)
    {
        _feiraRepository = feiraRepository; 
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
        
        }).ToList();

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
        Feira addNovaFeira = new()
        {
            ContaID = contaID,
            Nome = novaFeira.Nome,
            DataInicio = novaFeira.DataInicio.GetValueOrDefault(),
            DataFim = novaFeira.DataFim.GetValueOrDefault()
        };

        var novaFeiraCriada = await _feiraRepository.InsertNovaFeiraAsync(addNovaFeira);

        NovaFeira perfilContaView = new()
        {
            Nome = novaFeiraCriada.Nome,
            DataInicio = novaFeiraCriada.DataInicio.GetValueOrDefault(),
            DataFim = novaFeiraCriada.DataFim.GetValueOrDefault()
        };

        return perfilContaView;
    }

    public async Task<NovaFeira> UpdateFeiraAsync(NovaFeira novaFeira, int feiraID, string contaID)
    {
        var feiraExistente = await _feiraRepository.GetFeiraByIdAsync(feiraID); 

        if (feiraExistente.ContaID != contaID)
            throw new UnauthorizedAccessException("O perfil não pertence à conta fornecida.");

        Feira feiraParaAlterar = new()
            {
                ContaID = contaID,
                Nome = novaFeira.Nome,
                FeiraID = feiraID,
            };

        var feiraAlterada = await _feiraRepository.UpdateFeiraAsync(feiraParaAlterar);

        NovaFeira perfilContaView = new()
        {
            Nome = feiraAlterada.Nome,
            DataInicio = feiraAlterada.DataInicio.GetValueOrDefault(),
            DataFim = feiraAlterada.DataFim.GetValueOrDefault()
        };

        return perfilContaView;
    }
}
