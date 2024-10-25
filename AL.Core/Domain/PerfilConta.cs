using NanoidDotNet;

namespace AL.Core.Domain;
public class PerfilConta
{
    public string PerfilContaID { get; set; } = Nanoid.Generate(size: 10);
    public required string Nome { get; set; }

    public required string ContaID { get; set; }
    public Conta? Conta { get; set; }

    public List<Produto>? Produtos { get; set; }
}
