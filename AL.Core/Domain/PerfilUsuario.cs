namespace AL.Core.Domain;
public class PerfilConta
{
    public int PerfilContaID { get; set; }
    public required string Nome { get; set; }

    public int ContaID { get; set; }
    public required Conta Conta { get; set; }
}
