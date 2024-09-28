using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Conta;

namespace AL.Manager.Interfaces.Managers;

public interface IContaManager
{
    Task<IEnumerable<Conta>> GetContasAsync();
    Task<ContaView> GetContaByIdAsync(int id);
}
