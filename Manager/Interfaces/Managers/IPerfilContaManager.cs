using AL.Core.Shared.ModelViews.PerfilConta;

namespace AL.Manager.Interfaces.Managers;

public interface IPerfilContaManager
{
    Task<IEnumerable<PerfilContaView>> GetPerfisContaAsync(int contaID);
}
