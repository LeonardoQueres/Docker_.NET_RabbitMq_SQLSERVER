using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurante_Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_novo_campo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurante",
                keyColumn: "Id",
                keyValue: new Guid("2f6f74d3-4727-493f-91f5-5a66713ab7f2"));

            migrationBuilder.DeleteData(
                table: "Restaurante",
                keyColumn: "Id",
                keyValue: new Guid("6dede088-4fa5-4a14-a6dd-0d2c5f83f3cc"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Restaurante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Restaurante",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Endereco", "Nome", "Site" },
                values: new object[,]
                {
                    { new Guid("495d3582-6b96-4ede-a541-bfa8ea2f7604"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 4, 18, 21, 48, 480, DateTimeKind.Local).AddTicks(999), "Rua dos Testes", "Restaurante do Queres", "queres.com.br" },
                    { new Guid("b566998a-461f-4143-8f9f-fb6acd270a3d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 18, 21, 48, 480, DateTimeKind.Local).AddTicks(1002), "Rua dos Desenvolvedores", "Restaurante dos Desenvolvedores", "desenvolvedores.com.br" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurante",
                keyColumn: "Id",
                keyValue: new Guid("495d3582-6b96-4ede-a541-bfa8ea2f7604"));

            migrationBuilder.DeleteData(
                table: "Restaurante",
                keyColumn: "Id",
                keyValue: new Guid("b566998a-461f-4143-8f9f-fb6acd270a3d"));

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Restaurante");

            migrationBuilder.InsertData(
                table: "Restaurante",
                columns: new[] { "Id", "DataCriacao", "Endereco", "Nome", "Site" },
                values: new object[,]
                {
                    { new Guid("2f6f74d3-4727-493f-91f5-5a66713ab7f2"), new DateTime(2024, 11, 4, 14, 46, 12, 590, DateTimeKind.Local).AddTicks(5493), "Rua dos Testes", "Restaurante do Queres", "queres.com.br" },
                    { new Guid("6dede088-4fa5-4a14-a6dd-0d2c5f83f3cc"), new DateTime(2024, 11, 7, 14, 46, 12, 590, DateTimeKind.Local).AddTicks(5496), "Rua dos Desenvolvedores", "Restaurante dos Desenvolvedores", "desenvolvedores.com.br" }
                });
        }
    }
}
