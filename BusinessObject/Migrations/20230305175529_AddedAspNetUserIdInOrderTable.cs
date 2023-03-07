using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class AddedAspNetUserIdInOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_AspNetUserId",
                table: "Orders",
                column: "AspNetUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AspNetUserId",
                table: "Orders",
                column: "AspNetUserId");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ba2ce8e3-0281-407c-a341-71056b22c875");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ab20f117-3390-4d9a-a970-257176216f68");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84137281-a40c-4dfa-9075-675848a3cc8a", "AQAAAAEAACcQAAAAEB1r32rhvUpXpGtTYWRdxWKoW2ie1UoFKmXeTqI7NLbPPoInTC/qzMIoeSC9HB+1hQ==", "ab7025a7-b30f-42f1-901a-622fb7b570df" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95b7d32d-f7f6-4648-9393-36de9f5efe8e", "AQAAAAEAACcQAAAAENK10C9jFAoPkb3VwP3b3utmRwDwyK87lyaUilBK3VpIe4Sy1JngNcFeYQIfpwTqEQ==", "80eac1e8-8eff-4de9-b756-fdd8b6fd68a0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                    name: "FK_Orders_Users_AspNetUserId",
                    table: "Orders");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AspNetUserId",
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
    }
}
