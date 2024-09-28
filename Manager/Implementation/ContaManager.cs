using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Conta;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;

public class ContaManager : IContaManager
{
    private readonly IContaRepository _contaRepository;

    public ContaManager(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<IEnumerable<ContaView>> GetContasAsync()
    {
        var contas = await _contaRepository.GetContasAsync();

        var contasView = contas.Select(cliente => new ContaView
        {
            ContaID = cliente.ContaID,  
            Email = cliente.Email,
        }).ToList();

        return contasView;
    }

    public async Task<ContaView> GetContaByIdAsync(int id)
    {
        var conta = await _contaRepository.GetContaByIdAsync(id);

        ContaView contaView = new()
        {
            ContaID = conta.ContaID,
            Email = conta.Email,
        };

        return contaView;
    }

    public async Task<Conta> InsertContaAsync(NovaConta conta)
    {
        Conta novaContaView = new Conta
        {
            Email = conta.Email,
            Senha = conta.Senha,
        };

        return await _contaRepository.InsertContaAsync(novaContaView);
    }

    public async Task<Conta> UpdateContaAsync(AlteraConta conta)
    {
        Conta alteraContaView = new Conta
        {
            ContaID = conta.ContaID,
            Email = conta.Email,
            Senha = conta.Senha,
        };

        return await _contaRepository.UpdateContaAsync(alteraContaView);
    }

    public async Task DeleteContaAsync(int id)
    {
        await _contaRepository.DeleteContaAsync(id);
    }
}
