namespace AL.Core.Shared.ModelViews.Feira;

public class FeiraView
{
        public int FeiraID { get; set; }
        public required string Nome { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime DataFim { get; set; }
}
