using AL.Core.Domain;
using Microsoft.AspNetCore.Identity;

public class SenhaService
{
    public void CriptografarSenha(Conta conta)
    {
        var passwordHasher = new PasswordHasher<Conta>();
        conta.Senha = passwordHasher.HashPassword(conta, conta.Senha);
    }

    public async Task<bool> ValidaEAtualizaHashAsync(Conta conta, string hash)
    {
        var passwordHasher = new PasswordHasher<Conta>();
        var resultado = passwordHasher.VerifyHashedPassword(conta, hash, conta.Senha);

        switch (resultado)
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

}
