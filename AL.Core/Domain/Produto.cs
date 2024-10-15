namespace AL.Core.Domain;

public class Produto
{
    public int ProdutoID { get; set; }
    public required string Nome { get; set; }
    public required int Quantidade { get; set; }
    public string? Unidade { get; set; }

    public required int CategoriaID { get; set; }
    public Categoria? Categoria { get; set; }
    public required int PerfilContaID { get; set; }
    public PerfilConta? PerfilConta { get; set; }
    public required int DimPeriodoFeiraID { get; set; }
    public DimPeriodoFeira? DimPeriodoFeira { get; set; }
}
