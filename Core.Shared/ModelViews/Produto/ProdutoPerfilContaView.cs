using AL.Core.Shared.ModelViews.Categoria;
using AL.Core.Shared.ModelViews.PerfilConta;

namespace AL.Core.Shared.ModelViews.Produto;

public class ProdutoPerfilContaView
{
    public int ProdutoID { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required int Quantidade { get; set; }
    public string? Unidade { get; set; }
    public string? QuantidadeUnidade { get; set; } 
    public required CategoriaView Categoria { get; set; }
    public PerfilContaView PerfilConta {get;set;}
}
