using AL.Core.Domain;

namespace AL.Manager.Interfaces.Services;

public interface IJWTService
{
    string GerarToken(Conta conta);
}
