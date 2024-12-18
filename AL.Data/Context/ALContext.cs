﻿using AL.Core.Domain;
using AL.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AL.Data.Context;

public class ALContext : IdentityDbContext<Conta>
{
    public ALContext(DbContextOptions<ALContext> options) : base(options)
    {
    }
     // Construtor sem parâmetros para ser usado no design-time
    public ALContext() 
    { 
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Configura o SQLite como banco de dados padrão para migrações
            optionsBuilder.UseSqlite("Data Source=AnotaLi.db");
        }
    }

    public DbSet<Conta> Contas { get; set; }
    public DbSet<PerfilConta> PerfilContas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Feira> Feiras { get; set; }
    public DbSet<Imagem> Imagems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ContaConfiguration());
        modelBuilder.ApplyConfiguration(new PerfilContaConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        modelBuilder.ApplyConfiguration(new FeiraConfiguration());

        modelBuilder.Entity<Imagem>().HasData(
            new Imagem
            {
                Id = 1,
                CaminhoImagem = "/assets/imagens/perfis/anotali/anotaliperfil1.png"
            },
            new Imagem
            {
                Id = 2,
                CaminhoImagem = "/assets/imagens/perfis/anotali/anotaliperfil2.png"
            },
            new Imagem
            {
                Id = 3,
                CaminhoImagem = "/assets/imagens/perfis/anotali/anotaliperfil3.png"
            },
            new Imagem
            {
                Id = 4,
                CaminhoImagem = "/assets/imagens/perfis/anotali/anotaliperfil4.png"
            },
            new Imagem
            {
                Id = 5,
                CaminhoImagem = "/assets/imagens/perfis/anotali/anotaliperfil5.png"
            },
            new Imagem
            {
                Id = 6,
                CaminhoImagem = "/assets/imagens/perfis/anotali/anotaliperfil6.png"
            },
            new Imagem
            {
                Id = 7,
                CaminhoImagem = "/assets/imagens/perfis/anotali/anotaliperfil7.png"
            },
            new Imagem
            {
                Id = 8,
                CaminhoImagem = "/assets/imagens/perfis/animals/animalprofile1.png"
            },
            new Imagem
            {
                Id = 9,
                CaminhoImagem = "/assets/imagens/perfis/animals/animalprofile2.png"
            },
            new Imagem
            {
                Id = 10,
                CaminhoImagem = "/assets/imagens/perfis/animals/animalprofile3.png"
            },
            new Imagem
            {
                Id = 11,
                CaminhoImagem = "/assets/imagens/perfis/animals/animalprofile4.png"
            },
            new Imagem
            {
                Id = 12,
                CaminhoImagem = "/assets/imagens/perfis/animals/animalprofile5.png"
            },
            new Imagem
            {
                Id = 13,
                CaminhoImagem = "/assets/imagens/perfis/animals/animalprofile6.png"
            },
            new Imagem
            {
                Id = 14,
                CaminhoImagem = "/assets/imagens/perfis/animals/animalprofile7.png"
            },
            new Imagem
            {
                Id = 15,
                CaminhoImagem = "/assets/imagens/perfis/animals/animalprofile8.png"
            }
        );

        modelBuilder.Entity<Feira>().HasData(
            new Feira
            {
                FeiraID = 1,
                Nome = "Diária",
                ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now, 
            },
            new Feira
            {
                FeiraID = 2,
                Nome = "Quinzenal",
                ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now,
            },
            new Feira
            {
                FeiraID = 3,
                Nome = "Mensal",
                ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now,
            },
            new Feira
            {
                FeiraID = 4,
                Nome = "Semanal",
                ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now,
            }
        );

        modelBuilder.Entity<Categoria>().HasData(
            new Categoria
            {
                CategoriaID = 1,
                Nome = "Frutas",
            },
            new Categoria
            {
                CategoriaID = 2,
                Nome = "Verduras e Legumes",
            },
            new Categoria
            {
                CategoriaID = 3,
                Nome = "Grãos e Cereais",
            },
            new Categoria
            {
                CategoriaID = 4,
                Nome = "Laticínios",
            },
            new Categoria
            {
                CategoriaID = 5,
                Nome = "Carnes e Peixes",
            },
            new Categoria
            {
                CategoriaID = 6,
                Nome = "Bebidas",
            },
            new Categoria
            {
                CategoriaID = 7,
                Nome = "Produtos de Limpeza",
            },
            new Categoria
            {
                CategoriaID = 8,
                Nome = "Alimentos Enlatados",
            },
            new Categoria
            {
                CategoriaID = 9,
                Nome = "Doces e Sobremesas",
            },
            new Categoria
            {
                CategoriaID = 10,
                Nome = "Pães e Massas",
            },
            new Categoria
            {
                CategoriaID = 11,
                Nome = "Especiarias e Temperos",
            },
            new Categoria
            {
                CategoriaID = 12,
                Nome = "Produtos Congelados",
            },
            new Categoria
            {
                CategoriaID = 13,
                Nome = "Snacks e Petiscos",
            },
            new Categoria
            {
                CategoriaID = 14,
                Nome = "Condimentos",
            },
            new Categoria
            {
                CategoriaID = 15,
                Nome = "Frutos Secos e Sementes",
            }
        );

        modelBuilder.Entity<Conta>().HasData(
            new Conta
            {
                Id = "7318d839-ff36-48fd-92a9-3401ab215121",
                Email = "yuri@gmail.com",
                Senha = "AQAAAAIAAYagAAAAEBetXPkYb4myWCUoS+w53eIcqBtq5un6kzi8EgY5kXkaDWBeGRvmAzIi/JEZpblXRg=="
            },
            new Conta
            {
                Id = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                Email = "marcelo@gmail.com",
                Senha = "AQAAAAIAAYagAAAAEJIK61UE+3YzbIzvKpEXJZQ8+oiG9wKPLw5ntv0x3clwXVh3QnhXSJ5rpvLgduyYAQ=="
            }
        );

        modelBuilder.Entity<PerfilConta>().HasData(
            new PerfilConta
            {
                PerfilContaID = "V4c8jL7x2d",
                Nome = "Yago",
                ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                ImagemPerfilID = 1,
            },
            new PerfilConta
            {
                PerfilContaID = "m3Fz6kQp1W",
                Nome = "Yuri",
                ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                ImagemPerfilID = 1,

            },
            new PerfilConta
            {
                PerfilContaID = "R1n8bY5sXq",
                Nome = "Marcelo",
                ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                ImagemPerfilID = 1,

            },
            new PerfilConta
            {
                PerfilContaID = "uE3jK9d2Fv",
                Nome = "Gislene",
                ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe"
            },
            new PerfilConta
            {
                PerfilContaID = "Z7xqL8mP4H",
                Nome = "Lucas",
                ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe"
            }
        );

        modelBuilder.Entity<Produto>().HasData(
            new Produto
            {
                ProdutoID = 1,
                Nome = "Leite",
                Quantidade = 1,
                Unidade = "un",
                CategoriaID = 4, // Laticínios
                PerfilContaID = "V4c8jL7x2d",
                FeiraID = 1, // Quinzenal
                ContaID = "7318d839-ff36-48fd-92a9-3401ab215121"
            },
            new Produto
            {
                ProdutoID = 2,
                Nome = "Cacau",
                Quantidade = 3,
                Unidade = "un",
                CategoriaID = 9, // Doces e Sobremesas
                PerfilContaID = "m3Fz6kQp1W",
                FeiraID = 3, // Mensal,
                ContaID = "7318d839-ff36-48fd-92a9-3401ab215121"

            },
            new Produto
            {
                ProdutoID = 3,
                Nome = "Feijão",
                Descricao = "preto e carioca",
                Quantidade = 5,
                Unidade = "un",
                CategoriaID = 3, // Grãos e Cereais
                PerfilContaID = "R1n8bY5sXq",
                FeiraID = 4, // Mensal
                ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe"
            },
            new Produto
            {
                ProdutoID = 5,
                Nome = "Arroz",
                Quantidade = 3,
                Unidade = "un",
                CategoriaID = 3, // Grãos e Cereais
                PerfilContaID = "R1n8bY5sXq",
                FeiraID = 4, // Mensal
                ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe"
            },
            new Produto
            {
                ProdutoID = 6,
                Nome = "Macarrão",
                Quantidade = 8,
                Unidade = "un",
                CategoriaID = 10, // Pães e Massas
                PerfilContaID = "uE3jK9d2Fv",
                FeiraID = 2, // Quinzenal
                ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe"
            },
            new Produto
            {
                ProdutoID = 7,
                Nome = "Desinfetante",
                Quantidade = 1,
                Unidade = "un",
                CategoriaID = 7, // Produtos de Limpeza
                PerfilContaID = "Z7xqL8mP4H",
                FeiraID = 4, // Mensal
                ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe"
            }
        );
    }
}
