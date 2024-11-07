using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;
public interface IFeiraRepository
{
    Task<IEnumerable<Feira>> GetFeirasAsync(string contaID);
    Task<Feira> GetFeiraByIdAsync(int feiraID);
    Task<Feira> InsertNovaFeiraAsync(Feira novaFeira);
    Task<Feira> UpdateFeiraAsync(Feira feira);
    Task DeleteFeiraAsync(int feiraID);
}
