using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImagensRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfilContas_Imagem_ImagemPerfilId",
                table: "PerfilContas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagem",
                table: "Imagem");

            migrationBuilder.RenameTable(
                name: "Imagem",
                newName: "Imagems");

            migrationBuilder.RenameColumn(
                name: "ImagemPerfilId",
                table: "PerfilContas",
                newName: "ImagemPerfilID");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilContas_ImagemPerfilId",
                table: "PerfilContas",
                newName: "IX_PerfilContas_ImagemPerfilID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagems",
                table: "Imagems",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "2e81ad9b-54d4-4c3f-b6e7-0987654321fe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eb2cd948-1751-472b-839f-9c3a84bf6eaa", "daef3eab-be91-4405-b829-7f2a2203eff9" });

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "Id",
                keyValue: "7318d839-ff36-48fd-92a9-3401ab215121",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8024e968-d984-43f6-aaac-4e5482ab29da", "b530611f-95f1-44cd-86ea-66659cf56b34" });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 1,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9547), new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9514) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 2,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9553), new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9552) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 3,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9557), new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9556) });

            migrationBuilder.UpdateData(
                table: "Feiras",
                keyColumn: "FeiraID",
                keyValue: 4,
                columns: new[] { "DataFim", "DataInicio" },
                values: new object[] { new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9561), new DateTime(2024, 11, 10, 16, 32, 55, 632, DateTimeKind.Local).AddTicks(9559) });

            migrationBuilder.UpdateData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: "m3Fz6kQp1W",
                column: "ImagemPerfilID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: "R1n8bY5sXq",
                column: "ImagemPerfilID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PerfilContas",
                keyColumn: "PerfilContaID",
                keyValue: "V4c8jL7x2d",
                column: "ImagemPerfilID",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilContas_Imagems_ImagemPerfilID",
                table: "PerfilContas",
                column: "ImagemPerfilID",
                principalTable: "Imagems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfilContas_Imagems_ImagemPerfilID",
                table: "PerfilContas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagems",
                table: "Imagems");

            migrationBuilder.RenameTable(
                name: "Imagems",
                newName: "Imagem");

            migrationBuilder.RenameColumn(
                name: "ImagemPerfilID",
                table: "PerfilContas",
                newName: "ImagemPerfilId");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilContas_ImagemPerfilID",
                table: "PerfilContas",
                newName: "IX_PerfilContas_ImagemPerfilId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagem",
                table: "Imagem",
                column: "Id");

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
                keyValue: "V4c8jL7x2d",
                column: "ImagemPerfilId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilContas_Imagem_ImagemPerfilId",
                table: "PerfilContas",
                column: "ImagemPerfilId",
                principalTable: "Imagem",
                principalColumn: "Id");
        }
    }
}
