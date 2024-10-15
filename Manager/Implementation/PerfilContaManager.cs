using AL.Core.Shared.ModelViews.PerfilConta;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;

public class PerfilContaManager : IPerfilContaManager
{
    private readonly IPerfilContaRepository _perfilContaRepository;

    public PerfilContaManager(IPerfilContaRepository perfilContaRepository)
    {
        _perfilContaRepository = perfilContaRepository;   
    }

    public async Task<IEnumerable<PerfilContaView>> GetPerfisContaAsync(int contaID)
    {
        var perfisConta = await _perfilContaRepository.GetPerfisContaAsync(contaID);

        var perfisContaView = perfisConta.Select(p => new PerfilContaView
        {
            Nome = p.Nome,  
            PerfilContaID = p.PerfilContaID,
        });

        return perfisContaView;
    }
}
