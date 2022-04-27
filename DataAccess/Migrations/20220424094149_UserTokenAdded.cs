using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UserTokenAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "@dbo",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 24, 12, 41, 48, 948, DateTimeKind.Local).AddTicks(6209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "@dbo",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                schema: "@dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpireDate",
                schema: "@dbo",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "@dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PhoneNumber", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 24, 12, 41, 48, 948, DateTimeKind.Local).AddTicks(7087), "+90 555 555 55 55", new DateTime(2022, 4, 24, 12, 41, 48, 948, DateTimeKind.Local).AddTicks(7095) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "@dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Token",
                schema: "@dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenExpireDate",
                schema: "@dbo",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "@dbo",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(5828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 24, 12, 41, 48, 948, DateTimeKind.Local).AddTicks(6209));

            migrationBuilder.UpdateData(
                schema: "@dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(6867), new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(6875) });
        }
    }
}
