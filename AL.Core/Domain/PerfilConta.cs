namespace AL.Core.Domain;
public class PerfilConta(Conta conta)
{
    public int PerfilContaID { get; set; }
    public required string Nome { get; set; }

    public required string ContaID { get; set; }
    public required Conta Conta { get; set; } = conta ?? throw new ArgumentNullException(nameof(conta));

    public List<Produto>? Produtos { get; set; }
}
