namespace AL.Core.Domain;
public class PerfilConta
{
    public int PerfilContaID { get; set; }
    public required string Nome { get; set; }

    public required int ContaID { get; set; }
    public Conta Conta { get; set; }

    public List<Produto>? Produtos { get; set; }
}
