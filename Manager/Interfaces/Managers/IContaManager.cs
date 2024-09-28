using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Conta;

namespace AL.Manager.Interfaces.Managers;

public interface IContaManager
{
    Task<IEnumerable<ContaView>> GetContasAsync();
    Task<ContaView> GetContaByIdAsync(int id);
    Task<Conta> InsertContaAsync(NovaConta conta);
    Task<Conta> UpdateContaAsync(AlteraConta conta);
    Task DeleteContaAsync(int id);
}
