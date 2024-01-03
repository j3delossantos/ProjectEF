using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnImpactCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Impact",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Impact",
                table: "Category");
        }
    }
}
