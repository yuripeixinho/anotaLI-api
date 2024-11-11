using AL.Core.Shared.ModelViews.Categoria;
using AL.Core.Shared.ModelViews.Feira;
using AL.Core.Shared.ModelViews.PerfilConta;

namespace AL.Core.Shared.ModelViews.Produto;
public class ProdutoContaView
{
    public int ProdutoID { get; set; }
    public int FeiraID { get; set; }    
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required int Quantidade { get; set; }
    public string? Unidade { get; set; }
    public required string PerfilContaID { get; set; }    
    public string? QuantidadeUnidade { get; set; }
    public int? CategoriaID { get; set; }
    public PerfilContaView? PerfilConta { get; set; }
    public CategoriaView? Categoria {get;set;}
    public FeiraView? Feira { get; set; }
}
