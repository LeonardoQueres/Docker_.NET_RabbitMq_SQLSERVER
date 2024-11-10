using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurante_Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurante",
                columns: new[] { "Id", "DataCriacao", "Endereco", "Nome", "Site" },
                values: new object[,]
                {
                    { new Guid("2f6f74d3-4727-493f-91f5-5a66713ab7f2"), new DateTime(2024, 11, 4, 14, 46, 12, 590, DateTimeKind.Local).AddTicks(5493), "Rua dos Testes", "Restaurante do Queres", "queres.com.br" },
                    { new Guid("6dede088-4fa5-4a14-a6dd-0d2c5f83f3cc"), new DateTime(2024, 11, 7, 14, 46, 12, 590, DateTimeKind.Local).AddTicks(5496), "Rua dos Desenvolvedores", "Restaurante dos Desenvolvedores", "desenvolvedores.com.br" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurante");
        }
    }
}
