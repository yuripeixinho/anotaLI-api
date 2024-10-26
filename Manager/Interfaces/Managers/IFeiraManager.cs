using AL.Core.Shared.ModelViews.Feira;

namespace AL.Manager.Interfaces.Managers;

public interface IFeiraManager
{
    Task<IEnumerable<FeiraView>> GetFeirasAsync(string contaID);

}
