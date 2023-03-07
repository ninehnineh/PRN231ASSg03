using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class AddedAspNetUserIdInTableOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4c6f0c7a-368d-409a-a8e4-58d735d63da5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "838359c5-c20d-40c0-a328-9e636583f319");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb1e67b6-9338-4793-9eef-6c2427dd2ad1", "AQAAAAEAACcQAAAAEMAOCKIJsQF/qe+grOnC4i+ygEl+go7f/hPsyY/WCDHnr0gqPH5Gxb4W9hlf3oR3fw==", "12f52783-5479-47b7-b49b-048f86f1e660" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84226e76-29af-446b-b161-af652af9f92e", "AQAAAAEAACcQAAAAEC0csrw4ZQrG7zNUsi5ravgXmVIK2zhtzXduCWebr+duDnDE7m3c2CV3rk6OBy7t5g==", "5a44859b-5891-43fa-a57e-2cb75c7bab9b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUserId",
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
    }
}
