using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Conta;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;

public class ContaManager : IContaManager
{
    private readonly IContaRepository _contaRepository;

    public ContaManager(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<IEnumerable<Conta>> GetContasAsync()
    {
        var contas = await _contaRepository.GetContasAsync();
        return contas;
    }

    public async Task<ContaView> GetContaByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

}
