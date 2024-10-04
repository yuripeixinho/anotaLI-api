using AL.Core.Domain;
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

    public async Task<IEnumerable<PerfilConta>> GetPerfisContaAsync(int contaID)
    {
        var perfilConta = await _perfilContaRepository.GetPerfisContaAsync(contaID);

        return perfilConta;
    }
}
