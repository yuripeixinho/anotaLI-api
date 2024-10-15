﻿using AL.Core.Domain;

namespace AL.Manager.Interfaces.Repositories;
public interface IProdutoRepository
{
    Task<List<Produto>> GetProdutosByContaAsync(int contaID);
    Task<List<Produto>> GetProdutosByPerfilContasAsync(int perfilContaID);
    Task<IEnumerable<Produto>> FiltrarFeirasPorPeriodosAsync(IEnumerable<int> periodoIDs);
}