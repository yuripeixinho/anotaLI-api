using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class dataFeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "Feiras",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Feiras",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "48ede5cd-8639-40b8-abd1-88f05ca7656c", "d4605b87-0067-4a49-8a42-dcdc97da0b41" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2df0d5af-3345-4227-ba62-e92af64f1024", "7a96396b-536c-41f4-88f3-4fb216c03616" });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 1,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 25, 23, 59, 59, 999, DateTimeKind.Local).AddTicks(9999), new DateTime(2024, 10, 25, 20, 25, 11, 909, DateTimeKind.Local).AddTicks(2072) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 2,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 25, 23, 59, 59, 999, DateTimeKind.Local).AddTicks(9999), new DateTime(2024, 10, 25, 20, 25, 11, 909, DateTimeKind.Local).AddTicks(2094) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 3,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 25, 23, 59, 59, 999, DateTimeKind.Local).AddTicks(9999), new DateTime(2024, 10, 25, 20, 25, 11, 909, DateTimeKind.Local).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 4,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 10, 25, 23, 59, 59, 999, DateTimeKind.Local).AddTicks(9999), new DateTime(2024, 10, 25, 20, 25, 11, 909, DateTimeKind.Local).AddTicks(2097) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "Feiras");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Feiras");

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "070011a7-9dc8-4c92-95a2-27f7fb09beac", "a8899307-6376-4989-8e30-4d06bbebf201" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "703589b1-a54e-4289-bc30-14b4e3c31c39", "34114c36-bdc4-483c-be13-f7a1b121ae5c" });
        }
    }
}
