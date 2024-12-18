﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imagems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaminhoImagem = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Contas_UserId",
                        column: x => x.UserId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Contas_UserId",
                        column: x => x.UserId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Contas_UserId",
                        column: x => x.UserId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Contas_UserId",
                        column: x => x.UserId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    ContaID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaID);
                    table.ForeignKey(
                        name: "FK_Categorias_Contas_ContaID",
                        column: x => x.ContaID,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feiras",
                columns: table => new
                {
                    FeiraID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ContaID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feiras", x => x.FeiraID);
                    table.ForeignKey(
                        name: "FK_Feiras_Contas_ContaID",
                        column: x => x.ContaID,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilContas",
                columns: table => new
                {
                    PerfilContaID = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    ContaID = table.Column<string>(type: "TEXT", nullable: false),
                    ImagemPerfilID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilContas", x => x.PerfilContaID);
                    table.ForeignKey(
                        name: "FK_PerfilContas_Contas_ContaID",
                        column: x => x.ContaID,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilContas_Imagems_ImagemPerfilID",
                        column: x => x.ImagemPerfilID,
                        principalTable: "Imagems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Unidade = table.Column<string>(type: "TEXT", nullable: true),
                    ContaID = table.Column<string>(type: "TEXT", nullable: false),
                    CategoriaID = table.Column<int>(type: "INTEGER", nullable: false),
                    PerfilContaID = table.Column<string>(type: "TEXT", nullable: true),
                    FeiraID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoID);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Contas_ContaID",
                        column: x => x.ContaID,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Feiras_FeiraID",
                        column: x => x.FeiraID,
                        principalTable: "Feiras",
                        principalColumn: "FeiraID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_PerfilContas_PerfilContaID",
                        column: x => x.PerfilContaID,
                        principalTable: "PerfilContas",
                        principalColumn: "PerfilContaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaID", "ContaID", "Nome" },
                values: new object[,]
                {
                    { 1, null, "Frutas" },
                    { 2, null, "Verduras e Legumes" },
                    { 3, null, "Grãos e Cereais" },
                    { 4, null, "Laticínios" },
                    { 5, null, "Carnes e Peixes" },
                    { 6, null, "Bebidas" },
                    { 7, null, "Produtos de Limpeza" },
                    { 8, null, "Alimentos Enlatados" },
                    { 9, null, "Doces e Sobremesas" },
                    { 10, null, "Pães e Massas" },
                    { 11, null, "Especiarias e Temperos" },
                    { 12, null, "Produtos Congelados" },
                    { 13, null, "Snacks e Petiscos" },
                    { 14, null, "Condimentos" },
                    { 15, null, "Frutos Secos e Sementes" }
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Senha", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", 0, "b9b68e36-660d-4e11-9a0b-159eb6458ab3", "marcelo@gmail.com", false, false, null, null, null, null, null, false, "38879ef6-e268-4120-b7f7-faab920a5061", "AQAAAAIAAYagAAAAEJIK61UE+3YzbIzvKpEXJZQ8+oiG9wKPLw5ntv0x3clwXVh3QnhXSJ5rpvLgduyYAQ==", false, null },
                    { "7318d839-ff36-48fd-92a9-3401ab215121", 0, "b7a48aab-ce70-41e0-bc5d-b17b0aa125f8", "yuri@gmail.com", false, false, null, null, null, null, null, false, "f9bc400f-98ac-4e8c-9180-0d9485c025f4", "AQAAAAIAAYagAAAAEBetXPkYb4myWCUoS+w53eIcqBtq5un6kzi8EgY5kXkaDWBeGRvmAzIi/JEZpblXRg==", false, null }
                });

            migrationBuilder.InsertData(
                table: "Imagems",
                columns: new[] { "Id", "CaminhoImagem" },
                values: new object[,]
                {
                    { 1, "/assets/imagens/perfis/anotali/anotaliperfil1.png" },
                    { 2, "/assets/imagens/perfis/anotali/anotaliperfil2.png" },
                    { 3, "/assets/imagens/perfis/anotali/anotaliperfil3.png" },
                    { 4, "/assets/imagens/perfis/anotali/anotaliperfil4.png" },
                    { 5, "/assets/imagens/perfis/anotali/anotaliperfil5.png" },
                    { 6, "/assets/imagens/perfis/anotali/anotaliperfil6.png" },
                    { 7, "/assets/imagens/perfis/anotali/anotaliperfil7.png" },
                    { 8, "/assets/imagens/perfis/animals/animalprofile1.png" },
                    { 9, "/assets/imagens/perfis/animals/animalprofile2.png" },
                    { 10, "/assets/imagens/perfis/animals/animalprofile3.png" },
                    { 11, "/assets/imagens/perfis/animals/animalprofile4.png" },
                    { 12, "/assets/imagens/perfis/animals/animalprofile5.png" },
                    { 13, "/assets/imagens/perfis/animals/animalprofile6.png" },
                    { 14, "/assets/imagens/perfis/animals/animalprofile7.png" },
                    { 15, "/assets/imagens/perfis/animals/animalprofile8.png" }
                });

            migrationBuilder.InsertData(
                table: "Feiras",
                columns: new[] { "FeiraID", "ContaID", "DataFim", "DataInicio", "Nome" },
                values: new object[,]
                {
                    { 1, "7318d839-ff36-48fd-92a9-3401ab215121", new DateTime(2024, 11, 12, 20, 4, 21, 682, DateTimeKind.Local).AddTicks(1349), new DateTime(2024, 11, 12, 20, 4, 21, 682, DateTimeKind.Local).AddTicks(1330), "Diária" },
                    { 2, "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", new DateTime(2024, 11, 12, 20, 4, 21, 682, DateTimeKind.Local).AddTicks(1350), new DateTime(2024, 11, 12, 20, 4, 21, 682, DateTimeKind.Local).AddTicks(1350), "Quinzenal" },
                    { 3, "7318d839-ff36-48fd-92a9-3401ab215121", new DateTime(2024, 11, 12, 20, 4, 21, 682, DateTimeKind.Local).AddTicks(1352), new DateTime(2024, 11, 12, 20, 4, 21, 682, DateTimeKind.Local).AddTicks(1351), "Mensal" },
                    { 4, "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", new DateTime(2024, 11, 12, 20, 4, 21, 682, DateTimeKind.Local).AddTicks(1353), new DateTime(2024, 11, 12, 20, 4, 21, 682, DateTimeKind.Local).AddTicks(1353), "Semanal" }
                });

            migrationBuilder.InsertData(
                table: "PerfilContas",
                columns: new[] { "PerfilContaID", "ContaID", "ImagemPerfilID", "Nome" },
                values: new object[,]
                {
                    { "m3Fz6kQp1W", "7318d839-ff36-48fd-92a9-3401ab215121", 1, "Yuri" },
                    { "R1n8bY5sXq", "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", 1, "Marcelo" },
                    { "uE3jK9d2Fv", "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", null, "Gislene" },
                    { "V4c8jL7x2d", "7318d839-ff36-48fd-92a9-3401ab215121", 1, "Yago" },
                    { "Z7xqL8mP4H", "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", null, "Lucas" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoID", "CategoriaID", "ContaID", "Descricao", "FeiraID", "Nome", "PerfilContaID", "Quantidade", "Unidade" },
                values: new object[,]
                {
                    { 1, 4, "7318d839-ff36-48fd-92a9-3401ab215121", null, 1, "Leite", "V4c8jL7x2d", 1, "un" },
                    { 2, 9, "7318d839-ff36-48fd-92a9-3401ab215121", null, 3, "Cacau", "m3Fz6kQp1W", 3, "un" },
                    { 3, 3, "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", "preto e carioca", 4, "Feijão", "R1n8bY5sXq", 5, "un" },
                    { 5, 3, "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", null, 4, "Arroz", "R1n8bY5sXq", 3, "un" },
                    { 6, 10, "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", null, 2, "Macarrão", "uE3jK9d2Fv", 8, "un" },
                    { 7, 7, "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", null, 4, "Desinfetante", "Z7xqL8mP4H", 1, "un" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ContaID",
                table: "Categorias",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Contas",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Contas",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feiras_ContaID",
                table: "Feiras",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilContas_ContaID",
                table: "PerfilContas",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilContas_ImagemPerfilID",
                table: "PerfilContas",
                column: "ImagemPerfilID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaID",
                table: "Produtos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ContaID",
                table: "Produtos",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FeiraID",
                table: "Produtos",
                column: "FeiraID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PerfilContaID",
                table: "Produtos",
                column: "PerfilContaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Feiras");

            migrationBuilder.DropTable(
                name: "PerfilContas");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Imagems");
        }
    }
}
