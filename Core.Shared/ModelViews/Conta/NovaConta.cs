using AL.Core.Shared.ModelViews.PerfilConta;

namespace AL.Core.Shared.ModelViews.Conta;

public class NovaConta
{
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public required NovoPerfilConta PerfilConta { get; set; }   
}
