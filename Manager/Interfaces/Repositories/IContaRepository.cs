using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;

public interface IContaRepository
{
    Task<IEnumerable<Conta>> GetContasAsync();
    Task<Conta> GetContaByIdAsync(int id);
    Task<Conta> InsertContaAsync(Conta conta);
    Task<Conta> UpdateContaAsync(Conta conta);
    Task DeleteContaAsync(int id);
}
