namespace AL.Core.Domain;

public class Feira
{
    public int FeiraID { get; set; }
    public required string Nome { get; set; }


    public required string ContaID { get; set; }
    public Conta? Conta { get; set; }    
    public IEnumerable<Produto>? Produtos { get; set; }   
}
