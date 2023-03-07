using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class FixManualRelationshipOrderAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                    name: "FK_Orders_Users_AspNetUsersId",
                    table: "Orders"
                );

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "baa9a1d2-3f50-4725-a03b-df314b0a7b82");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c1c72789-63a9-48bd-b9a0-e8ac7fb279da");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ec88952-02b2-4ff7-ba6c-a41f4fe58a8d", "AQAAAAEAACcQAAAAENQnROEb2uI9oxJUEu1scK5DbxpIzKyeITa1Zzi1PsXn3wupZZ3xJGSxwIFhAa776g==", "fc7c445a-9ec5-43e5-ba63-c0d17ba9ea5f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc52a3c0-6dc2-432b-bbee-a55f924f1176", "AQAAAAEAACcQAAAAECP3wqBZTD3GEmDCoE6rcygulg+QDIJSuEexjADYH9H0fxXUo4R2O7+rVFXuhyUDFg==", "6fc1c8e1-63a7-417e-a986-24520451d449" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_AspNetUsersId",
                table: "Orders",
                column: "AspNetUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
