﻿namespace AL.Core.Shared.ModelViews.PerfilConta;

public class PerfilContaView
{
    public required string PerfilContaID { get; set; }
    public required string Nome { get; set; }
    public int? QtdProdutos { get; set; } 
    public string? ContaID { get; set;  }
}
