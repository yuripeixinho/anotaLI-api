using AL.Core.Domain;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;
public class CategoriaManager : ICategoriaManager
{
    private readonly ICategoriaRepository _categoriaRepository;  

    public CategoriaManager(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository; 
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasDefaultAsync()
    {
        return await _categoriaRepository.GetCategoriasDefaultAsync();
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasByContaAsync(string contaID)
    {
        return await _categoriaRepository.GetCategoriasByContaAsync(contaID);
    }
}
