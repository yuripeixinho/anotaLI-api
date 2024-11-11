﻿// <auto-generated />
using System;
using AL.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AL.Data.Migrations
{
    [DbContext(typeof(ALContext))]
    [Migration("20241110193256_ImagensRelationship")]
    partial class ImagensRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("AL.Core.Domain.Categoria", b =>
                {
                    b.Property<int>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriaID");

                    b.HasIndex("ContaID");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaID = 1,
                            Nome = "Frutas"
                        },
                        new
                        {
                            CategoriaID = 2,
                            Nome = "Verduras e Legumes"
                        },
                        new
                        {
                            CategoriaID = 3,
                            Nome = "Grãos e Cereais"
                        },
                        new
                        {
                            CategoriaID = 4,
                            Nome = "Laticínios"
                        },
                        new
                        {
                            CategoriaID = 5,
                            Nome = "Carnes e Peixes"
                        },
                        new
                        {
                            CategoriaID = 6,
                            Nome = "Bebidas"
                        },
                        new
                        {
                            CategoriaID = 7,
                            Nome = "Produtos de Limpeza"
                        },
                        new
                        {
                            CategoriaID = 8,
                            Nome = "Alimentos Enlatados"
                        },
                        new
                        {
                            CategoriaID = 9,
                            Nome = "Doces e Sobremesas"
                        },
                        new
                        {
                            CategoriaID = 10,
                            Nome = "Pães e Massas"
                        },
                        new
                        {
                            CategoriaID = 11,
                            Nome = "Especiarias e Temperos"
                        },
                        new
                        {
                            CategoriaID = 12,
                            Nome = "Produtos Congelados"
                        },
                        new
                        {
                            CategoriaID = 13,
                            Nome = "Snacks e Petiscos"
                        },
                        new
                        {
                            CategoriaID = 14,
                            Nome = "Condimentos"
                        },
                        new
                        {
                            CategoriaID = 15,
                            Nome = "Frutos Secos e Sementes"
                        });
                });

            modelBuilder.Entity("AL.Core.Domain.Conta", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Contas", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "7318d839-ff36-48fd-92a9-3401ab215121",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8024e968-d984-43f6-aaac-4e5482ab29da",
                            Email = "yuri@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b530611f-95f1-44cd-86ea-66659cf56b34",
                            Senha = "AQAAAAIAAYagAAAAEBetXPkYb4myWCUoS+w53eIcqBtq5un6kzi8EgY5kXkaDWBeGRvmAzIi/JEZpblXRg==",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eb2cd948-1751-472b-839f-9c3a84bf6eaa",
                            Email = "marcelo@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "daef3eab-be91-4405-b829-7f2a2203eff9",
                            Senha = "AQAAAAIAAYagAAAAEJIK61UE+3YzbIzvKpEXJZQ8+oiG9wKPLw5ntv0x3clwXVh3QnhXSJ5rpvLgduyYAQ==",
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("AL.Core.Domain.Feira", b =>
                {
                    b.Property<int>("FeiraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContaID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("TEXT");

                    b.HasKey("FeiraID");

                    b.HasIndex("ContaID");

                    b.ToTable("Feiras");

                    b.HasData(
                        new
                        {
                            FeiraID = 1,
                            ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                            DataFim = new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9547),
                            DataInicio = new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9514),
                            Nome = "Diária"
                        },
                        new
                        {
                            FeiraID = 2,
                            ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            DataFim = new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9553),
                            DataInicio = new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9552),
                            Nome = "Quinzenal"
                        },
                        new
                        {
                            FeiraID = 3,
                            ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                            DataFim = new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9557),
                            DataInicio = new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9556),
                            Nome = "Mensal"
                        },
                        new
                        {
                            FeiraID = 4,
                            ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            DataFim = new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9561),
                            DataInicio = new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9559),
                            Nome = "Semanal"
                        });
                });

            modelBuilder.Entity("AL.Core.Domain.Imagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CaminhoImagem")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Imagems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CaminhoImagem = "/imagens/perfil1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            CaminhoImagem = "/imagens/perfil2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            CaminhoImagem = "/imagens/perfil3.jpg"
                        });
                });

            modelBuilder.Entity("AL.Core.Domain.PerfilConta", b =>
                {
                    b.Property<string>("PerfilContaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContaID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ImagemPerfilID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.HasKey("PerfilContaID");

                    b.HasIndex("ContaID");

                    b.HasIndex("ImagemPerfilID");

                    b.ToTable("PerfilContas");

                    b.HasData(
                        new
                        {
                            PerfilContaID = "V4c8jL7x2d",
                            ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                            ImagemPerfilID = 1,
                            Nome = "Yago"
                        },
                        new
                        {
                            PerfilContaID = "m3Fz6kQp1W",
                            ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                            ImagemPerfilID = 1,
                            Nome = "Yuri"
                        },
                        new
                        {
                            PerfilContaID = "R1n8bY5sXq",
                            ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            ImagemPerfilID = 1,
                            Nome = "Marcelo"
                        },
                        new
                        {
                            PerfilContaID = "uE3jK9d2Fv",
                            ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            Nome = "Gislene"
                        },
                        new
                        {
                            PerfilContaID = "Z7xqL8mP4H",
                            ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            Nome = "Lucas"
                        });
                });

            modelBuilder.Entity("AL.Core.Domain.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContaID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("FeiraID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("PerfilContaID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Unidade")
                        .HasColumnType("TEXT");

                    b.HasKey("ProdutoID");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("ContaID");

                    b.HasIndex("FeiraID");

                    b.HasIndex("PerfilContaID");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoID = 1,
                            CategoriaID = 4,
                            ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                            FeiraID = 1,
                            Nome = "Leite",
                            PerfilContaID = "V4c8jL7x2d",
                            Quantidade = 1,
                            Unidade = "un"
                        },
                        new
                        {
                            ProdutoID = 2,
                            CategoriaID = 9,
                            ContaID = "7318d839-ff36-48fd-92a9-3401ab215121",
                            FeiraID = 3,
                            Nome = "Cacau",
                            PerfilContaID = "m3Fz6kQp1W",
                            Quantidade = 3,
                            Unidade = "un"
                        },
                        new
                        {
                            ProdutoID = 3,
                            CategoriaID = 3,
                            ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            Descricao = "preto e carioca",
                            FeiraID = 4,
                            Nome = "Feijão",
                            PerfilContaID = "R1n8bY5sXq",
                            Quantidade = 5,
                            Unidade = "un"
                        },
                        new
                        {
                            ProdutoID = 5,
                            CategoriaID = 3,
                            ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            FeiraID = 4,
                            Nome = "Arroz",
                            PerfilContaID = "R1n8bY5sXq",
                            Quantidade = 3,
                            Unidade = "un"
                        },
                        new
                        {
                            ProdutoID = 6,
                            CategoriaID = 10,
                            ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            FeiraID = 2,
                            Nome = "Macarrão",
                            PerfilContaID = "uE3jK9d2Fv",
                            Quantidade = 8,
                            Unidade = "un"
                        },
                        new
                        {
                            ProdutoID = 7,
                            CategoriaID = 7,
                            ContaID = "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                            FeiraID = 4,
                            Nome = "Desinfetante",
                            PerfilContaID = "Z7xqL8mP4H",
                            Quantidade = 1,
                            Unidade = "un"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AL.Core.Domain.Categoria", b =>
                {
                    b.HasOne("AL.Core.Domain.Conta", "Conta")
                        .WithMany("Categorias")
                        .HasForeignKey("ContaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("AL.Core.Domain.Feira", b =>
                {
                    b.HasOne("AL.Core.Domain.Conta", "Conta")
                        .WithMany("Feiras")
                        .HasForeignKey("ContaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("AL.Core.Domain.PerfilConta", b =>
                {
                    b.HasOne("AL.Core.Domain.Conta", "Conta")
                        .WithMany("PerfilContas")
                        .HasForeignKey("ContaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AL.Core.Domain.Imagem", "ImagemPerfil")
                        .WithMany()
                        .HasForeignKey("ImagemPerfilID");

                    b.Navigation("Conta");

                    b.Navigation("ImagemPerfil");
                });

            modelBuilder.Entity("AL.Core.Domain.Produto", b =>
                {
                    b.HasOne("AL.Core.Domain.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AL.Core.Domain.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AL.Core.Domain.Feira", "Feira")
                        .WithMany("Produtos")
                        .HasForeignKey("FeiraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AL.Core.Domain.PerfilConta", "PerfilConta")
                        .WithMany("Produtos")
                        .HasForeignKey("PerfilContaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Categoria");

                    b.Navigation("Conta");

                    b.Navigation("Feira");

                    b.Navigation("PerfilConta");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AL.Core.Domain.Conta", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AL.Core.Domain.Conta", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AL.Core.Domain.Conta", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AL.Core.Domain.Conta", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AL.Core.Domain.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("AL.Core.Domain.Conta", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Feiras");

                    b.Navigation("PerfilContas");
                });

            modelBuilder.Entity("AL.Core.Domain.Feira", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("AL.Core.Domain.PerfilConta", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
