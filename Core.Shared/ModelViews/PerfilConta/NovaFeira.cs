using AL.Core.Shared.ModelViews.Produto;

namespace AL.Core.Shared.ModelViews.PerfilConta;

public class NovaFeira
{
    public int FeiraID { get; set; }
    public required string Nome { get; set; }
    public DateTime? DataInicio { get; set; }    
    public DateTime? DataFim { get; set; }
    public List<NovoProduto>? Produto {get ;set; }
}
