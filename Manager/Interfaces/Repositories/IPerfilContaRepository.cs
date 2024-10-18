using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;

public interface IPerfilContaRepository
{
    Task<IEnumerable<PerfilConta>> GetPerfisContaAsync(string contaID);
    //Task<PerfilConta> GetPerfilContaAsync(int perfilContaID);
}
