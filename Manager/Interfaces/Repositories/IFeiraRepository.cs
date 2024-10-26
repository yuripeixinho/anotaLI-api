using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;
public interface IFeiraRepository
{
    Task<IEnumerable<Feira>> GetFeirasAsync(string contaID);
}
