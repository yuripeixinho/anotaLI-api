using AL.Core.Shared.ModelViews.PerfilConta;

namespace AL.Core.Shared.ModelViews.Produto;
public class ProdutoContaView
{
    public int ProdutoID { get; set; }
    public required string Nome { get; set; }
    public required int Quantidade { get; set; }
    public string? Unidade { get; set; }
    public required string Categoria { get; set; }    
    public PerfilContaView? PerfilConta { get; set; }
}
