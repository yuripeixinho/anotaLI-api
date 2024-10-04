using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AL.Data.Migrations
{
    /// <inheritdoc />
    public partial class PerfilContas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_PerfilContas_ContaID",
                table: "PerfilContas",
                column: "ContaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilContas");
        }
    }
}
