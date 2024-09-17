using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.API.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4deb795-d72e-4a3a-849c-94bebed21c92", "AQAAAAIAAYagAAAAELvueXncERyq7BNb8qDTwuMej6t/9N9B81Zsk7446KKO2FH9zGaol42xEQjWJqZ27Q==", "c3417a05-96b5-4530-a4c0-238161726db3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d4f7ee6-c3c2-4992-9270-4467838475ab", "AQAAAAIAAYagAAAAELA5mN/7IrJvz2BxDFWjJNvd3wwi2bWx5sDyFRXycP2dyFfifr1CrKRjYIoGEtFG/Q==", "b6c28ff6-5701-4288-a851-47ed1e285b41" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
