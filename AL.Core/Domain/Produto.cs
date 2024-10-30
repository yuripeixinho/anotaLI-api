namespace AL.Core.Domain;

public class Produto
{
    public int ProdutoID { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required int Quantidade { get; set; }
    public string? Unidade { get; set; }

    public required string ContaID { get; set; }
    public Conta? Conta { get; set; }   
    public required int CategoriaID { get; set; }
    public Categoria? Categoria { get; set; }
    public required string PerfilContaID { get; set; }
    public PerfilConta? PerfilConta { get; set; }
    public required int FeiraID { get; set; }
    public Feira? Feira { get; set; }
}
