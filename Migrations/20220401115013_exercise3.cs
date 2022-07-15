using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class exercise3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 4, 1, 7, 50, 13, 93, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 4, 1, 7, 50, 13, 99, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 4, 1, 7, 50, 13, 99, DateTimeKind.Local).AddTicks(5499));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2019, 12, 19, 18, 2, 51, 201, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2019, 12, 19, 18, 2, 51, 203, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2019, 12, 19, 18, 2, 51, 203, DateTimeKind.Local).AddTicks(5117));
        }
    }
}
