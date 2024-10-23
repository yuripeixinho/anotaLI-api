using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstSQLiteMigrate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8a41c696-20ab-49c3-82ab-3144b5a6239b", "9ca01383-18a5-47dd-9a5c-120e667c927c" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d37619df-bbf3-4b2c-b37b-ff23cf58f8a4", "bb4dc464-b3e9-4c77-854c-2e558f793f4c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
