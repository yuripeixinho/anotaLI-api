using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Conta;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;
using AL.Manager.Interfaces.Services;

namespace AL.Manager.Implementation;

public class ContaManager : IContaManager
{
    private readonly IContaRepository _contaRepository;
    private readonly IJWTService _jwt;
    private readonly SenhaService _senhaService;

    public ContaManager(IContaRepository contaRepository, IJWTService jwt, SenhaService senhaService)
    {
        _contaRepository = contaRepository;
        _jwt = jwt;
        _senhaService = senhaService;
    }

    public async Task<IEnumerable<ContaView>> GetContasAsync()
    {
        var contas = await _contaRepository.GetContasAsync();

        var contasView = contas.Select(cliente => new ContaView
        {
            Id = cliente.Id,  
            Email = cliente.Email ?? "",
        }).ToList();

        return contasView;
    }

    public async Task<ContaLogada> ValidaContaEGeraTokenAsync(Conta conta)
    {
        if (string.IsNullOrWhiteSpace(conta.Email))
        {
            throw new ArgumentException("O e-mail não pode ser nulo ou vazio.", nameof(conta));
        }

        var contaConsultada = await _contaRepository.GetContaByEmailAsync(conta.Email) ?? throw new UnauthorizedAccessException("E-mail ou senha incorretos.");

        bool senhaValida =  _senhaService.ValidaEAtualizaHashAsync(conta, contaConsultada.Senha);

        if (!senhaValida)
        {
            throw new UnauthorizedAccessException("E-mail ou senha incorretos.");
        }

        ContaLogada contaLogadaView = new()
        {
            Id = contaConsultada.Id,
            Email = contaConsultada.Email ?? "",
            Token = _jwt.GerarToken(contaConsultada)
        };

        return contaLogadaView;
    }

    public async Task<ContaView> GetContaByIdAsync(string id)
    {
        var conta = await _contaRepository.GetContaByIdAsync(id);

        ContaView contaView = new()
        {
            Id = conta.Id,
            Email = conta?.Email ?? "",
        };

        return contaView;
    }

    public async Task<Conta> InsertContaAsync(NovaConta conta)
    {
        Conta novaContaView = new()
        {
            Email = conta.Email,
            Senha = conta.Senha,
        };

        _senhaService.CriptografarSenha(novaContaView);

        return await _contaRepository.InsertContaAsync(novaContaView);
    }

    public async Task<Conta> UpdateContaAsync(AlteraConta conta)
    {
        Conta alteraContaView = new()
        {
            Id = conta.Id,
            Email = conta.Email,
            Senha = conta.Senha,
        };

        return await _contaRepository.UpdateContaAsync(alteraContaView);
    }

    public async Task DeleteContaAsync(string id)
    {
        await _contaRepository.DeleteContaAsync(id);
    }
}
