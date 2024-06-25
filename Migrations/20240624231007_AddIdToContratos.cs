using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loja.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToContratos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Contratos");
        }
    }
}
