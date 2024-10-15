namespace AL.Core.Shared.ModelViews.Produto;

public class ProdutoPerfilContaView
{
    public int ProdutoID { get; set; }
    public required string Nome { get; set; }
    public required int Quantidade { get; set; }
    public string? Unidade { get; set; }
    public required string Categoria { get; set; }
}
