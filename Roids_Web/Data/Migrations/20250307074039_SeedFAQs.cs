using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Roids_Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedFAQs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "Question" },
                values: new object[,]
                {
                    { 1, "Можете да се регистрирате чрез бутона 'Регистрация' в горния десен ъгъл.", "Как да се регистрирам?" },
                    { 2, "Отидете в настройките на профила си и изберете 'Смяна на парола'.", "Как да сменя паролата си?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
