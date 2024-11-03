using AL.Core.Domain;
using AL.Core.Shared.ModelViews.Produto;

namespace AL.Core.Shared.ModelViews.Feira;

public class FeiraView
{
        public int FeiraID { get; set; }
        public required string Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public IEnumerable<ProdutoContaView>? Produtos { get; set; } 
}
