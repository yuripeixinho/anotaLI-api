using AL.Core.Domain;
using Microsoft.AspNetCore.Identity;

public class SenhaService
{
    public void CriptografarSenha(Conta conta)
    {
        var passwordHasher = new PasswordHasher<Conta>();
        conta.Senha = passwordHasher.HashPassword(conta, conta.Senha);
    }

    public bool ValidaEAtualizaHashAsync(Conta conta, string hash)
    {
        var passwordHasher = new PasswordHasher<Conta>();
        var resultado = passwordHasher.VerifyHashedPassword(conta, hash, conta.Senha);

        return resultado switch
        {
            PasswordVerificationResult.Failed => false,
            PasswordVerificationResult.Success => true,
            //case PasswordVerificationResult.SuccessRehashNeeded:
            //    await UpdateMedicoAsync(usuario);
            //    return true;
            _ => throw new InvalidOperationException(),
        };
    }

}
