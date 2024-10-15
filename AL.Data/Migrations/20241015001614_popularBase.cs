using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class popularBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ContaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaID);
                    table.ForeignKey(
                        name: "FK_Categorias_Contas_ContaID",
                        column: x => x.ContaID,
                        principalTable: "Contas",
                        principalColumn: "ContaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimPeriodoFeiras",
                columns: table => new
                {
                    DimPeriodoFeiraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Periodo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimPeriodoFeiras", x => x.DimPeriodoFeiraID);
                });

            migrationBuilder.CreateTable(
                name: "PerfilContas",
                columns: table => new
                {
                    PerfilContaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ContaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilContas", x => x.PerfilContaID);
                    table.ForeignKey(
                        name: "FK_PerfilContas_Contas_ContaID",
                        column: x => x.ContaID,
                        principalTable: "Contas",
                        principalColumn: "ContaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    PerfilContaID = table.Column<int>(type: "int", nullable: false),
                    DimPeriodoFeiraID = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Produtos_DimPeriodoFeiras_DimPeriodoFeiraID",
                        column: x => x.DimPeriodoFeiraID,
                        principalTable: "DimPeriodoFeiras",
                        principalColumn: "DimPeriodoFeiraID",
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
                columns: new[] { "ContaID", "Email", "Senha" },
                values: new object[,]
                {
                    { 1, "yuri@gmail.com", "senha123" },
                    { 2, "marcelo@gmail.com", "senha456" }
                });

            migrationBuilder.InsertData(
                table: "DimPeriodoFeiras",
                columns: new[] { "DimPeriodoFeiraID", "Periodo" },
                values: new object[,]
                {
                    { 1, "Diária" },
                    { 2, "Semanal" },
                    { 3, "Quinzenal" },
                    { 4, "Mensal" }
                });

            migrationBuilder.InsertData(
                table: "PerfilContas",
                columns: new[] { "PerfilContaID", "ContaID", "Nome" },
                values: new object[,]
                {
                    { 1, 1, "Yago" },
                    { 2, 1, "Yuri" },
                    { 3, 2, "Marcelo" },
                    { 4, 2, "Gislene" },
                    { 5, 2, "Lucas" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoID", "CategoriaID", "DimPeriodoFeiraID", "Nome", "PerfilContaID", "Quantidade", "Unidade" },
                values: new object[,]
                {
                    { 1, 4, 2, "Leite", 1, 1, "un" },
                    { 2, 9, 3, "Cacau", 2, 3, "un" },
                    { 3, 3, 4, "Feijão", 4, 5, "un" },
                    { 5, 3, 4, "Arroz", 5, 3, "un" },
                    { 6, 10, 1, "Macarrão", 5, 8, "un" },
                    { 7, 7, 4, "Desinfetante", 3, 1, "un" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ContaID",
                table: "Categorias",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilContas_ContaID",
                table: "PerfilContas",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaID",
                table: "Produtos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_DimPeriodoFeiraID",
                table: "Produtos",
                column: "DimPeriodoFeiraID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PerfilContaID",
                table: "Produtos",
                column: "PerfilContaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "DimPeriodoFeiras");

            migrationBuilder.DropTable(
                name: "PerfilContas");

            migrationBuilder.DeleteData(
                table: "Contas",
                keyColumn: "ContaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contas",
                keyColumn: "ContaID",
                keyValue: 2);
        }
    }
}
