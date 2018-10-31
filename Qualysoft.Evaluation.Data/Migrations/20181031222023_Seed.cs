using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualysoft.Evaluation.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                schema: "dbo",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(2018, 10, 31, 22, 20, 23, 270, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 10, 31, 21, 56, 47, 716, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Requests",
                columns: new[] { "Id", "Date", "Name", "Visits" },
                values: new object[] { 1, new DateTime(2018, 10, 31, 22, 20, 23, 271, DateTimeKind.Utc), "William Shakespeare", 13 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Requests",
                columns: new[] { "Id", "Date", "Name", "Visits" },
                values: new object[] { 2, new DateTime(2018, 11, 1, 0, 20, 23, 272, DateTimeKind.Local), "io", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                schema: "dbo",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(2018, 10, 31, 21, 56, 47, 716, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 10, 31, 22, 20, 23, 270, DateTimeKind.Utc));
        }
    }
}
