using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microblink.Library.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReservationDateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReservationActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservations_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "dbo",
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContacts",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ContactTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserContacts_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalSchema: "dbo",
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContacts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Books",
                columns: new[] { "ID", "Author", "DateCreated", "DateModified", "Title", "TotalCopies" },
                values: new object[,]
                {
                    { 1, "J. K. Rowling", new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(4316), null, "Harry Potter and the Philosopher's Stone", 10 },
                    { 2, "Frank Herbert", new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(4325), null, "Dune", 3 },
                    { 3, "J. R. R. Tolkien", new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(4327), null, "The Lord of the Rings", 13 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ContactTypes",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(2217), null, "Email" },
                    { 2, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(2244), null, "Mobile" },
                    { 3, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(2246), null, "Telephone" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "ID", "DateCreated", "DateModified", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(2952), null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Testić" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Reservations",
                columns: new[] { "ID", "BookId", "DateCreated", "DateModified", "IsReservationActive", "ReservationDateEnd", "ReservationDateStart", "ReservationDueDate", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(4977), null, true, null, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, 3, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(4989), null, false, new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, 1, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(4995), null, true, null, new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserContacts",
                columns: new[] { "ID", "ContactTypeId", "DateCreated", "DateModified", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(3699), null, 1, "test.test@test.test" },
                    { 2, 2, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(3707), null, 1, "+385987456123" },
                    { 3, 3, new DateTime(2022, 8, 1, 21, 21, 53, 439, DateTimeKind.Local).AddTicks(3709), null, 1, "011234567" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookId",
                schema: "dbo",
                table: "Reservations",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                schema: "dbo",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_ContactTypeId",
                schema: "dbo",
                table: "UserContacts",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_UserId",
                schema: "dbo",
                table: "UserContacts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserContacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
