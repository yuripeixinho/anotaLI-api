using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstSQLiteMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "13945932-178a-449a-925f-e61166a75304", "d8d2a800-e99f-42c1-a659-df69f00e4eae" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2ac452c4-9649-4c4f-8e01-87a39da23685", "de81e126-5436-43c1-8e23-e02ae3d49991" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
