using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class DescricaoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "64b1b831-1963-4e0b-8af7-860d14c98d60", "18461a6c-2122-4a83-9ec1-c377ba7dfced" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d74749de-732b-42dd-b72c-a937b0b4202d", "647f8b2a-59dd-496d-8518-fa48f4a3b594" });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 1,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 30, 19, 21, 4, 156, DateTimeKind.Local).AddTicks(5837), new DateTime(2024, 10, 30, 19, 21, 4, 156, DateTimeKind.Local).AddTicks(5821) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 2,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 30, 19, 21, 4, 156, DateTimeKind.Local).AddTicks(5840), new DateTime(2024, 10, 30, 19, 21, 4, 156, DateTimeKind.Local).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 3,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 30, 19, 21, 4, 156, DateTimeKind.Local).AddTicks(5842), new DateTime(2024, 10, 30, 19, 21, 4, 156, DateTimeKind.Local).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 4,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 30, 19, 21, 4, 156, DateTimeKind.Local).AddTicks(5843), new DateTime(2024, 10, 30, 19, 21, 4, 156, DateTimeKind.Local).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoID",
                keyValue: 1,
                column: "Descricao",
                value: null);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoID",
                keyValue: 2,
                column: "Descricao",
                value: null);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoID",
                keyValue: 3,
                column: "Descricao",
                value: null);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoID",
                keyValue: 5,
                column: "Descricao",
                value: null);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoID",
                keyValue: 6,
                column: "Descricao",
                value: null);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoID",
                keyValue: 7,
                column: "Descricao",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Produtos");

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "71eff823-3ff1-401a-96f2-c174a01025e1", "01c69407-f4f6-46c2-8162-21e3b673afea" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0ac64906-2fd4-4f38-96b0-a42abbae1b14", "c0c51c1a-af08-4ad8-961d-b699472aa5d6" });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 1,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 28, 23, 12, 19, 651, DateTimeKind.Local).AddTicks(995), new DateTime(2024, 10, 28, 23, 12, 19, 651, DateTimeKind.Local).AddTicks(977) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 2,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 28, 23, 12, 19, 651, DateTimeKind.Local).AddTicks(997), new DateTime(2024, 10, 28, 23, 12, 19, 651, DateTimeKind.Local).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 3,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 28, 23, 12, 19, 651, DateTimeKind.Local).AddTicks(999), new DateTime(2024, 10, 28, 23, 12, 19, 651, DateTimeKind.Local).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 4,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 28, 23, 12, 19, 651, DateTimeKind.Local).AddTicks(1001), new DateTime(2024, 10, 28, 23, 12, 19, 651, DateTimeKind.Local).AddTicks(1000) });
        }
    }
}
