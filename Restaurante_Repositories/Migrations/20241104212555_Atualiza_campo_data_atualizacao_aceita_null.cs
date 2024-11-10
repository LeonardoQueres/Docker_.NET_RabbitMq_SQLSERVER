using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurante_Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Atualiza_campo_data_atualizacao_aceita_null : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurante",
                keyColumn: "Id",
                keyValue: new Guid("495d3582-6b96-4ede-a541-bfa8ea2f7604"));

            migrationBuilder.DeleteData(
                table: "Restaurante",
                keyColumn: "Id",
                keyValue: new Guid("b566998a-461f-4143-8f9f-fb6acd270a3d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Restaurante",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Restaurante",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Endereco", "Nome", "Site" },
                values: new object[,]
                {
                    { new Guid("8f8f93be-baa1-4008-8236-e2ba9ccc8864"), null, new DateTime(2024, 11, 7, 18, 25, 55, 137, DateTimeKind.Local).AddTicks(8007), "Rua dos Desenvolvedores", "Restaurante dos Desenvolvedores", "desenvolvedores.com.br" },
                    { new Guid("dc9bc0d6-4266-4768-b4bd-d5959987ba44"), null, new DateTime(2024, 11, 4, 18, 25, 55, 137, DateTimeKind.Local).AddTicks(8004), "Rua dos Testes", "Restaurante do Queres", "queres.com.br" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurante",
                keyColumn: "Id",
                keyValue: new Guid("8f8f93be-baa1-4008-8236-e2ba9ccc8864"));

            migrationBuilder.DeleteData(
                table: "Restaurante",
                keyColumn: "Id",
                keyValue: new Guid("dc9bc0d6-4266-4768-b4bd-d5959987ba44"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Restaurante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Restaurante",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Endereco", "Nome", "Site" },
                values: new object[,]
                {
                    { new Guid("495d3582-6b96-4ede-a541-bfa8ea2f7604"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 4, 18, 21, 48, 480, DateTimeKind.Local).AddTicks(999), "Rua dos Testes", "Restaurante do Queres", "queres.com.br" },
                    { new Guid("b566998a-461f-4143-8f9f-fb6acd270a3d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 18, 21, 48, 480, DateTimeKind.Local).AddTicks(1002), "Rua dos Desenvolvedores", "Restaurante dos Desenvolvedores", "desenvolvedores.com.br" }
                });
        }
    }
}
