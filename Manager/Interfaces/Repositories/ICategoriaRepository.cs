using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetCategoriasDefaultAsync();
    Task<IEnumerable<Categoria>> GetCategoriasByContaAsync(int contaID);
}
