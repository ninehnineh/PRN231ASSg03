using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class DeletedPropertyAspNetUsersIDInOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_AspNetUsersId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Orders");
            
            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8d8a2833-46f2-4866-82ce-bb13c15e4a01");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3c6d8155-f1a4-4c58-98f5-e169723fc76b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3af52de1-50ad-4083-821f-ff09b9f825c9", "AQAAAAEAACcQAAAAEHr83hAN69+iqcmiwJhWPtMDZqcApPlLuearcp7c/p+oNcYRPAQ+o9hGFilZUXF54w==", "0139c6cd-a747-45bb-85a6-d404c11b7151" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f8db6a6-c3d0-49f9-9f57-b87a58d0cbae", "AQAAAAEAACcQAAAAEAZXEA7hRXZSiMULraTKgW93vmjX1W3rlO5ovHEORIlC3ntV27HMP0D2xC67sOIt4g==", "73038796-46b6-40d1-b5ca-7f98b51ebd2a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AspNetUsersId",
                table: "Orders",
                column: "AspNetUsersId");

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
    }
}
