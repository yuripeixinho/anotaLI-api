namespace AL.Core.Shared.ModelViews.Produto;

public class NovoProduto
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required int Quantidade { get; set; }
    public string? Unidade { get; set; }

    public required int CategoriaID { get; set; }
    public required string PerfilContaID { get; set; }
    public required int FeiraID { get; set; }
}
