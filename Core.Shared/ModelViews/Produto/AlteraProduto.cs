namespace AL.Core.Shared.ModelViews.Produto;

public class AlteraProduto
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int? Quantidade { get; set; }
    public string? Unidade { get; set; }

    public int? CategoriaID { get; set; }
    public string? PerfilContaID { get; set; }
    public int? FeiraID { get; set; }
}
