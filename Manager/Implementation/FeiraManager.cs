using AL.Core.Shared.ModelViews.Feira;
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
            DataFim = feira.DataFim,    
            DataInicio = feira.DataInicio,  
        
        }).ToList();

        return feiraView;
    }
}
