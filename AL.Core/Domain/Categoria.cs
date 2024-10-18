namespace AL.Core.Domain;

public class Categoria
{
    public int CategoriaID { get; set; }
    public required string Nome { get; set; }

    public List<Produto>? Produtos { get; set; }

    public string? ContaID { get; set; }
    public Conta? Conta { get; set; }    
}
