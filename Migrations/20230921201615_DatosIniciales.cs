using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bibliotecaEF.Migrations
{
    public partial class DatosIniciales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutorNombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AutorPais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutorGenero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    LibroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibroNombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LibroDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UbicacionLibroEstante = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneroLibro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.LibroId);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "AutorId", "AutorGenero", "AutorNombre", "AutorPais" },
                values: new object[] { new Guid("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e46"), "Masculino", "George RR Martin", "Estados Unidos" });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "AutorId", "AutorGenero", "AutorNombre", "AutorPais" },
                values: new object[] { new Guid("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e50"), "Masculino", "JRR Tolkien", "Inglaterra" });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "AutorId", "AutorGenero", "AutorNombre", "AutorPais" },
                values: new object[] { new Guid("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e54"), "Masculino", "David Gill", "España" });

            migrationBuilder.InsertData(
                table: "Libro",
                columns: new[] { "LibroId", "AutorId", "FechaRegistro", "GeneroLibro", "LibroDescripcion", "LibroNombre", "UbicacionLibroEstante" },
                values: new object[,]
                {
                    { new Guid("65344f60-bcf3-49a0-be7c-354155c12333"), new Guid("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e46"), new DateTime(2023, 9, 21, 14, 16, 15, 379, DateTimeKind.Local).AddTicks(1479), "Novela - Literatura fantastica", "Historia epica de Fantasia Medieval", "Juego de Tronos", 1 },
                    { new Guid("65344f60-bcf3-49a0-be7c-354155c12336"), new Guid("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e46"), new DateTime(2023, 9, 21, 14, 16, 15, 379, DateTimeKind.Local).AddTicks(1501), "Novela - Literatura fantastica", "Historia epica de Fantasia Medieval", "Choque de Reyes", 2 },
                    { new Guid("65344f60-bcf3-49a0-be7c-354155c12339"), new Guid("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e50"), new DateTime(2023, 9, 21, 14, 16, 15, 379, DateTimeKind.Local).AddTicks(1507), "Novela - Fantasia Heroica", "Historia de fantasia heroica", "El señor de los anillos - Las Dos Torres", 0 },
                    { new Guid("65344f60-bcf3-49a0-be7c-354155c12342"), new Guid("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e54"), new DateTime(2023, 9, 21, 14, 16, 15, 379, DateTimeKind.Local).AddTicks(1513), "Novela - Historia epica", "Historia epica samurai", "El guerrero a la sombra del cerezo", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorId",
                table: "Libro",
                column: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
