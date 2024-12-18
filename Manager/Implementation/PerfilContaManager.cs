﻿using AL.Core.Domain;
using AL.Core.Exceptions;
using AL.Core.Shared.ModelViews.Categoria;
using AL.Core.Shared.ModelViews.Feira;
using AL.Core.Shared.ModelViews.Imagens;
using AL.Core.Shared.ModelViews.PerfilConta;
using AL.Core.Shared.ModelViews.Produto;
using AL.Manager.Interfaces.Managers;
using AL.Manager.Interfaces.Repositories;

namespace AL.Manager.Implementation;

public class PerfilContaManager : IPerfilContaManager
{
    private readonly IPerfilContaRepository _perfilContaRepository;
    private readonly IContaRepository _contaRepository;

    public PerfilContaManager(IPerfilContaRepository perfilContaRepository, IContaRepository contaRepository)
    {
        _perfilContaRepository = perfilContaRepository;
        _contaRepository = contaRepository;
    }

    public async Task<IEnumerable<PerfilContaView>> GetPerfisContaAsync(string contaID)
    {
        var perfisConta = await _perfilContaRepository.GetPerfisContaAsync(contaID);

        var perfisContaView = perfisConta.Select(p => new PerfilContaView
        {
            Nome = p.Nome,
            PerfilContaID = p.PerfilContaID,
            QtdProdutos = p.Produtos?.Count() ?? 0,
            ImagemPerfil = p.ImagemPerfil != null 
                ? new ImagemView 
                {
                    CaminhoImagem = p.ImagemPerfil.CaminhoImagem, 
                    Id = p.ImagemPerfil.Id
                } 
                : null,
        });

        return perfisContaView;
    }

    public async Task<PerfilContaView> GetPerfilContaByIdAsync(string perfilContaID)
    {
        var perfilConta = await _perfilContaRepository.GetPerfilContaByIdAsync(perfilContaID);

        PerfilContaView perfilContaView = new()
        {
            Nome = perfilConta.Nome,
            PerfilContaID = perfilConta.PerfilContaID,
            ContaID = perfilConta.ContaID,
            ImagemPerfil = perfilConta.ImagemPerfil != null 
                ? new ImagemView 
                {
                    CaminhoImagem = perfilConta.ImagemPerfil.CaminhoImagem, 
                    Id = perfilConta.ImagemPerfil.Id
                } 
                : null,
            Produtos = perfilConta.Produtos?.Select(produto
                => new ProdutoContaView
                {
                    ProdutoID = produto.ProdutoID,
                    Quantidade = produto.Quantidade,
                    FeiraID = produto.FeiraID,
                    Descricao = produto.Descricao,  
                    PerfilContaID = produto.PerfilContaID,
                    Feira = new FeiraView { FeiraID = produto.Feira.FeiraID, Nome = produto.Feira.Nome  },
                    Nome = produto.Nome,
                    Categoria = new CategoriaView { Nome = produto.Categoria?.Nome ?? "", CategoriaID = produto.CategoriaID }

                }).ToList(),
        };

        return perfilContaView;
    }

    public async Task<PerfilContaView> InsertPerfilContaAsync(NovoPerfilConta perfilConta, string contaID)
    {
        PerfilConta novoPerfilConta = new()
        {
            Nome = perfilConta.Nome,
            ContaID = contaID,
        };

        var perfilContaCriada = await _perfilContaRepository.InsertPerfilContaAsync(novoPerfilConta);

        PerfilContaView perfilContaView = new()
        {
            Nome = perfilContaCriada.Nome,
            PerfilContaID = novoPerfilConta.PerfilContaID,
            ContaID = contaID
        };

        return perfilContaView;
    }

    public async Task<PerfilContaView> UpdatePerfilContaAsync(AlterarPerfilConta perfilConta, string contaID, string perfilContaID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);
        var perfilContaExistente = await _perfilContaRepository.GetPerfilContaByIdAsync(perfilContaID);

        if (perfilContaExistente.ContaID != contaID)
            throw new UnauthorizedAccessException("O perfil não pertence à conta fornecida.");

        PerfilConta alterarPerfilConta = new()
        {
            PerfilContaID = perfilContaID,
            ContaID = contaID,  
            Nome = perfilConta.Nome,
            ImagemPerfilID = perfilConta.ImagemPerfilID
        };

        var perfilContaAlterado = await _perfilContaRepository.UpdatePerfilContaAsync(alterarPerfilConta);

        PerfilContaView contaAlterada = new()
        {
            PerfilContaID = perfilContaID,
            ContaID = contaID,
            Nome = perfilContaAlterado.Nome,
            ImagemPerfil = perfilContaAlterado.ImagemPerfil != null 
                ? new ImagemView 
                {
                    CaminhoImagem = perfilContaAlterado.ImagemPerfil.CaminhoImagem, 
                    Id = perfilContaAlterado.ImagemPerfil.Id
                } 
                : null,
        };

        return contaAlterada;
    }

    public async Task DeletePerfilContaAsync(string contaID, string contaPerfilID)
    {
        var contaExistente = await _contaRepository.GetContaByIdAsync(contaID);
        if (contaExistente == null)
            throw new NotFoundException("Conta não encontrada.");

        var perfilContaIDExistente = await _perfilContaRepository.GetPerfilContaByIdAsync(contaPerfilID);
        if (perfilContaIDExistente == null)
            throw new NotFoundException("Conta não encontrada.");

        if (perfilContaIDExistente.ContaID != contaID)
            throw new NotFoundException("O Perfil não pertence à conta fornecida.");

        await _perfilContaRepository.DeletePerfilContaAsync(contaPerfilID);
    }
}