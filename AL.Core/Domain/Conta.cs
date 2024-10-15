namespace AL.Core.Domain;

public class Conta
{
    public int ContaID { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; } 
    public IEnumerable<PerfilConta>? PerfilContas { get; set; }
    public List<Categoria>? Categorias { get; set; }
}
