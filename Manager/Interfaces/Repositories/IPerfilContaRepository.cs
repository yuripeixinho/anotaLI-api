using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;

public interface IPerfilContaRepository
{
    Task<IEnumerable<PerfilConta>> GetPerfisContaAsync(int contaID);
}
