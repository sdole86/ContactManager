using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Organization = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Friend" },
                    { 3, "Work" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "Firstname", "Lastname", "Organization", "Phone" },
                values: new object[] { 1, 1, new DateTime(2019, 12, 19, 18, 2, 51, 201, DateTimeKind.Local).AddTicks(5117), "MaryEllen@yahoo.com", "Mary Ellen", "Walton", null, "555-123-4567" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "Firstname", "Lastname", "Organization", "Phone" },
                values: new object[] { 2, 2, new DateTime(2019, 12, 19, 18, 2, 51, 203, DateTimeKind.Local).AddTicks(5117), "delores@hotmail.com", "Delores", "Del Rio", null, "555-987-6543" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "Firstname", "Lastname", "Organization", "Phone" },
                values: new object[] { 3, 3, new DateTime(2019, 12, 19, 18, 2, 51, 203, DateTimeKind.Local).AddTicks(5117), "efren@aol.com", "Efren", "Herrera", null, "555-456-7890" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
