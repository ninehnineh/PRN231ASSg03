using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class DropUserIDIntType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUserID",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c600950b-8268-48ee-8680-4d91e6bd4347");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "56ebb5bf-204b-4453-be7c-705933392ff6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4c7d699-fd3f-4ae3-a972-c1a7339ea0ad", "AQAAAAEAACcQAAAAECEnOvUQYAepIWkzQDNW81knMXIz8sGWgyPqLj3qg/Kdl2LXXIfxPItuGowNb89DMQ==", "da3e14e0-58d1-4564-898e-6f0d7c7cdf59" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56af00ed-4d05-4bb1-87e7-9885ed2a161e", "AQAAAAEAACcQAAAAENuakCjqRJUvSMVrkI9hJ6c1wcqFyUckfta0SDFPJ3hrCoAKYkzoCUrgLg1p3tvJBA==", "1fece6b1-91d9-4634-87ed-29d98da107fe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspNetUserID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55f86f59-db7b-4d60-b8a1-56f986f83704", "AQAAAAEAACcQAAAAEOHYHjrS7Tlbl0W9xjSyEr20z1/siV6zbVrTxhQnIGFhzj53i7h55V/RSEfdhS7O9g==", "13ddd32b-ad17-4170-bd74-0022ad1faf7e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7fc82af-817a-4be4-ac50-27d2b66aeae0", "AQAAAAEAACcQAAAAEJKhhSiVwYqTYdutUPzKE+L/lVT+iFWuRdrZf7A/J0ml4UusVSmH1ubQhAtVAO/DtQ==", "e67605a6-1646-426b-9d93-9f7f251141b9" });
        }
    }
}
