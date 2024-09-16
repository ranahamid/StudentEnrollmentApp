using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.API.Migrations
{
    /// <inheritdoc />
    public partial class so1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09f262ca-3944-4756-b1e1-ed0426ddc2a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f55a17d-402d-4c45-9402-93a6b1135d1c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "53c04c38-6b60-4dc3-ab50-be88e73c17b5", null, "Administrator", "ADMINISTRATOR" },
                    { "54a0c2ac-9b37-480e-8aac-eff1cb25ae64", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53c04c38-6b60-4dc3-ab50-be88e73c17b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54a0c2ac-9b37-480e-8aac-eff1cb25ae64");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09f262ca-3944-4756-b1e1-ed0426ddc2a8", null, "Administrator", "ADMINISTRATOR" },
                    { "8f55a17d-402d-4c45-9402-93a6b1135d1c", null, "User", "USER" }
                });
        }
    }
}
