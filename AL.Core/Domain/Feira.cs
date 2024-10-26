namespace AL.Core.Domain;

public class Feira
{
    public int FeiraID { get; set; }
    public required string Nome { get; set; }
    public DateTime DataInicio { get; set; } = DateTime.Now;
    public DateTime DataFim { get; set; }

    public required string ContaID { get; set; }
    public Conta? Conta { get; set; }    
    public IEnumerable<Produto>? Produtos { get; set; }

    public Feira()
    {
        // Define DataFim como o mesmo dia de DataInicio, mas no final do dia
        DataFim = DataInicio.Date.AddDays(1).AddTicks(-1); // Adiciona 1 dia e subtrai 1 nanosegundo
    }
}
