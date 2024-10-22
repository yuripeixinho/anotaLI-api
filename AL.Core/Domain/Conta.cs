using Microsoft.AspNetCore.Identity;

namespace AL.Core.Domain;

public class Conta : IdentityUser
{
    public required string Senha { get; set; } 
    public IEnumerable<PerfilConta>? PerfilContas { get; set; }
    public List<Categoria>? Categorias { get; set; }
}
