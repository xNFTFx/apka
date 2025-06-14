using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apka.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreationNewDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autorzy",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorzy", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    IdKategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.IdKategoria);
                });

            migrationBuilder.CreateTable(
                name: "Poziomy",
                columns: table => new
                {
                    IdPoziom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poziomy", x => x.IdPoziom);
                });

            migrationBuilder.CreateTable(
                name: "Skladnik",
                columns: table => new
                {
                    IdSkladnik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladnik", x => x.IdSkladnik);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    IdProdukt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instrukcje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKategoria = table.Column<int>(type: "int", nullable: false),
                    IdPoziom = table.Column<int>(type: "int", nullable: false),
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    IdSkladnik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.IdProdukt);
                    table.ForeignKey(
                        name: "FK_Produkty_Autorzy_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "Autorzy",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkty_Kategorie_IdKategoria",
                        column: x => x.IdKategoria,
                        principalTable: "Kategorie",
                        principalColumn: "IdKategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkty_Poziomy_IdPoziom",
                        column: x => x.IdPoziom,
                        principalTable: "Poziomy",
                        principalColumn: "IdPoziom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkty_Skladnik_IdSkladnik",
                        column: x => x.IdSkladnik,
                        principalTable: "Skladnik",
                        principalColumn: "IdSkladnik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IdAutor",
                table: "Produkty",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IdKategoria",
                table: "Produkty",
                column: "IdKategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IdPoziom",
                table: "Produkty",
                column: "IdPoziom");

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IdSkladnik",
                table: "Produkty",
                column: "IdSkladnik");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "Autorzy");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Poziomy");

            migrationBuilder.DropTable(
                name: "Skladnik");
        }
    }
}
