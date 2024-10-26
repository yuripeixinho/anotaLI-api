using AL.Core.Domain;
using AL.Core.Shared.ModelViews.PerfilConta;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;

public class PerfilContaManager : IPerfilContaManager
{
    private readonly IPerfilContaRepository _perfilContaRepository;
    private readonly IContaRepository _contaRepository;

    public PerfilContaManager(IPerfilContaRepository perfilContaRepository, IContaRepository contaRepository)
    {
        _perfilContaRepository = perfilContaRepository;
        _contaRepository = contaRepository;
    }

    public async Task<IEnumerable<PerfilContaView>> GetPerfisContaAsync(string contaID)
    {
        var perfisConta = await _perfilContaRepository.GetPerfisContaAsync(contaID);

        var perfisContaView = perfisConta.Select(p => new PerfilContaView
        {
            Nome = p.Nome,
            PerfilContaID = p.PerfilContaID,
            QtdProdutos = p.Produtos?.Count() ?? 0,
        });

        return perfisContaView;
    }

    public async Task<PerfilContaView> InsertPerfilContaAsync(NovoPerfilConta perfilConta, string contaID)
    {
        PerfilConta novoPerfilConta = new()
        {
            Nome = perfilConta.Nome,
            ContaID = contaID,
        };

        var perfilContaCriada = await _perfilContaRepository.InsertPerfilContaAsync(novoPerfilConta);

        PerfilContaView perfilContaView = new()
        {
            Nome = perfilContaCriada.Nome,
            PerfilContaID = novoPerfilConta.PerfilContaID,
            ContaID = contaID
        };

        return perfilContaView;
    }

    public async Task<PerfilContaView> UpdatePerfilContaAsync(AlterarPerfilConta perfilConta, string contaID, string perfilContaID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);
        var perfilContaExistente = await _perfilContaRepository.GetPerfilContaByIdAsync(perfilContaID);

        if (perfilContaExistente.ContaID != contaID)
            throw new UnauthorizedAccessException("O perfil não pertence à conta fornecida.");

        PerfilConta alterarPerfilConta = new()
        {
            PerfilContaID = perfilContaID,
            ContaID = contaID,  
            Nome = perfilConta.Nome,
        };

        var perfilContaAlterado = await _perfilContaRepository.UpdatePerfilContaAsync(alterarPerfilConta);

        PerfilContaView contaAlterada = new()
        {
            PerfilContaID = perfilContaID,
            ContaID = contaID,
            Nome = perfilConta.Nome,
        };

        return contaAlterada;
    }
}