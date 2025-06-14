using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apka.Migrations
{
    /// <inheritdoc />
    public partial class RemoveInstructionsField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instrukcje",
                table: "Produkty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Instrukcje",
                table: "Produkty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
