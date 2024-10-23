using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstSQLiteMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "483275e3-bc81-402e-afdf-cfac213c9b6c", "d8b83f07-f14f-4b33-8a82-e318b963aa9b" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a94589ac-82c9-4e43-8cb5-c27ded178389", "6cb6b3d8-17a7-48b6-adea-09ee57a91da5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "02874997-c8af-49e3-bf92-074a8c070746", "3d0c4799-c149-46c8-bfcc-a827b9ee75ec" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f87f588d-0904-4ef3-8a8c-c5f1985f8dbb", "c6068222-f796-491b-9978-935c7084d64e" });

            migrationBuilder.InsertData(
                table: "PerfilContas",
                columns: new[] { "PerfilContaID", "ContaID", "Nome" },
                values: new object[,]
                {
                    { 1, "7318d839-ff36-48fd-92a9-3401ab215121", "Yago" },
                    { 2, "7318d839-ff36-48fd-92a9-3401ab215121", "Yuri" },
                    { 3, "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", "Marcelo" },
                    { 4, "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", "Gislene" },
                    { 5, "2e81ad9b-54d4-4c3f-b6e7-0987654321fe", "Lucas" }
                });
        }
    }
}
