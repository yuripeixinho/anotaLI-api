using AL.Core.Domain;

namespace AL.Manager.Interfaces.Managers;

public interface ICategoriaManager
{
    Task<IEnumerable<Categoria>> GetCategoriasDefaultAsync();
    Task<IEnumerable<Categoria>> GetCategoriasByContaAsync(string contaID);
}
