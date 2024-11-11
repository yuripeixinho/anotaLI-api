using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class Imagens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PerfilContaID",
                table: "Produtos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ImagemPerfilId",
                table: "PerfilContas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CaminhoImagem = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "af4ac92c-38ac-4fc6-a821-f66361929580", "32fccbeb-eee1-4316-b299-251bf7deda0b" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c178cb1b-31dc-4f60-9ef3-a1eb447d96a5", "95dadd58-9d0f-4d20-a0e6-8b3180fc226a" });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 1,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 11, 10, 16, 1, 55, 291, DateTimeKind.Local).AddTicks(7123), new DateTime(2024, 11, 10, 16, 1, 55, 291, DateTimeKind.Local).AddTicks(7097) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 2,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 11, 10, 16, 1, 55, 291, DateTimeKind.Local).AddTicks(7133), new DateTime(2024, 11, 10, 16, 1, 55, 291, DateTimeKind.Local).AddTicks(7129) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 3,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 11, 10, 16, 1, 55, 291, DateTimeKind.Local).AddTicks(7143), new DateTime(2024, 11, 10, 16, 1, 55, 291, DateTimeKind.Local).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 4,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 11, 10, 16, 1, 55, 291, DateTimeKind.Local).AddTicks(7152), new DateTime(2024, 11, 10, 16, 1, 55, 291, DateTimeKind.Local).AddTicks(7148) });

            migrationBuilder.InsertData(
                table: "Imagem",
                columns: new[] { "Id", "CaminhoImagem" },
                values: new object[,]
                {
                    { 1, "/imagens/perfil1.jpg" },
                    { 2, "/imagens/perfil2.jpg" },
                    { 3, "/imagens/perfil3.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: "m3Fz6kQp1W",
                column: "ImagemPerfilId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: "R1n8bY5sXq",
                column: "ImagemPerfilId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: "uE3jK9d2Fv",
                column: "ImagemPerfilId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: "V4c8jL7x2d",
                column: "ImagemPerfilId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: "Z7xqL8mP4H",
                column: "ImagemPerfilId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilContas_ImagemPerfilId",
                table: "PerfilContas",
                column: "ImagemPerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilContas_Imagem_ImagemPerfilId",
                table: "PerfilContas",
                column: "ImagemPerfilId",
                principalTable: "Imagem",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfilContas_Imagem_ImagemPerfilId",
                table: "PerfilContas");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropIndex(
                name: "IX_PerfilContas_ImagemPerfilId",
                table: "PerfilContas");

            migrationBuilder.DropColumn(
                name: "ImagemPerfilId",
                table: "PerfilContas");

            migrationBuilder.AlterColumn<string>(
                name: "PerfilContaID",
                table: "Produtos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a26c970-5282-469c-a7a0-a89225740771", "b6b993a2-a4e1-464a-a268-b9be8585bc16" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "21ed7b20-ee37-447c-96a7-2595ca90fb50", "1509eaf8-889d-44c0-8496-8695f693e4bb" });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 1,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 30, 20, 7, 33, 190, DateTimeKind.Local).AddTicks(148), new DateTime(2024, 10, 30, 20, 7, 33, 190, DateTimeKind.Local).AddTicks(131) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 2,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 30, 20, 7, 33, 190, DateTimeKind.Local).AddTicks(150), new DateTime(2024, 10, 30, 20, 7, 33, 190, DateTimeKind.Local).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 3,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 30, 20, 7, 33, 190, DateTimeKind.Local).AddTicks(152), new DateTime(2024, 10, 30, 20, 7, 33, 190, DateTimeKind.Local).AddTicks(151) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 4,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 30, 20, 7, 33, 190, DateTimeKind.Local).AddTicks(153), new DateTime(2024, 10, 30, 20, 7, 33, 190, DateTimeKind.Local).AddTicks(153) });
        }
    }
}
