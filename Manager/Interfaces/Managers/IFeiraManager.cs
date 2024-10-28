using AL.Core.Shared.ModelViews.Feira;
using AL.Core.Shared.ModelViews.PerfilConta;

namespace AL.Manager.Interfaces.Managers;

public interface IFeiraManager
{
    Task<IEnumerable<FeiraView>> GetFeirasAsync(string contaID);
    Task<FeiraView> GetFeiraByIdAsync(int feiraID);
    Task<NovaFeira> InsertNovaFeiraAsync(NovaFeira novaFeira, string contaID);
    Task<NovaFeira> UpdateFeiraAsync(NovaFeira novaFeira, int feiraID,  string contaID);
}
