using System.ComponentModel.DataAnnotations;

namespace AL.Core.Domain;

public class Feira
{
    [Key]
    public int FeiraID { get; set; }
    public required string Nome { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }
    public required string ContaID { get; set; }
    public Conta? Conta { get; set; }    
    public IEnumerable<Produto>? Produtos { get; set; }
}
