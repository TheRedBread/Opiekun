using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opiekun.Migrations
{
    /// <inheritdoc />
    public partial class MinimumIlosc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MinimumIlosc",
                table: "Zasoby",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumIlosc",
                table: "Zasoby");
        }
    }
}
