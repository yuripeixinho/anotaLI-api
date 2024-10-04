using AL.Core.Domain;

namespace AL.Manager.Interfaces.Managers;

public interface IPerfilContaManager
{
    Task<IEnumerable<PerfilConta>> GetPerfisContaAsync(int contaID);

}
