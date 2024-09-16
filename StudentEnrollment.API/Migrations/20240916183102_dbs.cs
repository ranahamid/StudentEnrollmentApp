using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.API.Migrations
{
    /// <inheritdoc />
    public partial class dbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf7c31ab-1fa5-44b1-807e-0857ff34ccef", "AQAAAAIAAYagAAAAEOJp+VG7cCYHyszpctnSWkYevNk2F+BnzWoojQU9+IPGNmDb20CvaiezwNFNXXM14w==", "670677b9-fd0d-4630-8a28-1af9571362c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01b565c4-7e56-406b-a8f0-e9698d8cbbf2", "AQAAAAIAAYagAAAAEPumqYBvmCk8et8XXafpylHw+z5kTftTRzxUKM7gE64bXm6/3m3OShFlMt9fEbbg1A==", "0b38ca4c-7818-40d3-953b-83cf0a371389" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f45685d9-0bdf-441c-b1c6-f9bdd43b068d", "AQAAAAIAAYagAAAAEHVgZ/N9hcBfjFODWQY7SMYCg9691wBzJTNjgDxoK131go9ZKpHDxEAv/YxFq5ZnRg==", "9916241c-fbe8-4bde-aa61-8b11358429a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3227cfab-4813-4a38-9da3-fcd73b98011a", "AQAAAAIAAYagAAAAEDhlFg98CCdjQKoqtilE5Dw3hzN6E26oiy5TBoh7oDs/O5Zm+2Cfvs2wRfCIyfm7Tw==", "f20b6dfc-d6d3-4244-bfbd-405d409327a1" });
        }
    }
}
