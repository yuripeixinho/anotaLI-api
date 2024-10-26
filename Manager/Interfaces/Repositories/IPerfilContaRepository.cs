using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;

public interface IPerfilContaRepository
{
    Task<IEnumerable<PerfilConta>> GetPerfisContaAsync(string contaID);
    Task<PerfilConta> GetPerfilContaByIdAsync(string perfilContaID);
    Task<PerfilConta> InsertPerfilContaAsync(PerfilConta conta);
    Task<PerfilConta> UpdatePerfilContaAsync(PerfilConta perfilConta);
}
