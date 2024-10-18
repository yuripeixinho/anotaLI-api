using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;

public interface IContaRepository
{
    Task<IEnumerable<Conta>> GetContasAsync();
    Task<Conta> GetContaByIdAsync(string id);
    Task<Conta> InsertContaAsync(Conta conta);
    Task<Conta> UpdateContaAsync(Conta conta);
    Task DeleteContaAsync(string id);
    Task<Conta> GetContaByEmailAsync(string email);
}

public interface IContaValidationRepository
{
    Conta GetContaValidationByEmailAsync(string email);
}

