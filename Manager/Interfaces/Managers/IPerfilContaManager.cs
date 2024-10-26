﻿using AL.Core.Shared.ModelViews.PerfilConta;

namespace AL.Manager.Interfaces.Managers;

public interface IPerfilContaManager
{
    Task<IEnumerable<PerfilContaView>> GetPerfisContaAsync(string contaID);
    Task<PerfilContaView> InsertPerfilContaAsync(NovoPerfilConta perfilConta, string contaID);
    Task<PerfilContaView> UpdatePerfilContaAsync(AlterarPerfilConta perfilConta, string contaID, string perfilContaID);
}
