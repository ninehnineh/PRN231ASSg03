using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class SeedingUserAndUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "55f86f59-db7b-4d60-b8a1-56f986f83704", "Customer@localhost.com", false, "System", "Customer", false, null, "CUSTOMER@LOCALHOST.COM", "CUSTOMER@LOCALHOST.com", "AQAAAAEAACcQAAAAEOHYHjrS7Tlbl0W9xjSyEr20z1/siV6zbVrTxhQnIGFhzj53i7h55V/RSEfdhS7O9g==", null, false, "13ddd32b-ad17-4170-bd74-0022ad1faf7e", false, "Customer@localhost.com" },
                    { "2", 0, "c7fc82af-817a-4be4-ac50-27d2b66aeae0", "Manager@localhost.com", false, "System", "Manager", false, null, "MANAGER@LOCALHOST.COM", "MANAGER@LOCALHOST.com", "AQAAAAEAACcQAAAAEJKhhSiVwYqTYdutUPzKE+L/lVT+iFWuRdrZf7A/J0ml4UusVSmH1ubQhAtVAO/DtQ==", null, false, "e67605a6-1646-426b-9d93-9f7f251141b9", false, "manager@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c1b5cd45-6f1d-4a18-bb7f-030bae5e1ceb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8ded7d06-c828-49e1-b7d6-aa6b0cd96353");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8e37b291-871a-4967-a4d9-abdf9b76ea16");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e4c680a8-4454-4c18-bbe7-41adb5f4b428");
        }
    }
}
