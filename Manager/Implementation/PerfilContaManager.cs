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

    public async Task<IEnumerable<PerfilContaView>> GetPerfisContaAsync(string contaID)
    {
        var perfisConta = await _perfilContaRepository.GetPerfisContaAsync(contaID);

        var perfisContaView = perfisConta.Select(p => new PerfilContaView
        {
            Nome = p.Nome,
            PerfilContaID = p.PerfilContaID,
            QtdProdutos = p.Produtos?.Count() ?? 0, 
        });

        return perfisContaView;
    }
}
