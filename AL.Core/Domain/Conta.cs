using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AL.Core.Domain;

public class Conta : IdentityUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? ContaID { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; } 
    public IEnumerable<PerfilConta>? PerfilContas { get; set; }
    public List<Categoria>? Categorias { get; set; }
}
