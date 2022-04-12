using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "@dbo");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "@dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(5828)),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "@dbo",
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "CreatedUserId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "Password", "UpdatedDate", "UpdatedUserId", "UserName" },
                values: new object[] { 1, "İstanbul/Pendik", new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(6867), 1, new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "furkanaltintas785@gmail.com", "Furkan", true, "Altıntaş", "12345", new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(6875), 1, "furkanaltintas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "@dbo");
        }
    }
}
