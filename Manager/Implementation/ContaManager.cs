using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Conta;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;
using AL.Manager.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace AL.Manager.Implementation;

public class ContaManager : IContaManager
{
    private readonly IContaRepository _contaRepository;
    private readonly IJWTService _jwt;

    public ContaManager(IContaRepository contaRepository, IJWTService jwt)
    {
        _contaRepository = contaRepository;
        _jwt = jwt;

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

    public async Task<ContaLogada> ValidaContaEGeraTokenAsync(Conta conta)
    {
        var contaConsultada = await _contaRepository.GetContaByEmailAsync(conta.Email);

        if(contaConsultada == null) 
            return null;

        if (await ValidaEAtualizaHashAsync(conta, contaConsultada.Senha))
        {
            ContaLogada contaLogadaView = new()
            {
                Email = conta.Email,
            };

            contaLogadaView.Token = _jwt.GerarToken(contaConsultada);

            return contaLogadaView;
        }

        return null;
    }

    private async Task<bool> ValidaEAtualizaHashAsync(Conta conta, string hash)
    {
        var passwordHasher = new PasswordHasher<Conta>();
        var status = passwordHasher.VerifyHashedPassword(conta, hash, conta.Senha);

        switch (status)
        {
            case PasswordVerificationResult.Failed:
                return false;

            case PasswordVerificationResult.Success:
                return true;

            //case PasswordVerificationResult.SuccessRehashNeeded:
            //    await UpdateMedicoAsync(usuario);
            //    return true;

            default:
                throw new InvalidOperationException();
        }
    }


    public async Task<ContaView> GetContaByIdAsync(string id)
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

        ConverteSenhaEmHash(novaContaView);

        return await _contaRepository.InsertContaAsync(novaContaView);
    }

    private static void ConverteSenhaEmHash(Conta conta)
    {
        var passwordHasher = new PasswordHasher<Conta>();
        conta.Senha = passwordHasher.HashPassword(conta, conta.Senha);
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

    public async Task DeleteContaAsync(string id)
    {
        await _contaRepository.DeleteContaAsync(id);
    }


}
